using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class UpdateHpMp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hp",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Mp",
                table: "Units");

            migrationBuilder.AddColumn<short>(
                name: "HpMax",
                table: "Units",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "MpMax",
                table: "Units",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HpMax",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "MpMax",
                table: "Units");

            migrationBuilder.AddColumn<short>(
                name: "Hp",
                table: "Units",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Mp",
                table: "Units",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
