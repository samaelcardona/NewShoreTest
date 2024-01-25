namespace NewShoreTest.Models.ApiModels
{
    public class JourneyObj
    {
        public string Origin { get; set; } = null!;

        public string Destination { get; set; } = null!;

        public int? Price { get; set; }

        public List<FlightObj> Flights { get; set; } = null!;

        public JourneyObj(string origin, string destination, int? price, List<FlightObj> flights)
        {
            Origin = origin;
            Destination = destination;
            Price = price;
            Flights = flights;
        }
    }
}
