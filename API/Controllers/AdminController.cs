using HireMeAPI.BLL.interfaces;
using HireMeAPI.utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HireMeAPI.API.Controllers
{
    // -------------------------------devController 
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public AdminController(IRoleService roleService,ILogger<AdminController> logger)
        {
            _roleService = roleService;
        }


        [HttpPost("AddtoAdmin/{UserId:guid}")]
        public async Task<IActionResult> AddUserToAdminRole([FromRoute] Guid UserId)
        {

            var response = await _roleService.AddUserToRole(UserId, RolesConsts.ADMIN);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        //[HttpPost("promoteToAdmin/{UserId:}")]

        [HttpPost("FeedAndSneed")]
        public async Task<IActionResult> SeedRoles() { 

            var response = await _roleService.AddRole(RolesConsts.ADMIN);
            var roleresponse=  await _roleService.AddRole(RolesConsts.USER);

            if (response.Success&& roleresponse.Success)
            {
                return Ok("both roles added");
            }
            return BadRequest("one of them or none");
        }

        [HttpGet("TestUser")]
        [Authorize(Roles =RolesConsts.USER)]
        public IActionResult TestUser() {

            return Ok("user role");
        }

        [HttpGet("TestAdmin")]
        [Authorize(Roles = RolesConsts.ADMIN)]
        public IActionResult TestAdmin()
        {

            return Ok("admin role");
        }

    }
}
