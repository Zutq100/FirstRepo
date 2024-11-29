using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationQualityInfoSystem.EFCore.Models
{
    public class QualityModel
    {
        public int Id { get; set; }
        public StudentsModel Student { get; set; }
        public DisciplinesModel Disciplines { get; set; }
        public DayOfWeekModel DayOfWeek { get; set; }
        public bool? IsEvaluated { get; set; }
        public bool? IsPresent { get; set; }
        public List<MainModel> Main { get; set; }
    }
}
