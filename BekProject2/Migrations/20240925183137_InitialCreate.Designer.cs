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
    [Migration("20240925183137_InitialCreate")]
    partial class InitialCreate
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
