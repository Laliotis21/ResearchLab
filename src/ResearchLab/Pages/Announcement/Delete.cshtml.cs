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

namespace ResearchLab.Pages.Announcement
{
    public class DeleteModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public DeleteModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Announcements Announcements { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Announcements = await _context.Announcements.FirstOrDefaultAsync(m => m.Id == id);

            if (Announcements == null)
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

            Announcements = await _context.Announcements.FindAsync(id);

            if (Announcements != null)
            {
                _context.Announcements.Remove(Announcements);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
