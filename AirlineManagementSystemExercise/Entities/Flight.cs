

namespace AirlineManagementSystemExercise.Entities
{
    public class Flight
    {
        public int FlightID { get; set; }   
        public string FlightName { get; set; }  
        public Airline Airline { get; set; }

        public virtual FlightCapacity FlightCapacity { get; set; }  
    }
}
