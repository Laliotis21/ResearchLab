using ResearchLab_Library.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLab_Library.Model
{
    public class ResearchWorks:Entity<long>

    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ProjectYearStart { get; set; }
        public DateTime ProjectYearPublished { get; set; }
        public Member Member { get; set; }
      

    }
}
