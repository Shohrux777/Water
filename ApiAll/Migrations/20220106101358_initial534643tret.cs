using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAll.Migrations
{
    public partial class initial534643tret : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PosClientid",
                table: "pos_check",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "bonus_summ",
                table: "pos_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "click_sum",
                table: "pos_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "humo_sum",
                table: "pos_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "mobil_sum",
                table: "pos_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "online_sum",
                table: "pos_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "payme_sum",
                table: "pos_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pos_check_pos_client_PosClientid",
                table: "pos_check");

            migrationBuilder.DropIndex(
                name: "IX_pos_check_PosClientid",
                table: "pos_check");

            migrationBuilder.DropColumn(
                name: "PosClientid",
                table: "pos_check");

            migrationBuilder.DropColumn(
                name: "bonus_summ",
                table: "pos_check");

            migrationBuilder.DropColumn(
                name: "click_sum",
                table: "pos_check");

            migrationBuilder.DropColumn(
                name: "humo_sum",
                table: "pos_check");

            migrationBuilder.DropColumn(
                name: "mobil_sum",
                table: "pos_check");

            migrationBuilder.DropColumn(
                name: "online_sum",
                table: "pos_check");

            migrationBuilder.DropColumn(
                name: "payme_sum",
                table: "pos_check");
        }
    }
}
