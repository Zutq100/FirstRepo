using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculityInform.Repository
{
    interface IRepository<TModel> where TModel : class
    {
        List<TModel> GetAll();
        void Create(TModel value);
        void Update(TModel value);
        void Delete(int id);
        TModel Get(int id);
    }
}
