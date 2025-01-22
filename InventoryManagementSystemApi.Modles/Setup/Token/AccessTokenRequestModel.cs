namespace InventoryManagementSystemApi.Modles.Setup.Token;

public class AccessTokenRequestModel
{
    public string UserName { get; set; }
    public DateTime TokenExpired { get; set; }
}