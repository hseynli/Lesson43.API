using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpVerbs.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Get {id}");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Post");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login()
        {
            return Ok("Login");
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok("Put");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Delete");
        }
    }
}