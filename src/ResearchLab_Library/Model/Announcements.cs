using ResearchLab_Library.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLab_Library.Model
{
    public class Announcements : Entity<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Member Member { get; set; }
        public DateTime Published { get; set; }
    }
}
