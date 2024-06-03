using InventoryManagementSystemApi.Modles;
using InventoryManagementSystemApi.Modles.Setup.InventoryCategory;

namespace InventoryManagementSystemApi.Features.InventoryCategory
{
    public class BL_InventoryCategory
    {
        private readonly DL_InventoryCategory dA_InventoryCategory;

        public BL_InventoryCategory(DL_InventoryCategory dA_InventoryCategory)
        {
            this.dA_InventoryCategory = dA_InventoryCategory;
        }

        public async Task<InventoryCategoryListResponseModel> GetCategorys()
        {
            var model = await dA_InventoryCategory.GetCategorys();
            return model;
        }

        public async Task<MessageResponseModel> CreateCategory(InventoryCategoryModel reqModel)
        {
            var model = await dA_InventoryCategory.CreateCategory(reqModel);
            return model;
        }

        public async Task<MessageResponseModel> DeleteCategory(string id)
        {
            var model = await dA_InventoryCategory.DeleteCategory(id);
            return model;
        }
    }
}
