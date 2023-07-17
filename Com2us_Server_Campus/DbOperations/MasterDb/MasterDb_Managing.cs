using WebAPIServer.ReqRes;

namespace WebAPIServer.DbOperations;

public partial class MasterDb : IMasterDb
{
    public async Task<Tuple<ErrorCode, GetItemTableResponse>> GetItemTableAsync()
    {
        /*
        try
        {
            var response = new GetItemTableResponse();
            var itemDataSet = new List<ItemProperty>();

            itemDataSet = await _queryFactory.Query("ItemTable")
                                             .GetAsync<ItemProperty>() as List<ItemProperty>;

            response.ItemProperty = itemDataSet;

            return new Tuple<ErrorCode, GetItemTableResponse>(ErrorCode.None, response);

        }
        catch (Exception ex)
        {
            _logger.ZLogError(ex, "GetItemTableAsync");
            return new Tuple<ErrorCode, GetItemTableResponse>(ErrorCode.DbError, null);
        }   
        */
        return null;
    }
}