using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.Modeles.CustomerModeles;
using FranksCarLot.Services.CustomerServices;
using Microsoft.AspNetCore.Mvc;

namespace FranksCarLot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        // we need to access customer services, we will do this through ICustomerService
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetCustomers());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _service.GetCustomerById(id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerCreate model)
        {
            if(ModelState.IsValid== false)
            {
                return BadRequest(ModelState);
            }
            if(await _service.AddCustomer(model))
            {
                return Ok();
            }
            return UnprocessableEntity();
        }

         [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(CustomerEdit model,int id)
        {
            if(id != model.Id)
            return BadRequest("Invalid Id");

            if(ModelState.IsValid== false)
            {
                return BadRequest(ModelState);
            }
            if(await _service.UpdateCustomer(model))
            {
                return Ok("Updated Customer");
            }
            return UnprocessableEntity();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id < 0)
            return BadRequest("Invalid Id");

          
            if(await _service.DeleteCustomer(id))
            {
                return Ok("Deleted Customer");
            }
            return StatusCode(500,"Internal Server Error");
        }

    }
}