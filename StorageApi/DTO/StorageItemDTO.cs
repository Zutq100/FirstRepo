namespace StorageApi.DTO
{
    public record StorageItemDTO(
    int Id,
    string Name,
    string? Description,
    string ArticleNumber,
    decimal Price,
    int Quantity,
    string Unit,
    int? MinimumStockLevel,
    int? MaximumStockLevel,
    string? Location,
    string? Category);

    public record CreateStorageItemDTO(
        string Name,
        string? Description,
        string ArticleNumber,
        decimal Price,
        int Quantity,
        string Unit,
        int? MinimumStockLevel,
        int? MaximumStockLevel,
        string? Location,
        string? Category);

    public record UpdateStorageItemDTO(
        string Name,
        string? Description,
        decimal Price,
        int Quantity,
        string Unit,
        int? MinimumStockLevel,
        int? MaximumStockLevel,
        string? Location,
        string? Category);
}
