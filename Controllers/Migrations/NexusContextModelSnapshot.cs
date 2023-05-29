﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nexus.Data;

#nullable disable

namespace Controller.Migrations
{
    [DbContext(typeof(NexusContext))]
    partial class NexusContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Controller.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 488, DateTimeKind.Local).AddTicks(60),
                            EmployeeId = 1,
                            Password = "50C2C9A046D2EACA5181ACE70C24DCCC57954C8368F90B6FEC4D24CF1C1ECEA7E724F46D459A459C4F9B668DD2DA7F7C42E1BF43E0551A3F845F5DE83B8AD192",
                            Salt = new byte[] { 199, 225, 157, 13, 34, 106, 174, 94, 95, 47, 127, 174, 102, 2, 255, 211, 160, 40, 21, 167, 12, 171, 140, 92, 205, 71, 12, 180, 36, 213, 56, 118, 216, 64, 221, 46, 72, 88, 189, 145, 50, 10, 251, 79, 254, 163, 178, 167, 166, 113, 15, 113, 68, 165, 178, 168, 56, 120, 220, 148, 122, 126, 134, 246 },
                            UpdatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 488, DateTimeKind.Local).AddTicks(120),
                            Username = "Joseph.Huntley"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 727, DateTimeKind.Local).AddTicks(870),
                            EmployeeId = 2,
                            Password = "EE85A9BB8C831235B1254239477244D475480F3179BA8831B94A1D4509EBEAB4A7E3372E47E6CA225B214AA2AB863664552A39C427DC3E8557E96F50D3F4A012",
                            Salt = new byte[] { 133, 179, 232, 164, 219, 140, 103, 45, 242, 129, 104, 59, 143, 88, 66, 194, 37, 78, 130, 79, 52, 141, 44, 233, 121, 249, 172, 90, 16, 198, 67, 202, 206, 239, 5, 206, 2, 12, 224, 155, 199, 71, 243, 235, 100, 220, 149, 244, 154, 60, 104, 34, 125, 131, 104, 20, 183, 250, 209, 197, 194, 182, 3, 36 },
                            UpdatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 727, DateTimeKind.Local).AddTicks(920),
                            Username = "John.Doe"
                        });
                });

            modelBuilder.Entity("Controller.Models.VacationTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<double>("HolidayAvail")
                        .HasColumnType("float");

                    b.Property<double>("HolidayAvailable")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("VacationAvail")
                        .HasColumnType("float");

                    b.Property<double>("VacationAvailable")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("VacationTime");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3450),
                            EmployeeId = 1,
                            HolidayAvail = 6.0,
                            HolidayAvailable = 16.0,
                            UpdatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3460),
                            VacationAvail = 20.0,
                            VacationAvailable = 100.0
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3460),
                            EmployeeId = 2,
                            HolidayAvail = 8.0,
                            HolidayAvailable = 12.0,
                            UpdatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3470),
                            VacationAvail = 16.0,
                            VacationAvailable = 104.0
                        });
                });

            modelBuilder.Entity("Nexus.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PayRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Terminated")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TerminatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "One Apple Parkway",
                            City = "Cupertino",
                            Country = "United States",
                            CreatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(2990),
                            Email = "Joseph.Huntley@outlook.com",
                            FName = "Joseph",
                            LName = "Huntley",
                            PayRate = 32.50m,
                            Phone = "(810) 555-1100",
                            PostalCode = "123456",
                            Region = "California",
                            Terminated = false,
                            TerminatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = ".Net Developer",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Address = "One Apple Parkway",
                            City = "Cupertino",
                            Country = "United States",
                            CreatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3040),
                            Email = "John.Doe@outlook.com",
                            FName = "John",
                            LName = "Doe",
                            PayRate = 27.56m,
                            Phone = "(810) 555-1100",
                            PostalCode = "123456",
                            Region = "California",
                            Terminated = false,
                            TerminatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Designer",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Nexus.Models.PayStub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Deductions401K")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("FICATaxes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FederalTaxes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Gross")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("HoursWorked")
                        .HasColumnType("float");

                    b.Property<decimal>("MedicareTaxes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Net")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StateTaxes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("Week")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("PayStubs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3300),
                            Date = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deductions401K = 17.20m,
                            EmployeeId = 1,
                            FICATaxes = 106.64m,
                            FederalTaxes = 134.02m,
                            Gross = 17.20m,
                            HoursWorked = 80.0,
                            MedicareTaxes = 24.94m,
                            Net = 1385.27m,
                            StateTaxes = 55.00m,
                            UpdatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3310),
                            Week = (short)4
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3320),
                            Date = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deductions401K = 17.20m,
                            EmployeeId = 1,
                            FICATaxes = 106.64m,
                            FederalTaxes = 134.02m,
                            Gross = 17.20m,
                            HoursWorked = 80.0,
                            MedicareTaxes = 24.94m,
                            Net = 1385.27m,
                            StateTaxes = 55.00m,
                            UpdatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3330),
                            Week = (short)4
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3380),
                            Date = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deductions401K = 17.20m,
                            EmployeeId = 2,
                            FICATaxes = 106.64m,
                            FederalTaxes = 134.02m,
                            Gross = 17.20m,
                            HoursWorked = 80.0,
                            MedicareTaxes = 24.94m,
                            Net = 1385.27m,
                            StateTaxes = 55.00m,
                            UpdatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3390),
                            Week = (short)4
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3410),
                            Date = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deductions401K = 17.20m,
                            EmployeeId = 2,
                            FICATaxes = 106.64m,
                            FederalTaxes = 134.02m,
                            Gross = 17.20m,
                            HoursWorked = 80.0,
                            MedicareTaxes = 24.94m,
                            Net = 1385.27m,
                            StateTaxes = 55.00m,
                            UpdatedDate = new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3410),
                            Week = (short)4
                        });
                });

            modelBuilder.Entity("Controller.Models.User", b =>
                {
                    b.HasOne("Nexus.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Controller.Models.VacationTime", b =>
                {
                    b.HasOne("Nexus.Models.Employee", "employee")
                        .WithOne("Vacation")
                        .HasForeignKey("Controller.Models.VacationTime", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("Nexus.Models.PayStub", b =>
                {
                    b.HasOne("Nexus.Models.Employee", "employee")
                        .WithMany("PayStubs")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("Nexus.Models.Employee", b =>
                {
                    b.Navigation("PayStubs");

                    b.Navigation("Vacation");
                });
#pragma warning restore 612, 618
        }
    }
}
