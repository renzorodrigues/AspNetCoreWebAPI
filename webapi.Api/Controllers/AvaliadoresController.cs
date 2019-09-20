using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Services;

namespace webapi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliadoresController : ControllerBase
    {
        private readonly IAvaliadorService _service;
        public AvaliadoresController(IAvaliadorService service)
        {
            this._service = service;
        }

        // GET api/avaliadores
        [HttpGet]
        public ActionResult<IEnumerable<string>> Gets()
        {
            return Ok(this._service.getAll());
        }

        // GET api/avaliadores/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(string id)
        {
            return Ok(_service.getById(id));
        }

        // POST api/avaliadores
        [HttpPost("")]
        public void Post([FromBody] string value) { }

        // PUT api/avaliadores/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] string value) { }

        // DELETE api/avaliadores/5
        [HttpDelete("{id}")]
        public void DeleteById(string id) { }
    }
}