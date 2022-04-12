#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ResearchLab_Library.Model;
using ResearchLab_Library.Views;

namespace ResearchLab.Pages.Reports
{
    public class ResearchProjectByYearModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public ResearchProjectByYearModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        public IList<ResearchWorks> ResearchWorks { get;set; }
        public IList<ResearchWorksByYear> ResearchWorksByYear { get; set; } = new List<ResearchWorksByYear>();
        public long SelectedMemberId { get; set; }
        public SelectList AvailableMembers { get; set; }
        public async Task OnGetAsync(long Names, string year, int? pageIndex)
        {
            AvailableMembers = new SelectList(await _context.Members.ToListAsync(), nameof(Member.Id), nameof(Member.FirstName), SelectedMemberId);

            if (Names == 0 || string.IsNullOrWhiteSpace(year) || !int.TryParse(year, out int result))
            {
                return;
            }

            var parameters = new[] {
                new SqlParameter("@Id" , Names ),
                new SqlParameter("@ProjectYearPublished" , result)};
            
            
              ResearchWorksByYear = await _context.ResearchWorksByYear.FromSqlRaw("exec dbo.ResearchWorksByYears @Id, @ProjectYearPublished", parameters).ToListAsync();
        }
    }
}
