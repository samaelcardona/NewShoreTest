using NewShoreTest.Models.DataAccessModels;

namespace NewShoreTest.DataAccess.Interfaces
{
    public interface IJourneyRepository
    {
        Journey? GetJourneyByOriginAndDestination(string origin, string destination);

        int AddJourney(Journey journey);

        void AddJourneyFlight(JourneyFlight journeyFlight);
    }
}
