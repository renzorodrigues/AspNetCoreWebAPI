using System;
using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Entities;
using webapi.Domain.Services;

namespace webapi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        // POST api/auth
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserAuth credentials)
        {
            return Ok(this._authService.authenticate(credentials));
        }

        // POST api/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserAuth credentials)
        {
            try
            {
                return Ok(this._authService.register(credentials));
            }
            catch (Exception e)
            {
                return StatusCode(400, "Bad Request: " + e.InnerException.Message);
            }
        }
    }
}