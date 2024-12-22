using InventoryManagementSystemApi.Modles.Category;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagementSystemApi.Features.Category;

[Authorize]
[Route("api/inventory/category")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly Bl_Category bl_Category;

    public CategoryController(Bl_Category bl_Category)
    {
        this.bl_Category = bl_Category;
    }

    [HttpPost("List")]
    public async Task<Result<CategoryListModel>> GetCategoryList()
    {
        var model = await bl_Category.GetCategoryList();
        return model;
    }

    [HttpPost("Edit")]
    public async Task<Result<CategoryModel>> GetCategoryById(string id)
    {
        var model = await bl_Category.GetCategoryById(id);
        return model;
    }

    [HttpPost("Create")]
    public async Task<Result<CategoryModel>> CreateCategory(CategoryModel reqModel)
    {
        var model = await bl_Category.CreateCategory(reqModel);
        return model;
    }

    [HttpPost("Delete")]
    public async Task<Result<string>> DeleteCategory(string id)
    {
        var model = await bl_Category.DeleteCategory(id);
        return model;
    }
}