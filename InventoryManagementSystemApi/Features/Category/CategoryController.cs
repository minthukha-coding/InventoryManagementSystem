using InventoryManagementSystemApi.Modles.Setup.Category;
using InventoryManagementSystemApi.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystemApi.Features.Category;

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

    [HttpPost("Create")]
    public async Task<Result<CategoryModel>> CreateCategory(CategoryModel reqModel)
    {
        var model = await bl_Category.CreateCategory(reqModel);
        return model;
    }
}