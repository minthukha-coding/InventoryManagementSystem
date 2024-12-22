namespace InventoryManagementSystemApi.DbService.Db;

public class TblOrder
{
    public string OrderId { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerUserId { get; set; } = null!;

    public string OrderItemId { get; set; } = null!;

    public string OrderItemPrice { get; set; } = null!;

    public string OrderItemAmount { get; set; } = null!;

    public string OrderItemTotalPrice { get; set; } = null!;

    public int IsDeliveried { get; set; }
}