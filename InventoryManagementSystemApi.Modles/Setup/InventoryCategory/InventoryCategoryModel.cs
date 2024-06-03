using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemApi.Modles.Setup.InventoryCategory
{
    public class InventoryCategoryModel
    {
        [Key]
        public string CategoryName { get; set; }
        public string CategoryId { get; set; }
    }
}
