using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Services;
//using webapi.Api.Models;

namespace webapi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            this._service = service;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<string>> Gets()
        {
            return Ok(this._service.getAll());
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            return Ok(_service.getById(id));
        }

        // POST api/products
        [HttpPost("")]
        public void Post([FromBody] string value) { }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void DeleteById(int id) { }
    }
}