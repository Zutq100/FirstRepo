using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationQualityInfoSystem.EFCore.Repository
{
    public interface IRepository<TValue> where TValue : class
    {
        List<TValue> GetAll();
        void Create(TValue value);
        void Update(TValue value);
        void Delete(int id);
    }
}
