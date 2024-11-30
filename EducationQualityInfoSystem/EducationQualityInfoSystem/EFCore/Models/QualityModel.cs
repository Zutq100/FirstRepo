using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationQualityInfoSystem.EFCore.Models
{
    public class QualityModel
    {
        public int Id { get; set; }
        public virtual int StudentID { get; set; }
        public virtual int DisciplineID { get; set; }
        public virtual int DayOfWeekID { get; set; }
        public StudentsModel Student { get; set; }
        public DisciplinesModel Disciplines { get; set; }
        public DayOfWeekModel DayOfWeek { get; set; }
        public bool? IsEvaluated { get; set; }
        public bool? IsPresent { get; set; }

        public override string ToString()
            => $"Индентификатор учащегося - {StudentID}\n"+(Student == null ? "Учащийся не выбран" : Student.FullName) + $"\nДисциплина - " +
            (Disciplines == null? "Дисциплина не выбрана" : Disciplines.DisciplineName) + "\nДень недели - " + (DayOfWeek == null ? "День недели не выбран" : DayOfWeek.Name) +
            (IsEvaluated == false ? "\nНе отработал - " : "\nОтработал - ") + (IsPresent == false ? "Отсутствовал" : "Присутствовал");
    }
}
