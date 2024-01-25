namespace NewShoreTest.Models.DataAccessModels;

public partial class Journey
{
    public int JourneyId { get; set; }

    public string Origin { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public int? Price { get; set; }

    public virtual ICollection<JourneyFlight> JourneyFlights { get; set; } = new List<JourneyFlight>();

    public Journey()
    {

    }

    public Journey(string origin, string destination, int? price)
    {
        Origin = origin;
        Destination = destination;
        Price = price;
    }
}
