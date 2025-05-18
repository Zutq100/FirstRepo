using StorageApi.Models;

namespace StorageApi.DTO
{
    public record StorageMovementDTO(
    int Id,
    DateTime MovementDate,
    MovementType Type,
    int Quantity,
    string? Source,
    string? Destination,
    string? Comment,
    int StorageItemId,
    string StorageItemName);

    public record CreateStorageMovementDTO(
        MovementType Type,
        int Quantity,
        string? Source,
        string? Destination,
        string? Comment,
        int StorageItemId);

    public record UpdateStorageMovementDTO(
        MovementType Type,
        int? Quantity,
        string? Source,
        string? Destination,
        string? Comment,
        int StorageItemId);
}
