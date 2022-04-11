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

namespace ResearchLab.Pages.Classes
{
    public class DeleteModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public DeleteModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LabClasses LabClasses { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LabClasses = await _context.LabClasses.FirstOrDefaultAsync(m => m.Id == id);

            if (LabClasses == null)
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

            LabClasses = await _context.LabClasses.FindAsync(id);

            if (LabClasses != null)
            {
                var parameters = new[] {
                new SqlParameter("@State", "Delete"),
                new SqlParameter("@Id", LabClasses.Id) };
                _context.Database.ExecuteSqlRaw("exec dbo.LabClassesQueries @State ,@Id", parameters); 
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
