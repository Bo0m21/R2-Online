using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class UpdateAttackType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UnitDrops_ItemId",
                table: "UnitDrops");

            migrationBuilder.AlterColumn<int>(
                name: "AttackDistance",
                table: "Units",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AttackDistance",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UnitDrops_ItemId_UnitId",
                table: "UnitDrops",
                columns: new[] { "ItemId", "UnitId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UnitDrops_ItemId_UnitId",
                table: "UnitDrops");

            migrationBuilder.AlterColumn<int>(
                name: "AttackDistance",
                table: "Units",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttackDistance",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitDrops_ItemId",
                table: "UnitDrops",
                column: "ItemId");
        }
    }
}
