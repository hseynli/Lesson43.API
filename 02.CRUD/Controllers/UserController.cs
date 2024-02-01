using _02.CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _02.CRUD.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<User> users = new List<User>()
        {
            new User() { Id = 1, Name = "User 1" },
            new User() { Id = 2, Name = "User 2" },
            new User() { Id = 3, Name = "User 3" },
            new User() { Id = 4, Name = "User 4" },
            new User() { Id = 5, Name = "User 5" },
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            if (user == null) 
            {
                return BadRequest();
            }
            users.Add(user);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            users.Remove(users.FirstOrDefault(x => x.Id == id));

            return NoContent();
        }
    }
}
