using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Entities;
using webapi.Domain.Services;

namespace webapi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendedsController : ControllerBase
    {
        private readonly IAttendedService _service;
        public AttendedsController(IAttendedService service)
        {
            this._service = service;
        }

        // GET api/Attendeds
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return Ok(this._service.getAll());
        }

        // GET api/Attendeds
        [HttpGet("search")]
        public ActionResult<IEnumerable<string>> GetByName(string search)
        {
            return Ok(this._service.getByName(search));
        }

        // GET api/Attendeds/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(Guid id)
        {
            return Ok(_service.getById(id));
        }

        // POST api/Attendeds
        [HttpPost]
        public IActionResult Post([FromBody] Attended attended)
        {
            try
            {
                return Ok(this._service.insert(attended));
            }
            catch (Exception e)
            {
                return StatusCode(422, "Unprocessable Entity: " + e.InnerException.Message);
            }
        }

        // PUT api/Attendeds/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Attended attended)
        {
            this._service.update(id, attended);
        }

        // DELETE api/Attendeds/5
        [HttpDelete("{id}")]
        public void DeleteById(Guid id)
        {
            this._service.delete(id);
        }
    }
}