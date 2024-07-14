namespace crmSystem.Domain.DTOs
{
    public class RequestDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string RequestType { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
    }
}