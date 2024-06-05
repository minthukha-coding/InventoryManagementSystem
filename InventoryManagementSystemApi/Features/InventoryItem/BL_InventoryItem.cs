using InventoryManagementSystemApi.Modles.Setup.InventoryCategory;
using InventoryManagementSystemApi.Modles;
using InventoryManagementSystemApi.Modles.Setup.InventoryItemListRespnseModel;
using InventoryManagementSystemApi.Modles.Setup.InventoryItem;

namespace InventoryManagementSystemApi.Features.InventoryItem
{
    public class BL_InventoryItem
    {
        private readonly DL_InventoryItem _dl_inventoryItem;

        public BL_InventoryItem(DL_InventoryItem dl_inventoryItem)
        {
            _dl_inventoryItem = dl_inventoryItem;
        }
        public async Task<InventoryItemListRespnseModel> GetItemList()
        {
            var model = await _dl_inventoryItem.GetItemList();
            return model;
        }

        public async Task<MessageResponseModel> CreateItem(InventoryItemModel reqModel)
        {
            var model = await _dl_inventoryItem.CreateItem(reqModel);
            return model;
        }
        public async Task<MessageResponseModel> DeleteItem(string id)
        {
            var model = await _dl_inventoryItem.DeleteItem(id);
            return model;
        }
    }
}
