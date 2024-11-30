using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationQualityInfoSystem.EFCore.Models
{
    public class DayOfWeekModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<QualityModel> Quality { get; set; }

        public override string ToString()
            => $"Индетификатор - {ID}\t {Name}";
    }
}
