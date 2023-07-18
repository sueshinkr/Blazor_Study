using WebAPIServer.DataClass;

namespace WebAPIServer.ReqRes;
public class GetUserBasicInfoRequest
{
    public Int64 UserID { get; set; }
}

public class GetUserBasicInfoListResponse
{
    public ErrorCode errorCode { get; set; }
    public List<UserInfo> UserInfo { get; set; }
}

public class GetMultipleUserBasicInfoRequest
{
    public string Category { get; set; }
    public Int64 MinValue { get; set; }
    public Int64 MaxValue { get; set; }
}

public class UserInfo
{
    public Int64 AccountID { get; set; }
    public Int64 UserID { get; set; }
    public Int64 Level { get; set; }
    public Int64 Exp { get; set; }
    public Int64 Money { get; set; }
    public Int64 BestClearStage { get; set; }
    public DateTime LastLogin { get; set; }
}
public class GetItemTableRequest
{

}
public class GetItemTableResponse
{
    public List<ItemAttribute> Item_Weapon { get; set; }
    public List<ItemAttribute> Item_Armor { get; set; }
    public List<ItemAttribute> Item_Clothes { get; set; }
    public List<ItemAttribute> Item_MagicTool { get; set; }
}


public class SendMailRequest
{
	public MailForm MailForm { get; set; }
	public Int64 UserID { get; set; }
}

public class SendMailResponse
{
    public ErrorCode errorCode { get; set; }
}
public class MailForm
{
	public string Title { get; set; }
	public string Content { get; set; }
	public Int64 ItemCode { get; set; }
	public Int64 ItemCount { get; set; }
}

public class GetUserItemListRequest
{
    public Int64 UserId { get; set; }
}
public class GetUserItemListResponse
{
    public ErrorCode errorCode { get; set; }
    public List<UserItem> UserItem { get; set; }
}

public class GetUserMailListRequest
{
    public Int64 UserID { get; set; }
}

public class GetUserMailListResponse
{
    public ErrorCode errorCode { get; set; }
    public List<MailData> UserMail { get; set; }
}
