using NewShoreTest.Business.Interfaces;
using NewShoreTest.Business.Ports;
using NewShoreTest.DataAccess.Interfaces;
using NewShoreTest.DataAccess.IRepositories;
using NewShoreTest.Models.ApiModels;
using NewShoreTest.Models.BusinessModels;
using NewShoreTest.Models.DataAccessModels;
using System.Collections.Generic;

namespace NewShoreTest.Business.Services
{
    public class JourneyService : IJourneyService
    {

        private readonly IFlightService flightService;
        private readonly IJourneyRepository journeyRepository;
        private readonly IFlightRepository flightRepository;
        private readonly ITransportRepository transportRepository;

        public JourneyService(IFlightService flightService, 
            IJourneyRepository journeyRepository, 
            IFlightRepository flightRepository,
            ITransportRepository transportRepository)
        {
            this.flightService = flightService;
            this.journeyRepository = journeyRepository;
            this.flightRepository = flightRepository;
            this.transportRepository = transportRepository;
        }

        #region public methods

        public ResponseObj GetJourneyReponse(string origin, string destination)
        {
            try
            {
                return new ResponseObj(this.GetJourney(origin, destination));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        #endregion

        #region private Methods

        private JourneyObj GetJourney(string origin, string destination)
        {
            try
            {
                Journey? journeyDTO = journeyRepository.GetJourneyByOriginAndDestination(origin, destination);

                if (journeyDTO == null)
                {
                    List<FlightObj> flights = flightService.GetFlightsToDestination(origin, destination);

                    JourneyObj journey = new JourneyObj(origin, destination, flights.Sum(f => f.Price), flights);

                    this.SaveJourney(journey);

                    return journey;
                }

                return this.GetMapJourney(journeyDTO);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        private JourneyObj GetMapJourney(Journey journeyDTO)
        {
            try
            {
                List<Flight> flight = flightRepository.GetFlightByJouney(journeyDTO.JourneyId);

                List<FlightObj> flightObjs = flight.Select(f => new FlightObj
                {
                    Transport = this.GetTransportById(f.TransportId),
                    Origin = f.Origin,
                    Destination = f.Destination,
                    Price = f.Price
                }).ToList(); ;

                return new JourneyObj(journeyDTO.Origin, journeyDTO.Destination, journeyDTO.Price, flightObjs);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        private void SaveJourney(JourneyObj journey)
        {
            try
            {
                int journeyId = journeyRepository.AddJourney(new Journey(journey.Origin,journey.Destination,journey.Price));

                foreach (var flight in journey.Flights)
                {   
                    Transport? transport = transportRepository.GetTransportByCarrierNumber(flight.Transport.FlightCarrier, flight.Transport.FlightNumber);
                    int transportId = transport!=null?transport.TransportId:0;
                    
                    if (transport == null)
                    {
                        transportId = transportRepository.AddTransport(new Transport(flight.Transport.FlightCarrier, flight.Transport.FlightNumber));
                    }

                    int flightId = flightRepository.AddFlight(new Flight(transportId, flight.Origin, flight.Destination, flight.Price));

                    journeyRepository.AddJourneyFlight(new JourneyFlight(journeyId, flightId));
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        private TransportObj GetTransportById(int transportId)
        {
            try
            {
                Transport transport = transportRepository.GetTransportById(transportId);
                return new TransportObj(transport.FlightCarrier, transport.FlightNumber);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        #endregion

    }
}
