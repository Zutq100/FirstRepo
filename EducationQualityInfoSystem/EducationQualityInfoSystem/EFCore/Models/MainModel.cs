using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationQualityInfoSystem.EFCore.Models
{
    public class MainModel
    {
        public int Id { get; set; }
        public QualityModel Quality { get; set; }
        public StudentsModel Students { get; set; }
        public int EducationQuality { get; set; }
    }
}
