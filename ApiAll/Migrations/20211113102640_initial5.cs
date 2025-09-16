using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "cutting",
                table: "tex_order_item_steps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "finish",
                table: "tex_order_item_steps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "tex_order_item_step_permissions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    order_steps_id = table.Column<long>(type: "bigint", nullable: false),
                    auth_id = table.Column<long>(type: "bigint", nullable: false),
                    edit = table.Column<bool>(type: "boolean", nullable: false),
                    delete = table.Column<bool>(type: "boolean", nullable: false),
                    update = table.Column<bool>(type: "boolean", nullable: false),
                    view = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_order_item_step_permissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_order_item_step_permissions_tex_authorization_auth_id",
                        column: x => x.auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tex_order_item_step_permissions_tex_order_item_steps_order_~",
                        column: x => x.order_steps_id,
                        principalTable: "tex_order_item_steps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tex_order_item_steps_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    order_item_steps_id = table.Column<long>(type: "bigint", nullable: false),
                    order_item_id = table.Column<long>(type: "bigint", nullable: false),
                    for_private_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    sort_number = table.Column<int>(type: "integer", nullable: false),
                    start = table.Column<bool>(type: "boolean", nullable: false),
                    stop = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_order_item_steps_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_order_item_steps_detail_tex_authorization_for_private_a~",
                        column: x => x.for_private_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_order_item_steps_detail_tex_order_item_order_item_id",
                        column: x => x.order_item_id,
                        principalTable: "tex_order_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tex_order_item_steps_detail_tex_order_item_steps_order_item~",
                        column: x => x.order_item_steps_id,
                        principalTable: "tex_order_item_steps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_step_permissions_auth_id_order_steps_id",
                table: "tex_order_item_step_permissions",
                columns: new[] { "auth_id", "order_steps_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_step_permissions_order_steps_id",
                table: "tex_order_item_step_permissions",
                column: "order_steps_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_steps_detail_for_private_auth_id",
                table: "tex_order_item_steps_detail",
                column: "for_private_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_steps_detail_order_item_id",
                table: "tex_order_item_steps_detail",
                column: "order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_steps_detail_order_item_steps_id",
                table: "tex_order_item_steps_detail",
                column: "order_item_steps_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_steps_detail_sort_number_order_item_id",
                table: "tex_order_item_steps_detail",
                columns: new[] { "sort_number", "order_item_id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tex_order_item_step_permissions");

            migrationBuilder.DropTable(
                name: "tex_order_item_steps_detail");

            migrationBuilder.DropColumn(
                name: "cutting",
                table: "tex_order_item_steps");

            migrationBuilder.DropColumn(
                name: "finish",
                table: "tex_order_item_steps");
        }
    }
}
