using Microsoft.EntityFrameworkCore;
using NewShoreTest.Models.DataAccessModels;

namespace NewShoreTest.DataAccess.Interfaces
{
    public interface IFlightRepository
    {
        Flight GetFlightById(int flightId);

        List<Flight> GetFlightByJouney(int journeyId);

        int AddFlight(Flight flight);

        void UpdateFlight(Flight flight);

        void DeleteFlight(int flightId);
    }
}
