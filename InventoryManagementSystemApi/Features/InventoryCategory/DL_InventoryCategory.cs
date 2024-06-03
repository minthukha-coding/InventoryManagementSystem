using Azure;
using InventoryManagementSystemApi.DbService.Model;
using InventoryManagementSystemApi.Modles;
using InventoryManagementSystemApi.Modles.Setup.InventoryCategory;

namespace InventoryManagementSystemApi.Features.InventoryCategory
{
    public class DL_InventoryCategory
    {
        private readonly AppDbContext _appDbContext;

        public DL_InventoryCategory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<InventoryCategoryListResponseModel> GetCategorys()
        {
            var model = new InventoryCategoryListResponseModel();

            try
            {
                var item = await _appDbContext
                    .TblCategories
                    .AsNoTracking()
                    .ToListAsync();
                model.DataLst = item
                    .Select(x => x.Change())
                    .ToList();
                model.MessageResponse = new MessageResponseModel(true,
                    EnumStatus.Success.ToString());
            }
            catch (Exception ex)
            {
                model.DataLst = new List<InventoryCategoryModel>();
                model.MessageResponse = new MessageResponseModel(false, ex.Message);
            }

            return model;
        }

        public async Task<MessageResponseModel> CreateCategory(InventoryCategoryModel reqModel)
        {
            var model = new MessageResponseModel();
            try
            {
                await _appDbContext.TblCategories.AddAsync(reqModel.Change());
                var result = await _appDbContext.SaveChangesAsync();
                model = result > 0
                ? new MessageResponseModel(true, EnumStatus.Success.ToString())
                : new MessageResponseModel(false, EnumStatus.Fail.ToString());
            }
            catch (Exception ex)
            {
                model = new MessageResponseModel(false, ex);
            }
            return model;
        }
    }
}
