using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class UpdateUnitDrop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Percent",
                table: "UnitDrops",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "EatTime",
                table: "UnitDrops",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ItemBind",
                table: "UnitDrops",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemStatus",
                table: "UnitDrops",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TermOfEffectivity",
                table: "UnitDrops",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "UseCount",
                table: "UnitDrops",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.Sql("UPDATE ItemEquips SET Type = 0 WHERE Type IS NULL");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "ItemEquips",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EatTime",
                table: "UnitDrops");

            migrationBuilder.DropColumn(
                name: "ItemBind",
                table: "UnitDrops");

            migrationBuilder.DropColumn(
                name: "ItemStatus",
                table: "UnitDrops");

            migrationBuilder.DropColumn(
                name: "TermOfEffectivity",
                table: "UnitDrops");

            migrationBuilder.DropColumn(
                name: "UseCount",
                table: "UnitDrops");

            migrationBuilder.AlterColumn<int>(
                name: "Percent",
                table: "UnitDrops",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "ItemEquips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
