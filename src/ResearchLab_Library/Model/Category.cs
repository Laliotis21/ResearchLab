using ResearchLab_Library.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLab_Library.Model
{

    //Κατηγορία ερευνητη εργαστηρίου π.χ ΔΕΠ/Ερευνητες
    public class Category : Entity<long>
    {
        public string CategoryName { get; set; }

        public List<Member>? Members { get; set; }
        = new List<Member>();
    }
}
