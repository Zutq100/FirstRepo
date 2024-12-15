using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculityInform.EFCore.Models
{
    public class Groups
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public int DirectionsId { get; set; }
        public Directions Directions {get; set;}
        public List<Students> Students {get; set;}

        public override string ToString()
            =>$"Название группы - {Title}\n" + (Directions == null ? "Направление отсутствует" : $"Название направления - {Directions.Title}\nКод направления - {Directions.GroupCode}\nПрофиль - {Directions.Profile}");
    }
}
