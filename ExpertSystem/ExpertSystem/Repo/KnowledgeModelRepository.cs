using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public class KnowledgeModelRepository
    {
        KnowledgeBaseContext _context;
        DbSet<KnowledgeModel> _knowledges;

        public KnowledgeModelRepository()
        {
            _context = new KnowledgeBaseContext();
            _knowledges = _context.Set<KnowledgeModel>();
        }

        public List<KnowledgeModel> GetAll() => _knowledges.ToList();
    }
}
