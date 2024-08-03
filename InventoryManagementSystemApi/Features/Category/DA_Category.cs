using InventoryManagementSystemApi.DbService.Db;
using InventoryManagementSystemApi.Modles.Setup.Category;

namespace InventoryManagementSystemApi.Features.Category;

public class DA_Category
{
    private readonly AppDbContext _db;
    private readonly ILogger<DA_Category> _logger;
    public DA_Category(AppDbContext db, ILogger<DA_Category> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<CategoryListModel> GetCategoryList()
    {
        var model = new CategoryListModel();
        try
        {
            var categories = await _db.TblCategories.ToListAsync();
            //if(categories.IsNullOrEmpty())
            //{
            //}
            model.Data = categories.Select(c => new CategoryModel
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, "An error occurred while fetching the category list.");
        }
        result:
        return model;
    }
    
}