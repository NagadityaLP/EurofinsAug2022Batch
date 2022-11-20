

using System;

namespace AirlineManagementSystemExercise.Entities
{
    public class FlightRoute
    {
        public int FlightRouteID { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int FlightDurationInMin { get; set; }
        public Flight Flight { get; set; }
        public FlightSchedule FlightSchedule { get; set; }
        public Route Route { get; set; }
    }
}
