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

namespace ResearchLab.Pages.Publications
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
        public Publication Publication { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var parameters = new[] {
                new SqlParameter("@State", "Insert"),
                new SqlParameter("@Id", Publication.Id),
                new SqlParameter("@Title", Publication.Title),
                new SqlParameter("@Description",Publication.Description),
                new SqlParameter("@Published", Publication.Published),
                new SqlParameter("@PublicationType", Publication.PublicationType)

            };
            var rowsAffected = 0;
            using var transaction = _context.Database.BeginTransaction();
            try
            {

                rowsAffected = _context.Database.ExecuteSqlRaw("exec dbo.sp_Publications @State, @Id, @Title, @Description, @Published, @PublicationType", parameters);
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
