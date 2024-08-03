using System;
using System.Collections.Generic;

namespace InventoryManagementSystemApi.DbService.Db;

public partial class TblOrder
{
    public string OrderId { get; set; } = null!;

    public string OrderItemId { get; set; } = null!;

    public string OrderItemPrice { get; set; } = null!;

    public string OrderItemAmount { get; set; } = null!;

    public string OrderItemTotalPrice { get; set; } = null!;

    public string OrderUserId { get; set; } = null!;

    public DateTime OrderCreateDateTime { get; set; }

    public int IsDeliveried { get; set; }
}
