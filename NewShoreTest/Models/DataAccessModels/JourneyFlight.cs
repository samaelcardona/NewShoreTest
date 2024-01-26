namespace NewShoreTest.Models.DataAccessModels;

public partial class JourneyFlight
{
    public int JourneyFlightId { get; set; }

    public int JourneyId { get; set; }

    public int FlightId { get; set; }

    public virtual Flight Flight { get; set; } = null!;

    public virtual Journey Journey { get; set; } = null!;

    public JourneyFlight(int journeyId, int flightId)
    {
        JourneyId = journeyId;
        FlightId = flightId;
    }
}
