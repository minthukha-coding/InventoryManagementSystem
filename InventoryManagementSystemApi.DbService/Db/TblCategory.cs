﻿namespace InventoryManagementSystemApi.DbService.Db;

public class TblCategory
{
    public string CategoryId { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public DateTime CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public string? UpdatedUserId { get; set; }

    public int IsDeleted { get; set; }
}