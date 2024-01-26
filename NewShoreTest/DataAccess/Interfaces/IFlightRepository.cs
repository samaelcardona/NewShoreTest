using NewShoreTest.Models.DataAccessModels;

namespace NewShoreTest.DataAccess.Interfaces
{
    public interface IFlightRepository
    {
        List<Flight> GetFlightByJouney(int journeyId);

        int AddFlight(Flight flight);
    }
}
