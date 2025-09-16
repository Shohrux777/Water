using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class fsdfsdfdsfdsfdsfdsfdsfds34543534 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "link_str",
                table: "serviceTypes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "um_item_1",
                table: "hospital_umumiy_qon_taxlili",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "um_item_10",
                table: "hospital_umumiy_qon_taxlili",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "um_item_2",
                table: "hospital_umumiy_qon_taxlili",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "um_item_3",
                table: "hospital_umumiy_qon_taxlili",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "um_item_4",
                table: "hospital_umumiy_qon_taxlili",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "um_item_5",
                table: "hospital_umumiy_qon_taxlili",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "um_item_6",
                table: "hospital_umumiy_qon_taxlili",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "um_item_7",
                table: "hospital_umumiy_qon_taxlili",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "um_item_8",
                table: "hospital_umumiy_qon_taxlili",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "um_item_9",
                table: "hospital_umumiy_qon_taxlili",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "obshiy_t3",
                table: "hospital_qondagi_garmonlar",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "svabodniy_t3",
                table: "hospital_qondagi_garmonlar",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "a",
                table: "hospital_gepatit_bc",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "b",
                table: "hospital_gepatit_bc",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "c",
                table: "hospital_gepatit_bc",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "d",
                table: "hospital_gepatit_bc",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "note",
                table: "hospital_gepatit_bc",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "hospital_analiz_gepatit",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    hav = table.Column<string>(type: "text", nullable: true),
                    hsg = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_gepatit", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_gepatit_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_number_mark",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentsId = table.Column<long>(type: "bigint", nullable: false),
                    finish_analiz = table.Column<bool>(type: "boolean", nullable: false),
                    link_str = table.Column<string>(type: "text", nullable: true),
                    date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                    table.PrimaryKey("PK_hospital_analiz_number_mark", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_number_mark_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_number_mark_payments_PaymentsId",
                        column: x => x.PaymentsId,
                        principalTable: "payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_number_mark_serviceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "serviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_sperma",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name_1 = table.Column<string>(type: "text", nullable: true),
                    name_2 = table.Column<string>(type: "text", nullable: true),
                    name_3 = table.Column<string>(type: "text", nullable: true),
                    name_4 = table.Column<string>(type: "text", nullable: true),
                    name_5 = table.Column<string>(type: "text", nullable: true),
                    name_6 = table.Column<string>(type: "text", nullable: true),
                    name_7 = table.Column<string>(type: "text", nullable: true),
                    name_8 = table.Column<string>(type: "text", nullable: true),
                    name_9 = table.Column<string>(type: "text", nullable: true),
                    name_10 = table.Column<string>(type: "text", nullable: true),
                    name_11 = table.Column<string>(type: "text", nullable: true),
                    name_12 = table.Column<string>(type: "text", nullable: true),
                    name_13 = table.Column<string>(type: "text", nullable: true),
                    name_14 = table.Column<string>(type: "text", nullable: true),
                    name_15 = table.Column<string>(type: "text", nullable: true),
                    name_16 = table.Column<string>(type: "text", nullable: true),
                    name_17 = table.Column<string>(type: "text", nullable: true),
                    name_18 = table.Column<string>(type: "text", nullable: true),
                    name_19 = table.Column<string>(type: "text", nullable: true),
                    name_20 = table.Column<string>(type: "text", nullable: true),
                    name_21 = table.Column<string>(type: "text", nullable: true),
                    name_22 = table.Column<string>(type: "text", nullable: true),
                    name_23 = table.Column<string>(type: "text", nullable: true),
                    name_24 = table.Column<string>(type: "text", nullable: true),
                    name_25 = table.Column<string>(type: "text", nullable: true),
                    name_26 = table.Column<string>(type: "text", nullable: true),
                    name_27 = table.Column<string>(type: "text", nullable: true),
                    name_28 = table.Column<string>(type: "text", nullable: true),
                    name_29 = table.Column<string>(type: "text", nullable: true),
                    name_30 = table.Column<string>(type: "text", nullable: true),
                    name_31 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_sperma", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_sperma_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_marker_serive_types_with_number",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    note = table.Column<string>(type: "text", nullable: true),
                    group_name = table.Column<string>(type: "text", nullable: true),
                    payments_list = table.Column<List<long>>(type: "bigint[]", nullable: true),
                    serviece_types = table.Column<List<long>>(type: "bigint[]", nullable: true),
                    number_str = table.Column<string>(type: "text", nullable: true),
                    finish_all_chekings = table.Column<bool>(type: "boolean", nullable: false),
                    url_str = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_marker_serive_types_with_number", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_marker_serive_types_with_number_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_client",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fio = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    born_date = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_1 = table.Column<string>(type: "text", nullable: true),
                    phone_number_2 = table.Column<string>(type: "text", nullable: true),
                    image_str = table.Column<string>(type: "text", nullable: true),
                    passport_number_str = table.Column<string>(type: "text", nullable: true),
                    bot_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_company",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_fanlar",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    summ_for_teacher = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_fanlar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_invoice",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    note = table.Column<string>(type: "text", nullable: true),
                    inv_number = table.Column<string>(type: "text", nullable: true),
                    date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_invoice", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_position",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_position", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_probniy_darslar",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    begin_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    end_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    finish_group = table.Column<bool>(type: "boolean", nullable: false),
                    intermade_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_probniy_darslar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_check",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    credit = table.Column<double>(type: "double precision", nullable: false),
                    debit = table.Column<double>(type: "double precision", nullable: false),
                    cash = table.Column<double>(type: "double precision", nullable: false),
                    card = table.Column<double>(type: "double precision", nullable: false),
                    online = table.Column<double>(type: "double precision", nullable: false),
                    salary = table.Column<double>(type: "double precision", nullable: false),
                    OquvMarkazClientid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_check", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_check_oquv_markaz_client_OquvMarkazClientid",
                        column: x => x.OquvMarkazClientid,
                        principalTable: "oquv_markaz_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_credit",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    real_summ = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    OquvMarkazClientid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_credit", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_credit_oquv_markaz_client_OquvMarkazClientid",
                        column: x => x.OquvMarkazClientid,
                        principalTable: "oquv_markaz_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_debit",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    real_summ = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    OquvMarkazClientid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_debit", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_debit_oquv_markaz_client_OquvMarkazClientid",
                        column: x => x.OquvMarkazClientid,
                        principalTable: "oquv_markaz_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_department",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazCompanyid = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_department", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_department_oquv_markaz_company_OquvMarkazCompan~",
                        column: x => x.OquvMarkazCompanyid,
                        principalTable: "oquv_markaz_company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_invlice_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    unit_price = table.Column<double>(type: "double precision", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    OquvMarkazProductid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazInvoiceid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_invlice_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_invlice_item_oquv_markaz_invoice_OquvMarkazInvo~",
                        column: x => x.OquvMarkazInvoiceid,
                        principalTable: "oquv_markaz_invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_invlice_item_oquv_markaz_product_OquvMarkazProd~",
                        column: x => x.OquvMarkazProductid,
                        principalTable: "oquv_markaz_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_ostatka",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazProductid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_ostatka", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_ostatka_oquv_markaz_product_OquvMarkazProductid",
                        column: x => x.OquvMarkazProductid,
                        principalTable: "oquv_markaz_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_payments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazCheckid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazClientid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazFanlarid = table.Column<long>(type: "bigint", nullable: true),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_payments_oquv_markaz_check_OquvMarkazCheckid",
                        column: x => x.OquvMarkazCheckid,
                        principalTable: "oquv_markaz_check",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_payments_oquv_markaz_client_OquvMarkazClientid",
                        column: x => x.OquvMarkazClientid,
                        principalTable: "oquv_markaz_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_payments_oquv_markaz_fanlar_OquvMarkazFanlarid",
                        column: x => x.OquvMarkazFanlarid,
                        principalTable: "oquv_markaz_fanlar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_credit_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazCheckid = table.Column<long>(type: "bigint", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    OquvMarkazCreditid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_credit_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_credit_item_oquv_markaz_check_OquvMarkazCheckid",
                        column: x => x.OquvMarkazCheckid,
                        principalTable: "oquv_markaz_check",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_credit_item_oquv_markaz_credit_OquvMarkazCredit~",
                        column: x => x.OquvMarkazCreditid,
                        principalTable: "oquv_markaz_credit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_debit_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazCheckid = table.Column<long>(type: "bigint", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    OquvMarkazDebitid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_debit_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_debit_item_oquv_markaz_check_OquvMarkazCheckid",
                        column: x => x.OquvMarkazCheckid,
                        principalTable: "oquv_markaz_check",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_debit_item_oquv_markaz_debit_OquvMarkazDebitid",
                        column: x => x.OquvMarkazDebitid,
                        principalTable: "oquv_markaz_debit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fio = table.Column<string>(type: "text", nullable: true),
                    OquvMarkazDepartmentid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazPositionid = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    bot_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_user_oquv_markaz_department_OquvMarkazDepartmen~",
                        column: x => x.OquvMarkazDepartmentid,
                        principalTable: "oquv_markaz_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_user_oquv_markaz_position_OquvMarkazPositionid",
                        column: x => x.OquvMarkazPositionid,
                        principalTable: "oquv_markaz_position",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_authorization",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    login = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    user_type = table.Column<int>(type: "integer", nullable: false),
                    OquvMarkazUserid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_authorization", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_authorization_oquv_markaz_user_OquvMarkazUserid",
                        column: x => x.OquvMarkazUserid,
                        principalTable: "oquv_markaz_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_check_in_out",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazClientid = table.Column<long>(type: "bigint", nullable: true),
                    OquvMarkazUserid = table.Column<long>(type: "bigint", nullable: true),
                    get_date = table.Column<DateTime>(type: "date", nullable: false),
                    get_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    saved_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    user_or_client = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_check_in_out", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_check_in_out_oquv_markaz_client_OquvMarkazClien~",
                        column: x => x.OquvMarkazClientid,
                        principalTable: "oquv_markaz_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_check_in_out_oquv_markaz_user_OquvMarkazUserid",
                        column: x => x.OquvMarkazUserid,
                        principalTable: "oquv_markaz_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_pupil_groups",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    begin_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    end_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    finish_group = table.Column<bool>(type: "boolean", nullable: false),
                    OquvMarkazUserid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazFanlarid = table.Column<long>(type: "bigint", nullable: false),
                    week_days = table.Column<List<double>>(type: "double precision[]", nullable: true),
                    gruppa_opened_date = table.Column<DateTime>(type: "date", nullable: false),
                    opened_group_status = table.Column<bool>(type: "boolean", nullable: false),
                    count_of_lessons_in_month = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_pupil_groups", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_pupil_groups_oquv_markaz_fanlar_OquvMarkazFanla~",
                        column: x => x.OquvMarkazFanlarid,
                        principalTable: "oquv_markaz_fanlar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_pupil_groups_oquv_markaz_user_OquvMarkazUserid",
                        column: x => x.OquvMarkazUserid,
                        principalTable: "oquv_markaz_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_rasxod_list",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    note = table.Column<string>(type: "text", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    OquvMarkazUserid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazProductid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_rasxod_list", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_rasxod_list_oquv_markaz_product_OquvMarkazProdu~",
                        column: x => x.OquvMarkazProductid,
                        principalTable: "oquv_markaz_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_rasxod_list_oquv_markaz_user_OquvMarkazUserid",
                        column: x => x.OquvMarkazUserid,
                        principalTable: "oquv_markaz_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_teacher_bonus",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    real_summ = table.Column<double>(type: "double precision", nullable: false),
                    OquvMarkazUserid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_teacher_bonus", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_teacher_bonus_oquv_markaz_user_OquvMarkazUserid",
                        column: x => x.OquvMarkazUserid,
                        principalTable: "oquv_markaz_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_teacher_bonus_payed_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    OquvMarkazUserid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_teacher_bonus_payed_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_teacher_bonus_payed_item_oquv_markaz_user_OquvM~",
                        column: x => x.OquvMarkazUserid,
                        principalTable: "oquv_markaz_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_user_salary",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazUserid = table.Column<long>(type: "bigint", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    real_summ = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_user_salary", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_user_salary_oquv_markaz_user_OquvMarkazUserid",
                        column: x => x.OquvMarkazUserid,
                        principalTable: "oquv_markaz_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_fan_and_group_payment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazClientid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazPupilGroupsid = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    payed_or_not = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_fan_and_group_payment", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_fan_and_group_payment_oquv_markaz_client_OquvMa~",
                        column: x => x.OquvMarkazClientid,
                        principalTable: "oquv_markaz_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_fan_and_group_payment_oquv_markaz_pupil_groups_~",
                        column: x => x.OquvMarkazPupilGroupsid,
                        principalTable: "oquv_markaz_pupil_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_fan_and_group_payment_left_lessons",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazClientid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazPupilGroupsid = table.Column<long>(type: "bigint", nullable: false),
                    left_real_lessons_count = table.Column<long>(type: "bigint", nullable: false),
                    lessons_count = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_fan_and_group_payment_left_lessons", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_fan_and_group_payment_left_lessons_oquv_markaz_~",
                        column: x => x.OquvMarkazClientid,
                        principalTable: "oquv_markaz_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_fan_and_group_payment_left_lessons_oquv_markaz~1",
                        column: x => x.OquvMarkazPupilGroupsid,
                        principalTable: "oquv_markaz_pupil_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_pupil_groups_detail_info",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazClientid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazPupilGroupsid = table.Column<long>(type: "bigint", nullable: false),
                    finished_group = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_pupil_groups_detail_info", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_pupil_groups_detail_info_oquv_markaz_client_Oqu~",
                        column: x => x.OquvMarkazClientid,
                        principalTable: "oquv_markaz_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_pupil_groups_detail_info_oquv_markaz_pupil_grou~",
                        column: x => x.OquvMarkazPupilGroupsid,
                        principalTable: "oquv_markaz_pupil_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_salary_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    OquvMarkazUserSalaryid = table.Column<long>(type: "bigint", nullable: false),
                    date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_salary_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_salary_item_oquv_markaz_user_salary_OquvMarkazU~",
                        column: x => x.OquvMarkazUserSalaryid,
                        principalTable: "oquv_markaz_user_salary",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_gepatit_PatientsId",
                table: "hospital_analiz_gepatit",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_number_mark_PatientsId",
                table: "hospital_analiz_number_mark",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_number_mark_PaymentsId",
                table: "hospital_analiz_number_mark",
                column: "PaymentsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_number_mark_ServiceTypeId",
                table: "hospital_analiz_number_mark",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_sperma_PatientsId",
                table: "hospital_analiz_sperma",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_marker_serive_types_with_number_PatientsId",
                table: "hospital_marker_serive_types_with_number",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_authorization_OquvMarkazUserid",
                table: "oquv_markaz_authorization",
                column: "OquvMarkazUserid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_check_OquvMarkazClientid",
                table: "oquv_markaz_check",
                column: "OquvMarkazClientid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_check_in_out_OquvMarkazClientid",
                table: "oquv_markaz_check_in_out",
                column: "OquvMarkazClientid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_check_in_out_OquvMarkazUserid",
                table: "oquv_markaz_check_in_out",
                column: "OquvMarkazUserid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_credit_OquvMarkazClientid",
                table: "oquv_markaz_credit",
                column: "OquvMarkazClientid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_credit_item_OquvMarkazCheckid",
                table: "oquv_markaz_credit_item",
                column: "OquvMarkazCheckid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_credit_item_OquvMarkazCreditid",
                table: "oquv_markaz_credit_item",
                column: "OquvMarkazCreditid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_debit_OquvMarkazClientid",
                table: "oquv_markaz_debit",
                column: "OquvMarkazClientid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_debit_item_OquvMarkazCheckid",
                table: "oquv_markaz_debit_item",
                column: "OquvMarkazCheckid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_debit_item_OquvMarkazDebitid",
                table: "oquv_markaz_debit_item",
                column: "OquvMarkazDebitid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_department_OquvMarkazCompanyid",
                table: "oquv_markaz_department",
                column: "OquvMarkazCompanyid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_fan_and_group_payment_OquvMarkazClientid",
                table: "oquv_markaz_fan_and_group_payment",
                column: "OquvMarkazClientid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_fan_and_group_payment_OquvMarkazPupilGroupsid",
                table: "oquv_markaz_fan_and_group_payment",
                column: "OquvMarkazPupilGroupsid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_fan_and_group_payment_left_lessons_OquvMarkazCl~",
                table: "oquv_markaz_fan_and_group_payment_left_lessons",
                column: "OquvMarkazClientid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_fan_and_group_payment_left_lessons_OquvMarkazPu~",
                table: "oquv_markaz_fan_and_group_payment_left_lessons",
                column: "OquvMarkazPupilGroupsid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_invlice_item_OquvMarkazInvoiceid",
                table: "oquv_markaz_invlice_item",
                column: "OquvMarkazInvoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_invlice_item_OquvMarkazProductid",
                table: "oquv_markaz_invlice_item",
                column: "OquvMarkazProductid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_ostatka_OquvMarkazProductid",
                table: "oquv_markaz_ostatka",
                column: "OquvMarkazProductid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_payments_OquvMarkazCheckid",
                table: "oquv_markaz_payments",
                column: "OquvMarkazCheckid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_payments_OquvMarkazClientid",
                table: "oquv_markaz_payments",
                column: "OquvMarkazClientid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_payments_OquvMarkazFanlarid",
                table: "oquv_markaz_payments",
                column: "OquvMarkazFanlarid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_pupil_groups_OquvMarkazFanlarid",
                table: "oquv_markaz_pupil_groups",
                column: "OquvMarkazFanlarid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_pupil_groups_OquvMarkazUserid",
                table: "oquv_markaz_pupil_groups",
                column: "OquvMarkazUserid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_pupil_groups_detail_info_OquvMarkazClientid",
                table: "oquv_markaz_pupil_groups_detail_info",
                column: "OquvMarkazClientid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_pupil_groups_detail_info_OquvMarkazPupilGroupsid",
                table: "oquv_markaz_pupil_groups_detail_info",
                column: "OquvMarkazPupilGroupsid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_rasxod_list_OquvMarkazProductid",
                table: "oquv_markaz_rasxod_list",
                column: "OquvMarkazProductid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_rasxod_list_OquvMarkazUserid",
                table: "oquv_markaz_rasxod_list",
                column: "OquvMarkazUserid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_salary_item_OquvMarkazUserSalaryid",
                table: "oquv_markaz_salary_item",
                column: "OquvMarkazUserSalaryid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_teacher_bonus_OquvMarkazUserid",
                table: "oquv_markaz_teacher_bonus",
                column: "OquvMarkazUserid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_teacher_bonus_payed_item_OquvMarkazUserid",
                table: "oquv_markaz_teacher_bonus_payed_item",
                column: "OquvMarkazUserid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_user_OquvMarkazDepartmentid",
                table: "oquv_markaz_user",
                column: "OquvMarkazDepartmentid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_user_OquvMarkazPositionid",
                table: "oquv_markaz_user",
                column: "OquvMarkazPositionid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_user_salary_OquvMarkazUserid",
                table: "oquv_markaz_user_salary",
                column: "OquvMarkazUserid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hospital_analiz_gepatit");

            migrationBuilder.DropTable(
                name: "hospital_analiz_number_mark");

            migrationBuilder.DropTable(
                name: "hospital_analiz_sperma");

            migrationBuilder.DropTable(
                name: "hospital_marker_serive_types_with_number");

            migrationBuilder.DropTable(
                name: "oquv_markaz_authorization");

            migrationBuilder.DropTable(
                name: "oquv_markaz_check_in_out");

            migrationBuilder.DropTable(
                name: "oquv_markaz_credit_item");

            migrationBuilder.DropTable(
                name: "oquv_markaz_debit_item");

            migrationBuilder.DropTable(
                name: "oquv_markaz_fan_and_group_payment");

            migrationBuilder.DropTable(
                name: "oquv_markaz_fan_and_group_payment_left_lessons");

            migrationBuilder.DropTable(
                name: "oquv_markaz_invlice_item");

            migrationBuilder.DropTable(
                name: "oquv_markaz_ostatka");

            migrationBuilder.DropTable(
                name: "oquv_markaz_payments");

            migrationBuilder.DropTable(
                name: "oquv_markaz_probniy_darslar");

            migrationBuilder.DropTable(
                name: "oquv_markaz_pupil_groups_detail_info");

            migrationBuilder.DropTable(
                name: "oquv_markaz_rasxod_list");

            migrationBuilder.DropTable(
                name: "oquv_markaz_salary_item");

            migrationBuilder.DropTable(
                name: "oquv_markaz_teacher_bonus");

            migrationBuilder.DropTable(
                name: "oquv_markaz_teacher_bonus_payed_item");

            migrationBuilder.DropTable(
                name: "oquv_markaz_credit");

            migrationBuilder.DropTable(
                name: "oquv_markaz_debit");

            migrationBuilder.DropTable(
                name: "oquv_markaz_invoice");

            migrationBuilder.DropTable(
                name: "oquv_markaz_check");

            migrationBuilder.DropTable(
                name: "oquv_markaz_pupil_groups");

            migrationBuilder.DropTable(
                name: "oquv_markaz_product");

            migrationBuilder.DropTable(
                name: "oquv_markaz_user_salary");

            migrationBuilder.DropTable(
                name: "oquv_markaz_client");

            migrationBuilder.DropTable(
                name: "oquv_markaz_fanlar");

            migrationBuilder.DropTable(
                name: "oquv_markaz_user");

            migrationBuilder.DropTable(
                name: "oquv_markaz_department");

            migrationBuilder.DropTable(
                name: "oquv_markaz_position");

            migrationBuilder.DropTable(
                name: "oquv_markaz_company");

            migrationBuilder.DropColumn(
                name: "link_str",
                table: "serviceTypes");

            migrationBuilder.DropColumn(
                name: "um_item_1",
                table: "hospital_umumiy_qon_taxlili");

            migrationBuilder.DropColumn(
                name: "um_item_10",
                table: "hospital_umumiy_qon_taxlili");

            migrationBuilder.DropColumn(
                name: "um_item_2",
                table: "hospital_umumiy_qon_taxlili");

            migrationBuilder.DropColumn(
                name: "um_item_3",
                table: "hospital_umumiy_qon_taxlili");

            migrationBuilder.DropColumn(
                name: "um_item_4",
                table: "hospital_umumiy_qon_taxlili");

            migrationBuilder.DropColumn(
                name: "um_item_5",
                table: "hospital_umumiy_qon_taxlili");

            migrationBuilder.DropColumn(
                name: "um_item_6",
                table: "hospital_umumiy_qon_taxlili");

            migrationBuilder.DropColumn(
                name: "um_item_7",
                table: "hospital_umumiy_qon_taxlili");

            migrationBuilder.DropColumn(
                name: "um_item_8",
                table: "hospital_umumiy_qon_taxlili");

            migrationBuilder.DropColumn(
                name: "um_item_9",
                table: "hospital_umumiy_qon_taxlili");

            migrationBuilder.DropColumn(
                name: "obshiy_t3",
                table: "hospital_qondagi_garmonlar");

            migrationBuilder.DropColumn(
                name: "svabodniy_t3",
                table: "hospital_qondagi_garmonlar");

            migrationBuilder.DropColumn(
                name: "a",
                table: "hospital_gepatit_bc");

            migrationBuilder.DropColumn(
                name: "b",
                table: "hospital_gepatit_bc");

            migrationBuilder.DropColumn(
                name: "c",
                table: "hospital_gepatit_bc");

            migrationBuilder.DropColumn(
                name: "d",
                table: "hospital_gepatit_bc");

            migrationBuilder.DropColumn(
                name: "note",
                table: "hospital_gepatit_bc");
        }
    }
}
