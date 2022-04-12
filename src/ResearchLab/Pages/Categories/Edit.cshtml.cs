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

namespace ResearchLab.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public EditModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (Category == null)
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
                new SqlParameter("@CategoryName", Category.CategoryName),
                new SqlParameter("@id", Category.Id),
            };
            var rowsAffected = 0;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                rowsAffected = _context.Database.ExecuteSqlRaw("exec dbo.UpdateCategoryName @CategoryName,@id ", parameters);
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
