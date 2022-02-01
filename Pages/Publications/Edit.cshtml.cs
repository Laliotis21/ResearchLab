#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResearchLab_Library;
using ResearchLab_Library.Model;

namespace ResearchLab.Pages.Publications
{
    public class EditModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public EditModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Publication Publication { get; set; } 
        public long SelectedMemberId { get; set; }
        public SelectList AvailableMembers { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AvailableMembers = new SelectList(await _context.Members.ToListAsync(), nameof(Member.Id), nameof(Member.FirstName), SelectedMemberId);
            
            Publication = await _context.Publications.SingleOrDefaultAsync(m => m.Id == id);

            if (Publication == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Publication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationExists(Publication.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PublicationExists(long id)
        {
            return _context.Publications.Any(e => e.Id == id);
        }
    }
}
