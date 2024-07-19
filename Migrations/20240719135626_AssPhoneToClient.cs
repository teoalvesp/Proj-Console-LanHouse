using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proj_Console_LanHause.Migrations
{
    /// <inheritdoc />
    public partial class AssPhoneToClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clients");
        }
    }
}
