

namespace AirlineManagementSystemExercise.Entities
{
    public class Route
    {
        public int RouteID { get; set; }
        public int FromCityID { get; set; }
        public int ToCityID { get; set; }
        public int DistanceInKms { get; set; }
    }
}
