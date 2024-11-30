using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationQualityInfoSystem.EFCore.Models
{
    public class DisciplinesModel
    {
        public int ID { get; set; }
        public string DisciplineName { get; set; }
        public int DisciplineTime { get; set; }
        public List<QualityModel> Quality { get; set; }

        public override string ToString()
            => $"Индентификатор - {ID}\n{DisciplineName}\t Всего часов на учебный год - {DisciplineTime}";


    }
}
