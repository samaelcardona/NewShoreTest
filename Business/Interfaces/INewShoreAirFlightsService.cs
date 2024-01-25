using NewShoreTest.Models.BusinessModels;

namespace NewShoreTest.Business.Interfaces
{
    public interface INewShoreAirFlightsService
    {
        Task<List<FlightApi>> GetFlightsExternalService();
    }
}
