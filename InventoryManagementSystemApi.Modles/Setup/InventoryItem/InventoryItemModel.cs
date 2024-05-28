namespace InventoryManagementSystemApi.Modles.Setup.InventoryItem
{
    public class InventoryItemModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string ItemAmount { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
