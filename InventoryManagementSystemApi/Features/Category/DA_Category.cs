using InventoryManagementSystemApi.DbService.Db;

namespace InventoryManagementSystemApi.Features.Category;

public class DA_Category
{
    private readonly AppDbContext _db;

    public DA_Category(AppDbContext db)
    {
        _db = db;
    }
    
}