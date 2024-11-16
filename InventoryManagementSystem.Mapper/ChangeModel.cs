namespace InventoryManagementSystemApi.Modles;

public static class ChangeModel
{
    public static List<CategoryModel> Change (this List<TblCategory> category)
    {
        return category.Select(category => new CategoryModel
        {
           CategoryId = category.CategoryId,
           CategoryName = category.CategoryName,
        }).ToList();
    }
}