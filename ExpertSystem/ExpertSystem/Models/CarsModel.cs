namespace EFCore.Models
{
    public class CarsModel
    {
        public int ID { get; set; }
        public string CarBrand { get; set; }
        public virtual List<KnowledgeModel>? Knowledge { get; set; }
    }
}
