using System;

namespace crmSystem.Domain.Entities
{
    public class Interaction : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string InteractionType { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
    }
}