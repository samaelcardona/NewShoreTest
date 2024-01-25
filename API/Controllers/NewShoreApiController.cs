using Microsoft.AspNetCore.Mvc;
using NewShoreTest.Business.Interfaces;
using NewShoreTest.Models.ApiModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewShoreTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewShoreApiController : ControllerBase
    {
        private readonly ILogger<NewShoreApiController> logger;
        private readonly IJourneyService journeyService;

        public NewShoreApiController(ILogger<NewShoreApiController> logger, IJourneyService journeyService)
        {
            this.logger = logger;
            this.journeyService = journeyService;
        }

        /// <summary>
        /// Get Journey.
        /// </summary>
        /// <remarks>
        /// Request example:
        ///
        ///     PUT /api/NewShoreApi
        ///     {
        ///         "origin": "MZL",
        ///         "destination": "BCN"
        ///     }
        ///
        /// </remarks>
        /// <param name="origin">Origin</param>
        /// <param name="detination">Destination</param>
        /// <returns>Journey with flights</returns>
        [HttpPut]
        public IActionResult Put([FromBody] RequestObj request)
        {
            try
            {
                this.logger.LogInformation($"PUT request received with this request - Origin: {request.Origin} - Destination: {request.Destination}");

                ResponseObj response = journeyService.GetJourneyReponse(request.Origin, request.Destination);

                if (response.Journey.Flights.Count>0)
                {
                    this.logger.LogInformation($"Request ok - {response}");
                    return Ok(new { Message = "Request ok", Data = response }); ;
                }
                else
                {
                    this.logger.LogError($"Your request cannot be processed - Origin: {request.Origin} - Destination: {request.Destination}");
                    return UnprocessableEntity(new { Message = "Your request cannot be processed" });
                }
            }
            catch (Exception ex)
            {
                var problemDetails = new ProblemDetails
                {
                    Status = 500,
                    Title = "Internal Server Error",
                    Detail = "An error occurred on the server while processing the request.",
                    Instance = HttpContext.Request.Path
                };

                problemDetails.Extensions["ExceptionMessage"] = ex.Message;

                this.logger.LogError($"Your request cannot be processed (Internal Server Error) - Origin: {request.Origin} - Destination: {request.Destination} - Error Message: {ex.Message}");

                return StatusCode(500, problemDetails);
            }

        }

    }
}
