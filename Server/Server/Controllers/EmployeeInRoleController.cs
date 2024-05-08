using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Core.DTOs;
using Server.Core.Models;
using Server.Core.Services;
using Server.Models;
using Server.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeInRoleController : ControllerBase
    {
        private readonly IEmployeeInRoleServices _employeeInRoleService;
        private readonly IMapper _mapper;
        public EmployeeInRoleController(IEmployeeInRoleServices employeeInRoleServices, IMapper mapper)
        {
            _employeeInRoleService = employeeInRoleServices;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeePositions(int id)
        {
            var rolesEmployee = await _employeeInRoleService.GetEmployeeInRoleByIdAsync(id);
            if (rolesEmployee == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<EmployeeInRole>>(rolesEmployee));
        }

        [HttpPost("{employeeId}")]
        public async Task<ActionResult<EmployeeInRole>> AddRoleToEmployee(int employeeId, [FromBody] EmployeeInRolePostModel employeeInRole)
        {
            var newRoleToEmployee = await _employeeInRoleService.AddPositionToEmployeeAsync(employeeId, _mapper.Map<EmployeeInRole>(employeeInRole));
            if (newRoleToEmployee == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeeInRoleDTO>(newRoleToEmployee));
        }

        [HttpPut("{employeeId}/role/{roleId}")]
        public async Task<ActionResult> Put(int employeeId, int roleId, [FromBody] EmployeeInRolePostModel Employee)
        {
            var updateRoleEmployee = await _employeeInRoleService.UpdateRoleToEmployeeAsync(employeeId, roleId, _mapper.Map<EmployeeInRole>(Employee));
            if (updateRoleEmployee == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeeInRoleDTO>(updateRoleEmployee));
        }
        [HttpDelete("{employeeId}/role/{roleId}")]

        public async Task<IActionResult> DeletePosition(int employeeId, int roleId)
        {
            var result = await _employeeInRoleService.DeletRoleToEmployeeAsync(employeeId, roleId);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
