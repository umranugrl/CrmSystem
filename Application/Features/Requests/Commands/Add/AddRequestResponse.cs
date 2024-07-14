namespace Application.Features.Requests.Commands.Add
{
    public class AddRequestResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string RequestType { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}