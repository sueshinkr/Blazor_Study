using System.Net.Http.Json;
using ManagingTool.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace ManagingTool.Client;

public class UserDataService
{
    public static HttpClient _httpClient { get; set; }

    public async Task<GetUserDataResponse> GetUserDataByUserId(long userId)
    {
        var request = new GetUserDataByUserIdRequest
        {
            UserID = userId
        };

        var response = await _httpClient.PostAsJsonAsync("api/UserData/GetByUserID", request);
        var responseDTO = await response.Content.ReadFromJsonAsync<GetUserDataResponse>();

        if (responseDTO == null)
        {
            // errorlog
        }

        return responseDTO;
    }

    public async Task<List<UserInfo>> GetUserDataByRange(string category, long minValue, long maxValue)
    {
        var request = new GetUserDataByRangeRequest
        {
            Category = category,
            MinValue = minValue,
            MaxValue = maxValue
        };

        var response = await _httpClient.PostAsJsonAsync("api/UserData/GetByRange", request);
        var responseDTO = await response.Content.ReadFromJsonAsync<GetUserDataResponse>();

        if (responseDTO == null)
        {
            // errorlog
        }

        return responseDTO.UserInfo;
    }
}

