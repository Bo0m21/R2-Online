using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class AddItemParams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddDDvWhenCritical",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AddMDvWhenCritical",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AddRDvWhenCritical",
                table: "Items");

            migrationBuilder.AddColumn<short>(
                name: "CriticalProtect",
                table: "Items",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "DDvCriticalAdd",
                table: "Items",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "DDvCriticalRemove",
                table: "Items",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "HumanKiller",
                table: "Items",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "HumanProtect",
                table: "Items",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "MobKiller",
                table: "Items",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "MobProtect",
                table: "Items",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriticalProtect",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DDvCriticalAdd",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DDvCriticalRemove",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HumanKiller",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HumanProtect",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MobKiller",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MobProtect",
                table: "Items");

            migrationBuilder.AddColumn<short>(
                name: "AddDDvWhenCritical",
                table: "Items",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "AddMDvWhenCritical",
                table: "Items",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "AddRDvWhenCritical",
                table: "Items",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
