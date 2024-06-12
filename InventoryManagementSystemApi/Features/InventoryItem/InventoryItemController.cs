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
                var model = await _bl_inventoryItem.GetItemList();
                return Ok(model);
        }  

        [HttpGet("GetItemByItemName")]
        public async Task<IActionResult> GetItemByItemName(string reqModel)
        {
                var model = await _bl_inventoryItem.GetItemByItemName(reqModel);
                return Ok(model);
        }

        [HttpPost("CreateItem")]
        public async Task<IActionResult> CreateItem(InventoryItemModel reqModel)
        {
                var model = await _bl_inventoryItem.CreateItem(reqModel);
                return Ok(model);
        }

        [HttpDelete("{itemName}")]
        public async Task<IActionResult> DeleteItemByItemName(string itemName)
        {
                var model = await _bl_inventoryItem.DeleteItemByItemName(itemName);
                return Ok(model);
        }  

        [HttpPatch]
        public async Task<IActionResult> UpdateItemByItemName(string itemName, UpdateInventoryItemReqModel reqModel)
        {
                var model = await _bl_inventoryItem.UpdateItemByItemName(itemName, reqModel);
                return Ok(model);
        }
    }
}
