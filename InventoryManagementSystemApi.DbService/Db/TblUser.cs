using System;
using System.Collections.Generic;

namespace InventoryManagementSystemApi.DbService.Db;

public partial class TblUser
{
    public string UsereId { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string HashPassword { get; set; } = null!;
}
