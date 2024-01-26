using NewShoreTest.Models.ApiModels;

namespace NewShoreTest.Business.Ports
{
    public interface IFlightService
    {
        List<FlightObj> GetFlightsToDestination(string origin, string destination);
    }
}
