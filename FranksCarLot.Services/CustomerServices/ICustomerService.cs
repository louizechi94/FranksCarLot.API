using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.Modeles.CustomerModeles;

namespace FranksCarLot.Services.CustomerServices
{
    public interface ICustomerService
    {
        Task<bool> AddCustomer(CustomerCreate model);
        Task<bool> UpdateCustomer(CustomerEdit model);
        Task<bool> DeleteCustomer(int id);
        Task<List<CustomerListItem>> GetCustomers();
        Task<CustomerDetail> GetCustomerById(int id);
    }
}