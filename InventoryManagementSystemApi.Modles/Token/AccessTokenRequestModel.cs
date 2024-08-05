using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemApi.Modles.Token;

public class AccessTokenRequestModel
{
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public DateTime TokenExpired { get; set; }
}
