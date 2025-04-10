using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubIS.Models
{
   public class TypeTeam
    {
        public int Id { get; set; }
        public string Type {  get; set; }
        public List<FootballTeam> Team { get; set; }

        public override string ToString()
            => $"{Type}";
    }
}
