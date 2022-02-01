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

namespace ResearchLab.Pages.Reports
{
    public class LabclassesByYearModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public LabclassesByYearModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }
        
        public IList<LabClasses> LabClasses { get;set; }
        public long SelectedMemberId { get; set; }
        public IList<LabClassesByYear> LabClassesByYear { get; set; } = new List<LabClassesByYear>();
        public SelectList AvailableMembers { get; set; }
        public async Task OnGetAsync(long MemberName, string years)
        {
            AvailableMembers = new SelectList(await _context.Members.ToListAsync(), nameof(Member.Id), nameof(Member.FirstName), SelectedMemberId); 

            if(MemberName == 0 || string.IsNullOrWhiteSpace(years) || !int.TryParse(years, out int result))
            {
                return;
            }

            var parameters = new[] {
                new SqlParameter("@Id" , MemberName ),
                new SqlParameter("@YearTaught" , result)};
            LabClassesByYear = await _context.LabClassesByYear.FromSqlRaw("exec dbo.LabClassesByYeara @Id, @YearTaught", parameters).ToListAsync();

        }
    }


    
}
