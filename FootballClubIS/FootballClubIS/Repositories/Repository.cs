using FootballClubIS.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubIS.Repositories
{
    internal class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        private FootballClubContext _context;

        public Repository()
        {
            _context = new FootballClubContext();
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

        public TModel Get(int id) 
            => _context.Set<TModel>().Find(id);

        public List<TModel> GetList(IEnumerable<string>? includes = null)
        {
            var set = _context.Set<TModel>().AsQueryable();
            if (includes is null)
                return set.ToList();
            foreach (var include in includes)
                set = set.Include(include);
            return set.ToList();
        }

        public void Update(TModel value)
        {
            _context.Update(value);
            _context.SaveChanges();
        }

        public void Dispose()
            =>_context.Dispose();

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
