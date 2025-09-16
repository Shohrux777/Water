using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial34455 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PosInvoiceItemid",
                table: "pos_payments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "qty_in_pack",
                table: "pos_payments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "pos_revert",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    postavshik_id = table.Column<long>(type: "bigint", nullable: true),
                    revert_status = table.Column<int>(type: "integer", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    revert_date = table.Column<DateTime>(type: "date", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    applayment_status = table.Column<bool>(type: "boolean", nullable: false),
                    reg_date = table.Column<DateTime>(type: "date", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_revert", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_revert_pos_company_postavshik_id",
                        column: x => x.postavshik_id,
                        principalTable: "pos_company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pos_revert_status",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_revert_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PosCreditor",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    creditor_price = table.Column<double>(type: "double precision", nullable: false),
                    real_creditor_price = table.Column<double>(type: "double precision", nullable: false),
                    reg_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PosInvoiceid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosCreditor", x => x.id);
                    table.ForeignKey(
                        name: "FK_PosCreditor_pos_invoice_PosInvoiceid",
                        column: x => x.PosInvoiceid,
                        principalTable: "pos_invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_revert_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PosRevertid = table.Column<long>(type: "bigint", nullable: false),
                    PosInvoiceItemid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    qty_in_pack = table.Column<double>(type: "double precision", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    check_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_revert_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_revert_item_pos_check_check_id",
                        column: x => x.check_id,
                        principalTable: "pos_check",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pos_revert_item_pos_invoice_item_PosInvoiceItemid",
                        column: x => x.PosInvoiceItemid,
                        principalTable: "pos_invoice_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_revert_item_pos_product_product_id",
                        column: x => x.product_id,
                        principalTable: "pos_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_revert_item_pos_revert_PosRevertid",
                        column: x => x.PosRevertid,
                        principalTable: "pos_revert",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PosCreditorItem",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    PosCreditorid = table.Column<long>(type: "bigint", nullable: false),
                    reg_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosCreditorItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_PosCreditorItem_PosCreditor_PosCreditorid",
                        column: x => x.PosCreditorid,
                        principalTable: "PosCreditor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pos_payments_PosInvoiceItemid",
                table: "pos_payments",
                column: "PosInvoiceItemid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_revert_postavshik_id",
                table: "pos_revert",
                column: "postavshik_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_revert_item_check_id",
                table: "pos_revert_item",
                column: "check_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_revert_item_PosInvoiceItemid",
                table: "pos_revert_item",
                column: "PosInvoiceItemid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_revert_item_PosRevertid",
                table: "pos_revert_item",
                column: "PosRevertid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_revert_item_product_id",
                table: "pos_revert_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_PosCreditor_PosInvoiceid",
                table: "PosCreditor",
                column: "PosInvoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_PosCreditorItem_PosCreditorid",
                table: "PosCreditorItem",
                column: "PosCreditorid");

            migrationBuilder.AddForeignKey(
                name: "FK_pos_payments_pos_invoice_item_PosInvoiceItemid",
                table: "pos_payments",
                column: "PosInvoiceItemid",
                principalTable: "pos_invoice_item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pos_payments_pos_invoice_item_PosInvoiceItemid",
                table: "pos_payments");

            migrationBuilder.DropTable(
                name: "pos_revert_item");

            migrationBuilder.DropTable(
                name: "pos_revert_status");

            migrationBuilder.DropTable(
                name: "PosCreditorItem");

            migrationBuilder.DropTable(
                name: "pos_revert");

            migrationBuilder.DropTable(
                name: "PosCreditor");

            migrationBuilder.DropIndex(
                name: "IX_pos_payments_PosInvoiceItemid",
                table: "pos_payments");

            migrationBuilder.DropColumn(
                name: "PosInvoiceItemid",
                table: "pos_payments");

            migrationBuilder.DropColumn(
                name: "qty_in_pack",
                table: "pos_payments");
        }
    }
}
