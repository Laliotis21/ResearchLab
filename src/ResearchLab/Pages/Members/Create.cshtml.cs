using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ResearchLab_Library.Model;

namespace ResearchLab.Pages.Members
{
    public class CreateModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public CreateModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            CategoriesOptions = new SelectList(await _context.Categories.ToListAsync(), nameof(Category.Id), nameof(Category.CategoryName), Member.CategoryId);
            return Page();
        }

        [BindProperty]
        public MemberCreateDto Member { get; set; } = new MemberCreateDto();

        public SelectList CategoriesOptions { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var parameters = new[] {
                new SqlParameter("@FirstName", Member.FirstName),
                new SqlParameter("@LastName", Member.LastName),
                new SqlParameter("WebPage", Member.WebPage.AbsoluteUri),
                new SqlParameter("Email", Member.Email),
                new SqlParameter("CV", Member.Cv),
                new SqlParameter("CategoryID", Member.CategoryId),
            };
            var rowsAffected = 0;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                rowsAffected = _context.Database.ExecuteSqlRaw("exec dbo.InsertNew_MEMBER @FirstName, @LastName, @WebPage, @Email, @CV, @CategoryId", parameters);
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

    public class MemberCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Uri WebPage { get; set; }
        public string Email { get; set; }
        public string Cv { get; set; }

        public long CategoryId { get; set; }
    }
}
