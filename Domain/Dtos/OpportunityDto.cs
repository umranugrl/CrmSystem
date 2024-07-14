using System;

namespace crmSystem.Domain.DTOs
{
    public class OpportunityDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OpportunityName { get; set; }
        public string Description { get; set; }
        public decimal EstimatedValue { get; set; }
        public string Status { get; set; }
    }
}