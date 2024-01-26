using NewShoreTest.Models.DataAccessModels;

namespace NewShoreTest.DataAccess.IRepositories
{
    public interface ITransportRepository
    {
        Transport GetTransportById(int transportId);

        Transport? GetTransportByCarrierNumber(string flightCarrier, string flightNumber);

        int AddTransport(Transport transport);
    }
}
