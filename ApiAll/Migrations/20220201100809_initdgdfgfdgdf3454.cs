using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initdgdfgfdgdf3454 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hospital_doctor_earned_report",
                columns: table => new
                {
                    pos_name = table.Column<string>(type: "text", nullable: true),
                    fio = table.Column<string>(type: "text", nullable: true),
                    summ = table.Column<long>(type: "bigint", nullable: true),
                    cash = table.Column<long>(type: "bigint", nullable: true),
                    card = table.Column<long>(type: "bigint", nullable: true),
                    real_summ = table.Column<long>(type: "bigint", nullable: true),
                    dolg_summ = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "hospital_telegram_bot_information_builder",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    image_base_64_list = table.Column<List<string>>(type: "text[]", nullable: true),
                    images_url_list_after_saving_list = table.Column<List<string>>(type: "text[]", nullable: true),
                    title_name = table.Column<string>(type: "text", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_telegram_bot_information_builder", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hospital_doctor_earned_report");

            migrationBuilder.DropTable(
                name: "hospital_telegram_bot_information_builder");
        }
    }
}
