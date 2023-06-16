using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.API.FranksCarLot.Modeles.CustomerPurchaseModeles;
using FranksCarLot.Data.Context;
using FranksCarLot.Data.Entities;
using FranksCarLot.Modeles.CustomerPurchaseModeles;
using Microsoft.EntityFrameworkCore;

namespace FranksCarLot.Services.CustomerPurchaseServices
{
    public class CustomerPurchaseService : ICustomerPurchaseService
    {
        private readonly FranksDbContext _context;

        public CustomerPurchaseService(FranksDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPurchase(CustomerPurchaseCreate model)
        {

            var entity = new CustomerPurchase
            {
                CustomerId = model.CustomerId,
                CarId = model.CarId
            };

            await _context.CustomerPurchases.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<CustomerPurchaseListItem>> GetCustomerPurchases()
        {
            return await _context.CustomerPurchases.Include(cp => cp.Customer)
                                                    .Include(cp => cp.PurchasedCar)
                                                    .Select(cp => new CustomerPurchaseListItem
                                                    {
                                                        CustomerFirstName = cp.Customer.FirstName,
                                                        CustomerLastName = cp.Customer.LastName,
                                                        CarLotAddress = cp.PurchasedCar.CarLot.Address,
                                                        CarName = cp.PurchasedCar.Model
                                                    }).ToListAsync();
        }
    }
}

