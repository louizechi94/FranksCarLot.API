using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.API.FranksCarLot.Modeles.CarModeles;
using FranksCarLot.Data.Context;
using FranksCarLot.Data.Entities;
using FranksCarLot.Modeles.CarLotModeles;
using FranksCarLot.Modeles.CarModeles;
using Microsoft.EntityFrameworkCore;

namespace FranksCarLot.Services.CarServices
{
    public class CarService : ICarService
    {
        private readonly FranksDbContext _context;

        public CarService(FranksDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCar(CarCreate model)
        {
            var entity = new Car
            {
                Id = Guid.NewGuid().ToString(),
                Year = model.Year,
                Make = model.Make,
                Model = model.Model,
                CarLotId = model.CarLotId
            };

            await _context.Cars.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCar(string id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);

            if (car is null)
                return false;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CarDetail> GetCarById(string id)
        {
            var car = await _context.Cars.Include(c => c.CarLot).FirstOrDefaultAsync(x => x.Id == id);

            if (car is null)
                return new CarDetail();

            return new CarDetail
            {
                Id = car.Id,
                Year = car.Year,
                Make = car.Make,
                Model = car.Model,
                CarLot = new CarLotListItem
                {
                    Id = car.CarLot.Id,
                    City = car.CarLot.City,
                    PhoneNumber = car.CarLot.PhoneNumber
                }
            };
        }

        public async Task<List<CarListItem>> GetCars()
        {
            return await _context.Cars.Include(c => c.CarLot).Select(c => new CarListItem
            {
                Make = c.Make,
                Model = c.Model,
                CarLotAddress = c.CarLot.Address
            }).ToListAsync();
        }

        public async Task<bool> UpdateCar(CarEdit model)
        {
            var car = await _context.Cars.Include(c => c.CarLot).SingleOrDefaultAsync(x => x.Id == model.Id);

            if (car is null)
                return false;

            car.CarLotId = model.CarLotId;
            car.Year = model.Year;
            car.Make = model.Make;
            car.Model = model.Model;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}