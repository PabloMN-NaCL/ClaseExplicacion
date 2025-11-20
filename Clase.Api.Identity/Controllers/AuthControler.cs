using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Clase.Api.Identity.Controllers
{
    //Necesario para que los enpoint en Swagger Funiconen
    [ApiController]
    [Route("api/[controller]")]
    public class AuthControler : ControllerBase
    {
        private IEnumerable<User> _users = new List<User>();
        
        
        //Endpoint para login
        [HttpPost("register")]
        //Interfaz 
        public IActionResult RegisterUser([FromBody] User user)
        {
            _users.ToList().Add(user);
            return Ok(user);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (existingUser != null)
            {
                return Ok("Login successful");
            }
            return Unauthorized("Invalid credentials");
        }
    }

    public class User
    {
               public string Username { get; set; }
        public string Password { get; set; }
    }
}


