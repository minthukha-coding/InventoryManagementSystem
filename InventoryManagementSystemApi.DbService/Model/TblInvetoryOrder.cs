using System;
using System.Collections.Generic;

namespace InventoryManagementSystemApi.DbService.Model;

public partial class TblInvetoryOrder
{
    public int OrderId { get; set; }

    public string Items { get; set; } = null!;

    public decimal TotalPrice { get; set; }
}
