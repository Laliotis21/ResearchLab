using ResearchLab_Library.Abstractions;
using ResearchLab_Library.Joins;


namespace ResearchLab_Library.Views
{
    public class JournalPublication : Entity<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Published { get; set; }
    }
}

