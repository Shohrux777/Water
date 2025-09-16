using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial992022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "qty_in_pack",
                table: "pos_product_price",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "bot_name",
                table: "pos_product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "contains_number_in_pack",
                table: "pos_product",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dozirofka",
                table: "pos_product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "global_name",
                table: "pos_product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "manifacturer_name",
                table: "pos_product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_type_str",
                table: "pos_product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "retsepniy",
                table: "pos_product",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "sale_name",
                table: "pos_product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "spravichniy",
                table: "pos_product",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "tax_number",
                table: "pos_product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "expired_date",
                table: "pos_invoice_item",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "persantage_discount",
                table: "pos_invoice_item",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "persantage_nds",
                table: "pos_invoice_item",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "qty_in_pack",
                table: "pos_invoice_item",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "saved_in_pack",
                table: "pos_invoice_item",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "unit_discount_price",
                table: "pos_invoice_item",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "pastavshik_status",
                table: "pos_company",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "stir",
                table: "pos_company",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "pos_currency_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    nds_persantage = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_currency_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_manifacturer",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_manifacturer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_real_summ_of_all_products",
                columns: table => new
                {
                    buyed_summa = table.Column<double>(type: "double precision", nullable: true),
                    saled_summa = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pos_currency_type");

            migrationBuilder.DropTable(
                name: "pos_manifacturer");

            migrationBuilder.DropTable(
                name: "pos_real_summ_of_all_products");

            migrationBuilder.DropColumn(
                name: "qty_in_pack",
                table: "pos_product_price");

            migrationBuilder.DropColumn(
                name: "bot_name",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "contains_number_in_pack",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "dozirofka",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "global_name",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "manifacturer_name",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "product_type_str",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "retsepniy",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "sale_name",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "spravichniy",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "tax_number",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "expired_date",
                table: "pos_invoice_item");

            migrationBuilder.DropColumn(
                name: "persantage_discount",
                table: "pos_invoice_item");

            migrationBuilder.DropColumn(
                name: "persantage_nds",
                table: "pos_invoice_item");

            migrationBuilder.DropColumn(
                name: "qty_in_pack",
                table: "pos_invoice_item");

            migrationBuilder.DropColumn(
                name: "saved_in_pack",
                table: "pos_invoice_item");

            migrationBuilder.DropColumn(
                name: "unit_discount_price",
                table: "pos_invoice_item");

            migrationBuilder.DropColumn(
                name: "pastavshik_status",
                table: "pos_company");

            migrationBuilder.DropColumn(
                name: "stir",
                table: "pos_company");
        }
    }
}
