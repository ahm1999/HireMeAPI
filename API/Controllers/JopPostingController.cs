using HireMeAPI.BLL.interfaces;
using HireMeAPI.BLL.Services;
using HireMeAPI.DTOs;
using HireMeAPI.utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HireMeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JopPostingController : ControllerBase
    {
        private readonly IJobPostingService _jobPostingService;
        public JopPostingController(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }


        [Authorize(Roles = RolesConsts.RECRUITER)]
        [HttpPost]
        public async Task<IActionResult> CreateJobPosting(CreateJobPostingDTO createJobPostingDTO) {

            JobPostingServiceResponse serviceResponse = await _jobPostingService.createJobPosting(createJobPostingDTO);

            if (!serviceResponse.succes) {

                return BadRequest(serviceResponse.Messege);
            
            }

            return Ok(serviceResponse);

        }



    }
}
