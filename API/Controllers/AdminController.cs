using HireMeAPI.BLL.interfaces;
using HireMeAPI.BLL.Services;
using HireMeAPI.DAL.Entities;
using HireMeAPI.DTOs;
using HireMeAPI.utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireMeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IWorkFieldService _workFieldService;
        public AdminController(IRoleService roleService, ILogger<AdminController> logger, IWorkFieldService workFieldService)
        {
            _roleService = roleService;
            _workFieldService = workFieldService;
        }


        [Authorize(Roles = RolesConsts.ADMIN)]
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

        [Authorize(Roles = RolesConsts.ADMIN)]
        [HttpPost("AddWorkField")]
        public async Task<IActionResult> AddWorkField([FromBody] WorkFieldDTO userData)
        {

            WorkFieldServiceResponse response = await _workFieldService.AddWorkField(userData);
            if (!response.Status)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [Authorize(Roles = RolesConsts.ADMIN)]
        [HttpDelete("RemoveWorkField/{WorkFieldId:guid}")]
        public async Task<IActionResult> RemoveWorkField([FromRoute] Guid WorkFieldId)
        {

            WorkFieldServiceResponse response = await _workFieldService.RemoveWrokField(WorkFieldId);
            if (!response.Status)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("GetAllWorkFields")]
        public async Task<IActionResult> GetAllWrokFields() {

            WorkFieldServiceResponse response = await _workFieldService.GetAllWorkField();
            if (!response.Status)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("FeedAndSneed")]
        public async Task<IActionResult> SeedRoles()
        {

            var response = await _roleService.AddRole(RolesConsts.ADMIN);
            var roleresponse = await _roleService.AddRole(RolesConsts.USER);

            if (response.Success && roleresponse.Success)
            {
                return Ok("both roles added");
            }
            return BadRequest("one of them or none");
        }




    }

}










      

        //[HttpGet("TestUser")]
        //[Authorize(Roles =RolesConsts.USER)]
        //public IActionResult TestUser() {

        //    return Ok("user role");
        //}

        //[HttpGet("TestAdmin")]
        //[Authorize(Roles = RolesConsts.ADMIN)]
        //public IActionResult TestAdmin()
        //{

        //    return Ok("admin role");
        //}

    

