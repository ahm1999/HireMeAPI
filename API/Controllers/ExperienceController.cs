using HireMeAPI.BLL.interfaces;
using HireMeAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("UserExperience/{UserId:guid}")]
        public async Task<IActionResult> UserExperience([FromRoute] Guid UserId) {
            var response = await _experienceService.GetUserExperience(UserId);

            if (!response.success)
            {
                return BadRequest(response.messege);
            }
            return Ok(response);


        }

        [Authorize]
        [HttpDelete("RemoveExperience/{ExperienceId:guid}")]

        public async Task<IActionResult> RemoveUserExperience([FromRoute]  Guid ExperienceId) {

            var response = await _experienceService.RemoveUserExperience(ExperienceId);

            if (!response.success)
            {
                return BadRequest(response.messege);
            }
            return Ok(response);

        }

    }
}
