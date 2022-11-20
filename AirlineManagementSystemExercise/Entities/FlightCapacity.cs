
using System.ComponentModel.DataAnnotations;

namespace AirlineManagementSystemExercise.Entities
{
    public class FlightCapacity
    {
        [Key]
        public int FlightCapacityId { get; set; }
        public int FlightClassID { get; set; }
        public int TotalSeats { get; set; }
        //public Flight Flight { get; set; }
    }
}
