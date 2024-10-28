using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HireMeAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using HireMeAPI.BLL.interfaces;
using HireMeAPI.BLL.Services;

namespace HireMeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
            
        }

        [HttpPost("SignUp")]

        public async Task<ActionResult<ResponseStatusDTO>> SignUp(SignUpDTO userData)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseStatusDTO() { Status = "Failed" , Messege = ModelState.ToString()}); // Return the view with validation errors
            }
            var Res = await _userService.CreateUserAccountAsync(userData,false);

            if (Res == Guid.Empty) return BadRequest("account with that id already created");

            return Ok(new ResponseStatusDTO() { Status = "Success", Messege = "Account created" });
        }


        [HttpPost("SignUpRecruiter")]

        public async Task<ActionResult<ResponseStatusDTO>> SignUpAsRecruiter(SignUpDTO userData)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseStatusDTO() { Status = "Failed", Messege = ModelState.ToString() }); // Return the view with validation errors
            }
            var Res = await _userService.CreateUserAccountAsync(userData, true);

            if (Res == Guid.Empty) return BadRequest("account with that id already created");

            return Ok(new ResponseStatusDTO() { Status = "Success", Messege = "Recruiter Account created" });
        }



        [HttpPost("LogIn")]
        public async Task<ActionResult<ResponseStatusDTO>> LogIn(LogInDTO userData)
        {

            LogInResponse response =  await _userService.LogInAsync(userData);

            if (!response.LoggedIn) {

                return BadRequest(response);
            
            }
            return Ok(response);



        }

        [Authorize]
        [HttpGet("UserData")]
        public async Task<ActionResult<ResponseStatusDTO>> UserData()
        {
            var response = _userService.GetUserData(User);
            return Ok(response);
        }
    }

}
