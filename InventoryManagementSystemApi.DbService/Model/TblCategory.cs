using System;
using System.Collections.Generic;

namespace InventoryManagementSystemApi.DbService.Model;

public partial class TblCategory
{
    public string CategoryName { get; set; } = null!;

    public string CategoryId { get; set; } = null!;
}
