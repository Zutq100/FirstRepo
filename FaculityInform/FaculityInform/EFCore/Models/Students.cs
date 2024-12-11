using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculityInform.EFCore.Models
{
    class Students
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public Groups Group { get; set; }

        public override string ToString()
            => $"Имя учащегося - {FullName}\n" + (Group == null ? "Группа отсутствует" : $"Группа - {Group.Title}");
    }
}
