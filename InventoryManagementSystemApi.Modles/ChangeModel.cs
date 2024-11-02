using InventoryManagementSystemApi.DbService.Db;
using InventoryManagementSystemApi.Modles.Setup.Category;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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