using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.API.FranksCarLot.Modeles.CarModeles;
using FranksCarLot.Modeles.CarModeles;
using FranksCarLot.Services.CarServices;
using Microsoft.AspNetCore.Mvc;

namespace FranksCarLot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _carService.GetCars());
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var car = await _carService.GetCarById(id);
            if (car is null)
                return NotFound();
            else
                return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CarCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _carService.AddCar(model))
                return Ok("Car Created!");
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(CarEdit model, Guid id)
        {
            if (id != model.Id)
            {
                return BadRequest("Invalid Id.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _carService.UpdateCar(model))
                return Ok("Car Updated!");
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _carService.DeleteCar(id))
                return Ok("Car Deleted!");
            else
                return StatusCode(500, "Internal Server Error.");
        }
    }
}