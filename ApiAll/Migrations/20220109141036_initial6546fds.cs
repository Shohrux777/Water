using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial6546fds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "client_status",
                table: "pos_company",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "pos_debitor",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    debitor_price = table.Column<double>(type: "double precision", nullable: false),
                    real_debitor_price = table.Column<double>(type: "double precision", nullable: false),
                    reg_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PosCompanyid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_debitor", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_debitor_pos_company_PosCompanyid",
                        column: x => x.PosCompanyid,
                        principalTable: "pos_company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_debitor_invoice",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    factura_number = table.Column<string>(type: "text", nullable: true),
                    postavshik_id = table.Column<long>(type: "bigint", nullable: true),
                    sklad_id = table.Column<long>(type: "bigint", nullable: false),
                    department_id = table.Column<long>(type: "bigint", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    debit_summ = table.Column<double>(type: "double precision", nullable: false),
                    credit_sum = table.Column<double>(type: "double precision", nullable: false),
                    applyment_status = table.Column<bool>(type: "boolean", nullable: false),
                    PosAuthorizationid = table.Column<long>(type: "bigint", nullable: false),
                    closed_status = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_debitor_invoice", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_debitor_invoice_pos_authorization_PosAuthorizationid",
                        column: x => x.PosAuthorizationid,
                        principalTable: "pos_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_debitor_invoice_pos_company_postavshik_id",
                        column: x => x.postavshik_id,
                        principalTable: "pos_company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pos_debitor_invoice_pos_department_department_id",
                        column: x => x.department_id,
                        principalTable: "pos_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_debitor_invoice_pos_sklad_sklad_id",
                        column: x => x.sklad_id,
                        principalTable: "pos_sklad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_kassa_current_position_with_name",
                columns: table => new
                {
                    user_name = table.Column<string>(type: "text", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "pos_saled_products_degree_qty",
                columns: table => new
                {
                    product_name = table.Column<string>(type: "text", nullable: true),
                    total_qty = table.Column<double>(type: "double precision", nullable: true),
                    total_saled_sum = table.Column<double>(type: "double precision", nullable: true),
                    total_prixod_price = table.Column<double>(type: "double precision", nullable: true),
                    profit_price = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "pos_debitor_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    PosDebitorid = table.Column<long>(type: "bigint", nullable: false),
                    reg_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    card_sum = table.Column<double>(type: "double precision", nullable: false),
                    cash_sum = table.Column<double>(type: "double precision", nullable: false),
                    payme_sum = table.Column<double>(type: "double precision", nullable: false),
                    click_sum = table.Column<double>(type: "double precision", nullable: false),
                    online_sum = table.Column<double>(type: "double precision", nullable: false),
                    humo_sum = table.Column<double>(type: "double precision", nullable: false),
                    mobil_sum = table.Column<double>(type: "double precision", nullable: false),
                    discount_summ = table.Column<double>(type: "double precision", nullable: false),
                    bonus_summ = table.Column<double>(type: "double precision", nullable: false),
                    profit_summ = table.Column<double>(type: "double precision", nullable: false),
                    PosAuthorizationid = table.Column<long>(type: "bigint", nullable: false),
                    closed_status = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_debitor_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_debitor_item_pos_authorization_PosAuthorizationid",
                        column: x => x.PosAuthorizationid,
                        principalTable: "pos_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_debitor_item_pos_debitor_PosDebitorid",
                        column: x => x.PosDebitorid,
                        principalTable: "pos_debitor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_debitor_invoice_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    saled_price = table.Column<double>(type: "double precision", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    PosDebitorInvoiceid = table.Column<long>(type: "bigint", nullable: false),
                    reg_date = table.Column<DateTime>(type: "date", nullable: false),
                    PosInvoiceItemid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_debitor_invoice_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_debitor_invoice_item_pos_debitor_invoice_PosDebitorInvo~",
                        column: x => x.PosDebitorInvoiceid,
                        principalTable: "pos_debitor_invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_debitor_invoice_item_pos_invoice_item_PosInvoiceItemid",
                        column: x => x.PosInvoiceItemid,
                        principalTable: "pos_invoice_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_debitor_invoice_item_pos_product_product_id",
                        column: x => x.product_id,
                        principalTable: "pos_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pos_debitor_PosCompanyid",
                table: "pos_debitor",
                column: "PosCompanyid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_debitor_invoice_department_id",
                table: "pos_debitor_invoice",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_debitor_invoice_PosAuthorizationid",
                table: "pos_debitor_invoice",
                column: "PosAuthorizationid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_debitor_invoice_postavshik_id",
                table: "pos_debitor_invoice",
                column: "postavshik_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_debitor_invoice_sklad_id",
                table: "pos_debitor_invoice",
                column: "sklad_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_debitor_invoice_item_PosDebitorInvoiceid",
                table: "pos_debitor_invoice_item",
                column: "PosDebitorInvoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_debitor_invoice_item_PosInvoiceItemid",
                table: "pos_debitor_invoice_item",
                column: "PosInvoiceItemid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_debitor_invoice_item_product_id",
                table: "pos_debitor_invoice_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_debitor_item_PosAuthorizationid",
                table: "pos_debitor_item",
                column: "PosAuthorizationid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_debitor_item_PosDebitorid",
                table: "pos_debitor_item",
                column: "PosDebitorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pos_debitor_invoice_item");

            migrationBuilder.DropTable(
                name: "pos_debitor_item");

            migrationBuilder.DropTable(
                name: "pos_kassa_current_position_with_name");

            migrationBuilder.DropTable(
                name: "pos_saled_products_degree_qty");

            migrationBuilder.DropTable(
                name: "pos_debitor_invoice");

            migrationBuilder.DropTable(
                name: "pos_debitor");

            migrationBuilder.DropColumn(
                name: "client_status",
                table: "pos_company");
        }
    }
}
