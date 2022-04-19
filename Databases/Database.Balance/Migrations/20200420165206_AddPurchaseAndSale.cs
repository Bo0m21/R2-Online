using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class AddPurchaseAndSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitPurchases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Flag = table.Column<int>(nullable: false),
                    SortKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitPurchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitPurchases_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitPurchases_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitSales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitSales_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitPurchases_ItemId",
                table: "UnitPurchases",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitPurchases_UnitId",
                table: "UnitPurchases",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitSales_ItemId",
                table: "UnitSales",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitPurchases");

            migrationBuilder.DropTable(
                name: "UnitSales");
        }
    }
}
