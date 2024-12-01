using EducationQualityInfoSystem.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace EducationQualityInfoSystem.EFCore.Repository
{
    public class MainRepository<TValue> : IRepository<TValue> where TValue : class
    {
        private EducationQualityContext _context;

        public MainRepository()
        {
            _context = new EducationQualityContext();
        }
        public void Create(TValue value)
        {
            _context.Set<TValue>().Add(value);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Set<TValue>().Remove(_context.Set<TValue>().Find(id));
            _context.SaveChanges();
        }

        public List<TValue> GetAll() => _context.Set<TValue>().ToList();
        public void Update(TValue value)
        {
            _context.Update(value);
            _context.SaveChanges();
        }

        public TValue Get<TValue>(int id) where TValue : class => _context.Set<TValue>().Find(id);
        public TValue Get(int id) => _context.Set<TValue>().Find(id);
        public List<TValue> GetAll(List<string> includes)
        {
            var set = _context.Set<TValue>().AsQueryable();

            if (includes is null)
                return set.ToList();
            foreach (var include in includes)
                set = set.Include(include);
            return set.ToList();
        }
    }
}
