using System.Net.Http.Json;
using ManagingTool.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace ManagingTool.Client;

public class UserService
{
    public static HttpClient _httpClient { get; set; }

    public async Task<GetUserBasicInfoListResponse> GetUserBasicInfo(long userId)
    {
        var request = new GetUserBasicInfoRequest
        {
            UserID = userId
        };

        var response = await _httpClient.PostAsJsonAsync("api/UserData/GetUserBasicInfo", request);
        var responseDTO = await response.Content.ReadFromJsonAsync<GetUserBasicInfoListResponse>();

        if (responseDTO == null)
        {
            // errorlog
        }

        return responseDTO;
    }

    public async Task<List<UserInfo>> GetMultipleUserBasicInfo(string category, long minValue, long maxValue)
    {
        var request = new GetMultipleUserBasicInfoRequest
        {
            Category = category,
            MinValue = minValue,
            MaxValue = maxValue
        };

        var response = await _httpClient.PostAsJsonAsync("api/UserData/GetMultipleUserBasicInfo", request);
        var responseDTO = await response.Content.ReadFromJsonAsync<GetUserBasicInfoListResponse>();

        if (responseDTO == null)
        {
            // errorlog
        }

        return responseDTO.UserInfo;
    }
}

