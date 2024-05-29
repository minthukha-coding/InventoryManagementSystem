using InventoryManagementSystemApi.DbService.Model;

namespace InventoryManagementSystemApi.Features.InventoryCategory
{
    public class DA_InventoryCategory
    {
        private readonly AppDbContext _appDbContext;

        public DA_InventoryCategory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
