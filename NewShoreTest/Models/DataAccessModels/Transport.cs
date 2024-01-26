namespace NewShoreTest.Models.DataAccessModels;

public partial class Transport
{
    public int TransportId { get; set; }

    public string FlightCarrier { get; set; } = null!;

    public string FlightNumber { get; set; } = null!;

    public Transport()
    {

    }

    public Transport(string flightCarrier, string flightNumber)
    {
        FlightCarrier = flightCarrier;
        FlightNumber = flightNumber;
    }
}
