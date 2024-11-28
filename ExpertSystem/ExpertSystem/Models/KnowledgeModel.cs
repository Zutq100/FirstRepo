namespace EFCore.Models
{
    public class KnowledgeModel
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public int QuestionID { get; set; }
        public bool Answer { get; set; }
        public QuestionsModel? Question { get; set; }
        public CarsModel? Car { get; set; }
    }
}
