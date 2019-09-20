using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Services;

namespace webapi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluatorsController : ControllerBase
    {
        private readonly IEvaluatorService _service;
        public EvaluatorsController(IEvaluatorService service)
        {
            this._service = service;
        }

        // GET api/Evaluatores
        [HttpGet]
        public ActionResult<IEnumerable<string>> Gets()
        {
            return Ok(this._service.getAll());
        }

        // GET api/Evaluatores/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(Guid id)
        {
            return Ok(_service.getById(id));
        }

        // POST api/Evaluatores
        [HttpPost("")]
        public void Post([FromBody] string value) { }

        // PUT api/Evaluatores/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] string value) { }

        // DELETE api/Evaluatores/5
        [HttpDelete("{id}")]
        public void DeleteById(string id) { }
    }
}