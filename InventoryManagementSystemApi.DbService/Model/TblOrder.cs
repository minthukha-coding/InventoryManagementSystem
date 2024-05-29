using System;
using System.Collections.Generic;

namespace InventoryManagementSystemApi.DbService.Model;

public partial class TblOrder
{
    public string OrderId { get; set; } = null!;

    public string OrderItemId { get; set; } = null!;

    public decimal OrderItemPrice { get; set; }

    public int OrderItemAmount { get; set; }

    public decimal OrderTotalPrice { get; set; }
}
