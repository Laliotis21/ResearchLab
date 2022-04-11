using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ResearchLab_Library.Model;


namespace ResearchLab.Pages.Members
{
    public class EditModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public EditModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        // public Member Member { get; set; }
        public MemberEditDto Member { get; set; } = new MemberEditDto();
        public SelectList CategoriesOptions { get; set; }
        public long SelectedCategoryId { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            Member = (await _context.Members.Include(m => m.Category).ToListAsync())
            .Select(x => new MemberEditDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CategoryId = x.Category.Id,
                WebPage = x.WebPage,
                Cv  =   x.Cv,
                Email = x.Email,
            })
                .FirstOrDefault(m => m.Id == id);


            CategoriesOptions = new SelectList(await _context.Categories.ToListAsync(), nameof(Category.Id), nameof(Category.CategoryName), Member.CategoryId);

            if (Member == null)
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

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var parameters = new[] {
                new SqlParameter("@Id", Member.Id),
                new SqlParameter("@FirstName", Member.FirstName),
                new SqlParameter("@LastName", Member.LastName),
                new SqlParameter("@WebPage", Member.WebPage.AbsoluteUri),
                new SqlParameter("@email", Member.Email),
                new SqlParameter("@Cv", Member.Cv),
                new SqlParameter("@CategoryId", Member.CategoryId),
            };
            var rowsAffected = 0;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                rowsAffected = _context.Database.ExecuteSqlRaw("exec dbo.UpdateMemberDetails  @FirstName,@LastName, @Id, @WebPage,@email,@Cv,@CategoryId ", parameters);
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
    public class MemberEditDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Uri WebPage { get; set; }
        public string Email { get; set; }
        public string Cv { get; set; }

        public long CategoryId { get; set; }
    }

}
