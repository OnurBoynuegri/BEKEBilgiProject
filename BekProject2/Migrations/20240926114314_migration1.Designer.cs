﻿// <auto-generated />
using System;
using BekProject2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BekProject2.Migrations
{
    [DbContext(typeof(BekEbilgiDbContext))]
    [Migration("20240926114314_migration1")]
    partial class migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BekProject2.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            FirstName = "Semih",
                            LastName = "Kılıçsoy"
                        },
                        new
                        {
                            EmployeeId = 2,
                            FirstName = "Mert",
                            LastName = "Günok"
                        },
                        new
                        {
                            EmployeeId = 3,
                            FirstName = "Rafa",
                            LastName = "Silva"
                        },
                        new
                        {
                            EmployeeId = 4,
                            FirstName = "Ciro",
                            LastName = "Immobile"
                        },
                        new
                        {
                            EmployeeId = 5,
                            FirstName = "Gabriel",
                            LastName = "Paulista"
                        },
                        new
                        {
                            EmployeeId = 6,
                            FirstName = "Mustafa Erhan",
                            LastName = "Hekimoğlu"
                        });
                });

            modelBuilder.Entity("BekProject2.EmployeeJob", b =>
                {
                    b.Property<int>("EmployeeJobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeJobId"));

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeJobId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("JobId");

                    b.ToTable("EmployeeJobs");
                });

            modelBuilder.Entity("BekProject2.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            JobId = 1,
                            Difficulty = 1,
                            JobName = "Job 1"
                        },
                        new
                        {
                            JobId = 2,
                            Difficulty = 2,
                            JobName = "Job 2"
                        },
                        new
                        {
                            JobId = 3,
                            Difficulty = 3,
                            JobName = "Job 3"
                        },
                        new
                        {
                            JobId = 4,
                            Difficulty = 4,
                            JobName = "Job 4"
                        },
                        new
                        {
                            JobId = 5,
                            Difficulty = 5,
                            JobName = "Job 5"
                        },
                        new
                        {
                            JobId = 6,
                            Difficulty = 6,
                            JobName = "Job 6"
                        });
                });

            modelBuilder.Entity("BekProject2.EmployeeJob", b =>
                {
                    b.HasOne("BekProject2.Employee", "Employee")
                        .WithMany("EmployeeJobs")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BekProject2.Job", "Job")
                        .WithMany("EmployeeJobs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("BekProject2.Employee", b =>
                {
                    b.Navigation("EmployeeJobs");
                });

            modelBuilder.Entity("BekProject2.Job", b =>
                {
                    b.Navigation("EmployeeJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
