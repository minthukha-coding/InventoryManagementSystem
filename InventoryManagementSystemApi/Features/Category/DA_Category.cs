using InventoryManagementSystem.Mapper;
using InventoryManagementSystemApi.Modles.Category;
using InventoryManagementSystemApi.Modles.Setup.Resources;

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

    public async Task<Result<CategoryListModel>> GetCategoryList()
    {
        var model = new Result<CategoryListModel>();
        try
        {
            var categories = await _db.TblCategories.ToListAsync();
            if (categories == null || categories.Count == 0)
            {
                model = Result<CategoryListModel>.FailureResult(MessageResources.NotFound);
                goto result;
            }

            model = Result<CategoryListModel>.SuccessResult(new CategoryListModel
            {
                Data = categories.Change()
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, "An error occurred while fetching the category list.");
            model = Result<CategoryListModel>.FailureResult("An error occurred while fetching the category list.");
        }

        result:
        return model;
    }

    public async Task<Result<CategoryModel>> GetCategoryById(string id)
    {
        var model = new Result<CategoryModel>();
        try
        {
            var item = await _db.TblCategories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (item is null) model = Result<CategoryModel>.FailureResult(MessageResources.NotFound);
            model = Result<CategoryModel>.SuccessResult(item!.Change());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, "An error occurred while fetching the category.");
            model = Result<CategoryModel>.FailureResult("An error occurred while fetching the category.");
        }

        return model;
    }

    public async Task<Result<CategoryModel>> CreateCategory(CategoryModel reqModel)
    {
        var model = new Result<CategoryModel>();
        try
        {
            var category = await _db.TblCategories
                .FirstOrDefaultAsync(x => x.CategoryId == reqModel.CategoryId);
            if (category != null)
            {
                model = Result<CategoryModel>.FailureResult(MessageResources.Duplicate);
                goto result;
            }

            var item = new TblCategory
            {
                CategoryId = reqModel.CategoryId,
                CategoryName = reqModel.CategoryName,
                CreatedUserId = DevCode.GenerateGuid(),
                CreatedDateTime = DevCode.GetServerDateTime()
            };
            await _db.TblCategories.AddAsync(item);
            var result = await _db.SaveChangesAsync();
            model = Result<CategoryModel>.ExecuteResult(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, "An error occurred while fetching the category create.");
            model = Result<CategoryModel>.FailureResult("An error occurred while fetching the category create.");
        }

        result:
        return model;
    }

    public async Task<Result<string>> DeleteCategory(string id)
    {
        var model = new Result<string>();
        try
        {
            var category = await _db.TblCategories
                .FirstOrDefaultAsync(x => x.CategoryId == id);
            if (category == null)
            {
                model = Result<string>.FailureResult(MessageResources.NotFound);
                goto result;
            }

            _db.Remove(category);

            var item = await _db.TblItems
                .Where(x => x.ItemCategory == category.CategoryId)
                .ToListAsync();
            _db.RemoveRange(item);

            var result = await _db.SaveChangesAsync();
            model = result > 0
                ? Result<string>.SuccessResult("Success")
                : Result<string>.FailureResult("Fail");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, "An error occured while featching the category delete.");
            model = Result<string>.FailureResult("An error occured while featching the category delete.");
        }

        result:
        return model;
    }
}