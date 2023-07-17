using System.Net.Http.Json;
using ManagingTool.Shared.DTO;

namespace ManagingTool.Client;

public class UserDataService
{
    public static HttpClient HttpClient { get; set; }

    public async Task<GetUserDataResponse> GetUserDataByUserId(long userId)
    {
        var request = new GetUserDataByUserIdRequest
        {
            UserID = userId
        };

        var response = await HttpClient.PostAsJsonAsync("Managing/UserData/GetByUserID", request);
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

        var response = await HttpClient.PostAsJsonAsync("Managing/UserData/GetByRange", request);
        var responseDTO = await response.Content.ReadFromJsonAsync<GetUserDataResponse>();

        if (responseDTO == null)
        {
            // errorlog
        }

        return responseDTO.UserInfo;
    }
}

