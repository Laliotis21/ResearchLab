#nullable disable
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ResearchLab_Library;
using ResearchLab_Library.Joins;
using ResearchLab_Library.Model;
using ResearchLab_Library.Views;

namespace ResearchLab.Pages.Reports
{
    public class PublicationByYearModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public PublicationByYearModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }
        private LabDbContext db = new LabDbContext();

        public string CurrentFilter { get; set; }

        public IList<Publication> Publication { get; set; }

        public IList<MemberPublishedByYear> MemberPublishedByYear { get; set; } = new List<MemberPublishedByYear>();
        public long SelectedMemberId { get; set; }
        public SelectList AvailableMembers { get; set; }
        public async Task OnGetAsync(long Names, string year, int? pageIndex)
        {

            AvailableMembers = new SelectList(await _context.Members.ToListAsync(), nameof(Member.Id), nameof(Member.FirstName), SelectedMemberId);

            if (Names == 0 || string.IsNullOrWhiteSpace(year) || !int.TryParse(year, out int result))
            {
                return;
            }
         
                var parameters2 = new[] {
                new SqlParameter("@Id" , Names ),
                new SqlParameter("@Published" , result)};
                MemberPublishedByYear = await _context.MemberPublishedByYears.FromSqlRaw("exec dbo.MemberPublishedByYear @Id, @Published", parameters2).ToListAsync();
            

               
            
            
            

        }
        
    }
}
