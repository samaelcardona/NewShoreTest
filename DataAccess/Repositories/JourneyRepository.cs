using Microsoft.EntityFrameworkCore;
using NewShoreTest.DataAccess.Context;
using NewShoreTest.DataAccess.Interfaces;
using NewShoreTest.Models.DataAccessModels;

namespace NewShoreTest.DataAccess.Repositories
{
    public class JourneyRepository : IJourneyRepository
    {
        private readonly NewShoreTestContext dbContext;

        public JourneyRepository(NewShoreTestContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Journey GetJourneyById(int journeyId)
        {
            var journey = dbContext.Journeys.Find(journeyId);
            return journey != null ? journey : new Journey();
        }


        public Journey? GetJourneyByOriginAndDestination(string origin, string destination)
        {
            var journey = dbContext.Journeys.Where(j=> j.Origin.Equals(origin) && j.Destination.Equals(destination)).FirstOrDefault();
            return journey;
        }

        public int AddJourney(Journey journey)
        {
            dbContext.Journeys.Add(journey);
            dbContext.SaveChanges();

            return journey.JourneyId;
        }

        public void AddJourneyFlight(JourneyFlight journeyFlight)
        {
            dbContext.JourneyFlights.Add(journeyFlight);
            dbContext.SaveChanges();
        }

        public void UpdateJourney(Journey journey)
        {
            dbContext.Entry(journey).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void DeleteJourney(int journeyId)
        {
            var journeyToDelete = dbContext.Journeys.Find(journeyId);
            if (journeyToDelete != null)
            {
                dbContext.Journeys.Remove(journeyToDelete);
                dbContext.SaveChanges();
            }
        }
    }
}
