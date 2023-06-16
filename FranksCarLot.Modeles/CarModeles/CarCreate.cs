using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FranksCarLot.Modeles.CarModeles
{
    public class CarCreate
    {   
        [Required]
        public string Id { get; set; }
        
        [Required]
        public DateTime Year { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Make { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Model { get; set; } = string.Empty;

        [Required]
        public int CarLotId { get; set; }
       
    }
}