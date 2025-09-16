using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAll.Migrations
{
    public partial class initial3453222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TexSizeid",
                table: "tex_planning_items",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TexSubProductid",
                table: "tex_planning_items",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "measurment_name",
                table: "tex_planning_items",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "measurment_name_1",
                table: "tex_planning_items",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "sub_qty",
                table: "tex_planning_items",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "sub_qty_1",
                table: "tex_planning_items",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "sub_qty_2",
                table: "tex_planning_items",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "sub_qty_3",
                table: "tex_planning_items",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "sub_qty_4",
                table: "tex_planning_items",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "sub_qty_5",
                table: "tex_planning_items",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_items_TexSizeid",
                table: "tex_planning_items",
                column: "TexSizeid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_items_TexSubProductid",
                table: "tex_planning_items",
                column: "TexSubProductid");

            migrationBuilder.AddForeignKey(
                name: "FK_tex_planning_items_tex_size_TexSizeid",
                table: "tex_planning_items",
                column: "TexSizeid",
                principalTable: "tex_size",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_planning_items_tex_sub_product_TexSubProductid",
                table: "tex_planning_items",
                column: "TexSubProductid",
                principalTable: "tex_sub_product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tex_planning_items_tex_size_TexSizeid",
                table: "tex_planning_items");

            migrationBuilder.DropForeignKey(
                name: "FK_tex_planning_items_tex_sub_product_TexSubProductid",
                table: "tex_planning_items");

            migrationBuilder.DropIndex(
                name: "IX_tex_planning_items_TexSizeid",
                table: "tex_planning_items");

            migrationBuilder.DropIndex(
                name: "IX_tex_planning_items_TexSubProductid",
                table: "tex_planning_items");

            migrationBuilder.DropColumn(
                name: "TexSizeid",
                table: "tex_planning_items");

            migrationBuilder.DropColumn(
                name: "TexSubProductid",
                table: "tex_planning_items");

            migrationBuilder.DropColumn(
                name: "measurment_name",
                table: "tex_planning_items");

            migrationBuilder.DropColumn(
                name: "measurment_name_1",
                table: "tex_planning_items");

            migrationBuilder.DropColumn(
                name: "sub_qty",
                table: "tex_planning_items");

            migrationBuilder.DropColumn(
                name: "sub_qty_1",
                table: "tex_planning_items");

            migrationBuilder.DropColumn(
                name: "sub_qty_2",
                table: "tex_planning_items");

            migrationBuilder.DropColumn(
                name: "sub_qty_3",
                table: "tex_planning_items");

            migrationBuilder.DropColumn(
                name: "sub_qty_4",
                table: "tex_planning_items");

            migrationBuilder.DropColumn(
                name: "sub_qty_5",
                table: "tex_planning_items");
        }
    }
}
