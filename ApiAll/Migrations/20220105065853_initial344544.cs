using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAll.Migrations
{
    public partial class initial344544 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosCreditor_pos_invoice_PosInvoiceid",
                table: "PosCreditor");

            migrationBuilder.DropForeignKey(
                name: "FK_PosCreditorItem_PosCreditor_PosCreditorid",
                table: "PosCreditorItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PosCreditorItem",
                table: "PosCreditorItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PosCreditor",
                table: "PosCreditor");

            migrationBuilder.RenameTable(
                name: "PosCreditorItem",
                newName: "pos_creditor_item");

            migrationBuilder.RenameTable(
                name: "PosCreditor",
                newName: "pos_creditor");

            migrationBuilder.RenameIndex(
                name: "IX_PosCreditorItem_PosCreditorid",
                table: "pos_creditor_item",
                newName: "IX_pos_creditor_item_PosCreditorid");

            migrationBuilder.RenameIndex(
                name: "IX_PosCreditor_PosInvoiceid",
                table: "pos_creditor",
                newName: "IX_pos_creditor_PosInvoiceid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pos_creditor_item",
                table: "pos_creditor_item",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pos_creditor",
                table: "pos_creditor",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_pos_creditor_pos_invoice_PosInvoiceid",
                table: "pos_creditor",
                column: "PosInvoiceid",
                principalTable: "pos_invoice",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pos_creditor_item_pos_creditor_PosCreditorid",
                table: "pos_creditor_item",
                column: "PosCreditorid",
                principalTable: "pos_creditor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pos_creditor_pos_invoice_PosInvoiceid",
                table: "pos_creditor");

            migrationBuilder.DropForeignKey(
                name: "FK_pos_creditor_item_pos_creditor_PosCreditorid",
                table: "pos_creditor_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pos_creditor_item",
                table: "pos_creditor_item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pos_creditor",
                table: "pos_creditor");

            migrationBuilder.RenameTable(
                name: "pos_creditor_item",
                newName: "PosCreditorItem");

            migrationBuilder.RenameTable(
                name: "pos_creditor",
                newName: "PosCreditor");

            migrationBuilder.RenameIndex(
                name: "IX_pos_creditor_item_PosCreditorid",
                table: "PosCreditorItem",
                newName: "IX_PosCreditorItem_PosCreditorid");

            migrationBuilder.RenameIndex(
                name: "IX_pos_creditor_PosInvoiceid",
                table: "PosCreditor",
                newName: "IX_PosCreditor_PosInvoiceid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PosCreditorItem",
                table: "PosCreditorItem",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PosCreditor",
                table: "PosCreditor",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PosCreditor_pos_invoice_PosInvoiceid",
                table: "PosCreditor",
                column: "PosInvoiceid",
                principalTable: "pos_invoice",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PosCreditorItem_PosCreditor_PosCreditorid",
                table: "PosCreditorItem",
                column: "PosCreditorid",
                principalTable: "PosCreditor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
