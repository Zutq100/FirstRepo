using Microsoft.EntityFrameworkCore;
using FaculityInform.EFCore.Context;

namespace FaculityInform.Repository
{
    class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        private FaculityInformContext _context;

        public Repository()
        {
            _context = new FaculityInformContext();
        }

        public void Create(TModel value)
        {
            _context.Set<TModel>().Add(value);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Set<TModel>().Remove(_context.Set<TModel>().Find(id));
            _context.SaveChanges();
        }

        public List<TModel> GetAll() => _context.Set<TModel>().ToList();

        public void Update(TModel value)
        {
            _context.Update(value);
            _context.SaveChanges();
        }

        public TModel Get(int id) => _context.Set<TModel>().Find(id);

        public List<TModel> GetAll(List<string> includes)
        {
            var set = _context.Set<TModel>().AsQueryable();

            if (includes is null)
                return set.ToList();
            foreach (var include in includes)
                set = set.Include(include);
            return set.ToList();
        }

        public List<TModel> GetAll(string include) => _context.Set<TModel>().AsQueryable().Include(include).ToList();
    }
}
