using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class fixAdressInModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
