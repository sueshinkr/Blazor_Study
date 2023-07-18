namespace WebAPIServer.Controllers.ManagingController;

using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using ManagingTool.Shared.DTO;
using System.Net.Http;

[ApiController]
[Route("api/[controller]")]
public class UserData : ControllerBase
{
    readonly ILogger<UserData> _logger;
    readonly HttpClient _httpClient;

    public UserData(ILogger<UserData> logger, HttpClient httpClient)
    {
		_logger = logger;
        _httpClient = httpClient;
    }

    [HttpPost("GetByUserID")]
	public async Task<GetUserDataResponse> Post(GetUserDataByUserIdRequest request)
	{
        var response = await _httpClient.PostAsJsonAsync("Managing/UserData/GetByUserID", request);
        var responseDTO = await response.Content.ReadFromJsonAsync<GetUserDataResponse>();

        if (responseDTO == null)
        {
            // errorlog
        }

        return responseDTO;
    }

	[HttpPost("GetByRange")]
	public async Task<GetUserDataResponse> Post(GetUserDataByRangeRequest request)
	{
        var response = await _httpClient.PostAsJsonAsync("Managing/UserData/GetByRange", request);
        var responseDTO = await response.Content.ReadFromJsonAsync<GetUserDataResponse>();

        if (responseDTO == null)
        {
            // errorlog

        }

        return responseDTO;
    }
}
