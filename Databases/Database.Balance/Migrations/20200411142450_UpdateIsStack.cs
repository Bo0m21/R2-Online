using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class UpdateIsStack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStack",
                table: "ItemEquips",
                nullable: false,
                defaultValue: false);

            migrationBuilder.Sql("UPDATE ItemEquips SET IsStack = 1 WHERE MaxStack > 1");

            migrationBuilder.DropColumn(
                name: "MaxStack",
                table: "ItemEquips");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxStack",
                table: "ItemEquips",
                type: "int",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.Sql("UPDATE ItemEquips SET MaxStack = 1");

            migrationBuilder.Sql("UPDATE ItemEquips SET MaxStack = 2000000000 WHERE IsStack = 0");

            migrationBuilder.DropColumn(
                name: "IsStack",
                table: "ItemEquips");
        }
    }
}
