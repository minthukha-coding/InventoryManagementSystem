namespace InventoryManagementSystemApi.Modles.Setup.InventoryCategory
{
    public class InventoryCategoryListResponseModel
    {
        public List<InventoryCategoryModel> DataLst { get; set; }
        public MessageResponseModel MessageResponse { get; set; }
        public PageSettingModel PageSetting { get; set; }
    }
}
