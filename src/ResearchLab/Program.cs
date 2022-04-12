using Microsoft.EntityFrameworkCore;
using ResearchLab.DataProviders;
using ResearchLab_Library;
using ResearchLab_Library.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<LabDbContext>((sp, optionsAction) => optionsAction.UseSqlServer(sp.GetRequiredService<IConfiguration>().GetConnectionString("MyDb")).EnableSensitiveDataLogging());
var app = builder.Build();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var ctx = scope.ServiceProvider
        .GetRequiredService<LabDbContext>();

    
    await SeedDatabase(ctx);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

async Task SeedDatabase(LabDbContext context)
{
    var random = new Random();
    await context.Database.MigrateAsync();
    if (await context.Categories.AnyAsync())
    {
        return;
    }
    var categories = new List<Category>
    
    {
        new Category{CategoryName="ΔΕΠ"},
        new Category{CategoryName="Ερευνητές"}, 
        new Category{CategoryName="Προπτυχιακοί"},
    };
    context.Categories.AddRange(categories);
    var sample = DbSeeder.MemberProvider.Generate(100);
    var users = sample.Select(x =>
    {
        x.Category = categories[random.Next(0, categories.Count)];
        return x;
    })
        .ToList();
    context.Members.AddRange(users);
    var sample1 = DbSeeder.PublicationProvider.Generate(100).ToList();
    context.Publications.AddRange(sample1);
    await context.SaveChangesAsync();
    foreach (var publication in sample1) 
    { 
        for (int i = 0; i < random.Next(1,5); i++)
        {
            
            var member = users
                .Where(x => publication.MembersPublications.Select(x => x.Member.Id).All(y => y != x.Id))
                .ElementAt(random.Next(0, users.Count -publication.MembersPublications.Count));
            publication.MembersPublications.Add(new ResearchLab_Library.Joins.MembersPublications { Member = member, Publication = publication });
        }
    
    }



    
  
    var sample2 = DbSeeder.LabClassesProvider.RuleFor( x => x.Member , f => f.PickRandom(users)).Generate(100).ToList();
    context.LabClasses.AddRange(sample2);

    var sample3 = DbSeeder.ResearchWorksProvider.RuleFor(x => x.Member, f => f.PickRandom(users)).Generate(100).ToList();
    context.ResearchWorks.AddRange(sample3);

    var sample4 = DbSeeder.AnnouncementsProvider.RuleFor(x => x.Member, f => f.PickRandom(users)).Generate(100).ToList();
    context.Announcements.AddRange(sample4);

    await context.SaveChangesAsync();



}
