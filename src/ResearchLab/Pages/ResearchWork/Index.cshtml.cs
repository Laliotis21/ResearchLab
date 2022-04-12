#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResearchLab_Library;
using ResearchLab_Library.Model;

namespace ResearchLab.Pages.ResearchWork
{
    public class IndexModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public IndexModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        public IList<ResearchWorks> ResearchWorks { get;set; }

        public async Task OnGetAsync()
        {
            ResearchWorks = await _context.ResearchWorks.ToListAsync();
        }
    }
}
