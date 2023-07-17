using System.Net.Http.Json;
using ManagingTool.Shared.DTO;

namespace ManagingTool.Client;

public class ItemService
{
    public static HttpClient HttpClient { get; set; }

    public async Task<GetItemTableResponse> GetItemTable()
    {
        var request = new GetItemTableRequest
        {
        };

        var response = await HttpClient.PostAsJsonAsync("Managing/GetItemData/ItemTable", request);
        var responseDTO = await response.Content.ReadFromJsonAsync<GetItemTableResponse>();

        return responseDTO;
    }
}

