﻿// <auto-generated />
using System;
using HireMeAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HireMeAPI.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241022103914_AddingJobPostingsApplications")]
    partial class AddingJobPostingsApplications
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HireMeAPI.DAL.Entities.Application", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobPostingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "JobPostingId");

                    b.HasIndex("JobPostingId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.Experience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ComanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("StartedFrom")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("WorkedUntill")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.ExperienceWorkFields", b =>
                {
                    b.Property<Guid>("ExperienceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkFieldId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExperienceId", "WorkFieldId");

                    b.HasIndex("WorkFieldId");

                    b.ToTable("ExperienceWorkFields");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.JobPosting", b =>
                {
                    b.Property<Guid>("JobPostingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JobDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobPostingId");

                    b.HasIndex("CreatorId");

                    b.ToTable("jobPostings");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.Resume", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssignedRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.WorkFields", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkFields");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.Application", b =>
                {
                    b.HasOne("HireMeAPI.DAL.Entities.JobPosting", "JobPosting")
                        .WithMany("UserApplications")
                        .HasForeignKey("JobPostingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HireMeAPI.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobPosting");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.Experience", b =>
                {
                    b.HasOne("HireMeAPI.DAL.Entities.User", "_User")
                        .WithMany("Experiences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_User");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.ExperienceWorkFields", b =>
                {
                    b.HasOne("HireMeAPI.DAL.Entities.Experience", "Experience_")
                        .WithMany("WorkFields")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HireMeAPI.DAL.Entities.WorkFields", "WorkField")
                        .WithMany("ExperienceWorkFields")
                        .HasForeignKey("WorkFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Experience_");

                    b.Navigation("WorkField");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.JobPosting", b =>
                {
                    b.HasOne("HireMeAPI.DAL.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.Resume", b =>
                {
                    b.HasOne("HireMeAPI.DAL.Entities.User", "Applicant")
                        .WithMany("Resumes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.UserRole", b =>
                {
                    b.HasOne("HireMeAPI.DAL.Entities.Role", "Role_")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HireMeAPI.DAL.Entities.User", "User_")
                        .WithMany("userRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role_");

                    b.Navigation("User_");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.Experience", b =>
                {
                    b.Navigation("WorkFields");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.JobPosting", b =>
                {
                    b.Navigation("UserApplications");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.User", b =>
                {
                    b.Navigation("Experiences");

                    b.Navigation("Resumes");

                    b.Navigation("userRoles");
                });

            modelBuilder.Entity("HireMeAPI.DAL.Entities.WorkFields", b =>
                {
                    b.Navigation("ExperienceWorkFields");
                });
#pragma warning restore 612, 618
        }
    }
}
