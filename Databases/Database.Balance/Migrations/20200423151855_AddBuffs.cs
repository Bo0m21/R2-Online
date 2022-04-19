using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class AddBuffs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuffId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DDvMin = table.Column<int>(nullable: false),
                    DDvMax = table.Column<int>(nullable: false),
                    MDvMin = table.Column<int>(nullable: false),
                    MDvMax = table.Column<int>(nullable: false),
                    RDvMin = table.Column<int>(nullable: false),
                    RDvMax = table.Column<int>(nullable: false),
                    DPv = table.Column<int>(nullable: false),
                    MPv = table.Column<int>(nullable: false),
                    RPv = table.Column<int>(nullable: false),
                    Dhit = table.Column<int>(nullable: false),
                    DDd = table.Column<int>(nullable: false),
                    Rhit = table.Column<int>(nullable: false),
                    RDd = table.Column<int>(nullable: false),
                    Mhit = table.Column<int>(nullable: false),
                    MDd = table.Column<int>(nullable: false),
                    Critical = table.Column<short>(nullable: false),
                    CriticalProtect = table.Column<short>(nullable: false),
                    DDvCriticalAdd = table.Column<short>(nullable: false),
                    DDvCriticalRemove = table.Column<short>(nullable: false),
                    HumanKiller = table.Column<short>(nullable: false),
                    HumanProtect = table.Column<short>(nullable: false),
                    MobKiller = table.Column<short>(nullable: false),
                    MobProtect = table.Column<short>(nullable: false),
                    Str = table.Column<short>(nullable: false),
                    Dex = table.Column<short>(nullable: false),
                    Int = table.Column<short>(nullable: false),
                    Hp = table.Column<short>(nullable: false),
                    HpRegen = table.Column<short>(nullable: false),
                    HpPotionRestore = table.Column<short>(nullable: false),
                    AddPotionRestoreHp = table.Column<short>(nullable: false),
                    AddTransformMaxHp = table.Column<short>(nullable: false),
                    Mp = table.Column<short>(nullable: false),
                    MpRegen = table.Column<short>(nullable: false),
                    MpPotionRestore = table.Column<short>(nullable: false),
                    AddPotionRestoreMp = table.Column<short>(nullable: false),
                    AddTransformMaxMp = table.Column<short>(nullable: false),
                    WeightMax = table.Column<short>(nullable: false),
                    AttackRate = table.Column<short>(nullable: false),
                    AttackRateWhenTransform = table.Column<short>(nullable: false),
                    MoveRate = table.Column<short>(nullable: false),
                    MoveRateWhenTransform = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buffs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buffs_BuffId",
                table: "Buffs",
                column: "BuffId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buffs");
        }
    }
}
