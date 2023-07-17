namespace ManagingTool.Shared.DTO;

public class GetUserDataByUserIdRequest
{
    public Int64 UserID { get; set; }
}

public class GetUserDataResponse
{
    public List<UserInfo> UserInfo { get; set; }
}

public class GetUserDataByRangeRequest
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