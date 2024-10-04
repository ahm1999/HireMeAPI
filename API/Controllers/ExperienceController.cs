using HireMeAPI.BLL.interfaces;
using HireMeAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HireMeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;
        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpPost("AddExperience")]
        [Authorize]
        public async Task<IActionResult> AddExperience([FromBody] UserExperienceDTO userData) {

            var response = await _experienceService.AddUserExperience(userData);

            if (!response.success)
            {
                return BadRequest(response.messege);
            }
            return Ok(response);
        }
    }
}
