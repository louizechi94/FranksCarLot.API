using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FranksCarLot.Data.Context
{
    public class FranksDbContext: DbContext
    {
        public FranksDbContext(DbContextOptions<FranksDbContext>options):base(options)
        {
            
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarLot> CarLots { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPurchase> CustomerPurchases { get; set; }
    }
}