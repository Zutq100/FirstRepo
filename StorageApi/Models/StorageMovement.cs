namespace StorageApi.Models
{
    public enum MovementType
    {
        Receipt,
        Consumption,
        Transfer,
        Adjustment
    }

    public class StorageMovement
    {
        public int Id { get; set; }
        public DateTime MovementDate { get; set; } = DateTime.UtcNow;
        public MovementType Type { get; set; }
        public int Quantity { get; set; }
        public string? Source { get; set; }
        public string? Destination { get; set; }
        public string? Comment { get; set; }

        public int StorageItemId { get; set; }
        public StorageItem StorageItem { get; set; } = null!;
    }
}
