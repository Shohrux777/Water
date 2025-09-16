using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial532dgfbvv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hospital_patient_analiz_history",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    analiz_name = table.Column<string>(type: "text", nullable: true),
                    analiz_file_name = table.Column<string>(type: "text", nullable: true),
                    date_time_reg = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    date_time_analiz_get = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    analiz_base_str = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_patient_analiz_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_patient_analiz_history_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hospital_patient_analiz_history_PatientsId",
                table: "hospital_patient_analiz_history",
                column: "PatientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hospital_patient_analiz_history");
        }
    }
}
