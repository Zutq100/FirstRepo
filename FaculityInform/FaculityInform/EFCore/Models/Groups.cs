using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculityInform.EFCore.Models
{
    class Groups
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public Directions Directions {get; set;}
        public List<Students> Students {get; set;}

        public override string ToString()
            =>"";
    }
}
