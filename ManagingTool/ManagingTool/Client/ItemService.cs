using System.Net.Http.Json;
using ManagingTool.Shared.DTO;

namespace ManagingTool.Client;

public class ItemService
{
    public static HttpClient _httpClient { get; set; }

    public async Task<GetItemTableResponse> GetItemTable()
    {
        var request = new GetItemTableRequest();

        var response = await _httpClient.PostAsJsonAsync("api/ItemData/GetItemTable", request);
        var responseDTO = await response.Content.ReadFromJsonAsync<GetItemTableResponse>();

        return responseDTO;
    }

    public async Task<GetUserItemListResponse> GetUserItemList(Int64 userId)
    {
        var request = new GetUserItemListRequest
        {
            UserId = userId
        };

        var response = await _httpClient.PostAsJsonAsync("api/ItemData/GetUserItemList", request);
        var responseDTO = await response.Content.ReadFromJsonAsync<GetUserItemListResponse>();

        if (responseDTO.errorCode != ErrorCode.None)
        {
            //errorlog
        }

        return responseDTO;
    }
}

