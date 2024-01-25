using NewShoreTest.Models.ApiModels;

namespace NewShoreTest.Business.Interfaces
{
    public interface IJourneyService
    {
        ResponseObj GetJourneyReponse(string origin, string destination);
    }
}
