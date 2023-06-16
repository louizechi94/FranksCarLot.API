using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.Modeles.CarLotModeles;
using FranksCarLot.Services.CarLotServices;
using Microsoft.AspNetCore.Mvc;

namespace FranksCarLot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarLotsController : ControllerBase
    {
        private readonly ICarLotService _service;

        public CarLotsController(ICarLotService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetCarLots());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var carlot = await _service.GetCarLotById(id);
            if (carlot is null)
            {
                return NotFound();
            }
            return Ok(carlot);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CarLotCreate model)
        {
            if(ModelState.IsValid== false)
            {
                return BadRequest(ModelState);
            }
            if(await _service.AddCarLot(model))
            {
                return Ok();
            }
            return UnprocessableEntity();
        }

         [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(CarLotEdit model,int id)
        {
            if(id != model.Id)
            return BadRequest("Invalid Id");

            if(ModelState.IsValid== false)
            {
                return BadRequest(ModelState);
            }
            if(await _service.UpdateCarLot(model))
            {
                return Ok("Updated CarLot");
            }
            return UnprocessableEntity();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id < 0)
            return BadRequest("Invalid Id");

          
            if(await _service.DeleteCarLot(id))
            {
                return Ok("Deleted CarLot");
            }
            return StatusCode(500,"Internal Server Error");
        }

    }
}