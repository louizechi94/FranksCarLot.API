using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranksCarLot.Modeles.CustomerModeles
{
    public class CustomerDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CreditScore { get; set; }
    }
}