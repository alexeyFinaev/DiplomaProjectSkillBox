using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomaProjectWebApi.Migrations
{
    public partial class Mymigration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FaceBookText",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstaText",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterText",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhatsAppText",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YoutobeText",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaceBookText",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "InstaText",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "TwitterText",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "WhatsAppText",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "YoutobeText",
                table: "Contacts");
        }
    }
}
