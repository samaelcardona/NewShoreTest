using Azure;
using NewShoreTest.Business.Interfaces;
using NewShoreTest.Models.BusinessModels;
using Newtonsoft.Json;

namespace NewShoreTest.Business.ExternalServices
{
    public class NewShoreAirFlightsService : INewShoreAirFlightsService
    {

        private readonly HttpClient _httpClient;

        public NewShoreAirFlightsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FlightApi>> GetFlightsExternalService()
        {
            try
            {
                string urlNewShoreService = "https://recruiting-api.newshore.es/api/flights/2";
    
                HttpResponseMessage response = await _httpClient.GetAsync(urlNewShoreService);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (content != null)
                    {
                        List<FlightApi>? flights = JsonConvert.DeserializeObject<List<FlightApi>>(content);

                        return flights != null? flights:new  List<FlightApi>();
                    }

                    throw new JsonException($"Error data is empty");
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

    }
}
