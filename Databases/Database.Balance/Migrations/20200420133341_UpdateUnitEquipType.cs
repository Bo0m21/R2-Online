using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class UpdateUnitEquipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ItemEquips");

            migrationBuilder.AddColumn<int>(
                name: "EquipType",
                table: "ItemEquips",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Percent",
                table: "ItemEquips",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipType",
                table: "ItemEquips");

            migrationBuilder.DropColumn(
                name: "Percent",
                table: "ItemEquips");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ItemEquips",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
