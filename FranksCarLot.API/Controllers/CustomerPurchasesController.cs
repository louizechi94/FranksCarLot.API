using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.Modeles.CustomerPurchaseModeles;
using FranksCarLot.Services.CustomerPurchaseServices;
using Microsoft.AspNetCore.Mvc;

namespace FranksCarLot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerPurchasesController : ControllerBase
    {
        private readonly ICustomerPurchaseService _cPService;

        public CustomerPurchasesController(ICustomerPurchaseService cPService)
        {
            _cPService = cPService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _cPService.GetCustomerPurchases());
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerPurchaseCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _cPService.AddPurchase(model))
                return Ok("Customer Purchased a Car!");
            else
                return StatusCode(500, "Internal Server Error.");
        }
    }
}