
using System.Collections;
using System.Linq.Expressions;
using Moq;
using Nexus.Models;
using Nexus.Models.DTO;
using Nexus.Repositories;

namespace Nexus.Mocks;
internal class MockEmployeeRepository
{
    public static Mock<IEmployeeRepository> GetMock()
    {
        var mock = new Mock<IEmployeeRepository>();

        // Setup the mock
        IEnumerable<Employee> employees = new List<Employee>
        {
           new Employee
            {
                EmpId = 1,
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
                EmpId = 2,
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
        };

        mock.Setup(m => m.RetrieveAllAsync(It.IsAny<Expression<Func<Employee, bool>>>()))
            .Returns(() => Task.FromResult(employees));
        mock.Setup(m => m.RetrieveAsync(It.IsAny<int>()))
            .Returns((int id) => Task.FromResult(employees.FirstOrDefault(emp => emp.EmpId == id)));
        mock.Setup(m => m.CreateAsync(It.IsAny<Employee>()))
            .Returns((Employee? emp) => Task.FromResult(emp));
        mock.Setup(m => m.DeleteAsync(It.IsAny<Employee>()))
            .Returns(() => Task.FromResult(true));
        mock.Setup(m => m.UpdateAsync(It.IsAny<Employee>()))
            .Returns((Employee? emp) => Task.FromResult(emp));
        // Assumes every employee is terminated successfully
        mock.Setup(m => m.TerminateAsync(It.IsAny<Employee>()))
            .Returns(() => Task.FromResult(true));

        return mock;
    }
}

