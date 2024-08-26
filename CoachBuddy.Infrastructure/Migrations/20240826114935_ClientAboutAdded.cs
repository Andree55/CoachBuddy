using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachBuddy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClientAboutAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Clients");
        }
    }
}
