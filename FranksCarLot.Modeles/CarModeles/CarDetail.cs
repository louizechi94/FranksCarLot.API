using FranksCarLot.Modeles.CarLotModeles;

namespace FranksCarLot.API.FranksCarLot.Modeles.CarModeles
{
    public class CarDetail
    {

        public string Id { get; set; }

        public DateTime Year { get; set; }

        public string Make { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        // VM only talk to VM , NEVER TO DOMAIN OBJ's!!!!!!
        public CarLotListItem CarLot { get; set; } = new CarLotListItem();
    }
}