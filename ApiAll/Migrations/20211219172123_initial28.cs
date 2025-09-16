using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAll.Migrations
{
    public partial class initial28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArchiveWorkingTime",
                columns: table => new
                {
                    working_time_without_gr = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchiveWorkingTime");
        }
    }
}
