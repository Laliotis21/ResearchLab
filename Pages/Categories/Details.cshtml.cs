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
    public class DetailsModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public DetailsModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }
        //public List<Category> Categories { get; set; }
        public Category Category { get; set; }

        public long SelectedMemberId { get; set; }
        public IList<Category> Categories { get; set; } = new List<Category>();
        public SelectList AvailableMembers { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AvailableMembers = new SelectList(await _context.Members.ToListAsync(), nameof(Member.Id), nameof(Member.FirstName), SelectedMemberId);
            Category = await _context.Categories.Include(m => m.Members).FirstOrDefaultAsync(m => m.Id == id);
            var parameters2 = new[] {
                new SqlParameter("@CategoryName" , Category.CategoryName) };
            Categories = await _context.Categories.FromSqlRaw("exec dbo.sp_GetMembersByCategoryName @CategoryName", parameters2).ToListAsync();
            if (Category == null)
            {
                return NotFound();
            }
            return Page();
            
            
        }
    }
}
