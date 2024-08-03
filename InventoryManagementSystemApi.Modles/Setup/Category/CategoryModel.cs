using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemApi.Modles.Setup.Category;

public class CategoryModel
{
    public string CategoryId { get; set; }
    public string CategoryName { get; set; }
}

public class CategoryListModel
{
    public List<CategoryModel> Data { get; set; }
}