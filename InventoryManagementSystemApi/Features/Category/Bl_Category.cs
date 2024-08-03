using InventoryManagementSystemApi.Modles.Setup.Category;

namespace InventoryManagementSystemApi.Features.Category;

public class Bl_Category
{
    private readonly DA_Category _category;

    public Bl_Category(DA_Category category)
    {
        _category = category;
    }

    public async Task<CategoryListModel> GetCategoryList()
    {
        var model = await _category.GetCategoryList();
        return model;
    }
}
