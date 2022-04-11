using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ResearchLab_Library.Model;


namespace ResearchLab.Pages.Classes
{
    public class CreateModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public CreateModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }
        public long SelectedMemberId { get; set; }
        public IList<LabClasses> Classes { get; set; } = new List<LabClasses>();
        public SelectList AvailableMembers { get; set; }
        public async Task<IActionResult> OnGet()
        {
            AvailableMembers = new SelectList(await _context.Members.ToListAsync(), nameof(Member.Id), nameof(Member.FirstName), SelectedMemberId);
            return Page();
        }

       
        //public SelectList LabTypesOptions { get; set; }
        [BindProperty]
        public LabClasses LabClasses { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

        public async Task<IActionResult> OnPostAsync()
        {
     
            var parameters = new[] {
                new SqlParameter("@State", "Insert"),
                new SqlParameter("@Id", LabClasses.Id),
                new SqlParameter("@ClassName", LabClasses.ClassName),
                new SqlParameter("@Description", LabClasses.Description),
                new SqlParameter("@Memberid", LabClasses.Member.FirstName),
                new SqlParameter("@Labtype", LabClasses.LabType),
                new SqlParameter("@YearTaught", LabClasses.YearTaught),

            };
            var rowsAffected = 0;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
           
                rowsAffected = _context.Database.ExecuteSqlRaw("exec dbo.LabClassesQueries @State,@Id, @ClassName, @Description, @Memberid, @Labtype, @YearTaught", parameters);
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
