using InventoryManagementSystemApi.Modles.Setup.Category;
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

    [HttpPost]
    public async Task<CategoryListModel> GetCategoryList()
    {
        var model = await bl_Category.GetCategoryList();
        return model;
    }
}