using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAll.Migrations
{
    public partial class initial345345437888 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_vsk",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_umumiy_qon_taxlili",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_torch",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_rv",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_remoproba",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_qondagi_garmonlar",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_peshob",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_patient_analiz_history",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_onkomarker",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_nechiporenko",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_mazok",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_koagulogramma",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_gepatit_bc",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_express_gepatit_bc",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_covid_qon",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_covid_express",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sended_status",
                table: "hospital_bioximya_krov",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_vsk");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_umumiy_qon_taxlili");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_torch");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_rv");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_remoproba");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_qondagi_garmonlar");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_peshob");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_patient_analiz_history");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_onkomarker");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_nechiporenko");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_mazok");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_koagulogramma");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_gepatit_bc");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_express_gepatit_bc");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_covid_qon");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_covid_express");

            migrationBuilder.DropColumn(
                name: "sended_status",
                table: "hospital_bioximya_krov");
        }
    }
}
