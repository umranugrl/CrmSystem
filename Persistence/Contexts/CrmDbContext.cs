using Microsoft.EntityFrameworkCore;
using crmSystem.Domain.Entities;

namespace crmSystem.Persistence.Contexts
{
    public class CrmDbContext : DbContext
    {
        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Interaction>().ToTable("Interactions");
            modelBuilder.Entity<Opportunity>().ToTable("Opportunities");
            modelBuilder.Entity<Request>().ToTable("Requests");

            // Örnek ilişki tanımlaması
            modelBuilder.Entity<Interaction>()
               .HasOne(i => i.Customer)
               .WithMany(c => c.Interactions)
               .HasForeignKey(i => i.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);

            // Decimal alan için column type belirleme
            modelBuilder.Entity<Opportunity>()
                .Property(o => o.EstimatedValue)
                .HasColumnType("decimal(18,2)"); // Precision ve scale belirleme

            // Seed data ekleme
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Phone = "1234567890", Address = "123 Main St" },
                new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Phone = "0987654321", Address = "456 Oak Ave" },
                new Customer { Id = 3, Name = "Alice Johnson", Email = "alice.johnson@example.com", Phone = "1111111111", Address = "789 Pine Rd" },
                new Customer { Id = 4, Name = "Bob Brown", Email = "bob.brown@example.com", Phone = "2222222222", Address = "321 Elm St" },
                new Customer { Id = 5, Name = "Charlie Green", Email = "charlie.green@example.com", Phone = "3333333333", Address = "654 Maple Dr" }
            );

            modelBuilder.Entity<Interaction>().HasData(
                new Interaction { Id = 1, CustomerId = 1, InteractionType = "Email", Date = DateTime.Now.AddDays(-10), Details = "Initial contact" },
                new Interaction { Id = 2, CustomerId = 2, InteractionType = "Phone", Date = DateTime.Now.AddDays(-5), Details = "Follow-up call" },
                new Interaction { Id = 3, CustomerId = 3, InteractionType = "Meeting", Date = DateTime.Now.AddDays(-3), Details = "Product demo" },
                new Interaction { Id = 4, CustomerId = 4, InteractionType = "Email", Date = DateTime.Now.AddDays(-7), Details = "Price negotiation" },
                new Interaction { Id = 5, CustomerId = 5, InteractionType = "Phone", Date = DateTime.Now.AddDays(-2), Details = "Contract discussion" }
            );

            modelBuilder.Entity<Opportunity>().HasData(
                new Opportunity { Id = 1, CustomerId = 1, OpportunityName = "New Project", EstimatedValue = 10000m, Status = "Open", Description = "New software project" },
                new Opportunity { Id = 2, CustomerId = 2, OpportunityName = "Consulting Service", EstimatedValue = 5000m, Status = "Closed", Description = "Consulting services for business" },
                new Opportunity { Id = 3, CustomerId = 3, OpportunityName = "Product Sale", EstimatedValue = 15000m, Status = "Open", Description = "Selling software product" },
                new Opportunity { Id = 4, CustomerId = 4, OpportunityName = "Maintenance Contract", EstimatedValue = 7000m, Status = "Open", Description = "Annual maintenance contract" },
                new Opportunity { Id = 5, CustomerId = 5, OpportunityName = "Software Development", EstimatedValue = 20000m, Status = "Closed", Description = "Custom software development" }
            );

            modelBuilder.Entity<Request>().HasData(
                new Request { Id = 1, CustomerId = 1, RequestType = "Support", Details = "Technical support needed", Status = "Open" },
                new Request { Id = 2, CustomerId = 2, RequestType = "Inquiry", Details = "Product inquiry", Status = "Closed" },
                new Request { Id = 3, CustomerId = 3, RequestType = "Complaint", Details = "Service not satisfactory", Status = "Open" },
                new Request { Id = 4, CustomerId = 4, RequestType = "Feedback", Details = "Positive feedback on service", Status = "Closed" },
                new Request { Id = 5, CustomerId = 5, RequestType = "Request for Proposal", Details = "Need proposal for new project", Status = "Open" }
            );
        }
    }
}