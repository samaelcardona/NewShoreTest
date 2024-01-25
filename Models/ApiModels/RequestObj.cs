namespace NewShoreTest.Models.ApiModels
{
    public class RequestObj
    {
        public string Origin { get; set; } = null!;

        public string Destination { get; set; } = null!;

        public RequestObj() { }

        public RequestObj(string origin, string destination)
        {
            this.Origin = origin;
            this.Destination = destination;
        }

    }
}
