using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "code",
                table: "pos_product_code",
                newName: "barcode");

            migrationBuilder.AddColumn<DateTime>(
                name: "begin_date_time",
                table: "tex_order_item_steps_detail",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "start_time",
                table: "tex_order_item_steps_detail",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "stop_time",
                table: "tex_order_item_steps_detail",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "timer_in_minuts",
                table: "tex_order_item_steps_detail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "main_order_item_id",
                table: "tex_order_item",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "pos_product",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "buyed_price",
                table: "pos_product",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<string>(
                name: "barcode",
                table: "pos_product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "discount_status",
                table: "pos_product",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "main_product_id",
                table: "pos_product",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "min_qty",
                table: "pos_product",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "nds",
                table: "pos_product",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "percentage",
                table: "pos_product",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "unitmeasurment_id",
                table: "pos_product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "pos_recipe",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    recipe_product_id = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_recipe", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_recipe_pos_product_product_id",
                        column: x => x.product_id,
                        principalTable: "pos_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_recipe_pos_product_recipe_product_id",
                        column: x => x.recipe_product_id,
                        principalTable: "pos_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_main_order_item_id",
                table: "tex_order_item",
                column: "main_order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_product_main_product_id",
                table: "pos_product",
                column: "main_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_product_unitmeasurment_id",
                table: "pos_product",
                column: "unitmeasurment_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_recipe_product_id",
                table: "pos_recipe",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_recipe_recipe_product_id",
                table: "pos_recipe",
                column: "recipe_product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pos_product_pos_product_main_product_id",
                table: "pos_product",
                column: "main_product_id",
                principalTable: "pos_product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pos_product_pos_product_unitmeasurment_unitmeasurment_id",
                table: "pos_product",
                column: "unitmeasurment_id",
                principalTable: "pos_product_unitmeasurment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_order_item_tex_order_item_main_order_item_id",
                table: "tex_order_item",
                column: "main_order_item_id",
                principalTable: "tex_order_item",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pos_product_pos_product_main_product_id",
                table: "pos_product");

            migrationBuilder.DropForeignKey(
                name: "FK_pos_product_pos_product_unitmeasurment_unitmeasurment_id",
                table: "pos_product");

            migrationBuilder.DropForeignKey(
                name: "FK_tex_order_item_tex_order_item_main_order_item_id",
                table: "tex_order_item");

            migrationBuilder.DropTable(
                name: "pos_recipe");

            migrationBuilder.DropIndex(
                name: "IX_tex_order_item_main_order_item_id",
                table: "tex_order_item");

            migrationBuilder.DropIndex(
                name: "IX_pos_product_main_product_id",
                table: "pos_product");

            migrationBuilder.DropIndex(
                name: "IX_pos_product_unitmeasurment_id",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "begin_date_time",
                table: "tex_order_item_steps_detail");

            migrationBuilder.DropColumn(
                name: "start_time",
                table: "tex_order_item_steps_detail");

            migrationBuilder.DropColumn(
                name: "stop_time",
                table: "tex_order_item_steps_detail");

            migrationBuilder.DropColumn(
                name: "timer_in_minuts",
                table: "tex_order_item_steps_detail");

            migrationBuilder.DropColumn(
                name: "main_order_item_id",
                table: "tex_order_item");

            migrationBuilder.DropColumn(
                name: "barcode",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "discount_status",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "main_product_id",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "min_qty",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "nds",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "percentage",
                table: "pos_product");

            migrationBuilder.DropColumn(
                name: "unitmeasurment_id",
                table: "pos_product");

            migrationBuilder.RenameColumn(
                name: "barcode",
                table: "pos_product_code",
                newName: "code");

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "pos_product",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "buyed_price",
                table: "pos_product",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }
    }
}
