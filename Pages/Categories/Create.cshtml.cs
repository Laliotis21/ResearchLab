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
    public class CreateModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public CreateModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var parameters = new[] {
                new SqlParameter("@CategoryName", Category.CategoryName),
               
            };
            var rowsAffected = 0;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                rowsAffected = _context.Database.ExecuteSqlRaw("exec dbo.InsertNewCategoryName @CategoryName", parameters);
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
