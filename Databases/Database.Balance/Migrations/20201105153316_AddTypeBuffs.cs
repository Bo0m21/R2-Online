using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class AddTypeBuffs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "incSilver",
                table: "Items",
                newName: "IncSilver");

            migrationBuilder.RenameColumn(
                name: "incExp",
                table: "Items",
                newName: "IncExp");

            migrationBuilder.RenameColumn(
                name: "incDrop",
                table: "Items",
                newName: "IncDrop");

            migrationBuilder.RenameColumn(
                name: "incSilver",
                table: "Buffs",
                newName: "IncSilver");

            migrationBuilder.RenameColumn(
                name: "incExp",
                table: "Buffs",
                newName: "IncExp");

            migrationBuilder.RenameColumn(
                name: "incDrop",
                table: "Buffs",
                newName: "IncDrop");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Buffs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Buffs");

            migrationBuilder.RenameColumn(
                name: "IncSilver",
                table: "Items",
                newName: "incSilver");

            migrationBuilder.RenameColumn(
                name: "IncExp",
                table: "Items",
                newName: "incExp");

            migrationBuilder.RenameColumn(
                name: "IncDrop",
                table: "Items",
                newName: "incDrop");

            migrationBuilder.RenameColumn(
                name: "IncSilver",
                table: "Buffs",
                newName: "incSilver");

            migrationBuilder.RenameColumn(
                name: "IncExp",
                table: "Buffs",
                newName: "incExp");

            migrationBuilder.RenameColumn(
                name: "IncDrop",
                table: "Buffs",
                newName: "incDrop");
        }
    }
}
