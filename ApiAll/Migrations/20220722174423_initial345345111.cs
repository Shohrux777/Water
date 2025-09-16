using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial345345111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "value",
                table: "tex_size",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "tex_planning",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    planning_number = table.Column<string>(type: "text", nullable: true),
                    TexOrderid = table.Column<long>(type: "bigint", nullable: true),
                    TexRaskladkiid = table.Column<long>(type: "bigint", nullable: true),
                    reg_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    note_1 = table.Column<string>(type: "text", nullable: true),
                    note_2 = table.Column<string>(type: "text", nullable: true),
                    TexAuthorizationid = table.Column<long>(type: "bigint", nullable: true),
                    TexContragentid = table.Column<long>(type: "bigint", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_planning", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_planning_tex_authorization_TexAuthorizationid",
                        column: x => x.TexAuthorizationid,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_planning_tex_contragent_TexContragentid",
                        column: x => x.TexContragentid,
                        principalTable: "tex_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_planning_tex_order_TexOrderid",
                        column: x => x.TexOrderid,
                        principalTable: "tex_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_planning_tex_raskladki_TexRaskladkiid",
                        column: x => x.TexRaskladkiid,
                        principalTable: "tex_raskladki",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_sub_product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    print_name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_sub_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_planning_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    TexProductid = table.Column<long>(type: "bigint", nullable: true),
                    retsep_product_id = table.Column<long>(type: "bigint", nullable: true),
                    TexColorid = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    qty_1 = table.Column<double>(type: "double precision", nullable: false),
                    qty_2 = table.Column<double>(type: "double precision", nullable: false),
                    qty_3 = table.Column<double>(type: "double precision", nullable: false),
                    qty_4 = table.Column<double>(type: "double precision", nullable: false),
                    qty_5 = table.Column<double>(type: "double precision", nullable: false),
                    main_item = table.Column<bool>(type: "boolean", nullable: false),
                    TexPlanningItemsid = table.Column<long>(type: "bigint", nullable: true),
                    main_plan_itemid = table.Column<long>(type: "bigint", nullable: true),
                    TexPlanningid = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_planning_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_planning_items_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_planning_items_tex_color_TexColorid",
                        column: x => x.TexColorid,
                        principalTable: "tex_color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_planning_items_tex_planning_items_main_plan_itemid",
                        column: x => x.main_plan_itemid,
                        principalTable: "tex_planning_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_planning_items_tex_planning_TexPlanningid",
                        column: x => x.TexPlanningid,
                        principalTable: "tex_planning",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_planning_items_tex_product_retsep_product_id",
                        column: x => x.retsep_product_id,
                        principalTable: "tex_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_planning_items_tex_product_TexProductid",
                        column: x => x.TexProductid,
                        principalTable: "tex_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_product_and_sub_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TexProductid = table.Column<long>(type: "bigint", nullable: true),
                    TexSubProductid = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_product_and_sub_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_product_and_sub_detail_tex_product_TexProductid",
                        column: x => x.TexProductid,
                        principalTable: "tex_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_product_and_sub_detail_tex_sub_product_TexSubProductid",
                        column: x => x.TexSubProductid,
                        principalTable: "tex_sub_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_TexAuthorizationid",
                table: "tex_planning",
                column: "TexAuthorizationid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_TexContragentid",
                table: "tex_planning",
                column: "TexContragentid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_TexOrderid",
                table: "tex_planning",
                column: "TexOrderid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_TexRaskladkiid",
                table: "tex_planning",
                column: "TexRaskladkiid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_items_created_auth_id",
                table: "tex_planning_items",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_items_main_plan_itemid",
                table: "tex_planning_items",
                column: "main_plan_itemid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_items_retsep_product_id",
                table: "tex_planning_items",
                column: "retsep_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_items_TexColorid",
                table: "tex_planning_items",
                column: "TexColorid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_items_TexPlanningid",
                table: "tex_planning_items",
                column: "TexPlanningid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_items_TexProductid",
                table: "tex_planning_items",
                column: "TexProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_product_and_sub_detail_TexProductid",
                table: "tex_product_and_sub_detail",
                column: "TexProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_product_and_sub_detail_TexSubProductid",
                table: "tex_product_and_sub_detail",
                column: "TexSubProductid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tex_planning_items");

            migrationBuilder.DropTable(
                name: "tex_product_and_sub_detail");

            migrationBuilder.DropTable(
                name: "tex_planning");

            migrationBuilder.DropTable(
                name: "tex_sub_product");

            migrationBuilder.DropColumn(
                name: "value",
                table: "tex_size");
        }
    }
}
