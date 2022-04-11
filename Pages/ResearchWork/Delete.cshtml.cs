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
    public class DeleteModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public DeleteModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ResearchWorks ResearchWorks { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ResearchWorks = await _context.ResearchWorks.FirstOrDefaultAsync(m => m.Id == id);

            if (ResearchWorks == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ResearchWorks = await _context.ResearchWorks.FindAsync(id);

            if (ResearchWorks != null)
            {
                _context.ResearchWorks.Remove(ResearchWorks);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
