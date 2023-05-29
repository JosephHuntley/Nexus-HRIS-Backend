
using Microsoft.AspNetCore.Mvc; // [Route], [ApiController], ControllerBase
using Nexus.Models.DTO;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Nexus.Models;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Controller.Repository.Interfaces; // IEmployeeRepository
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Controller.Models;
using Controller;

namespace Nexus.Controllers;

// base address: api/Employee
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private IEmployeeRepository _repo;
    private IMapper _mapper;

    public EmployeeController(IEmployeeRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    // POST api/Employee
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [AllowAnonymous]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTO emp)
    {
        // Checks if emp value is supplied in the body.
        if (emp == null)
        {
            return BadRequest(); // 400 Bad request
        }


        // Map from the human readable DTO to db model
        Employee model = _mapper.Map<Employee>(emp);
        // Creates the entry in the db and applies business logic
        Employee? newModel = await _repo.CreateAsync(model);

        // Checks to ensure that the process was successfull.
        if (newModel is null)
        {
            return BadRequest("Repository failed to create employee.");
        }

        // Maps the data back to human format
        EmployeeDTO newEmployee = _mapper.Map<EmployeeDTO>(newModel);
        // Return 201 along with instructions on how to get new employee
        return CreatedAtAction("GetEmployee", new { id = newEmployee.Id }, newEmployee);
    }

    // GET api/Employee
    // This controller is allowed without authorization but that is intentional since this product isn't production.
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [AllowAnonymous]
    public async Task<IActionResult> GetEmployees()
    {
        // Retrieves all the rows from the Employees table
        IEnumerable<Employee> employees = await _repo.RetrieveAllAsync();

        // Checks to ensure the operation was successfull
        if (employees == null || employees.Count() == 0)
        {
            return BadRequest("Server failed to get employees");
        }
        else
        {
            // Map from the db model to human readable DTO
            IEnumerable<EmployeeDTO> models = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            // Returns list of employees and status code 200
            return Ok(models);
        }
    }

    // GET api/Employee/id
    [HttpGet(template: "id:int", Name = "GetEmployee")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetEmployee(int id)
    {
        // If id is default (0) or id is a negative value return bad request.
        if (id < 0)
        {
            return BadRequest("ID can't be default or less than 0");
        }

        // Authorize with JWT.
        if (!Password.Authorize(User, id)) return Unauthorized();

        var userId = User.FindFirst("EmployeeId")?.Value;
        // If emp is null that means that a result didn't return from the query.
        Employee? emp = await _repo.RetrieveAsync(id);
        if (emp is null)
        {
            return BadRequest("No Employee Found");
        }

        // Map from the db model to human readable DTO
        EmployeeDTO model = _mapper.Map<EmployeeDTO>(emp);

        // Return 200 along with employee data
        return Ok(model);
    }

    // PUT api/Employee/id
    [HttpPut(template: "id:int")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDTO emp)
    {
        // If id is default or negative.
        if (id <= 0)
        {
            return BadRequest("Id must be greater than 0");
        }


        // If an employee is not provided in the body
        if (emp is null)
        {
            return BadRequest("Must include an employee in request body");
        }

        // If the ids do not match
        if (emp.Id != id)
        {
            return BadRequest("The Ids must match");
        }

        // Authorize with JWT.
        if (!Password.Authorize(User, id)) return Unauthorized();

        // Map from human readable to db
        Employee model = _mapper.Map<Employee>(emp);
        // Update the entry in the db
        Employee? newModel = await _repo.UpdateAsync(model);

        // Checks to ensure the operation is successful.
        if (newModel is null)
        {
            return BadRequest("Server could not update employee");
        }

        return NoContent();
    }

    // DELETE api/Employee/id
    [HttpDelete(template: "id:int")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        if (id < 0)
        {
            return BadRequest("Id must be greater than 0");
        }

        // Authorize with JWT.
        if (!Password.Authorize(User, id)) return Unauthorized();

        Employee? emp = await _repo.RetrieveAsync(id);

        if (emp is null)
        {
            return BadRequest("Employee not found");
        }

        bool success = await _repo.DeleteAsync(emp);

        if (!success)
        {
            return BadRequest("Server could not delete the employee");
        }

        return NoContent();
    }

    // PUT api/Employee/Terminate/Id
    [HttpPut(template: "terminate/id:int")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [AllowAnonymous]
    public async Task<IActionResult> TerminateEmployee(int id)
    {
        // Checks to ensure the id is valid
        if (id < 0)
        {
            return BadRequest("Id must be greater than 0");
        }

        // Retrieve the employee from the db
        Employee? emp = await _repo.RetrieveAsync(id);

        // Checks to ensure that an employee was retrieved
        if (emp is null)
        {
            return BadRequest("Employee not found");
        }

        // Terminate the Employee
        bool success = await _repo.TerminateAsync(emp);

        if (!success)
        {
            return BadRequest("Couldn't terminate the employee");
        }

        // If everything works correctly reutrn 204
        return NoContent();
    }
}


