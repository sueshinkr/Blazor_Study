namespace WebAPIServer.Controllers.ManagingController;

using WebAPIServer.DbOperations;
using WebAPIServer.ReqRes;
using WebAPIServer.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using ZLogger;
using WebAPIServer.DataClass;
using ManagingTool.Shared.DTO;

[ApiController]
[Route("Managing/[controller]")]
public class GetUserData : ControllerBase
{
    readonly ILogger<GetUserData> _logger;
	readonly IGameDb _gameDb;


	public GetUserData(ILogger<GetUserData> logger, IGameDb gameDb)
    {
		_logger = logger;
		_gameDb = gameDb;
    }

    [HttpPost("byUserId")]
	public async Task<GetUserDataResponse> Post(GetUserDataByUserIdRequest request)
	{
		var response = await _gameDb.GetUserDataByUserIdAsync(request.UserID);

		if (response.Item1 != ErrorCode.None)
		{
			return null;
		}

		return response.Item2;
	}

	[HttpPost("byRange")]
	public async Task<GetUserDataResponse> Post(GetUserDataByRangeRequest request)
	{
		var response = await _gameDb.GetUserDataByRangeAsync(request.Category, request.MinValue, request.MaxValue);

		if (response.Item1 != ErrorCode.None)
		{
			return null;
		}

		return response.Item2;
	}
}
