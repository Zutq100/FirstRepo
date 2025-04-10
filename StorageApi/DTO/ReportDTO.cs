namespace StorageApi.DTO
{
    public record InventoryReportDTO(
    int TotalItems,
    int TotalQuantity,
    decimal TotalValue,
    IEnumerable<StockLevelDTO> LowStockItems,
    IEnumerable<StockLevelDTO> OverstockedItems);

    public record StockLevelDTO(
        int ItemId,
        string ItemName,
        string ArticleNumber,
        int CurrentQuantity,
        int? MinimumLevel,
        int? MaximumLevel);
}
