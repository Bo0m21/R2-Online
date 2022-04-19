using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class UpdateBuffAndMonsterAndItemsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAggressionInvisible",
                table: "Units",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<short>(
                name: "incDrop",
                table: "Items",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "incExp",
                table: "Items",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "incSilver",
                table: "Items",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemovable",
                table: "Buffs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<short>(
                name: "incDrop",
                table: "Buffs",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "incExp",
                table: "Buffs",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "incSilver",
                table: "Buffs",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAggressionInvisible",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "incDrop",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "incExp",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "incSilver",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsRemovable",
                table: "Buffs");

            migrationBuilder.DropColumn(
                name: "incDrop",
                table: "Buffs");

            migrationBuilder.DropColumn(
                name: "incExp",
                table: "Buffs");

            migrationBuilder.DropColumn(
                name: "incSilver",
                table: "Buffs");
        }
    }
}
