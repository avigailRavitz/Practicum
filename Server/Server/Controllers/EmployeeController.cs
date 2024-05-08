using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Core.DTOs;
using Server.Core.Models;
using Server.Core.Services;
using Server.Models;
using Server.Services;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeServices employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }


        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            var activeEmployeesFiltered = employees.Where(employee => employee.StatusActive);  
            return Ok(_mapper.Map<IEnumerable<EmployeeDTO>>(activeEmployeesFiltered));
        }


        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        { 
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeePostModel employee)
        {
            
            var newEmployee = await _employeeService.AddEmployeeAsync(_mapper.Map<Employee>(employee));
            var x = _mapper.Map<EmployeeDTO>(newEmployee);
            return Ok(x);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeePostModel employee)
        {
            var putEmployee = await _employeeService.GetEmployeeByIdAsync(id);
            if (putEmployee is null)
            {
                return NotFound();
            }
            _mapper.Map(employee, putEmployee);
            await _employeeService.UpdateEmployeeAsync(id,putEmployee);
            return Ok(putEmployee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
                await _employeeService.DeleteEmployeeAsync(id);
        }
    }
}
