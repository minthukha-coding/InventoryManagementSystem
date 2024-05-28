using InventoryManagementSystemApi.Modles.Setup.InventoryItemListRespnseModel;

namespace InventoryManagementSystemApi.Features.InventoryItem
{
    public class BL_InventoryItem
    {
        private readonly DL_InventoryItem _dl_inventoryItem;

        public BL_InventoryItem(DL_InventoryItem dl_inventoryItem)
        {
            _dl_inventoryItem = dl_inventoryItem;
        }
        public async Task<InventoryItemListRespnseModel> GetAllItem()
        {
            var response = await _dl_inventoryItem.GetListItem();
            return response;
        }
    }
}
