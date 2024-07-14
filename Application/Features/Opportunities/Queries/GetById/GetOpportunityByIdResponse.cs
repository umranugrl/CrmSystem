namespace Application.Features.Opportunities.Queries.GetById
{
    public class GetOpportunityByIdResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OpportunityName { get; set; }
        public string Description { get; set; }
        public decimal EstimatedValue { get; set; }
        public string Status { get; set; }
    }
}