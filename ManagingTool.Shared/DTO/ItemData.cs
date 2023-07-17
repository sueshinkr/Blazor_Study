namespace ManagingTool.Shared.DTO;

public class GetItemTableRequest
{

}
public class GetItemTableResponse
{
    public List<ItemProperty> ItemProperty { get; set; }
}


public class ItemProperty
{
    public Int64 Attribute { get; set; }
    public Int64 ItemCode { get; set; }
    public string Name { get; set; }
}