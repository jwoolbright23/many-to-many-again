using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingEventsMVC.Migrations
{
    public partial class MoreMigrations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Events_EventId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventId",
                table: "Events",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Events_EventId",
                table: "Events",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
