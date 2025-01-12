using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBook.Migrations
{
    /// <inheritdoc />
    public partial class ContactTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "_code",
                table: "contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_code",
                table: "contacts");
        }
    }
}
