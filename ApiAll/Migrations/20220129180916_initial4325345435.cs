using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial4325345435 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "type_product",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_xaraktersitika_tool",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_xarakteristika",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_valyuta",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_upakovka",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_unit_measurment",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_suroviy_vid",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_sub_proccess",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_status",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_sort",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_sklad",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_size",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_service_type",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_production_type",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_product",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_position",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_planning_type",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_payment_type",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_order_item_steps_detail",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_order_item_steps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_order_item_step_permissions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_order_item",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_order",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_message_group",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_message",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_measurment_type",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_main_prossess",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_language",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_invoice_type",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_invoice_item",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_invoice",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_guscolor",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_extra_work",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_device_type",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_device_sub_proccess_detail",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_device",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_department",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_contragent",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_column_config",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_colorvariant_recipe",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_colorvariant",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_color_variant_type",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_color_proccess",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_color_group",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_color",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_category",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_calctype",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_batchprocess",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_batch",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inv_accepted_status",
                table: "tex_authorization",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "deac",
                table: "hospital_qondagi_garmonlar",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "hospital_bron_room",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    room_name = table.Column<string>(type: "text", nullable: true),
                    room_type = table.Column<string>(type: "text", nullable: true),
                    room_beds_count = table.Column<int>(type: "integer", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_bron_room", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hospital_bron_room_bed",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    beds_name = table.Column<string>(type: "text", nullable: true),
                    beds_type = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_bron_room_bed", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hospital_check_patient",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    payments_ids_list = table.Column<List<long>>(type: "bigint[]", nullable: true),
                    real_patient_name = table.Column<string>(type: "text", nullable: true),
                    reg_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    close_status = table.Column<bool>(type: "boolean", nullable: false),
                    summ = table.Column<long>(type: "bigint", nullable: false),
                    auth_id = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true),
                    sended_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_check_patient", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_check_patient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_creditor_inv",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    sum = table.Column<double>(type: "double precision", nullable: false),
                    real_sum = table.Column<double>(type: "double precision", nullable: false),
                    reg_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    real_patient_name = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    service_name = table.Column<string>(type: "text", nullable: true),
                    finish_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    ContragentId = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true),
                    sended_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_creditor_inv", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_creditor_inv_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_creditor_inv_contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_creditor_inv_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_creditor_inv_serviceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "serviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_dolg_inv",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    qty = table.Column<long>(type: "bigint", nullable: false),
                    real_qty = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true),
                    sended_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_dolg_inv", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_dolg_inv_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_patient_messgae_history",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    message_name = table.Column<string>(type: "text", nullable: true),
                    message_file_name = table.Column<string>(type: "text", nullable: true),
                    date_time_reg = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    date_time_analiz_get = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    message_base_str = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true),
                    sended_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_patient_messgae_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_patient_messgae_history_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_patinet_dolg_payments_history",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    summ = table.Column<long>(type: "bigint", nullable: false),
                    card_or_credit = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true),
                    sended_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_patinet_dolg_payments_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_patinet_dolg_payments_history_authorizations_Autho~",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_patinet_dolg_payments_history_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalDefaultSettings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    ContragentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalDefaultSettings", x => x.id);
                    table.ForeignKey(
                        name: "FK_HospitalDefaultSettings_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalDefaultSettings_contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalDefaultSettings_serviceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "serviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalDoctorShablons",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    shablon_name = table.Column<string>(type: "text", nullable: true),
                    shablon_content = table.Column<string>(type: "text", nullable: true),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalDoctorShablons", x => x.id);
                    table.ForeignKey(
                        name: "FK_HospitalDoctorShablons_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_bron_room_add_bed",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    HospitalBronRoomBedsid = table.Column<long>(type: "bigint", nullable: false),
                    HospitalBronRoomsid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_bron_room_add_bed", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_bron_room_add_bed_hospital_bron_room_bed_HospitalB~",
                        column: x => x.HospitalBronRoomBedsid,
                        principalTable: "hospital_bron_room_bed",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_bron_room_add_bed_hospital_bron_room_HospitalBronR~",
                        column: x => x.HospitalBronRoomsid,
                        principalTable: "hospital_bron_room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_patient_bron_room_bed",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    HospitalBronRoomBedsid = table.Column<long>(type: "bigint", nullable: false),
                    begin_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    free_status = table.Column<bool>(type: "boolean", nullable: false),
                    registrator_name = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    reg_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_patient_bron_room_bed", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_patient_bron_room_bed_authorizations_Authorization~",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_patient_bron_room_bed_hospital_bron_room_bed_Hospi~",
                        column: x => x.HospitalBronRoomBedsid,
                        principalTable: "hospital_bron_room_bed",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_patient_bron_room_bed_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_creditor_inv_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    HospitalCreditorid = table.Column<long>(type: "bigint", nullable: false),
                    reg_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    real_patient_name = table.Column<string>(type: "text", nullable: true),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true),
                    sended_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_creditor_inv_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_creditor_inv_item_hospital_creditor_inv_HospitalCr~",
                        column: x => x.HospitalCreditorid,
                        principalTable: "hospital_creditor_inv",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_creditor_inv_item_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_dolg_inv_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    HospitalPatientDolgid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true),
                    sended_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_dolg_inv_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_dolg_inv_item_hospital_dolg_inv_HospitalPatientDol~",
                        column: x => x.HospitalPatientDolgid,
                        principalTable: "hospital_dolg_inv",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_dolg_inv_item_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hospital_bron_room_add_bed_HospitalBronRoomBedsid",
                table: "hospital_bron_room_add_bed",
                column: "HospitalBronRoomBedsid");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_bron_room_add_bed_HospitalBronRoomsid",
                table: "hospital_bron_room_add_bed",
                column: "HospitalBronRoomsid");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_check_patient_PatientsId",
                table: "hospital_check_patient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_creditor_inv_AuthorizationId",
                table: "hospital_creditor_inv",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_creditor_inv_ContragentId",
                table: "hospital_creditor_inv",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_creditor_inv_PatientsId",
                table: "hospital_creditor_inv",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_creditor_inv_ServiceTypeId",
                table: "hospital_creditor_inv",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_creditor_inv_item_HospitalCreditorid",
                table: "hospital_creditor_inv_item",
                column: "HospitalCreditorid");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_creditor_inv_item_PatientsId",
                table: "hospital_creditor_inv_item",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_dolg_inv_PatientsId",
                table: "hospital_dolg_inv",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_dolg_inv_item_HospitalPatientDolgid",
                table: "hospital_dolg_inv_item",
                column: "HospitalPatientDolgid");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_dolg_inv_item_PatientsId",
                table: "hospital_dolg_inv_item",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_patient_bron_room_bed_AuthorizationId",
                table: "hospital_patient_bron_room_bed",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_patient_bron_room_bed_HospitalBronRoomBedsid",
                table: "hospital_patient_bron_room_bed",
                column: "HospitalBronRoomBedsid");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_patient_bron_room_bed_PatientsId",
                table: "hospital_patient_bron_room_bed",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_patient_messgae_history_PatientsId",
                table: "hospital_patient_messgae_history",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_patinet_dolg_payments_history_AuthorizationId",
                table: "hospital_patinet_dolg_payments_history",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_patinet_dolg_payments_history_PatientsId",
                table: "hospital_patinet_dolg_payments_history",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalDefaultSettings_AuthorizationId",
                table: "HospitalDefaultSettings",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalDefaultSettings_ContragentId",
                table: "HospitalDefaultSettings",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalDefaultSettings_ServiceTypeId",
                table: "HospitalDefaultSettings",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalDoctorShablons_AuthorizationId",
                table: "HospitalDoctorShablons",
                column: "AuthorizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hospital_bron_room_add_bed");

            migrationBuilder.DropTable(
                name: "hospital_check_patient");

            migrationBuilder.DropTable(
                name: "hospital_creditor_inv_item");

            migrationBuilder.DropTable(
                name: "hospital_dolg_inv_item");

            migrationBuilder.DropTable(
                name: "hospital_patient_bron_room_bed");

            migrationBuilder.DropTable(
                name: "hospital_patient_messgae_history");

            migrationBuilder.DropTable(
                name: "hospital_patinet_dolg_payments_history");

            migrationBuilder.DropTable(
                name: "HospitalDefaultSettings");

            migrationBuilder.DropTable(
                name: "HospitalDoctorShablons");

            migrationBuilder.DropTable(
                name: "hospital_bron_room");

            migrationBuilder.DropTable(
                name: "hospital_creditor_inv");

            migrationBuilder.DropTable(
                name: "hospital_dolg_inv");

            migrationBuilder.DropTable(
                name: "hospital_bron_room_bed");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "type_product");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_xaraktersitika_tool");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_xarakteristika");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_valyuta");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_user");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_upakovka");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_unit_measurment");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_suroviy_vid");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_sub_proccess");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_status");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_sort");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_sklad");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_size");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_service_type");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_production_type");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_product");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_position");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_planning_type");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_payment_type");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_order_item_steps_detail");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_order_item_steps");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_order_item_step_permissions");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_order_item");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_order");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_message_group");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_message");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_measurment_type");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_main_prossess");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_language");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_invoice_type");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_invoice_item");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_invoice");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_guscolor");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_extra_work");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_device_type");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_device_sub_proccess_detail");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_device");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_department");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_contragent");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_column_config");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_colorvariant_recipe");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_colorvariant");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_color_variant_type");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_color_proccess");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_color_group");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_color");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_category");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_calctype");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_batchprocess");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_batch");

            migrationBuilder.DropColumn(
                name: "inv_accepted_status",
                table: "tex_authorization");

            migrationBuilder.DropColumn(
                name: "deac",
                table: "hospital_qondagi_garmonlar");
        }
    }
}
