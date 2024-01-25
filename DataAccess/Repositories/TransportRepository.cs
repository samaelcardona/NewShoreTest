using Microsoft.EntityFrameworkCore;
using NewShoreTest.DataAccess.Context;
using NewShoreTest.DataAccess.IRepositories;
using NewShoreTest.Models.DataAccessModels;

namespace NewShoreTest.DataAccess.Repositories
{
    public class TransportRepository : ITransportRepository
    {

        private readonly NewShoreTestContext dbContext;

        public TransportRepository(NewShoreTestContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Transport GetTransportById(int transportId)
        {
            var transport = dbContext.Transports.Find(transportId);
            return transport != null ? transport : new Transport();
        }

        public Transport? GetTransportByCarrierNumber(string flightCarrier, string flightNumber)
        {
            var transport = dbContext.Transports.Where(t => t.FlightCarrier.Equals(flightCarrier) && t.FlightNumber.Equals(flightNumber)).FirstOrDefault();
            return transport != null ? transport : null;
        }

        public int AddTransport(Transport transport)
        {
            dbContext.Transports.Add(transport);
            dbContext.SaveChanges();
            return transport.TransportId;
        }

        public void UpdateTransport(Transport transport)
        {
            dbContext.Entry(transport).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void DeleteTransport(int transportId)
        {
            var transportToDelete = dbContext.Transports.Find(transportId);
            if (transportToDelete != null)
            {
                dbContext.Transports.Remove(transportToDelete);
                dbContext.SaveChanges();
            }
        }

    }
}
