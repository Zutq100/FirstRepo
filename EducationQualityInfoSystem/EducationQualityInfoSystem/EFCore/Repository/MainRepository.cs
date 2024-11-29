using EducationQualityInfoSystem.EFCore.Context;
using EducationQualityInfoSystem.EFCore.Models;

namespace EducationQualityInfoSystem.EFCore.Repository
{
    public class MainRepository<TValue> : IRepository<TValue> where TValue : class
    {
        private EducationQualityContext _context;

        public MainRepository()
        {
            _context = new EducationQualityContext();
        }
        public void Create(TValue value) => _context.Set<TValue>().Add(value);
        public void Delete(int id) => _context.Set<TValue>().Remove(_context.Set<TValue>().Find(id));
        public List<TValue> GetAll() => _context.Set<TValue>().ToList();
        public void Update(TValue value) => _context.Set<TValue>().Update(value);
        public TValue Get<TValue>(int id) where TValue : class => _context.Set<TValue>().Find(id);
        public TValue Get(int id) => _context.Set<TValue>().Find(id);
    }
}
