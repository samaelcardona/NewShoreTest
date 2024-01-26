namespace NewShoreTest.Models.BusinessModels
{
    public class FlightApi
    {
        public string DepartureStation { get; set; } = null!;

        public string ArrivalStation { get; set; } = null!;

        public string FlightCarrier { get; set; } = null!;

        public string FlightNumber { get; set; } = null!;

        public int Price { get; set; }

    }
}
