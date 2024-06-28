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

        public async Task<InventoryCategoryResponseModel> GetCategoryById(string id)
        {
            var model = new InventoryCategoryResponseModel();

            try
            {
                var item = await _appDbContext
                    .TblCategories
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.CategoryId == id);
                if (item is null)
                {
                    model.MessageResponseModel = new MessageResponseModel(false,
                        EnumStatus.Fail.ToString());
                    goto Result;
                }
                model.Data = item.Change();
                model.MessageResponseModel = new MessageResponseModel(true,
                    EnumStatus.Success.ToString());
            }
            catch (Exception ex)
            {
                model.MessageResponseModel = new MessageResponseModel(false, ex.Message);
            }

        Result:
            return model;
        }

        public async Task<MessageResponseModel> CreateCategory(InventoryCategoryModel reqModel)
        {
            var model = new MessageResponseModel();

            if (reqModel.CategoryId.IsNullOrEmpty())
            {
                throw new Exception("CategoryId Field is Required");
            }

            if (reqModel.CategoryName.IsNullOrEmpty())
            {
                throw new Exception("CategoryName Field is Required");
            }

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

        public async Task<MessageResponseModel> DeleteCategory(string id)
        {
            var model = new MessageResponseModel();

            try
            {
                var item = await _appDbContext
                    .TblCategories
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.CategoryId == id);

                if (item is null)
                {
                    model = new MessageResponseModel(false, EnumStatus.NotFound.ToString());
                    goto Result;
                }

                _appDbContext.TblCategories.Remove(item);
                var result = await _appDbContext.SaveChangesAsync();

                model = result > 0
                    ? new MessageResponseModel(true, EnumStatus.Success.ToString())
                    : new MessageResponseModel(false, EnumStatus.Fail.ToString());
            }
            catch (Exception ex)
            {
                model = new MessageResponseModel(false, ex);
            }

        Result:
            return model;
        }
    }
}
