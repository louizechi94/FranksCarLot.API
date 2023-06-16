using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FranksCarLot.Modeles.CarLotModeles
{
    public class CarLotCreate
    {
        [Required]
        [MaxLength(200)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        // [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}