using Microsoft.EntityFrameworkCore;
using NewShoreTest.Models.DataAccessModels;

namespace NewShoreTest.DataAccess.Interfaces
{
    public interface IJourneyRepository
    {
        Journey GetJourneyById(int journeyId);

        Journey? GetJourneyByOriginAndDestination(string origin, string destination);

        int AddJourney(Journey journey);

        void AddJourneyFlight(JourneyFlight journeyFlight);

        void UpdateJourney(Journey journey);

        void DeleteJourney(int journeyId);
    }
}
