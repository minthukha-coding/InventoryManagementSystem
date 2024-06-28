namespace InventoryManagementSystemApi.Features.InventoryCategory
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InventoryCategoryController(BL_InventoryCategory blInventoryCategory) : ControllerBase
    {
        [HttpGet("GetCategorys")]
        public async Task<IActionResult> GetCategorys()
        {
            try
            {
                var model = await blInventoryCategory.GetCategorys();
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
                var model = await blInventoryCategory.GetCategoryById(id);
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
                var model = await blInventoryCategory.CreateCategory(reqModel);
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
                var model = await blInventoryCategory.DeleteCategory(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
