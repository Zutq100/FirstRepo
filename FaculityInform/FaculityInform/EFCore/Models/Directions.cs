using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculityInform.EFCore.Models
{
    class Directions
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string GroupCode { get; set; }
        public string Profile { get; set; }
        public Departments Department { get; set; }
        public List<Groups> Groups { get; set; }

        public override string ToString()
            => "";
    }
}
