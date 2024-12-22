namespace InventoryManagementSystemApi.DbService.Db;

public class TblOrderItem
{
    public string OrderItemId { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public string ItemId { get; set; } = null!;

    public string Quantity { get; set; } = null!;

    public decimal Price { get; set; }
}