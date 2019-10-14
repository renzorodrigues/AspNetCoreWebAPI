using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Entities;
using webapi.Domain.Services;

namespace webapi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            this._loginService = loginService;
        }

        // POST api/Login
        [HttpPost]
        public IActionResult Post([FromBody] Login login)
        {
            return Ok(this._loginService.authenticate(login));
        }
    }
}