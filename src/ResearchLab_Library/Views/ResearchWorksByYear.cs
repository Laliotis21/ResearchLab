using ResearchLab_Library.Abstractions;
using ResearchLab_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLab_Library.Views
{
    public class ResearchWorksByYear
    {
        public string MemberName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ProjectYearPublished { get; set; }
    }
}
