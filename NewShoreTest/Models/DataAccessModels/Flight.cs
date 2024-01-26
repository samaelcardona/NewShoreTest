namespace NewShoreTest.Models.DataAccessModels;

public partial class Flight
{
    public int FlightId { get; set; }

    public int TransportId { get; set; }

    public string Origin { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<JourneyFlight> JourneyFlights { get; set; } = new List<JourneyFlight>();

    public Flight()
    {

    }

    public Flight(int transportId, string origin, string destination, int price)
    {
        TransportId = transportId;
        Origin = origin;
        Destination = destination;
        Price = price;
    }
}
