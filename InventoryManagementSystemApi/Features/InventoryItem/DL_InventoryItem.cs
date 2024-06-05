﻿using InventoryManagementSystemApi.DbService.Model;
using InventoryManagementSystemApi.Modles;
using InventoryManagementSystemApi.Modles.Setup.InventoryCategory;
using InventoryManagementSystemApi.Modles.Setup.InventoryItem;
using InventoryManagementSystemApi.Modles.Setup.InventoryItemListRespnseModel;
using Microsoft.IdentityModel.Tokens;

namespace InventoryManagementSystemApi.Features.InventoryItem
{
    public class DL_InventoryItem
    {
        private readonly AppDbContext _appDbContext;

        public DL_InventoryItem(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<InventoryItemListRespnseModel> GetItemList()
        {
            var model = new InventoryItemListRespnseModel();

            try
            {
                var item = await _appDbContext
                    .TblItems
                    .AsNoTracking()
                    .ToListAsync();
                model.DataLst = item
                    .Select(x => x.Change())
                    .ToList();
                model.MessageResponse = new MessageResponseModel(true,
                    EnumStatus.Success.ToString());
            }
            catch (Exception ex)
            {
                model.DataLst = new List<InventoryItemModel>();
                model.MessageResponse = new MessageResponseModel(false, ex.Message);
            }

            return model;
        }

        //public async Task<InventoryItemListRespnseModel> GetItemByCategoryId(string id)
        //{
        //    var model = new InventoryItemModel();

        //    try
        //    {
        //        var item = await _appDbContext
        //            .TblCategories
        //            .AsNoTracking()
        //            .Where(category => id.Contains(category.CategoryId))
        //            .ToListAsync();

                //if (item is null)
                //{
                //    model.MessageResponseModel = new MessageResponseModel(false,
                //        EnumStatus.Fail.ToString());
                //    goto Result;
                //}

                //model.Data = item.Change();
                //model.MessageResponseModel = new MessageResponseModel(true,
                //    EnumStatus.Success.ToString());
            //}
            //catch (Exception ex)
            //{
                //model.MessageResponseModel = new MessageResponseModel(false, ex.Message);
            //}

        //Result:
            //return model;
        //}

        public async Task<MessageResponseModel> CreateItem(InventoryItemModel reqModel)
        {
            var model = new MessageResponseModel();

            if (reqModel.ItemName.IsNullOrEmpty())
            {
                throw new Exception("CategoryId Field is Required");
            }

            if (reqModel.ItemCategory.IsNullOrEmpty())
            {
                throw new Exception("ItemCategory Field is Required");
            }

            if (reqModel.ItemAmount.IsNullOrEmpty())
            {
                throw new Exception("ItemAmount Field is Required");
            }

            if (reqModel.ItemPrice.Equals(null))
            {
                throw new Exception("ItemPrice Field is Required");
            }

            var itemCategory = _appDbContext.TblCategories
                .FirstOrDefault(x => x.CategoryId == reqModel.ItemCategory);

            if (itemCategory is null)
            {
                model = new MessageResponseModel(false, "Invalid ItemCategory");
                goto Result;
            }

            var itemName = await _appDbContext.TblItems.FirstOrDefaultAsync(x => x.ItemName == reqModel.ItemName);
            if (itemName is null)
            {
                try
                {
                    await _appDbContext.TblItems.AddAsync(reqModel.Change());
                    var result = await _appDbContext.SaveChangesAsync();
                    model = result > 0
                    ? new MessageResponseModel(true, EnumStatus.Success.ToString())
                    : new MessageResponseModel(false, EnumStatus.Fail.ToString());
                }
                catch (Exception ex)
                {
                    model = new MessageResponseModel(false, ex);
                }
            }
            else
            {
                model = new MessageResponseModel(false, "Duplicate ItemName");
            }

        Result:
            return model;
        }

        public async Task<MessageResponseModel> DeleteItem(string id)
        {
            var model = new MessageResponseModel();

            try
            {
                var item = await _appDbContext
                    .TblItems
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.ItemCategory == id);

                if (item is null)
                {
                    model = new MessageResponseModel(false, EnumStatus.NotFound.ToString());
                    goto Result;
                }

                _appDbContext.TblItems.Remove(item);
                var result = await _appDbContext.SaveChangesAsync();

                model = result > 0
                    ? new MessageResponseModel(true, EnumStatus.Success.ToString())
                    : new MessageResponseModel(false, EnumStatus.Fail.ToString());
            }
            catch (Exception ex)
            {
                model = new MessageResponseModel(false, ex);
            }

        Result:
            return model;
        }
    }
}
