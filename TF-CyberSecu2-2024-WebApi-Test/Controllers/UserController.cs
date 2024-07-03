using Microsoft.AspNetCore.Mvc;
using TF_CyberSecu2_2024_WebApi_Test.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TF_CyberSecu2_2024_WebApi_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static int _maxId = 3;
        private static List<User> _users = new List<User>() { 
            new User(){ Id = 1, Firstname = "Samuel", Lastname = "Legrain", Email = "samuel.legrain@bstorm.be", Password = "Test1234="},
            new User(){ Id = 2, Firstname = "Thierry", Lastname = "Morre", Email = "thierry.morre@bstorm.be", Password = "Test1234="},
            new User(){ Id = 3, Firstname = "Michael", Lastname = "Person", Email = "michael.person@bstorm.be", Password = "Test1234="}
        };
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User? user = _users.SingleOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post(User newUser)
        {
            newUser.Id = ++_maxId;
            _users.Add(newUser);
            return CreatedAtAction(nameof(Get),new { id = newUser.Id }, newUser);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, User newUser)
        {
            User? user = _users.SingleOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            user.Firstname = newUser.Firstname;
            user.Lastname = newUser.Lastname;
            user.Email = newUser.Email;
            user.Password = newUser.Password;
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User? user = _users.SingleOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            _users.Remove(user);
            return NoContent();
        }
    }
}
