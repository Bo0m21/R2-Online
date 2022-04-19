using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class UpdateDistanceAttack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttackDistance",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "AttackDistance",
                table: "Items");

            migrationBuilder.AddColumn<float>(
                name: "DistanceAttack",
                table: "Units",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DistanceAttack",
                table: "Items",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistanceAttack",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "DistanceAttack",
                table: "Items");

            migrationBuilder.AddColumn<float>(
                name: "AttackDistance",
                table: "Units",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "AttackDistance",
                table: "Items",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
