using ResearchLab_Library.Abstractions;
using ResearchLab_Library.Joins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLab_Library.Model
{
    public class Member : Entity<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Uri WebPage { get; set; }
        public string Email { get; set; }
        public string Cv { get; set; } 
        public Category Category { get; set; }
        public List<MembersPublications>? MembersPublications { get; set; }
        = new List<MembersPublications>();
     }
}
