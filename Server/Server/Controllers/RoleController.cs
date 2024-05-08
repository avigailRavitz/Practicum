using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Core.DTOs;
using Server.Core.Models;
using Server.Core.Services;
using Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleServices roleServices,IMapper mapper)
        {
            _roleService = roleServices;    
                _mapper = mapper;
        }


        // GET: api/<RoleController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var Roles = await _roleService.GetAllRolesAsync();
            return Ok(_mapper.Map<IEnumerable<RoleDTO>>(Roles));
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoleController>
        [HttpPost ]
        public async Task<ActionResult> Post([FromBody] RolePostModel name)
        {
            var roleName = await _roleService.AddRoleAsync(_mapper.Map<Role>(name));
            return Ok(_mapper.Map<RoleDTO>(roleName));
        }

    }
}
