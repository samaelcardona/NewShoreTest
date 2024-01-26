namespace NewShoreTest.Models.ApiModels
{
    public class ResponseObj
    {
        public JourneyObj Journey { get; set; } = null!;

        public ResponseObj(JourneyObj journey)
        {
            Journey = journey;
        }
    }
}
