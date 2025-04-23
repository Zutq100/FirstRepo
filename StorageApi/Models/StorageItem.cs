namespace StorageApi.Models
{
    public class StorageItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string ArticleNumber { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; } = "штук";
        public int? MinimumStockLevel { get; set; }
        public int? MaximumStockLevel { get; set; }
        public string? Location { get; set; }
        public string? Category { get; set; }

        public ICollection<StorageMovement> Movements { get; set; } = new List<StorageMovement>();
    }
}
