using InventoryManagementSystemApi.Modles.Category;

namespace InventoryManagementSystemApi.Features.Category;

public class Bl_Category
{
    private readonly DA_Category _category;

    public Bl_Category(DA_Category category)
    {
        _category = category;
    }

    public async Task<Result<CategoryListModel>> GetCategoryList()
    {
        var model = await _category.GetCategoryList();
        return model;
    }

    public async Task<Result<CategoryModel>> GetCategoryById(string id)
    {
        var model = await _category.GetCategoryById(id);
        return model;
    }

    public async Task<Result<CategoryModel>> CreateCategory(CategoryModel reqModel)
    {
        var model = await _category.CreateCategory(reqModel);
        return model;
    }

    public async Task<Result<string>> DeleteCategory(string id)
    {
        var model = await _category.DeleteCategory(id);
        return model;
    }
}