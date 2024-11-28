using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public class QuestionsModelRepository
    {
        KnowledgeBaseContext _context;
        DbSet<QuestionsModel> _questions;

        public QuestionsModelRepository()
        {
            _context = new KnowledgeBaseContext();
            _questions = _context.Set<QuestionsModel>();
        }

        public string GetQuestionToId(int id) => _questions.First(x => x.ID == id).QuestionText;
        public List<QuestionsModel> GetAll() => _questions.ToList();
    }
}
