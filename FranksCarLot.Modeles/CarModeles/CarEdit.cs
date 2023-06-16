using System.ComponentModel.DataAnnotations;

namespace FranksCarLot.API.FranksCarLot.Modeles.CarModeles
{
    public class CarEdit
    {
        
        [Required]
        public Guid Id { get; set; }
        
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