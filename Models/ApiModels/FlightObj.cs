namespace NewShoreTest.Models.ApiModels
{
    public class FlightObj
    {
        public TransportObj Transport { get; set; } = null!;

        public string Origin { get; set; } = null!;

        public string Destination { get; set; } = null!;

        public int Price { get; set; }
    }
}
