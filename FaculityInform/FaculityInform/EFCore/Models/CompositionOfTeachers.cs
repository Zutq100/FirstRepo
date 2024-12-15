using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculityInform.EFCore.Models
{
    public class CompositionOfTeachers
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Post {  get; set; }
        public int DepartmentId { get; set; }
        public Departments Department { get; set; }

        public override string ToString()
            => $"ФИО Преподавателя - {FullName}\nДолжность преподавателя - {Post}\n" + (Department == null ? "Кафедра отсутствует" : $"Кафедра - {Department.Title}");
    }
}
