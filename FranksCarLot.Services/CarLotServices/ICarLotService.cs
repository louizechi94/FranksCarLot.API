using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.Modeles.CarLotModeles;

namespace FranksCarLot.Services.CarLotServices
{
    public interface ICarLotService
    {
        Task<bool> AddCarLot(CarLotCreate model);
        Task<bool> UpdateCarLot(CarLotEdit model);
        Task<bool> DeleteCarLot(int id);
        Task<List<CarLotListItem>> GetCarLots();
        Task<CarLotDetail> GetCarLotById(int id);
    }
}