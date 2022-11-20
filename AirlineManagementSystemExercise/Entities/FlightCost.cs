

namespace AirlineManagementSystemExercise.Entities
{
    public class FlightCost
    {
        public int FlightCostID { get; set; }   
        public int CostPerSeat { get; set; }
        public int CurrencyCode { get; set; }
        public FlightClass FlightClass { get; set; }
        public FlightRoute FlightRoute { get; set; }
    }
}
