using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAll.Migrations
{
    public partial class initial18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "device_id",
                table: "archive_user_check_in_out_report",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "device_id",
                table: "archive_user_check_in_out_report");
        }
    }
}
