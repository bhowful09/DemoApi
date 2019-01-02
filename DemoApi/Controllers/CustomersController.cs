using DemoApi.Domain;
using DemoApi.Logic.Processors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private CustomersProcessor _customersProcessor;

        public CustomersController(CustomersProcessor customersProcessor)
        {
            _customersProcessor = customersProcessor;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(_customersProcessor.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = _customersProcessor.GetById(id);

            if (customer == null)
            {
                return NoContent();
            }

            return Ok(customer);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] CustomerCreate value)
        {
            var customer = _customersProcessor.Insert(value);

            if (customer == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Record could not be created");
            }

            return Ok(customer);
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<Customer> Put([FromBody] Customer value)
        {
            var customer = _customersProcessor.Update(value);

            if (customer == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Record does not exist to update id {value.Id}");
            }

            return Ok(customer);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _customersProcessor.Delete(id);
            return NoContent();
        }
    }
}