using System;

namespace crmSystem.Domain.Entities
{
    public class Request : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string RequestType { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
    }
}