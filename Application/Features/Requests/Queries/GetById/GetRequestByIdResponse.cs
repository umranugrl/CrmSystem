namespace Application.Features.Requests.Queries.GetById
{
    public class GetRequestByIdResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string RequestType { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
    }
}