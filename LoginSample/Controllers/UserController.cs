using LoginSample.Data.Dto;
using LoginSample.Service.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }
        [HttpPost("add")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] NewUserDto dto)
        {
           
            var result = service.CreateNewUser(dto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult SignIn([FromBody] SignInUserDto dto)
        {
            var result = service.SignIn(dto);
            if(result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("list")]
        public IActionResult GetAllUsers()
        {
            var result = service.GetAllUsers();
            if (result.Any())
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
