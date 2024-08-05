using System;
using System.Collections.Generic;

namespace InventoryManagementSystemApi.DbService.Db;

public partial class TblOrderInvoice
{
    public string OrderInvoiceId { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public DateTime InvoiceDate { get; set; }

    public decimal TotalAmount { get; set; }
}
