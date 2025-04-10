using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubIS.Models
{
    public class FootballTeam
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Players Player { get; set; }
        public int TypeId { get; set; }
        public TypeTeam Team { get; set; }

        public override string ToString()
            => $"Футболист - {Player.FullName} | Позиция - {Player.Position}\n{Team.Type}";
    }
}
