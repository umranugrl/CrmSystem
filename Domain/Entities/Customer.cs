using System;
using System.Collections.Generic;

namespace crmSystem.Domain.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation Properties
        public ICollection<Interaction> Interactions { get; set; }
        public ICollection<Opportunity> Opportunities { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}