using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FranksCarLot.Data.Entities
{
    public class Car
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        
        [Required]
        public DateTime Year { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Make { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Model { get; set; } = string.Empty;

        public int CarLotId { get; set; }

        [ForeignKey(nameof(CarLotId))]
        public virtual CarLot CarLot { get; set; }
    }
}