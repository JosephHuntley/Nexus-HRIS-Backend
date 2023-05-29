using System;
using AutoMapper;
using Controller.Repository.Interfaces;
using Controller.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Nexus.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Controller.Controllers;

// Base Address: api/Pay
[Route("api/[controller]")]
[ApiController]
public class PayController : ControllerBase
{
    private IPayStubRepository _repo;
    private IMapper _mapper;

    public PayController(IPayStubRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    // GET api/Pay/employee/id
    [HttpGet(template: "employee/int:id")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetByEmpId(int id)
    {
        // If id is default (0) or id is a negative value return bad request.
        if (id < 0)
        {
            return BadRequest("ID can't be default or less than 0");
        }

        // Authorize with JWT.
        if (!Password.Authorize(User, id)) return Unauthorized();

        // Retrieve all rows from the Pay table for a specific employee
        IEnumerable<PayStub>? payStubs = await _repo.RetrieveAllAsync(p => p.employee.Id == id);

        if (payStubs is null || payStubs.Count() == 0)
        {
            return BadRequest("Server failed to get pay stubs");
        }

        IEnumerable<PayStubDTO> models = _mapper.Map<IEnumerable<PayStubDTO>>(payStubs);

        return Ok(models);
    }

    // GET api/pay/id
    [HttpGet(template: "int:id", Name = "GetByPayId")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetByPayId(int id)
    {
        // If id is default (0) or id is a negative value return bad request.
        if (id < 0)
        {
            return BadRequest("ID can't be default or less than 0");
        }

        // Retrieve paystub
        PayStub? pay = await _repo.RetrieveAsync(id);

        if (pay is null)
        {
            return BadRequest("Server could not find the pay stub");
        }

        // Authorize with JWT.
        if (!Password.Authorize(User, pay.EmployeeId)) return Unauthorized();

        PayStubDTO model = _mapper.Map<PayStubDTO>(pay);

        return Ok(model);
    }

    //POST api/Pay
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostPay([FromBody] PayStubDTO pay)
    {
        if (pay is null)
        {
            return BadRequest("A paystub must be included in the request body");
        }

        if (pay.Id != 0)
        {
            return BadRequest("Pay Id is auto incrementing. Must be zero");
        }

        // Authorize with JWT.
        if (!Password.Authorize(User, pay.EmployeeId)) return Unauthorized();

        PayStub? entity = _mapper.Map<PayStub>(pay);

        entity = await _repo.CreateAsync(entity);

        if (entity is null)
        {
            return BadRequest("Server Error: Could not create pay stub");
        }

        PayStubDTO model = _mapper.Map<PayStubDTO>(entity);

        return CreatedAtAction("GetByPayId", new { id = model.Id }, model);
    }

    //DELETE api/Pay/id
    [HttpDelete(template: "int:id")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeletePay(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Id must be greater than zero");
        }

        PayStub? entity = await _repo.RetrieveAsync(id);

        if (entity is null)
        {
            return BadRequest("Server Error: Could not find the paystub.");
        }

        // Authorize with JWT.
        if (!Password.Authorize(User, entity.EmployeeId)) return Unauthorized();

        bool success = await _repo.DeleteAsync(entity);

        if (!success)
        {
            return BadRequest("Server Error: Could not delete the paystub");
        }

        return NoContent();
    }

    //PUT api/Pay/id
    [HttpPut(template: "int:id")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdatePay(int id, [FromBody] PayStubDTO pay)
    {
        if (id <= 0)
        {
            return BadRequest("Id must be greater than 0");
        }

        if (pay is null)
        {
            return BadRequest("A paystub must be included in the request body");
        }

        if (pay.Id != id)
        {
            return BadRequest("Ids must match");
        }

        // Authorize with JWT.
        if (!Password.Authorize(User, pay.EmployeeId)) return Unauthorized();

        PayStub? entity = _mapper.Map<PayStub>(pay);

        entity = await _repo.UpdateAsync(entity);

        if (entity is null)
        {
            return BadRequest("Server Error: Could not update pay stub.");
        }

        return NoContent();
    }
}


