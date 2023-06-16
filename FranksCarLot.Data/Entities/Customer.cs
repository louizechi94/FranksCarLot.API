using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FranksCarLot.Data.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
        
        [Required]
        public int CreditScore { get; set; }
       
        public bool HasBadCredit 
        {
            get
            {
                if(CreditScore >= 600 && CreditScore <= 800)
                {
                    return false;
                }
                return true;
            }
        }
    }
}