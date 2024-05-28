using InventoryManagementSystemApi.DbService.Model;
using InventoryManagementSystemApi.Modles;
using InventoryManagementSystemApi.Modles.Setup.InventoryItem;
using InventoryManagementSystemApi.Modles.Setup.InventoryItemListRespnseModel;

namespace InventoryManagementSystemApi.Features.InventoryItem
{
    public class DL_InventoryItem
    {
        private readonly AppDbContext _appDbContext;

        public DL_InventoryItem(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<InventoryItemListRespnseModel> GetListItem()
        {
            var model = new InventoryItemListRespnseModel();
            try
            {
                var items = await _appDbContext
                    .TblInventoryItems
                    .AsNoTracking()
                    .ToListAsync();
                model.DataLst = items
                    .Select(x => x.Change())
                    .ToList();
                model.MessageResponse = new MessageResponseModel(true,
                    EnumStatus.Success.ToString());
            }
            catch (Exception ex)
            {
                model.DataLst = new List<InventoryItemModel>();
                model.MessageResponse = new MessageResponseModel(false, ex.Message);
            }
            return model;
        }
    }
}
