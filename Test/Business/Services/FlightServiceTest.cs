using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewShoreTest.Business.Interfaces;
using NewShoreTest.Business.Ports;
using NewShoreTest.Business.Services;
using NewShoreTest.Models.ApiModels;
using NewShoreTest.Models.BusinessModels;

namespace NewShoreTest.Test.Business.Services
{
    [TestClass]
    public class FlightServiceTest
    {
        #region Dependencies

        // Example:
        private Mock<INewShoreAirFlightsService> newShoreAirFlightsServiceMock;
        private IFlightService flightService;

        #endregion

        #region Test Initialization and Clean Up

        [TestInitialize]
        public void TestInitialize()
        {
            newShoreAirFlightsServiceMock = new Mock<INewShoreAirFlightsService>();
            this.flightService = new FlightService(newShoreAirFlightsServiceMock.Object);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void GetFlightsToDestinationTest()
        {
            #region Arrange

            string origin = "MZL";
            string destination = "BCN";

            List<FlightApi> fligtsReponse = new List<FlightApi>
            {
                new FlightApi
                {
                    DepartureStation = "MZL",
                    ArrivalStation  = "MDE",
                    FlightCarrier = "CO",
                    FlightNumber = "8001",
                    Price = 200
                },
                new FlightApi
                {
                    DepartureStation = "MDE",
                    ArrivalStation  = "BCN",
                    FlightCarrier = "CO",
                    FlightNumber = "8004",
                    Price = 500
                }
            };

            Task<List<FlightApi>> taskWithData = Task.FromResult(fligtsReponse);

            newShoreAirFlightsServiceMock
                .Setup(x => x.GetFlightsExternalService())
                .Returns(taskWithData);

            #endregion

            #region Act

            List<FlightObj> flights = flightService.GetFlightsToDestination(origin, destination);

            #endregion

            #region Assert

            Assert.AreEqual(2, flights.Count);
           // Assert.AreEqual(segmentId, result.Variables[0].SegmentId);
           //Assert.IsNotNull(result.Variables[0].Indicators);

            #endregion
        }

        #endregion
    }
}
