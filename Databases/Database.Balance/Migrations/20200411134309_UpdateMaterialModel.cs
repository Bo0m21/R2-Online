using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class UpdateMaterialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStack",
                table: "ItemMaterials",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ItemMaterials",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<short>(
                name: "Weight",
                table: "ItemMaterials",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStack",
                table: "ItemMaterials");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ItemMaterials");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "ItemMaterials");
        }
    }
}
