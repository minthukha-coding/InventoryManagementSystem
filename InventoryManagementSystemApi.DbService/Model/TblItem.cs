using System;
using System.Collections.Generic;

namespace InventoryManagementSystemApi.DbService.Model;

public partial class TblItem
{
    public string ItemName { get; set; } = null!;

    public string ItemCategory { get; set; } = null!;

    public decimal ItemPrice { get; set; }

    public string IteamAmount { get; set; } = null!;
}
