namespace InventoryManagementSystemApi.Features.InventoryItem
{
    [Route("api/v1/inventoryItem/[controller]")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly BL_InventoryItem _bl_inventoryItem;

        public InventoryItemController(BL_InventoryItem bl_inventoryItem)
        {
            _bl_inventoryItem = bl_inventoryItem;
        }

        //[HttpGet("GetAllItem")]
        //public async Task<IActionResult> GetAllItem()
        //{
        //    var lst = await  _bl_inventoryItem.GetAllItem();
        //    return Ok(lst);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllItem1()
        //{
        //    try
        //    {
        //        var model = await _bl_inventoryItem.GetAllItem();
        //        return Ok(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
