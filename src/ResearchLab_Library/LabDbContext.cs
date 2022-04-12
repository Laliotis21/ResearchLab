using Microsoft.EntityFrameworkCore;
using ResearchLab_Library.Enums;
using ResearchLab_Library.Joins;
using ResearchLab_Library.Model;
using ResearchLab_Library.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLab_Library
{
    public class LabDbContext:DbContext
    {
        public LabDbContext()
        {
        }

        public LabDbContext(DbContextOptions<LabDbContext> options) 
            : base(options) 
        { 
        
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Publication> Publications { get; set; }
        
        public DbSet<MembersPublications> MembersPublications { get; set; }

        public DbSet<LabClasses> LabClasses { get; set; }
        public DbSet<ResearchWorks> ResearchWorks { get; set; }
        public DbSet<Announcements> Announcements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LabClassesByYear> LabClassesByYear { get; set; }
        public DbSet<ResearchWorksByYear> ResearchWorksByYear { get; set; }
        public DbSet<JournalPublication> JournalPublications { get; set;}
        public DbSet<MemberPublishedByYear> MemberPublishedByYears { get; set;}

        public DbSet<PublicationsByMember> PublicationsByMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q11K7TD\\SQLEXPRESS;Initial Catalog=ResearchLab;Integrated Security=SSPI;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PublicationsByMember>(e =>
            {
                e.HasNoKey();
                e.Property(e => e.PublicationType)
                .HasConversion<string>();
            });
            modelBuilder.Entity<MemberPublishedByYear>(e =>
            {
                e.HasNoKey();
                e.Property(e => e.PublicationType)
                .HasConversion<string>();
            });
            modelBuilder.Entity<LabClassesByYear>(e =>
            {
                e.HasNoKey();
                
            });
            modelBuilder.Entity<ResearchWorksByYear>(e =>
            {
                e.HasNoKey();

            });
            modelBuilder.Entity<JournalPublication>(e =>
            {
                e.ToView("JournalPublications");
            });
            
            modelBuilder.Entity<Member>(e => {
                e.Property(e => e.FirstName).IsRequired().HasMaxLength(255);

                e.HasOne(e => e.Category)
                .WithMany(e=>e.Members)
                .OnDelete(DeleteBehavior.Restrict); //εδω πρέπει να το αλλαξω
            } );
            modelBuilder.Entity<MembersPublications>(e => {
                e.HasOne(e => e.Member)
                .WithMany(e => e.MembersPublications)
                .HasForeignKey("MemberID")
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.Publication)
               .WithMany(e => e.MembersPublications)
               .HasForeignKey("PublicationID")
               .OnDelete(DeleteBehavior.Restrict);

                e.HasKey(new[] { "MemberID", "PublicationID" });
            });
           
            modelBuilder.Entity<Publication>(e =>
            {
                e.Property(e => e.PublicationType)
                .HasConversion<string>();

                e.HasIndex(e => e.PublicationType);
            });
            modelBuilder.Entity<LabClasses>(e =>
            {
                e.Property(e => e.LabType)
                .HasConversion<string>();

                e.HasIndex(e => e.LabType);
                
            });
            modelBuilder.Entity<Announcements>(e =>
            {
                e.Property(e => e.Title).IsRequired().HasMaxLength(255);

            });
            modelBuilder.Entity<ResearchWorks>(e =>
            {
                e.Property(e => e.Name).IsRequired().HasMaxLength(255);


            });
        }
    }
}
