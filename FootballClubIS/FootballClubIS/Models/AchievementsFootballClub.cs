using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubIS.Models
{
    public class AchievementsFootballClub
    {
        public int Id { get; set; }
        public int  PlayerId { get; set; }
        public Players Player { get; set; }
        public string Achievement { get; set; }
        public override string ToString()
            => (Player == null ? "Футбольный клуб" : $"Футболист - {Player.FullName}\nДостижение - {Achievement}");

    }
}
