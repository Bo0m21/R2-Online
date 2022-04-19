using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class MinMax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DDv",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "MDv",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "RDv",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "DDv",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MDv",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RDv",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DDv",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MDv",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "RDv",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "DDvMax",
                table: "Units",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DDvMin",
                table: "Units",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MDvMax",
                table: "Units",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MDvMin",
                table: "Units",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RDvMax",
                table: "Units",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RDvMin",
                table: "Units",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DDvMax",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DDvMin",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MDvMax",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MDvMin",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RDvMax",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RDvMin",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DDvMax",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DDvMin",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MDvMax",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MDvMin",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RDvMax",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RDvMin",
                table: "Characters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DDvMax",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "DDvMin",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "MDvMax",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "MDvMin",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "RDvMax",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "RDvMin",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "DDvMax",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DDvMin",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MDvMax",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MDvMin",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RDvMax",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RDvMin",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DDvMax",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "DDvMin",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MDvMax",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MDvMin",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "RDvMax",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "RDvMin",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "DDv",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MDv",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RDv",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DDv",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MDv",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RDv",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DDv",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MDv",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RDv",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
