using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResearchLab_Library.Model;
using Microsoft.Extensions.Configuration;


namespace ResearchLab.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly ResearchLab_Library.LabDbContext _context;

        public IndexModel(ResearchLab_Library.LabDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        private readonly IConfiguration Configuration;

        //public IndexModel(LabDbContext context, IConfiguration configuration)
        //{
        //    _context = context;
        //    Configuration = configuration;
        //}

        public string CurrentFilter { get; set; }

        public PaginatedList<Member> Members { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            CurrentFilter = searchString;
            IQueryable<Member> studentsIQ = _context.Members.Include(x => x.Category)
                .OrderBy(x => x.Category)
                .ThenBy(x => x.LastName);
            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.LastName.Contains(searchString)
                                      || s.FirstName.Contains(searchString));
            }
            //Members = 

            var pageSize = Configuration.GetValue("PageSize", 100);
            Members = await PaginatedList<Member>.CreateAsync(
                studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
