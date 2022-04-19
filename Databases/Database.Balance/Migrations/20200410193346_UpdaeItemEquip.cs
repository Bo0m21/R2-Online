using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class UpdaeItemEquip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable("Items", newName: "ItemEquips");
            migrationBuilder.RenameColumn("ItemId", "UnitDrops", "ItemEquipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("ItemEquipId", "UnitDrops", "ItemId");
            migrationBuilder.RenameTable("ItemEquips", newName: "Items");
        }
    }
}
