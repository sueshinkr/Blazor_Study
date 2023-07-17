using WebAPIServer.ReqRes;
using WebAPIServer.DataClass;
using WebAPIServer.Util;
using ZLogger;
using SqlKata.Execution;

namespace WebAPIServer.DbOperations;

public partial class MasterDb : IMasterDb
{
    public async Task<Tuple<ErrorCode, GetItemTableResponse>> GetItemTableAsync()
    {/*
        try
        {
            var response = new GetItemTableResponse();
            
            response.Item_Weapon = await _queryFactory.Query("ItemTable").Select("ItemId", "ItemName")
                                                      .Where("ItemCode", 1).GetAsync<ItemAttribute>() as List<ItemAttribute>;

            response.Item_Armor = await _queryFactory.Query("ItemTable").Select("ItemId", "ItemName")
                                                      .Where("ItemCode", 2).GetAsync<ItemAttribute>() as List<ItemAttribute>;
            re
          

            response.ItemProperty = itemDataSet;

            return new Tuple<ErrorCode, GetItemTableResponse>(ErrorCode.None, response);

        }
        catch (Exception ex)
        {
            var errorCode = ErrorCode.GetItemTableFailException;

            _logger.ZLogError(LogManager.MakeEventId(errorCode), ex, "GetUserDataByRange Exception");

            return new Tuple<ErrorCode, GetItemTableResponse>(ErrorCode.DbError, null);
        }   
        */
        return null;
    }
}