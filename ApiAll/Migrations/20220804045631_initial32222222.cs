using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial32222222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tex_sew_order",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TexContragentid = table.Column<long>(type: "bigint", nullable: true),
                    TexAuthorizationid = table.Column<long>(type: "bigint", nullable: true),
                    TexPlanningid = table.Column<long>(type: "bigint", nullable: true),
                    TexInvoiceid = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    reserved_note = table.Column<string>(type: "text", nullable: true),
                    TexRaskladkiid = table.Column<long>(type: "bigint", nullable: true),
                    reg_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    rejalashtrilgan_tugash_vaqti_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    real_finished_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    order_started_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    finish_status = table.Column<bool>(type: "boolean", nullable: false),
                    start_status = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_sew_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_tex_authorization_TexAuthorizationid",
                        column: x => x.TexAuthorizationid,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_tex_contragent_TexContragentid",
                        column: x => x.TexContragentid,
                        principalTable: "tex_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_tex_invoice_TexInvoiceid",
                        column: x => x.TexInvoiceid,
                        principalTable: "tex_invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_tex_planning_TexPlanningid",
                        column: x => x.TexPlanningid,
                        principalTable: "tex_planning",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_tex_raskladki_TexRaskladkiid",
                        column: x => x.TexRaskladkiid,
                        principalTable: "tex_raskladki",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_step",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    finish = table.Column<bool>(type: "boolean", nullable: false),
                    rasxod = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_step", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_warehouse_access",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TexAuthorizationid = table.Column<long>(type: "bigint", nullable: false),
                    TexSkladid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_warehouse_access", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_warehouse_access_tex_authorization_TexAuthorizationid",
                        column: x => x.TexAuthorizationid,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tex_warehouse_access_tex_sklad_TexSkladid",
                        column: x => x.TexSkladid,
                        principalTable: "tex_sklad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tex_sew_extra_work",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TexSewOrderid = table.Column<long>(type: "bigint", nullable: true),
                    TexPlanningid = table.Column<long>(type: "bigint", nullable: true),
                    TexProductid = table.Column<long>(type: "bigint", nullable: true),
                    TexContragentid = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    TexAuthorizationid = table.Column<long>(type: "bigint", nullable: true),
                    reg_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    start_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    start_status = table.Column<bool>(type: "boolean", nullable: false),
                    end_status = table.Column<bool>(type: "boolean", nullable: false),
                    tahminiy_tugah_vaqti = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_sew_extra_work", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_sew_extra_work_tex_authorization_TexAuthorizationid",
                        column: x => x.TexAuthorizationid,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_extra_work_tex_contragent_TexContragentid",
                        column: x => x.TexContragentid,
                        principalTable: "tex_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_extra_work_tex_planning_TexPlanningid",
                        column: x => x.TexPlanningid,
                        principalTable: "tex_planning",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_extra_work_tex_product_TexProductid",
                        column: x => x.TexProductid,
                        principalTable: "tex_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_extra_work_tex_sew_order_TexSewOrderid",
                        column: x => x.TexSewOrderid,
                        principalTable: "tex_sew_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_sew_order_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TexSewOrderid = table.Column<long>(type: "bigint", nullable: false),
                    TexProductid = table.Column<long>(type: "bigint", nullable: false),
                    TexColorid = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    brak_qty = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    image_base_64 = table.Column<string>(type: "text", nullable: true),
                    TexSizeid = table.Column<long>(type: "bigint", nullable: true),
                    reserved_qty = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_sew_order_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_item_tex_color_TexColorid",
                        column: x => x.TexColorid,
                        principalTable: "tex_color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_item_tex_product_TexProductid",
                        column: x => x.TexProductid,
                        principalTable: "tex_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_item_tex_sew_order_TexSewOrderid",
                        column: x => x.TexSewOrderid,
                        principalTable: "tex_sew_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_item_tex_size_TexSizeid",
                        column: x => x.TexSizeid,
                        principalTable: "tex_size",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_sew_extra_work_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TexSewExtraWorkid = table.Column<long>(type: "bigint", nullable: false),
                    TexProductid = table.Column<long>(type: "bigint", nullable: true),
                    main_item = table.Column<bool>(type: "boolean", nullable: false),
                    TexColorid = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    brak_qty = table.Column<double>(type: "double precision", nullable: false),
                    TexAuthorizationid = table.Column<long>(type: "bigint", nullable: true),
                    reg_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    start_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    start_status = table.Column<bool>(type: "boolean", nullable: false),
                    end_status = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_sew_extra_work_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_sew_extra_work_item_tex_authorization_TexAuthorizationid",
                        column: x => x.TexAuthorizationid,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_extra_work_item_tex_color_TexColorid",
                        column: x => x.TexColorid,
                        principalTable: "tex_color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_extra_work_item_tex_product_TexProductid",
                        column: x => x.TexProductid,
                        principalTable: "tex_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_extra_work_item_tex_sew_extra_work_TexSewExtraWorkid",
                        column: x => x.TexSewExtraWorkid,
                        principalTable: "tex_sew_extra_work",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tex_sew_order_item_step",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TexSewOrderItemid = table.Column<long>(type: "bigint", nullable: true),
                    sort_number = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    brak_qty = table.Column<double>(type: "double precision", nullable: false),
                    start_status = table.Column<bool>(type: "boolean", nullable: false),
                    stop_status = table.Column<bool>(type: "boolean", nullable: false),
                    finish_status = table.Column<bool>(type: "boolean", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    finish_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    stop_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TexAuthorization = table.Column<long>(type: "bigint", nullable: true),
                    authorizationid = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    TexStepid = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_sew_order_item_step", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_item_step_tex_authorization_authorizationid",
                        column: x => x.authorizationid,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_item_step_tex_sew_order_item_TexSewOrderItemid",
                        column: x => x.TexSewOrderItemid,
                        principalTable: "tex_sew_order_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_item_step_tex_step_TexStepid",
                        column: x => x.TexStepid,
                        principalTable: "tex_step",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_sew_order_item_step_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TexSewOrderItemStepid = table.Column<long>(type: "bigint", nullable: false),
                    TexAuthorizationid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    brak_qty = table.Column<double>(type: "double precision", nullable: false),
                    brak = table.Column<bool>(type: "boolean", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_sew_order_item_step_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_item_step_item_tex_authorization_TexAuthoriza~",
                        column: x => x.TexAuthorizationid,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tex_sew_order_item_step_item_tex_sew_order_item_step_TexSew~",
                        column: x => x.TexSewOrderItemStepid,
                        principalTable: "tex_sew_order_item_step",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_extra_work_TexAuthorizationid",
                table: "tex_sew_extra_work",
                column: "TexAuthorizationid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_extra_work_TexContragentid",
                table: "tex_sew_extra_work",
                column: "TexContragentid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_extra_work_TexPlanningid",
                table: "tex_sew_extra_work",
                column: "TexPlanningid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_extra_work_TexProductid",
                table: "tex_sew_extra_work",
                column: "TexProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_extra_work_TexSewOrderid",
                table: "tex_sew_extra_work",
                column: "TexSewOrderid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_extra_work_item_TexAuthorizationid",
                table: "tex_sew_extra_work_item",
                column: "TexAuthorizationid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_extra_work_item_TexColorid",
                table: "tex_sew_extra_work_item",
                column: "TexColorid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_extra_work_item_TexProductid",
                table: "tex_sew_extra_work_item",
                column: "TexProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_extra_work_item_TexSewExtraWorkid",
                table: "tex_sew_extra_work_item",
                column: "TexSewExtraWorkid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_TexAuthorizationid",
                table: "tex_sew_order",
                column: "TexAuthorizationid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_TexContragentid",
                table: "tex_sew_order",
                column: "TexContragentid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_TexInvoiceid",
                table: "tex_sew_order",
                column: "TexInvoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_TexPlanningid",
                table: "tex_sew_order",
                column: "TexPlanningid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_TexRaskladkiid",
                table: "tex_sew_order",
                column: "TexRaskladkiid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_item_TexColorid",
                table: "tex_sew_order_item",
                column: "TexColorid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_item_TexProductid",
                table: "tex_sew_order_item",
                column: "TexProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_item_TexSewOrderid",
                table: "tex_sew_order_item",
                column: "TexSewOrderid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_item_TexSizeid",
                table: "tex_sew_order_item",
                column: "TexSizeid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_item_step_authorizationid",
                table: "tex_sew_order_item_step",
                column: "authorizationid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_item_step_TexSewOrderItemid",
                table: "tex_sew_order_item_step",
                column: "TexSewOrderItemid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_item_step_TexStepid",
                table: "tex_sew_order_item_step",
                column: "TexStepid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_item_step_item_TexAuthorizationid",
                table: "tex_sew_order_item_step_item",
                column: "TexAuthorizationid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sew_order_item_step_item_TexSewOrderItemStepid",
                table: "tex_sew_order_item_step_item",
                column: "TexSewOrderItemStepid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_warehouse_access_TexAuthorizationid",
                table: "tex_warehouse_access",
                column: "TexAuthorizationid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_warehouse_access_TexSkladid",
                table: "tex_warehouse_access",
                column: "TexSkladid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tex_sew_extra_work_item");

            migrationBuilder.DropTable(
                name: "tex_sew_order_item_step_item");

            migrationBuilder.DropTable(
                name: "tex_warehouse_access");

            migrationBuilder.DropTable(
                name: "tex_sew_extra_work");

            migrationBuilder.DropTable(
                name: "tex_sew_order_item_step");

            migrationBuilder.DropTable(
                name: "tex_sew_order_item");

            migrationBuilder.DropTable(
                name: "tex_step");

            migrationBuilder.DropTable(
                name: "tex_sew_order");
        }
    }
}
