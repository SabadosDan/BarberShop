using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public AuthController(WebAPIContext context)
        {
            _context = context;
        }

        // POST: api/Auth/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(c => c.PhoneNumber == loginRequest.PhoneNumber && c.Password == loginRequest.Password);

            if (client == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok(new { userId = client.ID, role = client.Role});
        }

    }

    public class LoginRequest
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
