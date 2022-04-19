using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class AddMaterialDrop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitMaterialDrops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(nullable: false),
                    ItemMaterialId = table.Column<int>(nullable: false),
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
                name: "IX_UnitMaterialDrops_ItemMaterialId",
                table: "UnitMaterialDrops",
                column: "ItemMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitMaterialDrops_UnitId",
                table: "UnitMaterialDrops",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitMaterialDrops");
        }
    }
}
