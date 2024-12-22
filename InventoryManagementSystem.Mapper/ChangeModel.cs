namespace InventoryManagementSystem.Mapper;

public static class ChangeModel
{
    public static List<CategoryModel> Change(this List<TblCategory> category)
    {
        return category.Select(category => new CategoryModel
        {
            CategoryId = category.CategoryId,
            CategoryName = category.CategoryName
        }).ToList();
    }

    public static CategoryModel Change(this TblCategory category)
    {
        return new CategoryModel
        {
            CategoryId = category.CategoryId,
            CategoryName = category.CategoryId
        };
    }
}