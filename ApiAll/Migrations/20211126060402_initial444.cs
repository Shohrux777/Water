using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAll.Migrations
{
    public partial class initial444 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "check_revert_status",
                table: "pos_payments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "cash_sum",
                table: "pos_client",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "cashback_percentage",
                table: "pos_client",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "discount_percantage",
                table: "pos_client",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "check_revert_status",
                table: "pos_check",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "check_revert_status",
                table: "pos_payments");

            migrationBuilder.DropColumn(
                name: "cash_sum",
                table: "pos_client");

            migrationBuilder.DropColumn(
                name: "cashback_percentage",
                table: "pos_client");

            migrationBuilder.DropColumn(
                name: "discount_percantage",
                table: "pos_client");

            migrationBuilder.DropColumn(
                name: "check_revert_status",
                table: "pos_check");
        }
    }
}
