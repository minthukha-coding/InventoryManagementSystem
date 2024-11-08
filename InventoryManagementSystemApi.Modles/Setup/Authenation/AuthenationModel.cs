namespace InventoryManagementSystemApi.Modles.Authenation;

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

public class RegisterRequestModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    // Add other properties as needed
}
