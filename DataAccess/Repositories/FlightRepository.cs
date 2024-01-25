using Microsoft.EntityFrameworkCore;
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

        public Flight GetFlightById(int flightId)
        {
            var flight = dbContext.Flights.Find(flightId);
            return flight != null ? flight : new Flight();
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

        public void UpdateFlight(Flight flight)
        {
            dbContext.Entry(flight).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void DeleteFlight(int flightId)
        {
            var flightToDelete = dbContext.Flights.Find(flightId);
            if (flightToDelete != null)
            {
                dbContext.Flights.Remove(flightToDelete);
                dbContext.SaveChanges();
            }
        }

    }
}
