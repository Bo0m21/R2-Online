using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Balance.Migrations
{
    public partial class UpdateUnitPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Script",
                table: "Units",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Script",
                table: "Units");
        }
    }
}
