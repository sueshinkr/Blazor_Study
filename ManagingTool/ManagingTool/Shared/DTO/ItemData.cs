namespace ManagingTool.Shared.DTO;

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

public class ItemAttribute
{
    public string Name { get; set; }
    public Int64 Code { get; set; }
}