using System;
using System.Collections.Generic;

namespace InventoryManagementSystemApi.DbService.Db;

public partial class TblLogin
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string AccessToken { get; set; } = null!;

    public DateTime LoginDate { get; set; }

    public string Email { get; set; } = null!;

    public DateTime LogoutDate { get; set; }
}
