using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.API.FranksCarLot.Modeles.CarModeles;
using FranksCarLot.Modeles.CarModeles;

namespace FranksCarLot.Services.CarServices
{
    public interface ICarService
    {
        Task<bool> AddCar(CarCreate model);
        Task<bool> UpdateCar(CarEdit model);
        Task<bool> DeleteCar(Guid id);
        Task<List<CarListItem>> GetCars();
        Task<CarDetail> GetCarById(Guid id);
    }
}