using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<int>(nullable: false),
                    X = table.Column<float>(nullable: false),
                    Z = table.Column<float>(nullable: false),
                    Y = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<int>(nullable: false),
                    Level = table.Column<short>(nullable: false),
                    DDv = table.Column<int>(nullable: false),
                    MDv = table.Column<int>(nullable: false),
                    RDv = table.Column<int>(nullable: false),
                    DPv = table.Column<int>(nullable: false),
                    MPv = table.Column<int>(nullable: false),
                    RPv = table.Column<int>(nullable: false),
                    Dhit = table.Column<int>(nullable: false),
                    DDd = table.Column<int>(nullable: false),
                    Rhit = table.Column<int>(nullable: false),
                    RDd = table.Column<int>(nullable: false),
                    Mhit = table.Column<int>(nullable: false),
                    MDd = table.Column<int>(nullable: false),
                    Str = table.Column<short>(nullable: false),
                    Dex = table.Column<short>(nullable: false),
                    Int = table.Column<short>(nullable: false),
                    HpMax = table.Column<short>(nullable: false),
                    HpRegen = table.Column<short>(nullable: false),
                    MpMax = table.Column<short>(nullable: false),
                    MpRegen = table.Column<short>(nullable: false),
                    WeightMax = table.Column<short>(nullable: false),
                    AttackRate = table.Column<short>(nullable: false),
                    MoveRate = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DDv = table.Column<int>(nullable: false),
                    MDv = table.Column<int>(nullable: false),
                    RDv = table.Column<int>(nullable: false),
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
                    AddDDvWhenCritical = table.Column<short>(nullable: false),
                    AddMDvWhenCritical = table.Column<short>(nullable: false),
                    AddRDvWhenCritical = table.Column<short>(nullable: false),
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
                    Weight = table.Column<short>(nullable: false),
                    WeightMax = table.Column<short>(nullable: false),
                    MaxStack = table.Column<int>(nullable: false),
                    AttackRate = table.Column<short>(nullable: false),
                    AttackRateWhenTransform = table.Column<short>(nullable: false),
                    MoveRate = table.Column<short>(nullable: false),
                    MoveRateWhenTransform = table.Column<short>(nullable: false),
                    UseLevel = table.Column<short>(nullable: false),
                    UseDelay = table.Column<long>(nullable: false),
                    UseKnight = table.Column<bool>(nullable: false),
                    UseRanger = table.Column<bool>(nullable: false),
                    UseMagician = table.Column<bool>(nullable: false),
                    UseAssassin = table.Column<bool>(nullable: false),
                    UseSummoner = table.Column<bool>(nullable: false),
                    UseInAttack = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Level = table.Column<short>(nullable: false),
                    Exp = table.Column<int>(nullable: false),
                    Chaotic = table.Column<short>(nullable: false),
                    DDv = table.Column<int>(nullable: false),
                    MDv = table.Column<int>(nullable: false),
                    RDv = table.Column<int>(nullable: false),
                    DPv = table.Column<int>(nullable: false),
                    MPv = table.Column<int>(nullable: false),
                    RPv = table.Column<int>(nullable: false),
                    Dhit = table.Column<int>(nullable: false),
                    DDd = table.Column<int>(nullable: false),
                    Rhit = table.Column<int>(nullable: false),
                    RDd = table.Column<int>(nullable: false),
                    Mhit = table.Column<int>(nullable: false),
                    MDd = table.Column<int>(nullable: false),
                    AttackRate = table.Column<short>(nullable: false),
                    MoveRate = table.Column<short>(nullable: false),
                    Hp = table.Column<short>(nullable: false),
                    HpRegen = table.Column<short>(nullable: false),
                    Mp = table.Column<short>(nullable: false),
                    MpRegen = table.Column<short>(nullable: false),
                    IsAggression = table.Column<bool>(nullable: false),
                    IsAggressionTransformation = table.Column<bool>(nullable: false),
                    DistanceAggression = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitDrops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    CountFrom = table.Column<int>(nullable: false),
                    CountTo = table.Column<int>(nullable: false),
                    Percent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitDrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitDrops_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitDrops_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(nullable: false),
                    X = table.Column<float>(nullable: false),
                    Z = table.Column<float>(nullable: false),
                    Y = table.Column<float>(nullable: false),
                    DirectionSight = table.Column<float>(nullable: false),
                    Respawn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitPositions_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPositions_Class",
                table: "CharacterPositions",
                column: "Class",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Class_Level",
                table: "Characters",
                columns: new[] { "Class", "Level" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemId",
                table: "Items",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitDrops_ItemId",
                table: "UnitDrops",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitDrops_UnitId",
                table: "UnitDrops",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitPositions_UnitId",
                table: "UnitPositions",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitId",
                table: "Units",
                column: "UnitId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterPositions");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "UnitDrops");

            migrationBuilder.DropTable(
                name: "UnitPositions");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
