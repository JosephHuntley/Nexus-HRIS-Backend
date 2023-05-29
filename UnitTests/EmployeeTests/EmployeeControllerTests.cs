using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Nexus.Controllers;
using Nexus.Data;
using Nexus.Mocks;
using Nexus.Models;
using Nexus.Models.DTO;
using Nexus.Repositories;
using UnitTests.Mocks;

namespace UnitTests;

public class EmployeeControllerTests
{
    // Arrange
    Mock<IEmployeeRepository> mockRepo;
    IMapper mockMapper;
    EmployeeController employeeController;

    public EmployeeControllerTests()
    {
        // Arrange
        mockRepo = MockEmployeeRepository.GetMock();
        mockMapper = MockMapper.GetMapper();
        employeeController = new EmployeeController(mockRepo.Object, mockMapper);

    }

    [Fact]
    public async void RetrieveAll_ThenAllEmployeesReturnWithStatus200()
    {

        // Act
        ObjectResult? result = await employeeController.GetEmployees() as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.IsAssignableFrom<IEnumerable<EmployeeDTO>>(result.Value);
#pragma warning disable CS8604 // Possible null reference argument.
        Assert.NotEmpty(result?.Value as IEnumerable<EmployeeDTO>);
#pragma warning restore CS8604 // Possible null reference argument.
    }

    [Fact]
    public async void RetrieveEmployeeById_ThenReturnsEmployeeWithMatchingIdAndStatus200()
    {
        // Arrange
        EmployeeDTO emp = new EmployeeDTO
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
            PostalCode = "123456"
        };

        // Act
        ObjectResult? resultId1 = await employeeController.GetEmployee(1) as ObjectResult;


        // Assert
        Assert.NotNull(resultId1);
        Assert.Equal(StatusCodes.Status200OK, resultId1.StatusCode);
        Assert.IsAssignableFrom<EmployeeDTO>(resultId1.Value);
    }

    [Fact]
    public async void CreateEmployee_ThenRecieveStatus201()
    {
        // Arrange
        EmployeeDTO newEmp = new EmployeeDTO
        {
            EmpId = 0,
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
            PostalCode = "123456"
        };

        // Act
        ObjectResult? result = await employeeController.CreateEmployee(newEmp) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
        Assert.IsAssignableFrom<EmployeeDTO>(result.Value);

    }

    [Fact]
    public async void UpdateEmployeeWithNotMatchingIds_ThenRecieveStatus400_IdMustBeGreaterThanZero()
    {
        // Arrange
        EmployeeDTO emp = new EmployeeDTO
        {
            EmpId = 2,
            FName = "John",
            LName = "Doe",
            Email = "Joseph.Huntley@outlook.com",
            Phone = "(810) 555-1100",
            PayRate = 32.50M,
            Title = ".Net Developer",
            Address = "One Apple Parkway",
            City = "Cupertino",
            Region = "California",
            Country = "United States",
            PostalCode = "123456"
        };

        // Act
        // Actual id is seven
        ObjectResult? result = await employeeController.UpdateEmployee(7, emp) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result?.StatusCode);
        Assert.Equal("The Ids must match", result?.Value);
    }

    [Fact]
    public async void DeleteEmployeeWithIdLessThanZero_ThenRecieveStatus400_IdMustBeGreaterThanZero()
    {
        // Act
        ObjectResult? result = await employeeController.DeleteEmployee(0) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result?.StatusCode);
        Assert.Equal("Id must be greater than 0", result?.Value);
    }

    [Fact]
    public async void TerminateEmployeeWithIdThatDoesntExit_ThenRecieveStatus400_EmployeeNotFound()
    {
        // Act
        // An Employee with the ID 6 doesn't exist in the mock db
        ObjectResult? result = await employeeController.TerminateEmployee(6) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        Assert.Equal("Employee not found", result.Value);
    }
}

