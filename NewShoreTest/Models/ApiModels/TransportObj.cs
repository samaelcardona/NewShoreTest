namespace NewShoreTest.Models.ApiModels
{
    public class TransportObj
    {
        public string FlightCarrier { get; set; } = null!;

        public string FlightNumber { get; set; } = null!;

        public TransportObj(string FlightCarrier, string FlightNumber)
        {
           this.FlightCarrier= FlightCarrier;
           this.FlightNumber= FlightNumber;
        }
    }
}
