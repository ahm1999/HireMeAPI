using HireMeAPI.BLL.interfaces;
using HireMeAPI.BLL.Services;
using HireMeAPI.DTOs;
using HireMeAPI.utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HireMeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        [Authorize(Roles = RolesConsts.USER)]
        [HttpPost("Apply")]
        public async Task<IActionResult> ApplyForJobPosting(CreateApplicationDTO createApplicationDTO) {

            ApplicationServiceResponse serviceResponse = await _applicationService.CreateApplication(createApplicationDTO);

            if (!serviceResponse.success)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }
    }
}
