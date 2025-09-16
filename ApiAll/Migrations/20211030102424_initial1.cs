using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAll.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tex_category_type_product_producttype_id",
                table: "tex_category");

            migrationBuilder.AlterColumn<long>(
                name: "producttype_id",
                table: "tex_category",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_tex_category_type_product_producttype_id",
                table: "tex_category",
                column: "producttype_id",
                principalTable: "type_product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tex_category_type_product_producttype_id",
                table: "tex_category");

            migrationBuilder.AlterColumn<long>(
                name: "producttype_id",
                table: "tex_category",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_category_type_product_producttype_id",
                table: "tex_category",
                column: "producttype_id",
                principalTable: "type_product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
