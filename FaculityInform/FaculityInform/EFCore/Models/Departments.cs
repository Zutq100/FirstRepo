using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculityInform.EFCore.Models
{
    class Departments
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Directions> Directions { get; set; } 
        public List<CompositionOfTeachers> CompositionOfTeachers { get; set; }

        public override string ToString()
            => "";
    }
}
