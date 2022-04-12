using ResearchLab_Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLab_Library.Views
{
    public class PublicationsByMember
    {
        public string FullName { get; set; }
        public PublicationType PublicationType { get; set; }
        public int SUM { get; set; }
    }
}
