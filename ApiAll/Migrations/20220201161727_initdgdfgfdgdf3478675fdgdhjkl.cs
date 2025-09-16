using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAll.Migrations
{
    public partial class initdgdfgfdgdf3478675fdgdhjkl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "eritoriseti_izminenne",
                table: "hospital_peshob",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "prozrachnost",
                table: "hospital_peshob",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eritoriseti_izminenne",
                table: "hospital_peshob");

            migrationBuilder.DropColumn(
                name: "prozrachnost",
                table: "hospital_peshob");
        }
    }
}
