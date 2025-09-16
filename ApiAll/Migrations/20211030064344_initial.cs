using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAll.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tex_invoice_item_tex_order_item_order_item_id",
                table: "tex_invoice_item");

            migrationBuilder.AlterColumn<long>(
                name: "order_item_id",
                table: "tex_invoice_item",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_item_tex_order_item_order_item_id",
                table: "tex_invoice_item",
                column: "order_item_id",
                principalTable: "tex_order_item",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tex_invoice_item_tex_order_item_order_item_id",
                table: "tex_invoice_item");

            migrationBuilder.AlterColumn<long>(
                name: "order_item_id",
                table: "tex_invoice_item",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_item_tex_order_item_order_item_id",
                table: "tex_invoice_item",
                column: "order_item_id",
                principalTable: "tex_order_item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
