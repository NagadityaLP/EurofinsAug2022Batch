
namespace AirlineManagementSystemExercise.Entities
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int CityCode { get; set; }
        public Country Country { get; set; }

    }
}
