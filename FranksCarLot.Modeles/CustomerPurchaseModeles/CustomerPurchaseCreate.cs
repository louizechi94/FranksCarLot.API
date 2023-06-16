using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FranksCarLot.Modeles.CustomerPurchaseModeles
{
    public class CustomerPurchaseCreate
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int CarLotId { get; set; }

        [Required]
         public Guid CarId { get; set; }
        
    }
}