using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class UpdateAllDatabaseUnitItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_ItemEquips_ItemEquipId",
                table: "ItemReinforces");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_ItemEquips_ItemEquipNewId",
                table: "ItemReinforces");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_ItemEquips_ItemEquipOldId",
                table: "ItemReinforces");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_ItemMaterials_ItemMaterial1Id",
                table: "ItemReinforces");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_ItemMaterials_ItemMaterial2Id",
                table: "ItemReinforces");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_ItemMaterials_ItemMaterial3Id",
                table: "ItemReinforces");

            migrationBuilder.DropTable(
                name: "UnitEquipDrops");

            migrationBuilder.DropTable(
                name: "UnitMaterialDrops");

            migrationBuilder.DropTable(
                name: "ItemEquips");

            migrationBuilder.DropTable(
                name: "ItemMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_ItemEquipNewId",
                table: "ItemReinforces");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_ItemEquipOldId",
                table: "ItemReinforces");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_ItemMaterial1Id",
                table: "ItemReinforces");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_ItemMaterial2Id",
                table: "ItemReinforces");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_ItemMaterial3Id",
                table: "ItemReinforces");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_ItemEquipId_ItemMaterial1Id_ItemMaterial2Id_ItemMaterial3Id",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "ItemEquipId",
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
                name: "ItemMaterial1Id",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "ItemMaterial2Count",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "ItemMaterial2Id",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "ItemMaterial3Count",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "ItemMaterial3Id",
                table: "ItemReinforces");

            migrationBuilder.AddColumn<int>(
                name: "Item1Count",
                table: "ItemReinforces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Item1Id",
                table: "ItemReinforces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Item2Count",
                table: "ItemReinforces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Item2Id",
                table: "ItemReinforces",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Item3Count",
                table: "ItemReinforces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Item3Id",
                table: "ItemReinforces",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ItemReinforces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemNewId",
                table: "ItemReinforces",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemOldId",
                table: "ItemReinforces",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Weight = table.Column<short>(nullable: false),
                    IsStack = table.Column<bool>(nullable: false),
                    EquipType = table.Column<int>(nullable: true),
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
                    MoveRateWhenTransform = table.Column<short>(nullable: false),
                    DistanceAttack = table.Column<float>(nullable: false),
                    UseLevel = table.Column<short>(nullable: false),
                    UseKnight = table.Column<bool>(nullable: false),
                    UseRanger = table.Column<bool>(nullable: false),
                    UseMagician = table.Column<bool>(nullable: false),
                    UseAssassin = table.Column<bool>(nullable: false),
                    UseSummoner = table.Column<bool>(nullable: false),
                    UseInAttack = table.Column<bool>(nullable: false),
                    Percent = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitDrops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ItemStatus = table.Column<int>(nullable: false),
                    UseCount = table.Column<short>(nullable: false),
                    EatTime = table.Column<long>(nullable: false),
                    TermOfEffectivity = table.Column<int>(nullable: false),
                    ItemBind = table.Column<int>(nullable: false),
                    CountFrom = table.Column<int>(nullable: false),
                    CountTo = table.Column<int>(nullable: false),
                    Percent = table.Column<float>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_Item1Id",
                table: "ItemReinforces",
                column: "Item1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_Item2Id",
                table: "ItemReinforces",
                column: "Item2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_Item3Id",
                table: "ItemReinforces",
                column: "Item3Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_ItemNewId",
                table: "ItemReinforces",
                column: "ItemNewId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_ItemOldId",
                table: "ItemReinforces",
                column: "ItemOldId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_ItemId_Item1Id_Item2Id_Item3Id",
                table: "ItemReinforces",
                columns: new[] { "ItemId", "Item1Id", "Item2Id", "Item3Id" },
                unique: true,
                filter: "[Item2Id] IS NOT NULL AND [Item3Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemId",
                table: "Items",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitDrops_UnitId",
                table: "UnitDrops",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitDrops_ItemId_UnitId",
                table: "UnitDrops",
                columns: new[] { "ItemId", "UnitId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReinforces_Items_Item1Id",
                table: "ItemReinforces",
                column: "Item1Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReinforces_Items_Item2Id",
                table: "ItemReinforces",
                column: "Item2Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReinforces_Items_Item3Id",
                table: "ItemReinforces",
                column: "Item3Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReinforces_Items_ItemId",
                table: "ItemReinforces",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReinforces_Items_ItemNewId",
                table: "ItemReinforces",
                column: "ItemNewId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReinforces_Items_ItemOldId",
                table: "ItemReinforces",
                column: "ItemOldId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_Items_Item1Id",
                table: "ItemReinforces");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_Items_Item2Id",
                table: "ItemReinforces");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_Items_Item3Id",
                table: "ItemReinforces");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_Items_ItemId",
                table: "ItemReinforces");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_Items_ItemNewId",
                table: "ItemReinforces");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReinforces_Items_ItemOldId",
                table: "ItemReinforces");

            migrationBuilder.DropTable(
                name: "UnitDrops");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_Item1Id",
                table: "ItemReinforces");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_Item2Id",
                table: "ItemReinforces");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_Item3Id",
                table: "ItemReinforces");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_ItemNewId",
                table: "ItemReinforces");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_ItemOldId",
                table: "ItemReinforces");

            migrationBuilder.DropIndex(
                name: "IX_ItemReinforces_ItemId_Item1Id_Item2Id_Item3Id",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "Item1Count",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "Item1Id",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "Item2Count",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "Item2Id",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "Item3Count",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "Item3Id",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "ItemNewId",
                table: "ItemReinforces");

            migrationBuilder.DropColumn(
                name: "ItemOldId",
                table: "ItemReinforces");

            migrationBuilder.AddColumn<int>(
                name: "ItemEquipId",
                table: "ItemReinforces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemEquipNewId",
                table: "ItemReinforces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemEquipOldId",
                table: "ItemReinforces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemMaterial1Count",
                table: "ItemReinforces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemMaterial1Id",
                table: "ItemReinforces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemMaterial2Count",
                table: "ItemReinforces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemMaterial2Id",
                table: "ItemReinforces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemMaterial3Count",
                table: "ItemReinforces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemMaterial3Id",
                table: "ItemReinforces",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemEquips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddPotionRestoreHp = table.Column<short>(type: "smallint", nullable: false),
                    AddPotionRestoreMp = table.Column<short>(type: "smallint", nullable: false),
                    AddTransformMaxHp = table.Column<short>(type: "smallint", nullable: false),
                    AddTransformMaxMp = table.Column<short>(type: "smallint", nullable: false),
                    AttackRate = table.Column<short>(type: "smallint", nullable: false),
                    AttackRateWhenTransform = table.Column<short>(type: "smallint", nullable: false),
                    Critical = table.Column<short>(type: "smallint", nullable: false),
                    CriticalProtect = table.Column<short>(type: "smallint", nullable: false),
                    DDd = table.Column<int>(type: "int", nullable: false),
                    DDvCriticalAdd = table.Column<short>(type: "smallint", nullable: false),
                    DDvCriticalRemove = table.Column<short>(type: "smallint", nullable: false),
                    DDvMax = table.Column<int>(type: "int", nullable: false),
                    DDvMin = table.Column<int>(type: "int", nullable: false),
                    DPv = table.Column<int>(type: "int", nullable: false),
                    Dex = table.Column<short>(type: "smallint", nullable: false),
                    Dhit = table.Column<int>(type: "int", nullable: false),
                    DistanceAttack = table.Column<float>(type: "real", nullable: false),
                    EquipType = table.Column<int>(type: "int", nullable: true),
                    Hp = table.Column<short>(type: "smallint", nullable: false),
                    HpPotionRestore = table.Column<short>(type: "smallint", nullable: false),
                    HpRegen = table.Column<short>(type: "smallint", nullable: false),
                    HumanKiller = table.Column<short>(type: "smallint", nullable: false),
                    HumanProtect = table.Column<short>(type: "smallint", nullable: false),
                    Int = table.Column<short>(type: "smallint", nullable: false),
                    IsStack = table.Column<bool>(type: "bit", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    MDd = table.Column<int>(type: "int", nullable: false),
                    MDvMax = table.Column<int>(type: "int", nullable: false),
                    MDvMin = table.Column<int>(type: "int", nullable: false),
                    MPv = table.Column<int>(type: "int", nullable: false),
                    Mhit = table.Column<int>(type: "int", nullable: false),
                    MobKiller = table.Column<short>(type: "smallint", nullable: false),
                    MobProtect = table.Column<short>(type: "smallint", nullable: false),
                    MoveRate = table.Column<short>(type: "smallint", nullable: false),
                    MoveRateWhenTransform = table.Column<short>(type: "smallint", nullable: false),
                    Mp = table.Column<short>(type: "smallint", nullable: false),
                    MpPotionRestore = table.Column<short>(type: "smallint", nullable: false),
                    MpRegen = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percent = table.Column<float>(type: "real", nullable: false),
                    RDd = table.Column<int>(type: "int", nullable: false),
                    RDvMax = table.Column<int>(type: "int", nullable: false),
                    RDvMin = table.Column<int>(type: "int", nullable: false),
                    RPv = table.Column<int>(type: "int", nullable: false),
                    Rhit = table.Column<int>(type: "int", nullable: false),
                    Str = table.Column<short>(type: "smallint", nullable: false),
                    UseAssassin = table.Column<bool>(type: "bit", nullable: false),
                    UseInAttack = table.Column<bool>(type: "bit", nullable: false),
                    UseKnight = table.Column<bool>(type: "bit", nullable: false),
                    UseLevel = table.Column<short>(type: "smallint", nullable: false),
                    UseMagician = table.Column<bool>(type: "bit", nullable: false),
                    UseRanger = table.Column<bool>(type: "bit", nullable: false),
                    UseSummoner = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<short>(type: "smallint", nullable: false),
                    WeightMax = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemEquips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsStack = table.Column<bool>(type: "bit", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemStatus = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percent = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitEquipDrops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountFrom = table.Column<int>(type: "int", nullable: false),
                    CountTo = table.Column<int>(type: "int", nullable: false),
                    EatTime = table.Column<long>(type: "bigint", nullable: false),
                    ItemBind = table.Column<int>(type: "int", nullable: false),
                    ItemEquipId = table.Column<int>(type: "int", nullable: false),
                    ItemStatus = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<float>(type: "real", nullable: false),
                    TermOfEffectivity = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    UseCount = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitEquipDrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitEquipDrops_ItemEquips_ItemEquipId",
                        column: x => x.ItemEquipId,
                        principalTable: "ItemEquips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitEquipDrops_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitMaterialDrops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountFrom = table.Column<int>(type: "int", nullable: false),
                    CountTo = table.Column<int>(type: "int", nullable: false),
                    EatTime = table.Column<long>(type: "bigint", nullable: false),
                    ItemBind = table.Column<int>(type: "int", nullable: false),
                    ItemMaterialId = table.Column<int>(type: "int", nullable: false),
                    ItemStatus = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<float>(type: "real", nullable: false),
                    TermOfEffectivity = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    UseCount = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMaterialDrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitMaterialDrops_ItemMaterials_ItemMaterialId",
                        column: x => x.ItemMaterialId,
                        principalTable: "ItemMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitMaterialDrops_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_ItemEquipNewId",
                table: "ItemReinforces",
                column: "ItemEquipNewId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_ItemEquipOldId",
                table: "ItemReinforces",
                column: "ItemEquipOldId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_ItemMaterial1Id",
                table: "ItemReinforces",
                column: "ItemMaterial1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_ItemMaterial2Id",
                table: "ItemReinforces",
                column: "ItemMaterial2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_ItemMaterial3Id",
                table: "ItemReinforces",
                column: "ItemMaterial3Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReinforces_ItemEquipId_ItemMaterial1Id_ItemMaterial2Id_ItemMaterial3Id",
                table: "ItemReinforces",
                columns: new[] { "ItemEquipId", "ItemMaterial1Id", "ItemMaterial2Id", "ItemMaterial3Id" },
                unique: true,
                filter: "[ItemMaterial2Id] IS NOT NULL AND [ItemMaterial3Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEquips_ItemId",
                table: "ItemEquips",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaterials_ItemId_ItemStatus",
                table: "ItemMaterials",
                columns: new[] { "ItemId", "ItemStatus" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitEquipDrops_UnitId",
                table: "UnitEquipDrops",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitEquipDrops_ItemEquipId_UnitId",
                table: "UnitEquipDrops",
                columns: new[] { "ItemEquipId", "UnitId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitMaterialDrops_ItemMaterialId",
                table: "UnitMaterialDrops",
                column: "ItemMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitMaterialDrops_UnitId",
                table: "UnitMaterialDrops",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReinforces_ItemEquips_ItemEquipId",
                table: "ItemReinforces",
                column: "ItemEquipId",
                principalTable: "ItemEquips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReinforces_ItemMaterials_ItemMaterial1Id",
                table: "ItemReinforces",
                column: "ItemMaterial1Id",
                principalTable: "ItemMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReinforces_ItemMaterials_ItemMaterial2Id",
                table: "ItemReinforces",
                column: "ItemMaterial2Id",
                principalTable: "ItemMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReinforces_ItemMaterials_ItemMaterial3Id",
                table: "ItemReinforces",
                column: "ItemMaterial3Id",
                principalTable: "ItemMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
