using System.Net.Http.Json;
using ManagingTool.Shared.DTO;  

namespace ManagingTool;

public class UserDataService
{
    public static HttpClient HttpClient { get; set; }  

    public async Task<GetUserDataResponse> GetUserDataByUserId(Int64 userId)
    {
        var request = new GetUserDataByUserIdRequest
		{
            UserID = userId
        };

        var response = await HttpClient.PostAsJsonAsync("Managing/GetUserData/byUserId", request);
        var responseDTO = await response.Content.ReadFromJsonAsync<GetUserDataResponse>();

        if (responseDTO == null)
        {
            // errorlog
        }

        return responseDTO;
    }

    public async Task<List<UserInfo>> GetUserDataByRange(string category, Int64 minValue, Int64 maxValue)
    {
        var request = new GetUserDataByRangeRequest
        {
            Category = category,
            MinValue = minValue,
            MaxValue = maxValue
        };

        var response = await HttpClient.PostAsJsonAsync("Managing/GetUserData/byRange", request);
        var responseDTO = await response.Content.ReadFromJsonAsync<GetUserDataResponse>();

        if (responseDTO == null)
        {
            // errorlog
        }

        return responseDTO.UserInfo;
    }
}

