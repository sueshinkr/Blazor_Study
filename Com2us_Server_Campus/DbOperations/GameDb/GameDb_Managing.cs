using System;
using Org.BouncyCastle.Asn1.Pkcs;
using SqlKata.Execution;
using WebAPIServer.DataClass;
using WebAPIServer.Util;
using ZLogger;
using ManagingTool.Shared.DTO;

namespace WebAPIServer.DbOperations;

public partial class GameDb : IGameDb
{
	// 유저 출석 데이터 로딩
	// User_BasicInformation 테이블에서 유저 출석 정보 가져온 뒤 새로운 출석인지 아닌지 판별
	public async Task<Tuple<ErrorCode, GetUserDataResponse>> GetUserDataByUserIdAsync(Int64 userId)
	{
		var response = new GetUserDataResponse();
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

			return new Tuple<ErrorCode, GetUserDataResponse>(ErrorCode.None, response);
		}
		catch (Exception ex)
		{
			var errorCode = ErrorCode.GetUserDataFromUserIdFailException;

			_logger.ZLogError(LogManager.MakeEventId(errorCode), ex, "GetUserDataFromUserId Exception");

			return new Tuple<ErrorCode, GetUserDataResponse>(errorCode, null);
		}
	}

	public async Task<Tuple<ErrorCode, GetUserDataResponse>> GetUserDataByRangeAsync(string category, Int64 minValue, Int64 maxValue)
	{
		try
		{
			var response = new GetUserDataResponse();
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

			return new Tuple<ErrorCode, GetUserDataResponse>(ErrorCode.None, response);
		}
		catch(Exception ex)
		{
			var errorCode = ErrorCode.GetUserDataFromUserIdFailException;

			_logger.ZLogError(LogManager.MakeEventId(errorCode), ex, "GetUserDataByRange Exception");

			return new Tuple<ErrorCode, GetUserDataResponse>(errorCode, null);
		}
	}
}