using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Entities;
using webapi.Domain.Services;

namespace webapi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendidosController : ControllerBase
    {
        private readonly IAtendidoService _service;
        public AtendidosController(IAtendidoService service)
        {
            this._service = service;
        }

        // GET api/atendidos
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return Ok(this._service.getAll());
        }

        // GET api/atendidos/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(string id)
        {
            return Ok(_service.getById(id));
        }

        // POST api/atendidos
        [HttpPost]
        public void Post([FromBody] Atendido Atendido)
        {
            this._service.insert(Atendido);
        }

        // PUT api/atendidos/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Atendido Atendido)
        {
            this._service.update(id, Atendido);
        }

        // DELETE api/atendidos/5
        [HttpDelete("{id}")]
        public void DeleteById(int id) { }
    }
}