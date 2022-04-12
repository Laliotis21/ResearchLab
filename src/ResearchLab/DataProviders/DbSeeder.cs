using Bogus;
using ResearchLab_Library.Enums;
using ResearchLab_Library.Model;

namespace ResearchLab.DataProviders;

public static class DbSeeder
{
   
    public static Faker<Member> MemberProvider { get; }
    = new Faker<Member>()
        .RuleFor(x => x.FirstName, f => f.Person.FirstName)
        .RuleFor(x => x.LastName, f => f.Person.LastName)
        .RuleFor(x => x.Email, f => f.Person.Email)
        .RuleFor(x => x.Cv, f => f.Name.JobDescriptor())
        .RuleFor(x => x.WebPage, f => new Uri($"https://{f.Person.Website}"));


    public static Faker<Publication> PublicationProvider { get; }
    = new Faker<Publication>("en")
        .RuleFor(x => x.Title, f => f.WaffleTitle())
        .RuleFor(x => x.Description, f => f.WaffleText(paragraphs: 1))
        .RuleFor(x => x.Published, f => f.Date.Past(3))
        .RuleFor(x => x.PublicationType, f => f.PickRandom<PublicationType>());

    public static Faker<LabClasses> LabClassesProvider { get; }
= new Faker<LabClasses>("en")
    .RuleFor(x => x.ClassName, f => f.WaffleTitle())
    .RuleFor(x => x.Description, f => f.WaffleText(paragraphs: 1))
    .RuleFor(x => x.LabType, f => f.PickRandom<LabType>())
    .RuleFor(x => x.YearTaught, f => f.Date.Past(3))
    .RuleFor(x => x.Member, f => f.PickRandom<Member>());


    public static Faker<Announcements> AnnouncementsProvider { get; }
= new Faker<Announcements>("en")
    .RuleFor(x => x.Title, f => f.WaffleTitle())
    .RuleFor(x => x.Description, f => f.WaffleText(paragraphs: 1))
    .RuleFor(x => x.Published, f => f.Date.Past(3));

    public static Faker<ResearchWorks> ResearchWorksProvider { get; }
= new Faker<ResearchWorks>("en")
   .RuleFor(x => x.Name, f => f.WaffleTitle())
   .RuleFor(x => x.Description, f => f.WaffleText(paragraphs: 1))
   .RuleFor(x => x.ProjectYearStart, f => f.Date.Past(3))
   .RuleFor(x => x.ProjectYearPublished, f => f.Date.Past(3));









}
