namespace ManagingTool.Shared.DTO;

public class SendMailRequest
{
    public MailForm MailForm { get; set; }
    public Int64 UserID { get; set; }
}

public class SendMailResponse
{
}

public class MailForm
{
	public string Title { get; set; }
	public string Content { get; set; }
	public Int64 ItemCode { get; set; }
}
