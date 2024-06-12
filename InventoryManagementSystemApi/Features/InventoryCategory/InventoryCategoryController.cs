namespace InventoryManagementSystemApi.Features.InventoryCategory
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InventoryCategoryController : ControllerBase
    {
        private readonly BL_InventoryCategory bl_inventoryCategory;

        public InventoryCategoryController(BL_InventoryCategory bl_inventoryCategory)
        {
            this.bl_inventoryCategory = bl_inventoryCategory;
        }

        [HttpGet("GetCategorys")]
        public async Task<IActionResult> GetCategorys()
        {
            try
            {
                var model = await bl_inventoryCategory.GetCategorys();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            try
            {
                var model = await bl_inventoryCategory.GetCategoryById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(InventoryCategoryModel reqModel)
        {
            try
            {
                var model = await bl_inventoryCategory.CreateCategory(reqModel);
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
                var model = await bl_inventoryCategory.DeleteCategory(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
