using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.Data.Context;
using FranksCarLot.Data.Entities;
using FranksCarLot.Modeles.CustomerModeles;
using Microsoft.EntityFrameworkCore;

namespace FranksCarLot.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {   
        //I need to interacte with a database
        private readonly FranksDbContext _context;

        public CustomerService(FranksDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCustomer(CustomerCreate model)
        {
            Customer customer = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                CreditScore = model.CreditScore
            };

            await _context.Customers.AddAsync(customer);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> DeleteCustomer(int id)
        {
           Customer customer = await _context.Customers.FindAsync(id);
           if(customer is null)
           {
            return false;
           }
           //if the customer exist we need to delete it
           _context.Customers.Remove(customer);
           //we need to save 
           await _context.SaveChangesAsync();
           return true;

        }

        public async Task<CustomerDetail> GetCustomerById(int id)
        {
            Customer customer = await _context.Customers.FindAsync(id);
           if(customer is null)
           {
            return new CustomerDetail();
           }
           return new CustomerDetail
           {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            CreditScore = customer.CreditScore
           };
        }

        public async Task<List<CustomerListItem>> GetCustomers()
        {
           List<CustomerListItem> customers = await _context.Customers.Select(c =>
           new CustomerListItem{
            Id = c.Id,
            FirstName =c.FirstName,
            LastName = c.LastName
           }).ToListAsync();
           return customers;
        }

        public async Task<bool> UpdateCustomer(CustomerEdit model)
        {
            Customer customer = await _context.Customers.FindAsync(model.Id);
           if(customer is null)
           {
            return false;
           }
           customer.FirstName = model.FirstName;
           customer.LastName = model.LastName;
           customer.CreditScore = model.CreditScore;
           await _context.SaveChangesAsync();
           return true;
    
        }
    }
}