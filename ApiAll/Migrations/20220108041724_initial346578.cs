using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAll.Migrations
{
    public partial class initial346578 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pos_check_pos_client_PosClientid",
                table: "pos_check");

            migrationBuilder.DropIndex(
                name: "IX_pos_check_PosClientid",
                table: "pos_check");

            migrationBuilder.RenameColumn(
                name: "PosClientid",
                table: "pos_check",
                newName: "pos_client_id");

            migrationBuilder.CreateTable(
                name: "pos_kassa_info",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: true),
                    total_sum = table.Column<double>(type: "double precision", nullable: true),
                    profit_sum = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pos_kassa_info");

            migrationBuilder.RenameColumn(
                name: "pos_client_id",
                table: "pos_check",
                newName: "PosClientid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_check_PosClientid",
                table: "pos_check",
                column: "PosClientid");

            migrationBuilder.AddForeignKey(
                name: "FK_pos_check_pos_client_PosClientid",
                table: "pos_check",
                column: "PosClientid",
                principalTable: "pos_client",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
