using System;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Entities;
using webapi.Domain.Services;

namespace webapi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserAuthService _authService;
        public AuthController(IUserAuthService authService)
        {
            this._authService = authService;
        }

        // POST api/auth
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserAuth credentials)
        {
            try
            {
                return Ok(this._authService.authenticate(credentials));
            }
            catch (InvalidCredentialException  e)
            {
                return StatusCode(401, "Unauthorized: " + e.Message);
            }
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
                return StatusCode(400, "Bad Request: " + e.Message);
            }
        }
    }
}