using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FranksCarLot.Data.Entities;

namespace FranksCarLot.Modeles.CustomerPurchaseModeles
{
    public class CustomerPurchaseCreate
    {
        [Required]
        public int CustomerId { get; set; }

        [NotMapped]
        private  Customer Customer { get; set; }= new Customer();

        [Required]
         public string CarId { get; set; }
      
        [NotMapped]
        private Car PurchasedCar { get; set; }= new Car();
    }
}