using NewShoreTest.Business.ExternalServices;
using NewShoreTest.Business.Interfaces;
using NewShoreTest.Business.Ports;
using NewShoreTest.Models.ApiModels;
using NewShoreTest.Models.BusinessModels;

namespace NewShoreTest.Business.Services
{
    public class FlightService : IFlightService
    {
        private readonly INewShoreAirFlightsService newShoreAirFlightsService;
        
        public FlightService(INewShoreAirFlightsService newShoreAirFlightsService)
        {
            this.newShoreAirFlightsService = newShoreAirFlightsService;
        }

        #region public methods

        public List<FlightObj> GetFlightsToDestination(string origin, string destination) 
        {
            try
            {
               List<FlightApi> flights = newShoreAirFlightsService.GetFlightsExternalService().Result;

               Dictionary<string, List<FlightApi>> originDestinations = this.CreateGraph(flights);

               List<string> route = this.GetShortestRoute(originDestinations, origin, destination);

               List<FlightApi> flightsApi = this.GetFlightsWithRoute(route, flights);

               return this.MapFlights(flightsApi);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
        
        #endregion

        #region private methods

        private Dictionary<string, List<FlightApi>> CreateGraph(List<FlightApi> flights)
        {
            try
            {
                Dictionary<string, List<FlightApi>> originDestinations;
                originDestinations = new Dictionary<string, List<FlightApi>>();

                foreach (var flight in flights)
                {
                    if (!originDestinations.ContainsKey(flight.DepartureStation))
                    {
                        originDestinations[flight.DepartureStation] = new List<FlightApi>();
                    }

                    originDestinations[flight.DepartureStation].Add(flight);
                }

                return originDestinations;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        private List<string> GetShortestRoute(Dictionary<string, List<FlightApi>> originDestinations, string origin, string destination)
        {
            try
            {
                Dictionary<string, string> parent = new Dictionary<string, string>();
                Queue<string> queue = new Queue<string>();
                HashSet<string> visited = new HashSet<string>();

                queue.Enqueue(origin);
                visited.Add(origin);

                while (queue.Count > 0)
                {
                    string current = queue.Dequeue();

                    if (originDestinations.ContainsKey(current))
                    {
                        foreach (var flight in originDestinations[current])
                        {
                            string neighbor = flight.ArrivalStation;

                            if (!visited.Contains(neighbor))
                            {
                                parent[neighbor] = current;
                                queue.Enqueue(neighbor);
                                visited.Add(neighbor);
                            }
                        }
                    }
                }

                return GetRoute(parent, origin, destination);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        private List<string> GetRoute(Dictionary<string, string> parent, string origin, string destination)
        {
            try
            {
                List<string> route = new List<string>();

                if (!parent.ContainsKey(destination))
                {
                    return route;
                }

                string current = destination;
                while (current != origin)
                {
                    route.Add(current);
                    current = parent[current];
                }

                route.Add(origin);
                route.Reverse();

                return route;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        private List<FlightApi> GetFlightsWithRoute(List<string> route, List<FlightApi> flights)
        {
            try
            {
                List < FlightApi > flightsRoute = new List<FlightApi>();
            
                if (route.Count<1)
                {
                    return flightsRoute;
                }

                for (int i = 0; i < (route.Count-1); i++)
                {
                    string origin = route[i];
                    string destination = route[i + 1];
                    var flight = flights.Where(f => f.DepartureStation.Equals(origin) && f.ArrivalStation.Equals(destination)).FirstOrDefault();
                    flightsRoute.Add(flight != null ? flight: throw new Exception($"Error: route don't exist"));
                }

                return flightsRoute;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        private List<FlightObj> MapFlights(List<FlightApi> flights)
        {
            return flights.Select(f => new FlightObj
            {
                Transport = new TransportObj(f.FlightCarrier,f.FlightNumber),
                Origin = f.DepartureStation,
                Destination = f.ArrivalStation,
                Price = f.Price
            }).ToList();
        }
        
        #endregion

    }
}
