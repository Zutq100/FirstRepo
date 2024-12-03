using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationQualityInfoSystem.EFCore.Models
{
    public class MainModel
    {
        public int Id { get; set; }
        public int StudentsID { get; set; }
        public virtual StudentsModel Students { get; set; }
        public int EducationQuality { get; set; }

        public override string ToString()
            => $"Идентификатор учащегося - {StudentsID}\nПолное имя учащегося - " + (Students == null ? "" : Students.FullName) + $"\nОценка успеваемости учащегося (%) - {EducationQuality}";
    }
}
