#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ResearchLab_Library;
using ResearchLab_Library.Model;

namespace ResearchLab.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public DeleteModel(ResearchLab_Library.LabDbContext context)
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.FindAsync(id);

            if (Category != null)
            {
                var parameters = new[] {
                new SqlParameter("@id", Category.Id),
            };
                _context.Database.ExecuteSqlRaw("exec dbo.sp_DeleteCategories @id", parameters);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
