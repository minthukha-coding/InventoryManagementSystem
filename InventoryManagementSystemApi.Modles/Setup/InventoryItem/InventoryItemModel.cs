using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystemApi.Modles.Setup.InventoryItem
{
    public class InventoryItemModel
    {
        [Key]
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemAmount { get; set; }
    }
}
