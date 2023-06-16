using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FranksCarLot.Data.Entities
{
    public class CustomerPurchase
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
   
        public virtual Customer Customer { get; set; }

        public string CarId { get; set; }

        [ForeignKey(nameof(CarId))]
     
        public virtual Car PurchasedCar { get; set; }
    }
}