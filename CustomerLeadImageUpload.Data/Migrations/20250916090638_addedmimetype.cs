using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerLeadImageUpload.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedmimetype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "CustomerImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "CustomerImage");
        }
    }
}
