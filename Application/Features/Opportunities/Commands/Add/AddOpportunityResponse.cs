namespace Application.Features.Opportunities.Commands.Add
{
    public class AddOpportunityResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OpportunityName { get; set; }
        public string Description { get; set; }
        public decimal EstimatedValue { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}