using NewShoreTest.DataAccess.Context;
using NewShoreTest.DataAccess.Interfaces;
using NewShoreTest.Models.DataAccessModels;

namespace NewShoreTest.DataAccess.Repositories
{
    public class FlightRepository : IFlightRepository
    {

        private readonly NewShoreTestContext dbContext;

        public FlightRepository(NewShoreTestContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Flight> GetFlightByJouney(int journeyId)
        {
            var flightsId = dbContext.JourneyFlights.Where(jf => jf.JourneyId.Equals(journeyId))
                                                    .Select(jf => jf.FlightId).ToList();
            
            var flights = dbContext.Flights.Where(jf => flightsId.Contains(jf.FlightId)).ToList();

            return flights != null ? flights : new List<Flight>();
        }

        public int AddFlight(Flight flight)
        {
            dbContext.Flights.Add(flight);
            dbContext.SaveChanges();
            return flight.FlightId;
        }
    }
}
