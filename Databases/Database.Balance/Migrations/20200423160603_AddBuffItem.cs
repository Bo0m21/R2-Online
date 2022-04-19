using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class AddBuffItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuffItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuffId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Time = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuffItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuffItems_Buffs_BuffId",
                        column: x => x.BuffId,
                        principalTable: "Buffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuffItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuffItems_ItemId",
                table: "BuffItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BuffItems_BuffId_ItemId",
                table: "BuffItems",
                columns: new[] { "BuffId", "ItemId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuffItems");
        }
    }
}
