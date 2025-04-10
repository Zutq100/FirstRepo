using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubIS.Models
{
    public class Players
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Number {  get; set; }
        public string Position { get; set; }
        public FootballTeam Team { get; set; }
        public List<AchievementsFootballClub> Achievements {  get; set; }
        public override string ToString()
            => $"Футболист - \"{FullName}\" под номером {Number}\nПозиция - {Position}";
    }
}
