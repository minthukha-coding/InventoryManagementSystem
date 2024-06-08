using InventoryManagementSystemApi.Features.InventoryCategory;
using InventoryManagementSystemApi.Modles.Setup.InventoryCategory;
using InventoryManagementSystemApi.Modles.Setup.InventoryItem;

namespace InventoryManagementSystemApi.Features.InventoryItem
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly BL_InventoryItem _bl_inventoryItem;

        public InventoryItemController(BL_InventoryItem bl_inventoryItem)
        {
            _bl_inventoryItem = bl_inventoryItem;
        }
        [HttpGet("GetItemList")]
        public async Task<IActionResult> GetItemList()
        {
            try
            {
                var model = await _bl_inventoryItem.GetItemList();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }  
        [HttpGet("GetItemListByItemName")]
        public async Task<IActionResult> GetItemListByItemName(string reqModel)
        {
            try
            {
                var model = await _bl_inventoryItem.GetItemByItemName(reqModel);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateItem")]
        public async Task<IActionResult> CreateItem(InventoryItemModel reqModel)
        {
            try
            {
                var model = await _bl_inventoryItem.CreateItem(reqModel);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            try
            {
                var model = await _bl_inventoryItem.DeleteItem(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
