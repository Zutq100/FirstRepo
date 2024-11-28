using EFCore.Models;
using EFCore.Repo;

namespace ESImplementer
{
    public class ExpertSystemForCars
    {
        public bool[] Answers { get; set; }
        public int CountQuestions { get; set; }
        private List<KnowledgeModel> Knowledges { get; set; }

        public ExpertSystemForCars()
        {
            CountQuestions = GetCountQuestions();
            Answers = new bool[CountQuestions];
            Knowledges = new KnowledgeModelRepository().GetAll();
        }

        private int GetCountQuestions() => new QuestionsModelRepository().GetAll().Count();

        public string GetQuestion(int selector)=> new QuestionsModelRepository().GetQuestionToId(selector);
        public string GetResult()
        {
            for (int i = 1; i <= Answers.Length; i++)
            {
                int verify = 0;
                var listCar = Knowledges.Where(x => x.CarID == i).ToList();
                for (int j = 0; j <listCar.Count; j++)
                {
                    if (listCar[j].Answer == Answers[j])
                    {
                        verify++;
                    }
                }
                if (verify == listCar.Count)
                {
                    return new CarsModelRepository().GetCarBrandToId(i);
                }
            }
            return "Элемент в списке отсутствует";
        }
        public List<string> GetAllResult()
        {
            var listResult = new List<string>();
            foreach (var item in new CarsModelRepository().GetAll())
            {
                listResult.Add(item.CarBrand);
            }
            return listResult;
        }
    }
}
