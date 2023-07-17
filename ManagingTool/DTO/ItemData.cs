namespace ManagingTool.Shared.DTO;

public class GetItemTableRequest
{

}
public class GetItemTableResponse
{
    public List<ItemAttribute> ItemProperty { get; set; }
}

public class ItemAttribute
{
    public string Name { get; }
    public Int64 Code { get; }
}