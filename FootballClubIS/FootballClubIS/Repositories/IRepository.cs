using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubIS.Repositories
{
    internal interface IRepository<TModel> where TModel : class
    {
        List<TModel> GetList(IEnumerable<string>? includes = null);
        TModel Get(int id);
        void Create(TModel value);
        void Update(TModel value);
        void Delete(int id);
        void Dispose();
    }
}
