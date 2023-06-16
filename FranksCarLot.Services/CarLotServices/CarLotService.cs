using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.Data.Context;
using FranksCarLot.Modeles.CarLotModeles;
using FranksCarLot.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FranksCarLot.Services.CarLotServices
{
    public class CarLotService : ICarLotService
    {
        //we need to access to database
        private readonly FranksDbContext _context;

        public CarLotService(FranksDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCarLot(CarLotCreate model)
        {
            CarLot carlot = new CarLot
            {
                City = model.City,
                State = model.State,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            };

            await _context.CarLots.AddAsync(carlot);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteCarLot(int id)
        {
            CarLot carlot = await _context.CarLots.FindAsync(id);
            if (carlot is null)
            return false;

            _context.CarLots.Remove(carlot);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CarLotDetail> GetCarLotById(int id)
        {
            CarLot carlot = await _context.CarLots.FindAsync(id);
            if (carlot is null)
            return new CarLotDetail();

            return new CarLotDetail
            {
                Id = carlot.Id,
                City = carlot.City,
                State = carlot.State,
                Address = carlot.Address,
                PhoneNumber = carlot.PhoneNumber
            };
        }

        public async Task<List<CarLotListItem>> GetCarLots()
        {
            List<CarLotListItem> carLots = await _context.CarLots.Select(c => new CarLotListItem
            {
                Id = c.Id,
                City= c.City,
                PhoneNumber= c.PhoneNumber

            }).ToListAsync();
            return carLots;        
        }

        public async Task<bool> UpdateCarLot(CarLotEdit model)
        {
             CarLot carlot = await _context.CarLots.FindAsync(model.Id);
            if (carlot is null)
            return false;

            carlot.City = model.City;
            carlot.State = model.State;
            carlot.Address = model.Address;
            carlot.PhoneNumber = model.PhoneNumber;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}