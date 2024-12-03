using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationQualityInfoSystem.EFCore.Models
{
    public class StudentsModel
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public List<QualityModel> Quality { get; set; }
        public List<MainModel> MainModel { get; set; }

        public override string ToString()
            => $"Идентификатор учащегося - {ID}\n Полное имя - {FullName}";

    }
}
