using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial34455667 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PosAuthorizationid",
                table: "pos_check",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "closed_status",
                table: "pos_check",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "pos_costs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    note = table.Column<string>(type: "text", nullable: true),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    PosAuthorizationid = table.Column<long>(type: "bigint", nullable: false),
                    closed_status = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_costs", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_costs_pos_authorization_PosAuthorizationid",
                        column: x => x.PosAuthorizationid,
                        principalTable: "pos_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pos_check_PosAuthorizationid",
                table: "pos_check",
                column: "PosAuthorizationid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_costs_PosAuthorizationid",
                table: "pos_costs",
                column: "PosAuthorizationid");

            migrationBuilder.AddForeignKey(
                name: "FK_pos_check_pos_authorization_PosAuthorizationid",
                table: "pos_check",
                column: "PosAuthorizationid",
                principalTable: "pos_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pos_check_pos_authorization_PosAuthorizationid",
                table: "pos_check");

            migrationBuilder.DropTable(
                name: "pos_costs");

            migrationBuilder.DropIndex(
                name: "IX_pos_check_PosAuthorizationid",
                table: "pos_check");

            migrationBuilder.DropColumn(
                name: "PosAuthorizationid",
                table: "pos_check");

            migrationBuilder.DropColumn(
                name: "closed_status",
                table: "pos_check");
        }
    }
}
