namespace EFCore.Models
{
    public class QuestionsModel
    {
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public virtual List<KnowledgeModel>? Knowledges { get; set; }
    }
}
