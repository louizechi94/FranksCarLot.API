using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FranksCarLot.Data.Entities
{
    public class CarLot
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        //setting up one-to-many relationship, this is the many side...
        public List<Car> CarsOnLot { get; set; } = new List<Car>();
    }
}