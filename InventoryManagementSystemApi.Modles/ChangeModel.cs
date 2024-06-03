using InventoryManagementSystemApi.DbService.Model;
using InventoryManagementSystemApi.Modles.Setup.InventoryCategory;
using InventoryManagementSystemApi.Modles.Setup.InventoryItem;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemApi.Modles
{
    public static class ChangeModel
    {
        #region InventoryItem

        //public static InventoryItemModel Change(this TblInventoryItem dataModel)
        //{
        //    var item = new InventoryItemModel
        //    {
        //        ItemId = dataModel.ItemId,
        //        ItemName = dataModel.ItemName,
        //        ItemCategory = dataModel.ItemCategory,
        //        ItemAmount = dataModel.ItemAmount,
        //        ItemPrice = dataModel.ItemPrice,
        //    };
        //    return item;
        //}

        #endregion

        #region InventoryCategory

        public static InventoryCategoryModel Change(this TblCategory dataModel)
        {
            var item = new InventoryCategoryModel
            {
                CategoryId = dataModel.CategoryId,
                CategoryName = dataModel.CategoryName,
            };
            return item;
        }

        public static TblCategory Change(this InventoryCategoryModel dataModel)
        {
            var item = new TblCategory
            {
                CategoryId = dataModel.CategoryId,
                CategoryName = dataModel.CategoryName,
            };
            return item;
        }

        #endregion
    }
}
