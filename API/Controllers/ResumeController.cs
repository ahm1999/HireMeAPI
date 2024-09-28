using HireMeAPI.BLL.interfaces;
using HireMeAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireMeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {

        private readonly IResumeService _resumeServic;
        public ResumeController(IResumeService resumeServic)
        {
            _resumeServic = resumeServic;
        }

        [Authorize]
        [HttpPost("AddResume")]
        public async Task<IActionResult> AddResume(AddResumeDTO resumeDTO) {

            ResumeServiceRespoonse response = await _resumeServic.AddResumeAsync(resumeDTO);

            if (!response.Success) {
                return BadRequest(response.messege);
            };

            return Ok(response);
        }

        [Authorize]
        [HttpDelete("DeleteResume/{ResumeId:guid}")]
        public async Task<IActionResult> RemoveResume([FromRoute] Guid ResumeId ) {

            ResumeServiceRespoonse response = await _resumeServic.DeleteAsync(ResumeId);
            if (!response.Success)
            {
                return BadRequest(response.messege);
            };

            return Ok(response);
        }
 

        [Authorize]
        [HttpGet("UserResumes")]
        public async Task<IActionResult> GetAllUserResumes() {

            ResumeServiceRespoonse response = await _resumeServic.GetAllUserResumes();
                
            if (!response.Success)
            {
                return BadRequest(response.messege);
            };

            return Ok(response);
        }
    }
}
