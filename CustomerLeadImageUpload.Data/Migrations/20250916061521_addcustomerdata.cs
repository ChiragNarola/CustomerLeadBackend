using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerLeadImageUpload.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcustomerdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


      migrationBuilder.InsertData(
        table: "Customer",
        columns: new[] { "Name", "Email", "ContactNumber", "CreatedAt" },
        values: new object[,]
        {
                { "John Doe", "john.doe@example.com", "1234567890", DateTime.UtcNow },
                { "Jane Smith", "jane.smith@example.com", "2345678901", DateTime.UtcNow },
                { "Michael Johnson", "michael.johnson@example.com", "3456789012", DateTime.UtcNow },
                { "Emily Davis", "emily.davis@example.com", "4567890123", DateTime.UtcNow },
                { "William Brown", "william.brown@example.com", "5678901234", DateTime.UtcNow },
                { "Olivia Wilson", "olivia.wilson@example.com", "6789012345", DateTime.UtcNow },
                { "James Taylor", "james.taylor@example.com", "7890123456", DateTime.UtcNow },
                { "Sophia Anderson", "sophia.anderson@example.com", "8901234567", DateTime.UtcNow },
                { "Benjamin Thomas", "benjamin.thomas@example.com", "9012345678", DateTime.UtcNow },
                { "Ava Martinez", "ava.martinez@example.com", "0123456789", DateTime.UtcNow }
        });

    }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
             table: "Customer",
             keyColumn: "Name",
             keyValues: new object[]
             {
                      "John Doe", "Jane Smith", "Michael Johnson", "Emily Davis", "William Brown",
                      "Olivia Wilson", "James Taylor", "Sophia Anderson", "Benjamin Thomas", "Ava Martinez"
             });
  }
    }
}
