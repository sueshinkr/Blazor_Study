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

[ApiController]
[Route("Managing/[controller]")]
public class UserData : ControllerBase
{
    readonly ILogger<UserData> _logger;
	readonly IGameDb _gameDb;


	public UserData(ILogger<UserData> logger, IGameDb gameDb)
    {
		_logger = logger;
		_gameDb = gameDb;
    }

    [HttpPost("GetByUserID")]
	public async Task<GetUserDataResponse> Post(GetUserDataByUserIdRequest request)
	{
		var response = await _gameDb.GetUserDataByUserIdAsync(request.UserID);

		if (response.Item1 != ErrorCode.None)
		{
			return null;
		}

		return response.Item2;
	}

	[HttpPost("GetByRange")]
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
