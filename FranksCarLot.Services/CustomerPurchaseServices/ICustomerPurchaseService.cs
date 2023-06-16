using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.API.FranksCarLot.Modeles.CustomerPurchaseModeles;
using FranksCarLot.Data.Entities;
using FranksCarLot.Modeles.CustomerPurchaseModeles;

namespace FranksCarLot.Services.CustomerPurchaseServices
{
    public interface ICustomerPurchaseService
    {
          Task<bool> AddPurchase(CustomerPurchaseCreate model);
          Task<List<CustomerPurchaseListItem>> GetCustomerPurchases();
    }
}