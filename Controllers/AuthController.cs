using Microsoft.AspNetCore.Mvc;
using HRMS.API.Repositories;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest req)
        {
            var user = _unitOfWork.Auth.ValidateUser(req.Username, req.PasswordHash);
            
            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid credentials or inactive user" });
            }

            return Ok(user);
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
