using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAll.Migrations
{
    public partial class initial53464dasdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "profit_summ",
                table: "pos_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "pos_kassa_current_position",
                columns: table => new
                {
                    total_sum = table.Column<double>(type: "double precision", nullable: true),
                    card_sum = table.Column<double>(type: "double precision", nullable: true),
                    cash_sum = table.Column<double>(type: "double precision", nullable: true),
                    payme_sum = table.Column<double>(type: "double precision", nullable: true),
                    click_sum = table.Column<double>(type: "double precision", nullable: true),
                    online_sum = table.Column<double>(type: "double precision", nullable: true),
                    humo_sum = table.Column<double>(type: "double precision", nullable: true),
                    mobil_sum = table.Column<double>(type: "double precision", nullable: true),
                    discount_sum = table.Column<double>(type: "double precision", nullable: true),
                    bonus_sum = table.Column<double>(type: "double precision", nullable: true),
                    xarajat_sum = table.Column<double>(type: "double precision", nullable: true),
                    profit_sum = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pos_kassa_current_position");

            migrationBuilder.DropColumn(
                name: "profit_summ",
                table: "pos_check");
        }
    }
}
