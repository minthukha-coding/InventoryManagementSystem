using System;
using System.Collections.Generic;

namespace InventoryManagementSystemApi.DbService.Db;

public partial class TblItem
{
    public string ItemName { get; set; } = null!;

    public string ItemCategory { get; set; } = null!;

    public decimal ItemPrice { get; set; }

    public string ItemAmount { get; set; } = null!;

    public DateTime CreatedDateTime { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public DateTime? UpdatedDateTime { get; set; }

    public string? UpdatedUserId { get; set; }
}
