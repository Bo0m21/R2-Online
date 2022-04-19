using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class AddItemReinforces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemReinforces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemEquipId = table.Column<int>(nullable: false),
                    ItemMaterial1Id = table.Column<int>(nullable: false),
                    Material1Count = table.Column<int>(nullable: false),
                    ItemMaterial2Id = table.Column<int>(nullable: true),
                    Material2Count = table.Column<int>(nullable: true),
                    ItemMaterial3Id = table.Column<int>(nullable: true),
                    Material3Count = table.Column<int>(nullable: true),
                    Percent = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemReinforces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemReinforces_ItemEquips_ItemEquipId",
                        column: x => x.ItemEquipId,
                        principalTable: "ItemEquips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemReinforces_ItemMaterials_ItemMaterial1Id",
                        column: x => x.ItemMaterial1Id,
                        principalTable: "ItemMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemReinforces_ItemMaterials_ItemMaterial2Id",
                        column: x => x.ItemMaterial2Id,
                        principalTable: "ItemMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemReinforces_ItemMaterials_ItemMaterial3Id",
                        column: x => x.ItemMaterial3Id,
                        principalTable: "ItemMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemReinforces");
        }
    }
}
