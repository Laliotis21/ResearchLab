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
using ResearchLab_Library.Joins;
using ResearchLab_Library.Model;

namespace ResearchLab.Pages.Publications
{
    public class DetailsModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public DetailsModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }
        public long SelectedMemberId { get; set; }
        public SelectList AvailableMembers { get; set; }
        public Publication Publication { get; set; }
        public MembersPublications MemberPublications { get; set; } 
        public IList<Publication> Publications { get; set; } = new List<Publication>();

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Publication = await _context.Publications.Include(x => x.MembersPublications).ThenInclude(x => x.Member).SingleOrDefaultAsync(m => m.Id == id);
            //MemberPublications = await _context.MembersPublications.ToListAsync();
            if (Publication == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
