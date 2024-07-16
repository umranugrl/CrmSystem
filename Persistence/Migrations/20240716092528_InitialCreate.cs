using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    InteractionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opportunities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OpportunityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opportunities_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedDate", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Ana Cad.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet.yilmaz@ornek.com", "Ahmet Yılmaz", "1234567890" },
                    { 2, "456 Meşe Sok.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.kaya@ornek.com", "Ayşe Kaya", "0987654321" },
                    { 3, "789 Çam Yolu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.vural@ornek.com", "Ali Vural", "1111111111" },
                    { 4, "321 Karaağaç Cd.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynep.demir@ornek.com", "Zeynep Demir", "2222222222" },
                    { 5, "654 Akçaağaç Sk.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.kara@ornek.com", "Mehmet Kara", "3333333333" }
                });

            migrationBuilder.InsertData(
                table: "Interactions",
                columns: new[] { "Id", "CustomerId", "Date", "Details", "InteractionType" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 6, 12, 25, 26, 680, DateTimeKind.Local).AddTicks(1205), "İlk temas", "E-posta" },
                    { 2, 2, new DateTime(2024, 7, 11, 12, 25, 26, 680, DateTimeKind.Local).AddTicks(1239), "Takip çağrısı", "Telefon" },
                    { 3, 3, new DateTime(2024, 7, 13, 12, 25, 26, 680, DateTimeKind.Local).AddTicks(1244), "Ürün tanıtımı", "Toplantı" },
                    { 4, 4, new DateTime(2024, 7, 9, 12, 25, 26, 680, DateTimeKind.Local).AddTicks(1248), "Fiyat müzakeresi", "E-posta" },
                    { 5, 5, new DateTime(2024, 7, 14, 12, 25, 26, 680, DateTimeKind.Local).AddTicks(1251), "Sözleşme görüşmesi", "Telefon" }
                });

            migrationBuilder.InsertData(
                table: "Opportunities",
                columns: new[] { "Id", "CustomerId", "Description", "EstimatedValue", "OpportunityName", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Yeni yazılım projesi", 10000m, "Yeni Proje", "Açık" },
                    { 2, 2, "İşletme için danışmanlık hizmetleri", 5000m, "Danışmanlık Hizmeti", "Kapalı" },
                    { 3, 3, "Yazılım ürünü satışı", 15000m, "Ürün Satışı", "Açık" },
                    { 4, 4, "Yıllık bakım anlaşması", 7000m, "Bakım Anlaşması", "Açık" },
                    { 5, 5, "Özel yazılım geliştirme", 20000m, "Yazılım Geliştirme", "Kapalı" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "CustomerId", "Details", "RequestType", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Teknik destek gerekli", "Destek", "Açık" },
                    { 2, 2, "Ürün hakkında soru", "Soru", "Kapalı" },
                    { 3, 3, "Hizmet memnuniyetsizliği", "Şikayet", "Açık" },
                    { 4, 4, "Hizmet hakkında olumlu geri bildirim", "Geri Bildirim", "Kapalı" },
                    { 5, 5, "Yeni proje için teklif talebi", "Teklif Talebi", "Açık" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_CustomerId",
                table: "Interactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_CustomerId",
                table: "Opportunities",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CustomerId",
                table: "Requests",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interactions");

            migrationBuilder.DropTable(
                name: "Opportunities");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
