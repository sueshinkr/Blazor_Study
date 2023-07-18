﻿using System;
using Org.BouncyCastle.Asn1.Pkcs;
using SqlKata.Execution;
using WebAPIServer.DataClass;
using WebAPIServer.Util;
using ZLogger;
using WebAPIServer.ReqRes;

namespace WebAPIServer.DbOperations;

public partial class GameDb : IGameDb
{
	// 유저 출석 데이터 로딩
	// User_BasicInformation 테이블에서 유저 출석 정보 가져온 뒤 새로운 출석인지 아닌지 판별
	public async Task<GetUserBasicInfoListResponse> GetUserBasicInfoAsync(Int64 userId)
	{
		var response = new GetUserBasicInfoListResponse
		{
			errorCode = ErrorCode.None
		};
		var userDataSet = new List<UserInfo>();
		try
		{
			var userData = await _queryFactory.Query("User_BasicInformation").Where("UserID", userId)
											  .FirstOrDefaultAsync<UserInfo>();

			if (userData == null)
			{
				userData = new UserInfo();
			}

			userDataSet.Add(userData);
			response.UserInfo = userDataSet;

			return response;
		}
		catch (Exception ex)
		{
			response.errorCode = ErrorCode.GetUserDataByUserIdFailException;

			_logger.ZLogError(LogManager.MakeEventId(response.errorCode), ex, "GetUserDataFromUserId Exception");

			return response;
		}
	}

	public async Task<GetUserBasicInfoListResponse> GetMultipleUserBasicInfoAsync(string category, Int64 minValue, Int64 maxValue)
	{
        var response = new GetUserBasicInfoListResponse
        {
            errorCode = ErrorCode.None

        };
        try
		{
			var userDataSet = new List<UserInfo>();

			if (category == "UserID")
			{
				userDataSet = await _queryFactory.Query("User_BasicInformation").WhereBetween("UserId", minValue, maxValue)
												 .GetAsync<UserInfo>() as List<UserInfo>;
			}
			else if (category == "Level")
			{
                userDataSet = await _queryFactory.Query("User_BasicInformation").WhereBetween("Level", minValue, maxValue)
                                                 .GetAsync<UserInfo>() as List<UserInfo>;
            }
			else if (category == "Money")
			{
                userDataSet = await _queryFactory.Query("User_BasicInformation").WhereBetween("Money", minValue, maxValue)
                                                 .GetAsync<UserInfo>() as List<UserInfo>;
            }
			else if (category == "BestClearStage")
			{
                userDataSet = await _queryFactory.Query("User_BasicInformation").WhereBetween("BestClearStage", minValue, maxValue)
                                                 .GetAsync<UserInfo>() as List<UserInfo>;
            }

			if (userDataSet == null)
			{
				userDataSet = new List<UserInfo>();
			}

			response.UserInfo = userDataSet;

			return response;
		}
		catch(Exception ex)
		{
			response.errorCode = ErrorCode.GetUserDataByRangeFailException;

			_logger.ZLogError(LogManager.MakeEventId(response.errorCode), ex, "GetUserDataByRange Exception");

			return response;
		}
	}

	public async Task<SendMailResponse> SendManagingMailAsync(MailForm mailForm, Int64 userId)
	{
		var mailId = _idGenerator.CreateId();
		var response = new SendMailResponse
		{
			errorCode = ErrorCode.None
		};

		try
		{
			var hasItem = false;
			if (mailForm.ItemCode != 0)
				hasItem = true;
			
			// 메일 본문 전송
			await _queryFactory.Query("Mail_Data").InsertAsync(new
			{
				MailId = mailId,
				UserId = userId,
				SenderId = 0,
				Title = mailForm.Title,
				Content = mailForm.Content,
				hasItem = hasItem,
				ExpiredAt = DateTime.Now.AddDays(7)
			});

			// 메일 아이템 전송
			if (hasItem == true)
			{
				response.errorCode = await InsertItemIntoMailAsync(mailId, mailForm.ItemCode, mailForm.ItemCount);
				if (response.errorCode != ErrorCode.None)
				{
					// 롤백
					await SendMailAttendanceRewardRollBack(mailId);

					return response;
				}
			}

			return response;
		}
		catch (Exception ex)
		{
			response.errorCode = ErrorCode.SendMailFailException;

			_logger.ZLogError(LogManager.MakeEventId(response.errorCode), ex, "SendManagingMail Exception");

			return response;
		}
	}

    public async Task<GetUserItemListResponse> GetUserItemListAsync(Int64 userId)
    {
		var response = new GetUserItemListResponse
		{
			errorCode = ErrorCode.None
        };

        var userItem = new List<UserItem>();

        try
        {
            response.UserItem = await _queryFactory.Query("User_Item").Where("UserId", userId)
												   .GetAsync<UserItem>() as List<UserItem>;

			return response;
        }
        catch (Exception ex)
        {
            response.errorCode = ErrorCode.GetUserItemListFailException;

            _logger.ZLogError(LogManager.MakeEventId(response.errorCode), ex, "GetUserItemList Exception");

			return response;
        }
    }

    public async Task<GetUserMailListResponse> GetUserMailListAsync(Int64 userId)
    {
        var response = new GetUserMailListResponse
        {
            errorCode = ErrorCode.None
        };

        var userItem = new List<UserItem>();

        try
        {
            response.UserMail = await _queryFactory.Query("mail_data").Where("UserId", userId)
                                                   .GetAsync<MailData>() as List<MailData>;

            return response;
        }
        catch (Exception ex)
        {
            response.errorCode = ErrorCode.GetUserMailListFailException;

            _logger.ZLogError(LogManager.MakeEventId(response.errorCode), ex, "GetUserMailList Exception");

            return response;
        }
    }
}