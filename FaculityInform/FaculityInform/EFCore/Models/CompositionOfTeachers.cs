using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculityInform.EFCore.Models
{
    class CompositionOfTeachers
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Post {  get; set; }
        public Departments Department { get; set; }

        public override string ToString()
            => "";
    }
}
