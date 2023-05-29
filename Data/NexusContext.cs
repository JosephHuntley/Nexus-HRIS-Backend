using System.Globalization;
using System.Security.Cryptography;
using Controller;
using Controller.Models;
using Microsoft.EntityFrameworkCore; // DbContext
using Nexus.Models;

namespace Nexus.Data;

public class NexusContext : DbContext
{
    private byte[] salt1 = RandomNumberGenerator.GetBytes(64);
    private byte[] salt2 = RandomNumberGenerator.GetBytes(64);

    public NexusContext()
    {
    }

    public NexusContext(DbContextOptions<NexusContext> contextOptions) : base(contextOptions)
    {
    }

    // The name will be the table name
    public DbSet<Employee> Employees { get; set; }
    public DbSet<PayStub> PayStubs { get; set; }
    public DbSet<VacationTime> VacationTime { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                FName = "Joseph",
                LName = "Huntley",
                Email = "Joseph.Huntley@outlook.com",
                Phone = "(810) 555-1100",
                PayRate = 32.50M,
                Title = ".Net Developer",
                Address = "One Apple Parkway",
                City = "Cupertino",
                Region = "California",
                Country = "United States",
                PostalCode = "123456",
                CreatedDate = DateTime.Now
            },
            new Employee
            {
                Id = 2,
                FName = "John",
                LName = "Doe",
                Email = "John.Doe@outlook.com",
                Phone = "(810) 555-1100",
                PayRate = 27.56M,
                Title = "Designer",
                Address = "One Apple Parkway",
                City = "Cupertino",
                Region = "California",
                Country = "United States",
                PostalCode = "123456",
                CreatedDate = DateTime.Now
            }
        );

        modelBuilder.Entity<PayStub>().HasData(
            new PayStub
            {
                Id = 1,
                HoursWorked = 80,
                Gross = 17.20M,
                Net = 1385.27M,
                FederalTaxes = 134.02M,
                FICATaxes = 106.64M,
                MedicareTaxes = 24.94M,
                StateTaxes = 55.00M,
                Deductions401K = 17.20M,
                Date = new DateTime(2023, 1, 23),
                Week = 4,
                EmployeeId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new PayStub
            {
                Id = 2,
                HoursWorked = 80,
                Gross = 17.20M,
                Net = 1385.27M,
                FederalTaxes = 134.02M,
                FICATaxes = 106.64M,
                MedicareTaxes = 24.94M,
                StateTaxes = 55.00M,
                Deductions401K = 17.20M,
                Date = new DateTime(2023, 1, 23),
                Week = 4,
                EmployeeId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new PayStub
            {
                Id = 3,
                HoursWorked = 80,
                Gross = 17.20M,
                Net = 1385.27M,
                FederalTaxes = 134.02M,
                FICATaxes = 106.64M,
                MedicareTaxes = 24.94M,
                StateTaxes = 55.00M,
                Deductions401K = 17.20M,
                Date = new DateTime(2023, 1, 23),
                Week = 4,
                EmployeeId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new PayStub
            {
                Id = 4,
                HoursWorked = 80,
                Gross = 17.20M,
                Net = 1385.27M,
                FederalTaxes = 134.02M,
                FICATaxes = 106.64M,
                MedicareTaxes = 24.94M,
                StateTaxes = 55.00M,
                Deductions401K = 17.20M,
                Date = new DateTime(2023, 1, 23),
                Week = 4,
                EmployeeId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            }
            );
        modelBuilder.Entity<VacationTime>().HasData(
            new VacationTime
            {
                Id = 1,
                EmployeeId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                HolidayAvail = 6.0,
                HolidayAvailable = 16.0,
                VacationAvail = 20.0,
                VacationAvailable = 100.0
            },
            new VacationTime
            {
                Id = 2,
                EmployeeId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                HolidayAvail = 8.0,
                HolidayAvailable = 12.0,
                VacationAvail = 16.0,
                VacationAvailable = 104.0
            }
            );
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "Joseph.Huntley",
                Salt = salt1,
                Password = Password.HashPassword("HelloWorld", salt1),
                EmployeeId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new User
            {
                Id = 2,
                Username = "John.Doe",
                Salt = salt2,
                Password = Password.HashPassword("HelloWorld", salt2),
                EmployeeId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            }
            );

        // Exclude any employees who have been terminated.
        modelBuilder.Entity<Employee>()
            .HasQueryFilter(emp => !emp.Terminated);
        modelBuilder.Entity<PayStub>()
            .HasQueryFilter(p => !p.employee.Terminated);
        modelBuilder.Entity<VacationTime>()
            .HasQueryFilter(v => !v.employee.Terminated);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.EnableSensitiveDataLogging();
        if (!optionsBuilder.IsConfigured)
        {
            string dir = Environment.CurrentDirectory;
            string path = string.Empty;

            if (dir.EndsWith("net7.0"))
            {
                // Running in the <project>\bin\<Debug|Release>\net7.0 directory.
                path = Path.Combine("..", "..", "..", "..", "..", "Nexus.db");
            }
            else
            {
                // Running in the <project> directory.
                path = Path.Combine("..", "..", "Nexus.db");
            }

            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }


}