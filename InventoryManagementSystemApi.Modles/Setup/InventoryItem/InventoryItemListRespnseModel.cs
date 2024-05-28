namespace InventoryManagementSystemApi.Modles.Setup.InventoryItemListRespnseModel
{
    public class InventoryItemListRespnseModel
    {
            public List<InventoryItemModel> DataLst { get; set; }
            public MessageResponseModel MessageResponse { get; set; }
            public PageSettingModel PageSetting { get; set; }
    }
}