using ResearchLab_Library.Abstractions;
using ResearchLab_Library.Enums;
using ResearchLab_Library.Joins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLab_Library.Model
{
    public class Publication:Entity<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Published { get; set; }

        public PublicationType PublicationType { get; set; }

        public List<MembersPublications>? MembersPublications { get; set; }
        = new List<MembersPublications>();
    }
}
