using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class LevelAndReputation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chaotic",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Units");

            migrationBuilder.AddColumn<short>(
                name: "Reputation",
                table: "Units",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reputation",
                table: "Units");

            migrationBuilder.AddColumn<short>(
                name: "Chaotic",
                table: "Units",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Level",
                table: "Units",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
