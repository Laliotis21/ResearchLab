using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ResearchLab_Library.Joins;
using ResearchLab_Library.Model;

namespace ResearchLab.Pages.Reports
{
    public class PublicationByCategoryModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;
        

        public PublicationByCategoryModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        public Member Member { get; set; }
        public Publication Publication { get; set; }   
        public IList<MembersPublications> MembersPublications { get;set; }

        public async Task OnGetAsync()
               
        {
            MembersPublications = await _context.MembersPublications
                .Include(x => x.Member).ToListAsync();

            var parameters = new[] {
                new SqlParameter("@MemberID", MembersPublications),
                };
            var Results = _context.Database.ExecuteSqlRaw("exec dbo.ResearchLab_FindPublications @MemberID ", parameters);

        }
    }
}
