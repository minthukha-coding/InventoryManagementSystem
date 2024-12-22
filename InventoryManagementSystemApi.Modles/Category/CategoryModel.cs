namespace InventoryManagementSystemApi.Modles.Category;

public class CategoryModel
{
    public string CategoryId { get; set; }
    public string CategoryName { get; set; }
}

public class CategoryListModel
{
    public List<CategoryModel> Data { get; set; }
}