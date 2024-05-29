namespace InventoryManagementSystemApi.Features.InventoryCategory
{
    [Route("api/v1/inventoryCategory/[controller]")]
    [ApiController]
    public class InventoryCategoryController : ControllerBase
    {
        private readonly BL_InventoryCategory _inventoryCategory;

        public InventoryCategoryController(BL_InventoryCategory inventoryCategory)
        {
            _inventoryCategory = inventoryCategory;
        }
    }
}
