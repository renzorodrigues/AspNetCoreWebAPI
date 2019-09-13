using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Services;

namespace webapi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            this._service = service;
        }

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return Ok(_service.getAll());
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            return "value" + id;
        }

        // POST api/users
        [HttpPost("")]
        public void Post([FromBody] string value) { }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void DeleteById(int id) { }
    }
}