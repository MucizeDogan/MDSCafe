using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_add_contactMe_new_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterTitle",
                table: "ContactMes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpenDays",
                table: "ContactMes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpenDaysDescription",
                table: "ContactMes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpenHours",
                table: "ContactMes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterTitle",
                table: "ContactMes");

            migrationBuilder.DropColumn(
                name: "OpenDays",
                table: "ContactMes");

            migrationBuilder.DropColumn(
                name: "OpenDaysDescription",
                table: "ContactMes");

            migrationBuilder.DropColumn(
                name: "OpenHours",
                table: "ContactMes");
        }
    }
}
