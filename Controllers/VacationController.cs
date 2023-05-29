using System;
using AutoMapper;
using Controller.Models;
using Controller.Models.DTO;
using Controller.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    // Base Address: api/Pay/timer
    [Route("api/[controller]/time")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private IVacationRepository _repo;
        private IMapper _mapper;

        public VacationController(IMapper mapper, IVacationRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet(template: "int:id", Name = "GetVacation")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetVacation(int id)
        {
            if (id < 0)
            {
                return BadRequest("ID can't be default or less than 0");
            }

            // Authorize with JWT.
            if (!Password.Authorize(User, id)) return Unauthorized();

            VacationTime? entity = await _repo.RetrieveByEmpIdAsync(id);

            if (entity is null)
            {
                return NotFound("A record with that id could not be found.");
            }

            VacationTimeDTO model = _mapper.Map<VacationTimeDTO>(entity);

            return Ok(model);
        }

        [HttpPost(template: "int:id")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateVacation([FromBody] VacationTimeDTO model, int id)
        {
            if (model is null)
            {
                return BadRequest("Must include Vacation time in the body.");
            }

            if (id <= 0)
            {
                return BadRequest("ID can't be default or less than 0");
            }

            if (id != model.EmployeeId)
            {
                return BadRequest("EmployeeId and Id must match");
            }

            // Check if a vacationtime already exists for the employee
            VacationTime? emp = await _repo.RetrieveByEmpIdAsync(id);

            // If emp is not null that means that a vacationtime row already exists for that employee
            if (emp is not null)
            {
                return BadRequest("An entry for that employee already exists");
            }

            VacationTime? entity = _mapper.Map<VacationTime>(model);

            entity = await _repo.CreateAsync(entity);

            if (entity is null)
            {
                return BadRequest("Could not create the vacation entry");
            }

            model = _mapper.Map<VacationTimeDTO>(entity);

            return CreatedAtAction("GetVacation", new { id = model.EmployeeId }, model);
        }

        [HttpPut(template: "int:id")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutVacation([FromBody] VacationTimeDTO model, int id)
        {

            if (model is null)
            {
                return BadRequest("Must include Vacation time in the body.");
            }

            if (id <= 0)
            {
                return BadRequest("ID can't be default or less than 0");
            }

            if (id != model.Id)
            {
                return BadRequest("Ids must match");
            }

            // Authorize with JWT.
            if (!Password.Authorize(User, id)) return Unauthorized();

            VacationTime? entity = _mapper.Map<VacationTime>(model);

            entity = await _repo.UpdateAsync(entity);

            if (entity is null)
            {
                return BadRequest("VacationTime could not be updated.");
            }



            return NoContent();
        }
    }
}

