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
                new Customer { Id = 1, Name = "Ahmet Yılmaz", Email = "ahmet.yilmaz@ornek.com", Phone = "1234567890", Address = "123 Ana Cad." },
                new Customer { Id = 2, Name = "Ayşe Kaya", Email = "ayse.kaya@ornek.com", Phone = "0987654321", Address = "456 Meşe Sok." },
                new Customer { Id = 3, Name = "Ali Vural", Email = "ali.vural@ornek.com", Phone = "1111111111", Address = "789 Çam Yolu" },
                new Customer { Id = 4, Name = "Zeynep Demir", Email = "zeynep.demir@ornek.com", Phone = "2222222222", Address = "321 Karaağaç Cd." },
                new Customer { Id = 5, Name = "Mehmet Kara", Email = "mehmet.kara@ornek.com", Phone = "3333333333", Address = "654 Akçaağaç Sk." }
            );

            modelBuilder.Entity<Interaction>().HasData(
                new Interaction { Id = 1, CustomerId = 1, InteractionType = "E-posta", Date = DateTime.Now.AddDays(-10), Details = "İlk temas" },
                new Interaction { Id = 2, CustomerId = 2, InteractionType = "Telefon", Date = DateTime.Now.AddDays(-5), Details = "Takip çağrısı" },
                new Interaction { Id = 3, CustomerId = 3, InteractionType = "Toplantı", Date = DateTime.Now.AddDays(-3), Details = "Ürün tanıtımı" },
                new Interaction { Id = 4, CustomerId = 4, InteractionType = "E-posta", Date = DateTime.Now.AddDays(-7), Details = "Fiyat müzakeresi" },
                new Interaction { Id = 5, CustomerId = 5, InteractionType = "Telefon", Date = DateTime.Now.AddDays(-2), Details = "Sözleşme görüşmesi" }
            );

            modelBuilder.Entity<Opportunity>().HasData(
                new Opportunity { Id = 1, CustomerId = 1, OpportunityName = "Yeni Proje", EstimatedValue = 10000m, Status = "Açık", Description = "Yeni yazılım projesi" },
                new Opportunity { Id = 2, CustomerId = 2, OpportunityName = "Danışmanlık Hizmeti", EstimatedValue = 5000m, Status = "Kapalı", Description = "İşletme için danışmanlık hizmetleri" },
                new Opportunity { Id = 3, CustomerId = 3, OpportunityName = "Ürün Satışı", EstimatedValue = 15000m, Status = "Açık", Description = "Yazılım ürünü satışı" },
                new Opportunity { Id = 4, CustomerId = 4, OpportunityName = "Bakım Anlaşması", EstimatedValue = 7000m, Status = "Açık", Description = "Yıllık bakım anlaşması" },
                new Opportunity { Id = 5, CustomerId = 5, OpportunityName = "Yazılım Geliştirme", EstimatedValue = 20000m, Status = "Kapalı", Description = "Özel yazılım geliştirme" }
            );

            modelBuilder.Entity<Request>().HasData(
                new Request { Id = 1, CustomerId = 1, RequestType = "Destek", Details = "Teknik destek gerekli", Status = "Açık" },
                new Request { Id = 2, CustomerId = 2, RequestType = "Soru", Details = "Ürün hakkında soru", Status = "Kapalı" },
                new Request { Id = 3, CustomerId = 3, RequestType = "Şikayet", Details = "Hizmet memnuniyetsizliği", Status = "Açık" },
                new Request { Id = 4, CustomerId = 4, RequestType = "Geri Bildirim", Details = "Hizmet hakkında olumlu geri bildirim", Status = "Kapalı" },
                new Request { Id = 5, CustomerId = 5, RequestType = "Teklif Talebi", Details = "Yeni proje için teklif talebi", Status = "Açık" }
            );

        }
    }
}