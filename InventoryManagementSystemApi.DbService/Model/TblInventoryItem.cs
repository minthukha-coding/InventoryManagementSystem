using System;
using System.Collections.Generic;

namespace InventoryManagementSystemApi.DbService.Model;

public partial class TblInventoryItem
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public string ItemCategory { get; set; } = null!;

    public string ItemAmount { get; set; } = null!;

    public decimal ItemPrice { get; set; }
}
