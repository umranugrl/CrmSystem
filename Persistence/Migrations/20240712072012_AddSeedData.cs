using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedDate", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John Doe", "1234567890" },
                    { 2, "456 Oak Ave", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane Smith", "0987654321" },
                    { 3, "789 Pine Rd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.johnson@example.com", "Alice Johnson", "1111111111" },
                    { 4, "321 Elm St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob Brown", "2222222222" },
                    { 5, "654 Maple Dr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie.green@example.com", "Charlie Green", "3333333333" }
                });

            migrationBuilder.InsertData(
                table: "Interactions",
                columns: new[] { "Id", "CustomerId", "Date", "Details", "InteractionType" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 2, 10, 20, 10, 108, DateTimeKind.Local).AddTicks(5072), "Initial contact", "Email" },
                    { 2, 2, new DateTime(2024, 7, 7, 10, 20, 10, 108, DateTimeKind.Local).AddTicks(5122), "Follow-up call", "Phone" },
                    { 3, 3, new DateTime(2024, 7, 9, 10, 20, 10, 108, DateTimeKind.Local).AddTicks(5130), "Product demo", "Meeting" },
                    { 4, 4, new DateTime(2024, 7, 5, 10, 20, 10, 108, DateTimeKind.Local).AddTicks(5139), "Price negotiation", "Email" },
                    { 5, 5, new DateTime(2024, 7, 10, 10, 20, 10, 108, DateTimeKind.Local).AddTicks(5146), "Contract discussion", "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Opportunities",
                columns: new[] { "Id", "CustomerId", "Description", "EstimatedValue", "OpportunityName", "Status" },
                values: new object[,]
                {
                    { 1, 1, "New software project", 10000m, "New Project", "Open" },
                    { 2, 2, "Consulting services for business", 5000m, "Consulting Service", "Closed" },
                    { 3, 3, "Selling software product", 15000m, "Product Sale", "Open" },
                    { 4, 4, "Annual maintenance contract", 7000m, "Maintenance Contract", "Open" },
                    { 5, 5, "Custom software development", 20000m, "Software Development", "Closed" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "CustomerId", "Details", "RequestType", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Technical support needed", "Support", "Open" },
                    { 2, 2, "Product inquiry", "Inquiry", "Closed" },
                    { 3, 3, "Service not satisfactory", "Complaint", "Open" },
                    { 4, 4, "Positive feedback on service", "Feedback", "Closed" },
                    { 5, 5, "Need proposal for new project", "Request for Proposal", "Open" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Interactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Interactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Interactions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Interactions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Opportunities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Opportunities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Opportunities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Opportunities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Opportunities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
