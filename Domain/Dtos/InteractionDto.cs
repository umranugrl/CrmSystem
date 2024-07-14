using System;

namespace crmSystem.Domain.DTOs
{
    public class InteractionDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string InteractionType { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
    }
}