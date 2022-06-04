using LoginSample.Data.Dto;
using LoginSample.Service.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }
        [HttpPost("add")]
        public IActionResult CreateNewUser([FromBody] NewUserDto dto)
        {
           
            var result = service.CreateNewUser(dto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
