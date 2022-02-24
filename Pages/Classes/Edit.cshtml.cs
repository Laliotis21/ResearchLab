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

namespace ResearchLab.Pages.Classes
{
    public class EditModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public EditModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LabClasses LabClasses { get; set; }
        public long SelectedMemberId { get; set; }
        public IList<LabClasses> LabClassess { get; set; } = new List<LabClasses>();
        public SelectList AvailableMembers { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AvailableMembers = new SelectList(await _context.Members.ToListAsync(), nameof(Member.Id), nameof(Member.FirstName), SelectedMemberId);
            LabClasses = await _context.LabClasses.Include(m => m.Member).FirstOrDefaultAsync(m => m.Id == id);

            if (LabClasses == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
           

              var parameters = new[] {
                new SqlParameter("@State","Update"),
                new SqlParameter("@Id", LabClasses.Id),
                new SqlParameter("@ClassName", LabClasses.ClassName),
                new SqlParameter("@Description", LabClasses.Description),
                new SqlParameter("@memberid", LabClasses.Member.FirstName),
                new SqlParameter("@Labtype", LabClasses.LabType),
                new SqlParameter("@YearTaught", LabClasses.YearTaught),

            };
            var rowsAffected = 0;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                rowsAffected = _context.Database.ExecuteSqlRaw("exec dbo.LabClassesQueries @State, @Id,@ClassName,@Description,@memberid,@Labtype,@YearTaught ", parameters);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;

            }
            if (rowsAffected == 0) { return Page(); }
            return RedirectToPage("./Index");
        }
        }
}
