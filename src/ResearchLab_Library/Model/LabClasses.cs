using ResearchLab_Library.Abstractions;
using ResearchLab_Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLab_Library.Model
{
    public class LabClasses:Entity<long>
    {
        public string ClassName { get; set; }
        public string Description { get; set; }
        public Member Member { get; set; }
        public LabType LabType { get; set; }
        public DateTime YearTaught { get; set; }
       
    }
}
