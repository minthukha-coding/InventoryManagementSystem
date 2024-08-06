using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemApi.Modles.Setup.Authenation;

public class SignInRequestModel
{
    public string UserName { get; set; }
    public string HashPassword { get; set; }
}
//public class SignInResponseModel
//{
//    public string accessToken { get; set; }
//}
public record class SignInResponseModel(string AccessToken);