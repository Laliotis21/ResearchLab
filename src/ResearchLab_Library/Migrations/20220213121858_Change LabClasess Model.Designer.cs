﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResearchLab_Library;

#nullable disable

namespace ResearchLab_Library.Migrations
{
    [DbContext(typeof(LabDbContext))]
    [Migration("20220213121858_Change LabClasess Model")]
    partial class ChangeLabClasessModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ResearchLab_Library.Joins.MembersPublications", b =>
                {
                    b.Property<long>("MemberID")
                        .HasColumnType("bigint");

                    b.Property<long>("PublicationID")
                        .HasColumnType("bigint");

                    b.HasKey("MemberID", "PublicationID");

                    b.HasIndex("PublicationID");

                    b.ToTable("MembersPublications");
                });

            modelBuilder.Entity("ResearchLab_Library.Model.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ResearchLab_Library.Model.LabClasses", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LabType")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LabType");

                    b.HasIndex("MemberId");

                    b.ToTable("LabClasses");
                });

            modelBuilder.Entity("ResearchLab_Library.Model.Member", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Cv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebPage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("ResearchLab_Library.Model.Publication", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Published")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PublicationType");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("ResearchLab_Library.Model.ResearchWorks", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Iscompleted")
                        .HasColumnType("bit");

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("ResearchWorks");
                });

            modelBuilder.Entity("ResearchLab_Library.Views.JournalPublication", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Published")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToView("JournalPublications");
                });

            modelBuilder.Entity("ResearchLab_Library.Views.MemberPublishedByYear", b =>
                {
                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Published")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("MemberPublishedByYears");
                });

            modelBuilder.Entity("ResearchLab_Library.Views.PublicationsByMember", b =>
                {
                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SUM")
                        .HasColumnType("int");

                    b.ToTable("PublicationsByMembers");
                });

            modelBuilder.Entity("ResearchLab_Library.Joins.MembersPublications", b =>
                {
                    b.HasOne("ResearchLab_Library.Model.Member", "Member")
                        .WithMany("MembersPublications")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ResearchLab_Library.Model.Publication", "Publication")
                        .WithMany("MembersPublications")
                        .HasForeignKey("PublicationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Publication");
                });

            modelBuilder.Entity("ResearchLab_Library.Model.LabClasses", b =>
                {
                    b.HasOne("ResearchLab_Library.Model.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("ResearchLab_Library.Model.Member", b =>
                {
                    b.HasOne("ResearchLab_Library.Model.Category", "Category")
                        .WithMany("Members")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ResearchLab_Library.Model.ResearchWorks", b =>
                {
                    b.HasOne("ResearchLab_Library.Model.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("ResearchLab_Library.Model.Category", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("ResearchLab_Library.Model.Member", b =>
                {
                    b.Navigation("MembersPublications");
                });

            modelBuilder.Entity("ResearchLab_Library.Model.Publication", b =>
                {
                    b.Navigation("MembersPublications");
                });
#pragma warning restore 612, 618
        }
    }
}
