﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThundersTrailEF.Data;

#nullable disable

namespace ThundersTrailEF.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ThundersTrailEF.Models.Office", b =>
                {
                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfficeId"));

                    b.Property<string>("OfficeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfficeId");

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            OfficeId = 1,
                            OfficeName = "IT"
                        },
                        new
                        {
                            OfficeId = 2,
                            OfficeName = "HR"
                        },
                        new
                        {
                            OfficeId = 3,
                            OfficeName = "Cloud"
                        },
                        new
                        {
                            OfficeId = 4,
                            OfficeName = "Compliance"
                        });
                });

            modelBuilder.Entity("ThundersTrailEF.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 1, 5, 16, 5, 30, 746, DateTimeKind.Local).AddTicks(1260));

                    b.Property<int?>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int?>("Office")
                        .HasColumnType("int");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });
        }
    }
}
