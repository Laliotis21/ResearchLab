#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ResearchLab_Library;
using ResearchLab_Library.Model;
using ResearchLab_Library.Views;

namespace ResearchLab.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public DetailsModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        public Member Member { get; set; }

        public List<Publication> Publications { get; set; }
        public List<PublicationsByMember> PublicationsByMembers { get; set; }
        public SelectList ValidYears { get; set; }
        public int ValidYear    { get; set; }
        public SelectList Years { get; set; }
        public SelectList PublicationYears { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            Member = await _context.Members
                .Include(x => x.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Member == null)
            {
                return NotFound();
            }
            var parameters = new[] {
                new SqlParameter("@Id", Member.Id) };
            Publications = await _context.Publications.FromSqlRaw("exec dbo.ResearchLab_FindPublications @Id", parameters).ToListAsync();
            DateTime date = DateTime.Now;
            //
            //Years = new SelectList(Publications.Select(x => x.Published.Year).Distinct().ToList(), nameof(Publication.Published), nameof(Publication.Published), ValidYear);
            //Years = new SelectList(await _context.Publications.Where(p => p.Published > date).ToListAsync(), nameof(Publication.Id), nameof(Publication.Published), ValidYear);
            var parameters2 = new[] {
                new SqlParameter("@MemberID" , Member.Id ) };
            PublicationsByMembers = await _context.PublicationsByMembers.FromSqlRaw("exec dbo.CountPublicationByPublicationType @MemberID", parameters2).ToListAsync();

            //PublicationYears = new SelectList(await _context.Publications.ToListAsync(), nameof(Publication.Id), nameof(Publication.Published), Member.MembersPublications);
            return Page();
        }
    }
}

