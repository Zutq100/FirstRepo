using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageWPF.Client.Models
{
    public class StorageItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ArticleNumber { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; } = "pcs";
        public int? MinimumStockLevel { get; set; }
        public int? MaximumStockLevel { get; set; }
        public string? Location { get; set; }
        public string? Category { get; set; }
    }
}
