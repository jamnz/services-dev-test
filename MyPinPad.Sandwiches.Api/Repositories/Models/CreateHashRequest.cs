namespace MyPinPad.Sandwiches.Api.Repositories.Models
{
    public class CreateHashRequest
    {
        public string Message { get; set; }
        public string Salt { get; set; }
        public string Algorithm { get; set; }
    }
}
