using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAll.Migrations
{
    public partial class initial23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "time",
                table: "archive_user_check_in_out_report",
                newName: "checktime");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "archive_user_check_in_out_report",
                newName: "checkdate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "checktime",
                table: "archive_user_check_in_out_report",
                newName: "time");

            migrationBuilder.RenameColumn(
                name: "checkdate",
                table: "archive_user_check_in_out_report",
                newName: "date");
        }
    }
}
