using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class intial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "unit_buyed_price",
                table: "pos_invoice_item",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<bool>(
                name: "change_price_status",
                table: "pos_invoice_item",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "persantage",
                table: "pos_invoice_item",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "unit_saled_price",
                table: "pos_invoice_item",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "applyment_status",
                table: "pos_invoice",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "pos_product_price",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: true),
                    buyed_price = table.Column<double>(type: "double precision", nullable: true),
                    percantage = table.Column<double>(type: "double precision", nullable: true),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_product_price", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_product_price_pos_product_product_id",
                        column: x => x.product_id,
                        principalTable: "pos_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pos_product_price_product_id",
                table: "pos_product_price",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pos_product_price");

            migrationBuilder.DropColumn(
                name: "change_price_status",
                table: "pos_invoice_item");

            migrationBuilder.DropColumn(
                name: "persantage",
                table: "pos_invoice_item");

            migrationBuilder.DropColumn(
                name: "unit_saled_price",
                table: "pos_invoice_item");

            migrationBuilder.DropColumn(
                name: "applyment_status",
                table: "pos_invoice");

            migrationBuilder.AlterColumn<double>(
                name: "unit_buyed_price",
                table: "pos_invoice_item",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }
    }
}
