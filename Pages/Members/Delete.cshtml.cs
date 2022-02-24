﻿#nullable disable
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

namespace ResearchLab.Pages.Members
{
    public class DeleteModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public DeleteModel(ResearchLab_Library.LabDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Member = await _context.Members.Include(x => x.Category).FirstOrDefaultAsync(m => m.Id == id);

            if (Member == null)
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

            Member = await _context.Members.FindAsync(id);

            if (Member != null)
            {
                var parameters = new[] {
                new SqlParameter("@Id", Member.Id) };
                _context.Database.ExecuteSqlRaw("exec dbo.sp_DeleteMember @Id",parameters);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
