#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResearchLab_Library;
using ResearchLab_Library.Model;

namespace ResearchLab.Pages.Announcement
{
    public class CreateModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public CreateModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Announcements Announcements { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Announcements.Add(Announcements);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
