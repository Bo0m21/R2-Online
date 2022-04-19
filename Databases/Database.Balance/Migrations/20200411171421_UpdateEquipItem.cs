using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class UpdateEquipItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Material1Count",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "Material2Count",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "Material3Count",
                table: "ItemReinforces");

            migrationBuilder.AddColumn<int>(
                name: "ItemEquipNewId",
                table: "ItemReinforces",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemEquipOldId",
                table: "ItemReinforces",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemMaterial1Count",
                table: "ItemReinforces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemMaterial2Count",
                table: "ItemReinforces",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemMaterial3Count",
                table: "ItemReinforces",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_ItemEquipNewId",
                table: "ItemReinforces",
                column: "ItemEquipNewId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_ItemEquipOldId",
                table: "ItemReinforces",
                column: "ItemEquipOldId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReinforces_ItemEquips_ItemEquipNewId",
                table: "ItemReinforces",
                column: "ItemEquipNewId",
                principalTable: "ItemEquips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReinforces_ItemEquips_ItemEquipOldId",
                table: "ItemReinforces",
                column: "ItemEquipOldId",
                principalTable: "ItemEquips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_ItemEquips_ItemEquipNewId",
                table: "ItemReinforces");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_ItemEquips_ItemEquipOldId",
                table: "ItemReinforces");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_ItemEquipNewId",
                table: "ItemReinforces");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_ItemEquipOldId",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "ItemEquipNewId",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "ItemEquipOldId",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "ItemMaterial1Count",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "ItemMaterial2Count",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "ItemMaterial3Count",
                table: "ItemReinforces");

            migrationBuilder.AddColumn<int>(
                name: "Material1Count",
                table: "ItemReinforces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Material2Count",
                table: "ItemReinforces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Material3Count",
                table: "ItemReinforces",
                type: "int",
                nullable: true);
        }
    }
}
