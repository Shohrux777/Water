using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial34534543 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_oquv_markaz_check_oquv_markaz_client_OquvMarkazClientid",
                table: "oquv_markaz_check");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkudSababli",
                table: "SkudSababli");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkudPeriod",
                table: "SkudPeriod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkudMyDepartments",
                table: "SkudMyDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkudMyCheckinout",
                table: "SkudMyCheckinout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkudImages",
                table: "SkudImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkudGroupAccess",
                table: "SkudGroupAccess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkudGrForEmp",
                table: "SkudGrForEmp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkudForTrenajor",
                table: "SkudForTrenajor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkudDoorCheckinout",
                table: "SkudDoorCheckinout");

            migrationBuilder.RenameTable(
                name: "SkudSmena",
                newName: "skud_smenam");

            migrationBuilder.RenameTable(
                name: "SkudSababli",
                newName: "skud_sababli");

            migrationBuilder.RenameTable(
                name: "SkudResultGr",
                newName: "skud_result_gr");

            migrationBuilder.RenameTable(
                name: "SkudPictureCheckinout",
                newName: "skud_picture_checkinout");

            migrationBuilder.RenameTable(
                name: "SkudPeriod",
                newName: "skud_period");

            migrationBuilder.RenameTable(
                name: "SkudMyDepartments",
                newName: "skud_my_department");

            migrationBuilder.RenameTable(
                name: "SkudMyCheckinout",
                newName: "skud_my_checkinout");

            migrationBuilder.RenameTable(
                name: "SkudLk",
                newName: "skud_lk");

            migrationBuilder.RenameTable(
                name: "SkudImages",
                newName: "skud_images");

            migrationBuilder.RenameTable(
                name: "SkudGroupAccess",
                newName: "skud_group_access");

            migrationBuilder.RenameTable(
                name: "SkudGrForEmp",
                newName: "skud_gr_for_emp");

            migrationBuilder.RenameTable(
                name: "SkudForTrenajor",
                newName: "skud_for_trenajor");

            migrationBuilder.RenameTable(
                name: "SkudFaces",
                newName: "skud_faces");

            migrationBuilder.RenameTable(
                name: "SkudDoors",
                newName: "skud_doors");

            migrationBuilder.RenameTable(
                name: "SkudDoorCheckinout",
                newName: "skud_door_checkinout");

            migrationBuilder.RenameIndex(
                name: "IX_SkudMyDepartments_deptname",
                table: "skud_my_department",
                newName: "IX_skud_my_department_deptname");

            migrationBuilder.RenameIndex(
                name: "IX_SkudMyCheckinout_userid_sana_checktime",
                table: "skud_my_checkinout",
                newName: "IX_skud_my_checkinout_userid_sana_checktime");

            migrationBuilder.RenameIndex(
                name: "IX_SkudLk_lkey",
                table: "skud_lk",
                newName: "IX_skud_lk_lkey");

            migrationBuilder.RenameIndex(
                name: "IX_SkudFaces_nomi",
                table: "skud_faces",
                newName: "IX_skud_faces_nomi");

            migrationBuilder.RenameIndex(
                name: "IX_SkudFaces_ip",
                table: "skud_faces",
                newName: "IX_skud_faces_ip");

            migrationBuilder.RenameIndex(
                name: "IX_SkudDoors_dbname",
                table: "skud_doors",
                newName: "IX_skud_doors_dbname");

            migrationBuilder.RenameIndex(
                name: "IX_SkudDoorCheckinout_userid_sana_checktime",
                table: "skud_door_checkinout",
                newName: "IX_skud_door_checkinout_userid_sana_checktime");

            migrationBuilder.AddColumn<long>(
                name: "TexSizeTypeid",
                table: "tex_size",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_user",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_user",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "car_number",
                table: "tegirmon_user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "card_number",
                table: "tegirmon_user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "salary",
                table: "tegirmon_user",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "user_face_id",
                table: "tegirmon_user",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_unit_measurment",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_unit_measurment",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_telegram_bot_message",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_telegram_bot_message",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_product",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_product",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "buyed_price",
                table: "tegirmon_product",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "shitrix_code",
                table: "tegirmon_product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_payments",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_payments",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_ostatka",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_ostatka",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_invoice_type",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_invoice_type",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_invoice_item",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_invoice_item",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TegirmonProductid",
                table: "tegirmon_invoice",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_invoice",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_invoice",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "client_names_list",
                table: "tegirmon_invoice",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "get_money_for_bugdoy_zaxira",
                table: "tegirmon_invoice",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "image_str_url",
                table: "tegirmon_invoice",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "qty_real",
                table: "tegirmon_invoice",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "status_inv_type_name",
                table: "tegirmon_invoice",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_distict",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_distict",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_department",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_department",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_debit_product_detail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_debit_product_detail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_debit_detail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_debit_detail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_debit",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_debit",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_credit_detail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_credit_detail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_credit",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_credit",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_contragent",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_contragent",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_client_group",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_client_group",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_client",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_client",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reserve",
                table: "tegirmon_client",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "reserve_val",
                table: "tegirmon_client",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "reserve_val_l",
                table: "tegirmon_client",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_check_in_out_detail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_check_in_out_detail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_check",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_check",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "for_buy_tovar_rasxod",
                table: "tegirmon_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "online",
                table: "tegirmon_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "rasxod",
                table: "tegirmon_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "salary",
                table: "tegirmon_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "srogi_otganlar_uchun_rasxod",
                table: "tegirmon_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_creator_id",
                table: "tegirmon_authorization",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "auth_user_updator_id",
                table: "tegirmon_authorization",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OquvMarkazClientid",
                table: "oquv_markaz_salary_item",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OquvMarkazPupilGroupsid",
                table: "oquv_markaz_salary_item",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<List<int>>(
                name: "week_days",
                table: "oquv_markaz_pupil_groups",
                type: "integer[]",
                nullable: true,
                oldClrType: typeof(List<double>),
                oldType: "double precision[]",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "bonus_summ",
                table: "oquv_markaz_fan_and_group_payment_left_lessons",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "bonus_summ_for_one_lesson",
                table: "oquv_markaz_fan_and_group_payment_left_lessons",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "OquvMarkazClientTypeid",
                table: "oquv_markaz_client",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OquvMarkazContragentid",
                table: "oquv_markaz_client",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "free_days",
                table: "oquv_markaz_client",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "free_pupil_time",
                table: "oquv_markaz_client",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "free_time",
                table: "oquv_markaz_client",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "note",
                table: "oquv_markaz_client",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "waiting_status",
                table: "oquv_markaz_client",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "OquvMarkazClientid",
                table: "oquv_markaz_check",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "OquvMarkazAuthid",
                table: "oquv_markaz_check",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OquvMarkazUserid",
                table: "oquv_markaz_check",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "bonus_summ",
                table: "oquv_markaz_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "cashback_card",
                table: "oquv_markaz_check",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "cashback_summ",
                table: "oquv_markaz_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "cashback_user_phone_number",
                table: "oquv_markaz_check",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cassir_name",
                table: "oquv_markaz_check",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "discount",
                table: "oquv_markaz_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "discount_pesantage",
                table: "oquv_markaz_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "discount_summ",
                table: "oquv_markaz_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "kam_chiqqan_summ",
                table: "oquv_markaz_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "kassa_close_status",
                table: "oquv_markaz_check",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "note",
                table: "oquv_markaz_check",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "rasxod",
                table: "oquv_markaz_check",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "reserve",
                table: "oquv_markaz_check",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "oquv_markaz_check",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_1",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_10",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_11",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_12",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_13",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_14",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_15",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_16",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_17",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_18",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_19",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_2",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_20",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_21",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_22",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_23",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_3",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_4",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_5",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_6",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_7",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_8",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "info_9",
                table: "archive_room",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_skud_sababli",
                table: "skud_sababli",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skud_period",
                table: "skud_period",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skud_my_department",
                table: "skud_my_department",
                column: "deptid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skud_my_checkinout",
                table: "skud_my_checkinout",
                column: "code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skud_images",
                table: "skud_images",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skud_group_access",
                table: "skud_group_access",
                column: "group_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skud_gr_for_emp",
                table: "skud_gr_for_emp",
                column: "id_emp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skud_for_trenajor",
                table: "skud_for_trenajor",
                column: "userid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skud_door_checkinout",
                table: "skud_door_checkinout",
                column: "code");

            migrationBuilder.CreateTable(
                name: "archive_javon",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archive_javon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "archive_quti",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    number = table.Column<string>(type: "text", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archive_quti", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "archive_stelaj",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archive_stelaj", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "archive_tokcha",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archive_tokcha", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "archive_xujjat",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    yili = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    registration_number = table.Column<string>(type: "text", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archive_xujjat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "archive_xujjat_turi",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archive_xujjat_turi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_1",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_1", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_1_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_10",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_10", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_10_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_11",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_11", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_11_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_12",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_12", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_12_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_13",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_13", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_13_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_14",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_14", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_14_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_15",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_15", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_15_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_16",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_16", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_16_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_17",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
                    name_33 = table.Column<string>(type: "text", nullable: true),
                    name_34 = table.Column<string>(type: "text", nullable: true),
                    name_35 = table.Column<string>(type: "text", nullable: true),
                    name_36 = table.Column<string>(type: "text", nullable: true),
                    name_37 = table.Column<string>(type: "text", nullable: true),
                    name_38 = table.Column<string>(type: "text", nullable: true),
                    name_39 = table.Column<string>(type: "text", nullable: true),
                    name_40 = table.Column<string>(type: "text", nullable: true),
                    name_41 = table.Column<string>(type: "text", nullable: true),
                    name_42 = table.Column<string>(type: "text", nullable: true),
                    name_43 = table.Column<string>(type: "text", nullable: true),
                    name_44 = table.Column<string>(type: "text", nullable: true),
                    name_45 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_17", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_17_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_2",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_2", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_2_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_3",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_3", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_3_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_4",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_4", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_4_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_5",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_5", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_5_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_6",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_6", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_6_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_7",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_7", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_7_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_8",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_8", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_8_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_analiz_9",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
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
                    name_32 = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_hospital_analiz_9", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_analiz_9_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_beds_type_and_summ",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    sum = table.Column<double>(type: "double precision", nullable: false),
                    discount_sum = table.Column<double>(type: "double precision", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    patient_or_not = table.Column<bool>(type: "boolean", nullable: false),
                    rooms_id_list = table.Column<List<long>>(type: "bigint[]", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    days_count = table.Column<int>(type: "integer", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_beds_type_and_summ", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hospital_ochred",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ochred_name_aout_genereted = table.Column<string>(type: "text", nullable: true),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    reg_date_ochred = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    accepted_status = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_ochred", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_ochred_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_ochred_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_ochred_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalOchredByDocotors",
                columns: table => new
                {
                    UsersId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_book",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    name1 = table.Column<string>(type: "text", nullable: true),
                    name2 = table.Column<string>(type: "text", nullable: true),
                    name3 = table.Column<string>(type: "text", nullable: true),
                    name4 = table.Column<string>(type: "text", nullable: true),
                    name5 = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_book", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_client_test",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    min_value = table.Column<double>(type: "double precision", nullable: false),
                    max_value = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_client_test", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_client_type",
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
                    table.PrimaryKey("PK_oquv_markaz_client_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_contragent",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    icon_base_64_str = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_contragent", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_daily_pupil_calculation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazPupilGroupsid = table.Column<long>(type: "bigint", nullable: false),
                    date_only = table.Column<DateTime>(type: "date", nullable: false),
                    all_accepted_status = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_daily_pupil_calculation", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_daily_pupil_calculation_oquv_markaz_pupil_group~",
                        column: x => x.OquvMarkazPupilGroupsid,
                        principalTable: "oquv_markaz_pupil_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_oquvchi_gruppaga_tolov",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    begin_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OquvMarkazPupilGroupsid = table.Column<long>(type: "bigint", nullable: true),
                    OquvMarkazClientid = table.Column<long>(type: "bigint", nullable: true),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    qarz_summ = table.Column<double>(type: "double precision", nullable: false),
                    discount_summ = table.Column<double>(type: "double precision", nullable: false),
                    real_summ = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_oquvchi_gruppaga_tolov", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_oquvchi_gruppaga_tolov_oquv_markaz_client_OquvM~",
                        column: x => x.OquvMarkazClientid,
                        principalTable: "oquv_markaz_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_oquvchi_gruppaga_tolov_oquv_markaz_pupil_groups~",
                        column: x => x.OquvMarkazPupilGroupsid,
                        principalTable: "oquv_markaz_pupil_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_oquvchi_yoqlama",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    status_keldi_ketdi = table.Column<bool>(type: "boolean", nullable: false),
                    date_keldi_ketti = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OquvMarkazClientid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazPupilGroupsid = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_oquvchi_yoqlama", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_oquvchi_yoqlama_oquv_markaz_client_OquvMarkazCl~",
                        column: x => x.OquvMarkazClientid,
                        principalTable: "oquv_markaz_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_oquvchi_yoqlama_oquv_markaz_pupil_groups_OquvMa~",
                        column: x => x.OquvMarkazPupilGroupsid,
                        principalTable: "oquv_markaz_pupil_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_salary_monthly_info",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazUserid = table.Column<long>(type: "bigint", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    real_summ = table.Column<double>(type: "double precision", nullable: false),
                    payed_summ = table.Column<double>(type: "double precision", nullable: false),
                    payed_for_card_summ = table.Column<double>(type: "double precision", nullable: false),
                    bounus_summ = table.Column<double>(type: "double precision", nullable: false),
                    year = table.Column<long>(type: "bigint", nullable: false),
                    month = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_salary_monthly_info", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_salary_monthly_info_oquv_markaz_user_OquvMarkaz~",
                        column: x => x.OquvMarkazUserid,
                        principalTable: "oquv_markaz_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OquvMarkazKassaCurrentCondition",
                columns: table => new
                {
                    summ = table.Column<double>(type: "double precision", nullable: true),
                    credit = table.Column<double>(type: "double precision", nullable: true),
                    debit = table.Column<double>(type: "double precision", nullable: true),
                    cash = table.Column<double>(type: "double precision", nullable: true),
                    card = table.Column<double>(type: "double precision", nullable: true),
                    online = table.Column<double>(type: "double precision", nullable: true),
                    salary = table.Column<double>(type: "double precision", nullable: true),
                    rasxod = table.Column<double>(type: "double precision", nullable: true),
                    discount = table.Column<double>(type: "double precision", nullable: true),
                    discount_pesantage = table.Column<double>(type: "double precision", nullable: true),
                    discount_summ = table.Column<double>(type: "double precision", nullable: true),
                    bonus_summ = table.Column<double>(type: "double precision", nullable: true),
                    cashback_summ = table.Column<double>(type: "double precision", nullable: true),
                    kam_chiqqan_summ = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_client_davennost",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fio = table.Column<string>(type: "text", nullable: true),
                    adddress = table.Column<string>(type: "text", nullable: true),
                    passport_number = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    home_phone_number = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    image_base_64 = table.Column<string>(type: "text", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    car_number = table.Column<string>(type: "text", nullable: true),
                    addiotionala_information = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    udate_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    passport_image_base_64 = table.Column<string>(type: "text", nullable: true),
                    passport_image_url = table.Column<string>(type: "text", nullable: true),
                    TegirmonClientid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false),
                    auth_user_creator_id = table.Column<long>(type: "bigint", nullable: true),
                    auth_user_updator_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_client_davennost", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_client_davennost_tegirmon_client_TegirmonClientid",
                        column: x => x.TegirmonClientid,
                        principalTable: "tegirmon_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_client_ostatka",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TegirmonClientid = table.Column<long>(type: "bigint", nullable: false),
                    TegirmonProductid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false),
                    auth_user_creator_id = table.Column<long>(type: "bigint", nullable: true),
                    auth_user_updator_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_client_ostatka", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_client_ostatka_tegirmon_client_TegirmonClientid",
                        column: x => x.TegirmonClientid,
                        principalTable: "tegirmon_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tegirmon_client_ostatka_tegirmon_product_TegirmonProductid",
                        column: x => x.TegirmonProductid,
                        principalTable: "tegirmon_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_client_ostatka_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TegirmonClientid = table.Column<long>(type: "bigint", nullable: false),
                    TegirmonProductid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    get_or_take_status = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false),
                    auth_user_creator_id = table.Column<long>(type: "bigint", nullable: true),
                    auth_user_updator_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_client_ostatka_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_client_ostatka_item_tegirmon_client_TegirmonClient~",
                        column: x => x.TegirmonClientid,
                        principalTable: "tegirmon_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tegirmon_client_ostatka_item_tegirmon_product_TegirmonProdu~",
                        column: x => x.TegirmonProductid,
                        principalTable: "tegirmon_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_product_persantage",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TegirmonProductid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false),
                    auth_user_creator_id = table.Column<long>(type: "bigint", nullable: true),
                    auth_user_updator_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_product_persantage", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_product_persantage_tegirmon_product_TegirmonProduc~",
                        column: x => x.TegirmonProductid,
                        principalTable: "tegirmon_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_tortilgan_bugdoy_royxati",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TegirmonProductid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    TegirmonClientid = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    accepted_get_value = table.Column<bool>(type: "boolean", nullable: false),
                    TegirmonAuthid = table.Column<long>(type: "bigint", nullable: true),
                    client_name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false),
                    auth_user_creator_id = table.Column<long>(type: "bigint", nullable: true),
                    auth_user_updator_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_tortilgan_bugdoy_royxati", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_tortilgan_bugdoy_royxati_tegirmon_authorization_Te~",
                        column: x => x.TegirmonAuthid,
                        principalTable: "tegirmon_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tegirmon_tortilgan_bugdoy_royxati_tegirmon_client_TegirmonC~",
                        column: x => x.TegirmonClientid,
                        principalTable: "tegirmon_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tegirmon_tortilgan_bugdoy_royxati_tegirmon_product_Tegirmon~",
                        column: x => x.TegirmonProductid,
                        principalTable: "tegirmon_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_tortilgan_bugdoy_royxati_group",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    reverced_str = table.Column<string>(type: "text", nullable: true),
                    date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    car_number = table.Column<string>(type: "text", nullable: true),
                    shafyor_name = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    reverced_need_id = table.Column<long>(type: "bigint", nullable: false),
                    qabul_qilgan_user_name = table.Column<string>(type: "text", nullable: true),
                    accepted_status = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false),
                    auth_user_creator_id = table.Column<long>(type: "bigint", nullable: true),
                    auth_user_updator_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_tortilgan_bugdoy_royxati_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TegirmonClientOstatakaSumInfo",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: true),
                    real_qty = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TegirmonMoneyInfoTemp",
                columns: table => new
                {
                    card = table.Column<double>(type: "double precision", nullable: true),
                    cash = table.Column<double>(type: "double precision", nullable: true),
                    summ = table.Column<double>(type: "double precision", nullable: true),
                    profit_sum = table.Column<double>(type: "double precision", nullable: true),
                    real_sum = table.Column<double>(type: "double precision", nullable: true),
                    humo = table.Column<double>(type: "double precision", nullable: true),
                    uz_card = table.Column<double>(type: "double precision", nullable: true),
                    perchisleniya = table.Column<double>(type: "double precision", nullable: true),
                    dolg = table.Column<double>(type: "double precision", nullable: true),
                    dolg_payed = table.Column<double>(type: "double precision", nullable: true),
                    creadit_payed = table.Column<double>(type: "double precision", nullable: true),
                    rasxod = table.Column<double>(type: "double precision", nullable: true),
                    online = table.Column<double>(type: "double precision", nullable: true),
                    salary = table.Column<double>(type: "double precision", nullable: true),
                    for_buy_tovar_rasxod = table.Column<double>(type: "double precision", nullable: true),
                    srogi_otganlar_uchun_rasxod = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tex_raskladki_device_information",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name1 = table.Column<string>(type: "text", nullable: true),
                    qty1 = table.Column<double>(type: "double precision", nullable: false),
                    name2 = table.Column<string>(type: "text", nullable: true),
                    qty2 = table.Column<double>(type: "double precision", nullable: false),
                    name3 = table.Column<string>(type: "text", nullable: true),
                    qty3 = table.Column<double>(type: "double precision", nullable: false),
                    name4 = table.Column<string>(type: "text", nullable: true),
                    qty4 = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_raskladki_device_information", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_raskladki_information",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    dlina = table.Column<string>(type: "text", nullable: true),
                    shirina = table.Column<string>(type: "text", nullable: true),
                    effect = table.Column<string>(type: "text", nullable: true),
                    optsii = table.Column<string>(type: "text", nullable: true),
                    qty_project = table.Column<double>(type: "double precision", nullable: false),
                    qty_product = table.Column<double>(type: "double precision", nullable: false),
                    qty_detail = table.Column<double>(type: "double precision", nullable: false),
                    qty_summ = table.Column<double>(type: "double precision", nullable: false),
                    TexUnitmeasurmentid = table.Column<long>(type: "bigint", nullable: true),
                    gotoviy_ves = table.Column<double>(type: "double precision", nullable: true),
                    ispolzivinniy_ves = table.Column<double>(type: "double precision", nullable: true),
                    lichniy_ves = table.Column<double>(type: "double precision", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_raskladki_information", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_raskladki_information_tex_unit_measurment_TexUnitmeasur~",
                        column: x => x.TexUnitmeasurmentid,
                        principalTable: "tex_unit_measurment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_raskladki_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_raskladki_item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_raskladki_model_information",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_raskladki_model_information", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_raskladki_model_kroy_information",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name1 = table.Column<string>(type: "text", nullable: true),
                    qty1 = table.Column<double>(type: "double precision", nullable: false),
                    name2 = table.Column<string>(type: "text", nullable: true),
                    qty2 = table.Column<double>(type: "double precision", nullable: false),
                    name3 = table.Column<string>(type: "text", nullable: true),
                    qty3 = table.Column<double>(type: "double precision", nullable: false),
                    name4 = table.Column<string>(type: "text", nullable: true),
                    qty4 = table.Column<double>(type: "double precision", nullable: false),
                    name5 = table.Column<string>(type: "text", nullable: true),
                    qty5 = table.Column<double>(type: "double precision", nullable: false),
                    name6 = table.Column<string>(type: "text", nullable: true),
                    qty6 = table.Column<double>(type: "double precision", nullable: false),
                    name7 = table.Column<string>(type: "text", nullable: true),
                    qty7 = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_raskladki_model_kroy_information", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_raskladki_model_rasxod_information",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TexProductid = table.Column<long>(type: "bigint", nullable: true),
                    ispolzvinnoy_measur = table.Column<string>(type: "text", nullable: true),
                    ispolzvinnoy = table.Column<double>(type: "double precision", nullable: false),
                    ubitok_measur = table.Column<string>(type: "text", nullable: true),
                    ubitok = table.Column<double>(type: "double precision", nullable: false),
                    zatrachen_measur = table.Column<string>(type: "text", nullable: true),
                    zatrachen = table.Column<double>(type: "double precision", nullable: false),
                    poverxnost_measur = table.Column<string>(type: "text", nullable: true),
                    poverxnost = table.Column<double>(type: "double precision", nullable: false),
                    poverxnost_measur1 = table.Column<string>(type: "text", nullable: true),
                    poverxnost1 = table.Column<double>(type: "double precision", nullable: false),
                    poverxnost_measur2 = table.Column<string>(type: "text", nullable: true),
                    poverxnost2 = table.Column<double>(type: "double precision", nullable: false),
                    ves_measurment = table.Column<string>(type: "text", nullable: true),
                    ves = table.Column<double>(type: "double precision", nullable: false),
                    ves_measurment1 = table.Column<string>(type: "text", nullable: true),
                    ves1 = table.Column<double>(type: "double precision", nullable: false),
                    ves_measurment2 = table.Column<string>(type: "text", nullable: true),
                    ves2 = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_raskladki_model_rasxod_information", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_raskladki_model_rasxod_information_tex_product_TexProdu~",
                        column: x => x.TexProductid,
                        principalTable: "tex_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_size_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_size_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "water_client_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    type_info = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_client_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "water_contragent_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_contragent_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "water_message_log",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    message_str = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    massager_user_name = table.Column<string>(type: "text", nullable: true),
                    reg_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_message_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "water_product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    main_product = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "water_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    note = table.Column<string>(type: "text", nullable: true),
                    fio = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    car_number = table.Column<string>(type: "text", nullable: true),
                    telegram_phonenumber = table.Column<string>(type: "text", nullable: true),
                    bot_id = table.Column<long>(type: "bigint", nullable: true),
                    addrress = table.Column<string>(type: "text", nullable: true),
                    position = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "water_viloyat",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_viloyat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WaterCheckFakeModel",
                columns: table => new
                {
                    summa = table.Column<double>(type: "double precision", nullable: true),
                    naqt = table.Column<double>(type: "double precision", nullable: true),
                    karta = table.Column<double>(type: "double precision", nullable: true),
                    debit = table.Column<double>(type: "double precision", nullable: true),
                    rasxod = table.Column<double>(type: "double precision", nullable: true),
                    fio = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "WaterOrderedProduct",
                columns: table => new
                {
                    product_name = table.Column<string>(type: "text", nullable: true),
                    product_qty = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "WaterStatistikaFakeReport",
                columns: table => new
                {
                    fio = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    tuman_name = table.Column<string>(type: "text", nullable: true),
                    last_order_date = table.Column<string>(type: "text", nullable: true),
                    olgan_suv_soni = table.Column<double>(type: "double precision", nullable: true),
                    bakalashka_soni1 = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "hospital_bron_payments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    HospitalPatientBronBedsid = table.Column<long>(type: "bigint", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    real_summ = table.Column<double>(type: "double precision", nullable: false),
                    payed_summ = table.Column<double>(type: "double precision", nullable: false),
                    HospitalBedsTypeAndPriceid = table.Column<long>(type: "bigint", nullable: false),
                    days_count = table.Column<int>(type: "integer", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_bron_payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_bron_payments_hospital_beds_type_and_summ_Hospital~",
                        column: x => x.HospitalBedsTypeAndPriceid,
                        principalTable: "hospital_beds_type_and_summ",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_bron_payments_hospital_patient_bron_room_bed_Hospi~",
                        column: x => x.HospitalPatientBronBedsid,
                        principalTable: "hospital_patient_bron_room_bed",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_book_and_group",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazBookid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazPupilGroupsid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_book_and_group", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_book_and_group_oquv_markaz_book_OquvMarkazBookid",
                        column: x => x.OquvMarkazBookid,
                        principalTable: "oquv_markaz_book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_book_and_group_oquv_markaz_pupil_groups_OquvMar~",
                        column: x => x.OquvMarkazPupilGroupsid,
                        principalTable: "oquv_markaz_pupil_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_book_unit",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    name1 = table.Column<string>(type: "text", nullable: true),
                    name2 = table.Column<string>(type: "text", nullable: true),
                    name3 = table.Column<string>(type: "text", nullable: true),
                    name4 = table.Column<string>(type: "text", nullable: true),
                    name5 = table.Column<string>(type: "text", nullable: true),
                    OquvMarkazBookid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_book_unit", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_book_unit_oquv_markaz_book_OquvMarkazBookid",
                        column: x => x.OquvMarkazBookid,
                        principalTable: "oquv_markaz_book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_client_test_result",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazTestid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazClientid = table.Column<long>(type: "bigint", nullable: false),
                    min_value = table.Column<double>(type: "double precision", nullable: false),
                    max_value = table.Column<double>(type: "double precision", nullable: false),
                    current_value = table.Column<double>(type: "double precision", nullable: false),
                    current_value_in_persantage = table.Column<double>(type: "double precision", nullable: false),
                    current_reg_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OquvMarkazPupilGroupsid = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_client_test_result", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_client_test_result_oquv_markaz_client_OquvMarka~",
                        column: x => x.OquvMarkazClientid,
                        principalTable: "oquv_markaz_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_client_test_result_oquv_markaz_client_test_Oquv~",
                        column: x => x.OquvMarkazTestid,
                        principalTable: "oquv_markaz_client_test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_client_test_result_oquv_markaz_pupil_groups_Oqu~",
                        column: x => x.OquvMarkazPupilGroupsid,
                        principalTable: "oquv_markaz_pupil_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_daily_pupil_calculation_info",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazDailyPupilsCalculationid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazPupilGroupsid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazClientid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazUserid = table.Column<long>(type: "bigint", nullable: false),
                    oqituvchi_bounus = table.Column<double>(type: "double precision", nullable: false),
                    accepted_status_client = table.Column<bool>(type: "boolean", nullable: false),
                    disaccepted_staus_client = table.Column<bool>(type: "boolean", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    date_only = table.Column<DateTime>(type: "date", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_daily_pupil_calculation_info", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_daily_pupil_calculation_info_oquv_markaz_client~",
                        column: x => x.OquvMarkazClientid,
                        principalTable: "oquv_markaz_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_daily_pupil_calculation_info_oquv_markaz_daily_~",
                        column: x => x.OquvMarkazDailyPupilsCalculationid,
                        principalTable: "oquv_markaz_daily_pupil_calculation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_daily_pupil_calculation_info_oquv_markaz_pupil_~",
                        column: x => x.OquvMarkazPupilGroupsid,
                        principalTable: "oquv_markaz_pupil_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_daily_pupil_calculation_info_oquv_markaz_user_O~",
                        column: x => x.OquvMarkazUserid,
                        principalTable: "oquv_markaz_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_product_persantage_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TegirmonProductid = table.Column<long>(type: "bigint", nullable: false),
                    persantage = table.Column<double>(type: "double precision", nullable: false),
                    TegirmonProductToProductPersentageid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false),
                    auth_user_creator_id = table.Column<long>(type: "bigint", nullable: true),
                    auth_user_updator_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_product_persantage_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_product_persantage_detail_tegirmon_product_persant~",
                        column: x => x.TegirmonProductToProductPersentageid,
                        principalTable: "tegirmon_product_persantage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tegirmon_product_persantage_detail_tegirmon_product_Tegirmo~",
                        column: x => x.TegirmonProductid,
                        principalTable: "tegirmon_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_tortilgan_bugdoy_royxati_group_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TegirmonTortilganBugdoyRoyxatiGroupid = table.Column<long>(type: "bigint", nullable: true),
                    TegirmonTortilganBugdoyRoyxatiid = table.Column<long>(type: "bigint", nullable: true),
                    TegirmonInvoiceid = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    reverced_note_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false),
                    auth_user_creator_id = table.Column<long>(type: "bigint", nullable: true),
                    auth_user_updator_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_tortilgan_bugdoy_royxati_group_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_tortilgan_bugdoy_royxati_group_detail_tegirmon_inv~",
                        column: x => x.TegirmonInvoiceid,
                        principalTable: "tegirmon_invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tegirmon_tortilgan_bugdoy_royxati_group_detail_tegirmon_to~1",
                        column: x => x.TegirmonTortilganBugdoyRoyxatiid,
                        principalTable: "tegirmon_tortilgan_bugdoy_royxati",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tegirmon_tortilgan_bugdoy_royxati_group_detail_tegirmon_tor~",
                        column: x => x.TegirmonTortilganBugdoyRoyxatiGroupid,
                        principalTable: "tegirmon_tortilgan_bugdoy_royxati_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_raskladki",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    order_name = table.Column<string>(type: "text", nullable: true),
                    file_path_name = table.Column<string>(type: "text", nullable: true),
                    file_name = table.Column<string>(type: "text", nullable: true),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    raskladki_name = table.Column<string>(type: "text", nullable: true),
                    reg_raskladki_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TexAuthorizationid = table.Column<long>(type: "bigint", nullable: true),
                    TexRaskladkiInformationid = table.Column<long>(type: "bigint", nullable: true),
                    name_model = table.Column<string>(type: "text", nullable: true),
                    vid_model = table.Column<string>(type: "text", nullable: true),
                    zakazchikn_model = table.Column<string>(type: "text", nullable: true),
                    TexContragentid = table.Column<long>(type: "bigint", nullable: true),
                    model_str = table.Column<string>(type: "text", nullable: true),
                    TexRaskladkiModelRasxodInformationid = table.Column<long>(type: "bigint", nullable: true),
                    TexRaskladkiKroyInformationid = table.Column<long>(type: "bigint", nullable: true),
                    TexRaskladkiDeviceInformationid = table.Column<long>(type: "bigint", nullable: true),
                    image_str = table.Column<string>(type: "text", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    TexOrderid = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_raskladki", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_raskladki_tex_authorization_TexAuthorizationid",
                        column: x => x.TexAuthorizationid,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_raskladki_tex_contragent_TexContragentid",
                        column: x => x.TexContragentid,
                        principalTable: "tex_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_raskladki_tex_order_TexOrderid",
                        column: x => x.TexOrderid,
                        principalTable: "tex_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_raskladki_tex_raskladki_device_information_TexRaskladki~",
                        column: x => x.TexRaskladkiDeviceInformationid,
                        principalTable: "tex_raskladki_device_information",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_raskladki_tex_raskladki_information_TexRaskladkiInforma~",
                        column: x => x.TexRaskladkiInformationid,
                        principalTable: "tex_raskladki_information",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_raskladki_tex_raskladki_model_kroy_information_TexRaskl~",
                        column: x => x.TexRaskladkiKroyInformationid,
                        principalTable: "tex_raskladki_model_kroy_information",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_raskladki_tex_raskladki_model_rasxod_information_TexRas~",
                        column: x => x.TexRaskladkiModelRasxodInformationid,
                        principalTable: "tex_raskladki_model_rasxod_information",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "water_contragent",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_1 = table.Column<string>(type: "text", nullable: true),
                    phone_number_2 = table.Column<string>(type: "text", nullable: true),
                    phone_number_3 = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    dokon_number = table.Column<string>(type: "text", nullable: true),
                    WaterContragentTypeid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_contragent", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_contragent_water_contragent_type_WaterContragentTypeid",
                        column: x => x.WaterContragentTypeid,
                        principalTable: "water_contragent_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "water_product_ostatka",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    WaterProductid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_product_ostatka", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_product_ostatka_water_product_WaterProductid",
                        column: x => x.WaterProductid,
                        principalTable: "water_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "water_auth",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    password = table.Column<string>(type: "text", nullable: true),
                    login = table.Column<string>(type: "text", nullable: true),
                    user_type = table.Column<int>(type: "integer", nullable: false),
                    WaterUserid = table.Column<long>(type: "bigint", nullable: false),
                    client_type_info = table.Column<int>(type: "integer", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_auth", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_auth_water_user_WaterUserid",
                        column: x => x.WaterUserid,
                        principalTable: "water_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "water_tuman",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    WaterViloyatid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_tuman", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_tuman_water_viloyat_WaterViloyatid",
                        column: x => x.WaterViloyatid,
                        principalTable: "water_viloyat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oquv_markaz_book_and_group_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OquvMarkazBookAndGroupid = table.Column<long>(type: "bigint", nullable: false),
                    OquvMarkazBookUnitid = table.Column<long>(type: "bigint", nullable: false),
                    readed = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oquv_markaz_book_and_group_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_book_and_group_detail_oquv_markaz_book_and_grou~",
                        column: x => x.OquvMarkazBookAndGroupid,
                        principalTable: "oquv_markaz_book_and_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oquv_markaz_book_and_group_detail_oquv_markaz_book_unit_Oqu~",
                        column: x => x.OquvMarkazBookUnitid,
                        principalTable: "oquv_markaz_book_unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tex_raskladki_model_qty_information",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TexRaskladkiid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    qty_detail = table.Column<double>(type: "double precision", nullable: false),
                    TexSizeid = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_raskladki_model_qty_information", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_raskladki_model_qty_information_tex_raskladki_TexRaskla~",
                        column: x => x.TexRaskladkiid,
                        principalTable: "tex_raskladki",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tex_raskladki_model_qty_information_tex_size_TexSizeid",
                        column: x => x.TexSizeid,
                        principalTable: "tex_size",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_raskladki_step_information",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TexRaskladkiid = table.Column<long>(type: "bigint", nullable: false),
                    name1 = table.Column<string>(type: "text", nullable: true),
                    qty1 = table.Column<double>(type: "double precision", nullable: false),
                    name2 = table.Column<string>(type: "text", nullable: true),
                    qty2 = table.Column<double>(type: "double precision", nullable: false),
                    name3 = table.Column<string>(type: "text", nullable: true),
                    qty3 = table.Column<double>(type: "double precision", nullable: false),
                    name4 = table.Column<string>(type: "text", nullable: true),
                    qty4 = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_raskladki_step_information", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_raskladki_step_information_tex_raskladki_TexRaskladkiid",
                        column: x => x.TexRaskladkiid,
                        principalTable: "tex_raskladki",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "water_check",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    bonus = table.Column<double>(type: "double precision", nullable: false),
                    credit = table.Column<double>(type: "double precision", nullable: false),
                    debit = table.Column<double>(type: "double precision", nullable: false),
                    cash = table.Column<double>(type: "double precision", nullable: false),
                    card = table.Column<double>(type: "double precision", nullable: false),
                    online = table.Column<double>(type: "double precision", nullable: false),
                    salary = table.Column<double>(type: "double precision", nullable: false),
                    rasxod = table.Column<double>(type: "double precision", nullable: false),
                    discount = table.Column<double>(type: "double precision", nullable: false),
                    discount_pesantage = table.Column<double>(type: "double precision", nullable: false),
                    discount_summ = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    reserve = table.Column<string>(type: "text", nullable: true),
                    bonus_summ = table.Column<double>(type: "double precision", nullable: false),
                    cashback_summ = table.Column<double>(type: "double precision", nullable: false),
                    cashback_card = table.Column<string>(type: "text", nullable: true),
                    cashback_user_phone_number = table.Column<string>(type: "text", nullable: true),
                    cassir_name = table.Column<string>(type: "text", nullable: true),
                    kassa_close_status = table.Column<bool>(type: "boolean", nullable: false),
                    kam_chiqqan_summ = table.Column<double>(type: "double precision", nullable: false),
                    WaterAuthid = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_check", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_check_water_auth_WaterAuthid",
                        column: x => x.WaterAuthid,
                        principalTable: "water_auth",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "water_invoice",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    note = table.Column<string>(type: "text", nullable: true),
                    invoice_number = table.Column<string>(type: "text", nullable: true),
                    WaterUserid = table.Column<long>(type: "bigint", nullable: true),
                    WaterAuthid = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_invoice", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_invoice_water_auth_WaterAuthid",
                        column: x => x.WaterAuthid,
                        principalTable: "water_auth",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_water_invoice_water_user_WaterUserid",
                        column: x => x.WaterUserid,
                        principalTable: "water_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "water_client",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    clinet_number = table.Column<int>(type: "integer", nullable: false),
                    fio = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    note1 = table.Column<string>(type: "text", nullable: true),
                    note2 = table.Column<string>(type: "text", nullable: true),
                    note3 = table.Column<string>(type: "text", nullable: true),
                    note4 = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number1 = table.Column<string>(type: "text", nullable: true),
                    phone_number2 = table.Column<string>(type: "text", nullable: true),
                    phone_number3 = table.Column<string>(type: "text", nullable: true),
                    WaterTumanid = table.Column<long>(type: "bigint", nullable: true),
                    card_number = table.Column<string>(type: "text", nullable: true),
                    client_active = table.Column<bool>(type: "boolean", nullable: false),
                    bot_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_client", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_client_water_tuman_WaterTumanid",
                        column: x => x.WaterTumanid,
                        principalTable: "water_tuman",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "water_invoice_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    WaterInvoiceid = table.Column<long>(type: "bigint", nullable: false),
                    WaterProductid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_invoice_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_invoice_item_water_invoice_WaterInvoiceid",
                        column: x => x.WaterInvoiceid,
                        principalTable: "water_invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_water_invoice_item_water_product_WaterProductid",
                        column: x => x.WaterProductid,
                        principalTable: "water_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "water_client_address",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_1 = table.Column<string>(type: "text", nullable: true),
                    phone_number_2 = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    note_1 = table.Column<string>(type: "text", nullable: true),
                    note_2 = table.Column<string>(type: "text", nullable: true),
                    longutidue = table.Column<double>(type: "double precision", nullable: false),
                    latitude = table.Column<double>(type: "double precision", nullable: false),
                    latidu = table.Column<double>(type: "double precision", nullable: false),
                    longitu = table.Column<double>(type: "double precision", nullable: false),
                    home_code = table.Column<string>(type: "text", nullable: true),
                    padez = table.Column<string>(type: "text", nullable: true),
                    home_number = table.Column<string>(type: "text", nullable: true),
                    WaterTumanid = table.Column<long>(type: "bigint", nullable: false),
                    WaterClientid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_client_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_client_address_water_client_WaterClientid",
                        column: x => x.WaterClientid,
                        principalTable: "water_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_water_client_address_water_tuman_WaterTumanid",
                        column: x => x.WaterTumanid,
                        principalTable: "water_tuman",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "water_client_dolg",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    WaterClientid = table.Column<long>(type: "bigint", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    real_summ = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_client_dolg", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_client_dolg_water_client_WaterClientid",
                        column: x => x.WaterClientid,
                        principalTable: "water_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "water_client_phone_number",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    WaterClientid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_client_phone_number", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_client_phone_number_water_client_WaterClientid",
                        column: x => x.WaterClientid,
                        principalTable: "water_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "water_client_bottle_info",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    bottle_count = table.Column<double>(type: "double precision", nullable: false),
                    bottle_count_real = table.Column<double>(type: "double precision", nullable: false),
                    WaterClientid = table.Column<long>(type: "bigint", nullable: false),
                    WaterClientAddressid = table.Column<long>(type: "bigint", nullable: false),
                    WaterProductid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_client_bottle_info", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_client_bottle_info_water_client_address_WaterClientAd~",
                        column: x => x.WaterClientAddressid,
                        principalTable: "water_client_address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_water_client_bottle_info_water_client_WaterClientid",
                        column: x => x.WaterClientid,
                        principalTable: "water_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_water_client_bottle_info_water_product_WaterProductid",
                        column: x => x.WaterProductid,
                        principalTable: "water_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "water_order",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    order_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WaterClientid = table.Column<long>(type: "bigint", nullable: false),
                    water_count = table.Column<long>(type: "bigint", nullable: false),
                    accepted_status = table.Column<bool>(type: "boolean", nullable: false),
                    order_accepted_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WaterClientAddressid = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    WaterUserid = table.Column<long>(type: "bigint", nullable: true),
                    deleivered_user_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_order_water_client_address_WaterClientAddressid",
                        column: x => x.WaterClientAddressid,
                        principalTable: "water_client_address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_water_order_water_client_WaterClientid",
                        column: x => x.WaterClientid,
                        principalTable: "water_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_water_order_water_user_WaterUserid",
                        column: x => x.WaterUserid,
                        principalTable: "water_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "water_client_bottle_info_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    WaterClientBottleInfoid = table.Column<long>(type: "bigint", nullable: false),
                    bottle_count = table.Column<long>(type: "bigint", nullable: false),
                    bottle_count_real = table.Column<long>(type: "bigint", nullable: false),
                    bottle_count_get = table.Column<long>(type: "bigint", nullable: false),
                    get_or_give = table.Column<bool>(type: "boolean", nullable: false),
                    last_order_item_accepted_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_client_bottle_info_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_client_bottle_info_detail_water_client_bottle_info_Wa~",
                        column: x => x.WaterClientBottleInfoid,
                        principalTable: "water_client_bottle_info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "water_order_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    info_order_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    give_botlle = table.Column<long>(type: "bigint", nullable: false),
                    get_botle = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    info_str = table.Column<string>(type: "text", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    WaterOrderid = table.Column<long>(type: "bigint", nullable: false),
                    WaterProductid = table.Column<long>(type: "bigint", nullable: false),
                    order_item_accepted_status = table.Column<bool>(type: "boolean", nullable: false),
                    bonus_or_not = table.Column<bool>(type: "boolean", nullable: false),
                    deleivered_user_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reserverd_number_id = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_1 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_number_id_3 = table.Column<long>(type: "bigint", nullable: true),
                    reserverd_numeric_id = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_1 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_2 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_numeric_id_3 = table.Column<double>(type: "double precision", nullable: true),
                    reserverd_note = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_1 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_2 = table.Column<string>(type: "text", nullable: true),
                    reserverd_note_3 = table.Column<string>(type: "text", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_water_order_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_water_order_item_water_order_WaterOrderid",
                        column: x => x.WaterOrderid,
                        principalTable: "water_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_water_order_item_water_product_WaterProductid",
                        column: x => x.WaterProductid,
                        principalTable: "water_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tex_size_TexSizeTypeid",
                table: "tex_size",
                column: "TexSizeTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_invoice_TegirmonProductid",
                table: "tegirmon_invoice",
                column: "TegirmonProductid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_salary_item_OquvMarkazClientid",
                table: "oquv_markaz_salary_item",
                column: "OquvMarkazClientid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_salary_item_OquvMarkazPupilGroupsid",
                table: "oquv_markaz_salary_item",
                column: "OquvMarkazPupilGroupsid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_client_OquvMarkazClientTypeid",
                table: "oquv_markaz_client",
                column: "OquvMarkazClientTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_client_OquvMarkazContragentid",
                table: "oquv_markaz_client",
                column: "OquvMarkazContragentid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_check_OquvMarkazAuthid",
                table: "oquv_markaz_check",
                column: "OquvMarkazAuthid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_check_OquvMarkazUserid",
                table: "oquv_markaz_check",
                column: "OquvMarkazUserid");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_1_PatientsId",
                table: "hospital_analiz_1",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_10_PatientsId",
                table: "hospital_analiz_10",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_11_PatientsId",
                table: "hospital_analiz_11",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_12_PatientsId",
                table: "hospital_analiz_12",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_13_PatientsId",
                table: "hospital_analiz_13",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_14_PatientsId",
                table: "hospital_analiz_14",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_15_PatientsId",
                table: "hospital_analiz_15",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_16_PatientsId",
                table: "hospital_analiz_16",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_17_PatientsId",
                table: "hospital_analiz_17",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_2_PatientsId",
                table: "hospital_analiz_2",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_3_PatientsId",
                table: "hospital_analiz_3",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_4_PatientsId",
                table: "hospital_analiz_4",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_5_PatientsId",
                table: "hospital_analiz_5",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_6_PatientsId",
                table: "hospital_analiz_6",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_7_PatientsId",
                table: "hospital_analiz_7",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_8_PatientsId",
                table: "hospital_analiz_8",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_analiz_9_PatientsId",
                table: "hospital_analiz_9",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_bron_payments_HospitalBedsTypeAndPriceid",
                table: "hospital_bron_payments",
                column: "HospitalBedsTypeAndPriceid");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_bron_payments_HospitalPatientBronBedsid",
                table: "hospital_bron_payments",
                column: "HospitalPatientBronBedsid");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_ochred_AuthorizationId",
                table: "hospital_ochred",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_ochred_PatientsId",
                table: "hospital_ochred",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_ochred_UsersId",
                table: "hospital_ochred",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_book_and_group_OquvMarkazBookid",
                table: "oquv_markaz_book_and_group",
                column: "OquvMarkazBookid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_book_and_group_OquvMarkazPupilGroupsid",
                table: "oquv_markaz_book_and_group",
                column: "OquvMarkazPupilGroupsid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_book_and_group_detail_OquvMarkazBookAndGroupid",
                table: "oquv_markaz_book_and_group_detail",
                column: "OquvMarkazBookAndGroupid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_book_and_group_detail_OquvMarkazBookUnitid",
                table: "oquv_markaz_book_and_group_detail",
                column: "OquvMarkazBookUnitid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_book_unit_OquvMarkazBookid",
                table: "oquv_markaz_book_unit",
                column: "OquvMarkazBookid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_client_test_result_OquvMarkazClientid",
                table: "oquv_markaz_client_test_result",
                column: "OquvMarkazClientid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_client_test_result_OquvMarkazPupilGroupsid",
                table: "oquv_markaz_client_test_result",
                column: "OquvMarkazPupilGroupsid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_client_test_result_OquvMarkazTestid",
                table: "oquv_markaz_client_test_result",
                column: "OquvMarkazTestid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_daily_pupil_calculation_OquvMarkazPupilGroupsid",
                table: "oquv_markaz_daily_pupil_calculation",
                column: "OquvMarkazPupilGroupsid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_daily_pupil_calculation_info_OquvMarkazClientid",
                table: "oquv_markaz_daily_pupil_calculation_info",
                column: "OquvMarkazClientid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_daily_pupil_calculation_info_OquvMarkazDailyPup~",
                table: "oquv_markaz_daily_pupil_calculation_info",
                column: "OquvMarkazDailyPupilsCalculationid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_daily_pupil_calculation_info_OquvMarkazPupilGro~",
                table: "oquv_markaz_daily_pupil_calculation_info",
                column: "OquvMarkazPupilGroupsid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_daily_pupil_calculation_info_OquvMarkazUserid",
                table: "oquv_markaz_daily_pupil_calculation_info",
                column: "OquvMarkazUserid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_oquvchi_gruppaga_tolov_OquvMarkazClientid",
                table: "oquv_markaz_oquvchi_gruppaga_tolov",
                column: "OquvMarkazClientid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_oquvchi_gruppaga_tolov_OquvMarkazPupilGroupsid",
                table: "oquv_markaz_oquvchi_gruppaga_tolov",
                column: "OquvMarkazPupilGroupsid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_oquvchi_yoqlama_OquvMarkazClientid",
                table: "oquv_markaz_oquvchi_yoqlama",
                column: "OquvMarkazClientid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_oquvchi_yoqlama_OquvMarkazPupilGroupsid",
                table: "oquv_markaz_oquvchi_yoqlama",
                column: "OquvMarkazPupilGroupsid");

            migrationBuilder.CreateIndex(
                name: "IX_oquv_markaz_salary_monthly_info_OquvMarkazUserid",
                table: "oquv_markaz_salary_monthly_info",
                column: "OquvMarkazUserid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_client_davennost_TegirmonClientid",
                table: "tegirmon_client_davennost",
                column: "TegirmonClientid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_client_ostatka_TegirmonClientid",
                table: "tegirmon_client_ostatka",
                column: "TegirmonClientid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_client_ostatka_TegirmonProductid",
                table: "tegirmon_client_ostatka",
                column: "TegirmonProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_client_ostatka_item_TegirmonClientid",
                table: "tegirmon_client_ostatka_item",
                column: "TegirmonClientid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_client_ostatka_item_TegirmonProductid",
                table: "tegirmon_client_ostatka_item",
                column: "TegirmonProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_product_persantage_TegirmonProductid",
                table: "tegirmon_product_persantage",
                column: "TegirmonProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_product_persantage_detail_TegirmonProductid",
                table: "tegirmon_product_persantage_detail",
                column: "TegirmonProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_product_persantage_detail_TegirmonProductToProduct~",
                table: "tegirmon_product_persantage_detail",
                column: "TegirmonProductToProductPersentageid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_tortilgan_bugdoy_royxati_TegirmonAuthid",
                table: "tegirmon_tortilgan_bugdoy_royxati",
                column: "TegirmonAuthid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_tortilgan_bugdoy_royxati_TegirmonClientid",
                table: "tegirmon_tortilgan_bugdoy_royxati",
                column: "TegirmonClientid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_tortilgan_bugdoy_royxati_TegirmonProductid",
                table: "tegirmon_tortilgan_bugdoy_royxati",
                column: "TegirmonProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_tortilgan_bugdoy_royxati_group_detail_TegirmonInvo~",
                table: "tegirmon_tortilgan_bugdoy_royxati_group_detail",
                column: "TegirmonInvoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_tortilgan_bugdoy_royxati_group_detail_TegirmonTor~1",
                table: "tegirmon_tortilgan_bugdoy_royxati_group_detail",
                column: "TegirmonTortilganBugdoyRoyxatiid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_tortilgan_bugdoy_royxati_group_detail_TegirmonTort~",
                table: "tegirmon_tortilgan_bugdoy_royxati_group_detail",
                column: "TegirmonTortilganBugdoyRoyxatiGroupid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_raskladki_TexAuthorizationid",
                table: "tex_raskladki",
                column: "TexAuthorizationid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_raskladki_TexContragentid",
                table: "tex_raskladki",
                column: "TexContragentid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_raskladki_TexOrderid",
                table: "tex_raskladki",
                column: "TexOrderid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_raskladki_TexRaskladkiDeviceInformationid",
                table: "tex_raskladki",
                column: "TexRaskladkiDeviceInformationid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_raskladki_TexRaskladkiInformationid",
                table: "tex_raskladki",
                column: "TexRaskladkiInformationid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_raskladki_TexRaskladkiKroyInformationid",
                table: "tex_raskladki",
                column: "TexRaskladkiKroyInformationid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_raskladki_TexRaskladkiModelRasxodInformationid",
                table: "tex_raskladki",
                column: "TexRaskladkiModelRasxodInformationid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_raskladki_information_TexUnitmeasurmentid",
                table: "tex_raskladki_information",
                column: "TexUnitmeasurmentid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_raskladki_model_qty_information_TexRaskladkiid",
                table: "tex_raskladki_model_qty_information",
                column: "TexRaskladkiid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_raskladki_model_qty_information_TexSizeid",
                table: "tex_raskladki_model_qty_information",
                column: "TexSizeid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_raskladki_model_rasxod_information_TexProductid",
                table: "tex_raskladki_model_rasxod_information",
                column: "TexProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_raskladki_step_information_TexRaskladkiid",
                table: "tex_raskladki_step_information",
                column: "TexRaskladkiid");

            migrationBuilder.CreateIndex(
                name: "IX_water_auth_WaterUserid",
                table: "water_auth",
                column: "WaterUserid");

            migrationBuilder.CreateIndex(
                name: "IX_water_check_WaterAuthid",
                table: "water_check",
                column: "WaterAuthid");

            migrationBuilder.CreateIndex(
                name: "IX_water_client_WaterTumanid",
                table: "water_client",
                column: "WaterTumanid");

            migrationBuilder.CreateIndex(
                name: "IX_water_client_address_WaterClientid",
                table: "water_client_address",
                column: "WaterClientid");

            migrationBuilder.CreateIndex(
                name: "IX_water_client_address_WaterTumanid",
                table: "water_client_address",
                column: "WaterTumanid");

            migrationBuilder.CreateIndex(
                name: "IX_water_client_bottle_info_WaterClientAddressid",
                table: "water_client_bottle_info",
                column: "WaterClientAddressid");

            migrationBuilder.CreateIndex(
                name: "IX_water_client_bottle_info_WaterClientid",
                table: "water_client_bottle_info",
                column: "WaterClientid");

            migrationBuilder.CreateIndex(
                name: "IX_water_client_bottle_info_WaterProductid",
                table: "water_client_bottle_info",
                column: "WaterProductid");

            migrationBuilder.CreateIndex(
                name: "IX_water_client_bottle_info_detail_WaterClientBottleInfoid",
                table: "water_client_bottle_info_detail",
                column: "WaterClientBottleInfoid");

            migrationBuilder.CreateIndex(
                name: "IX_water_client_dolg_WaterClientid",
                table: "water_client_dolg",
                column: "WaterClientid");

            migrationBuilder.CreateIndex(
                name: "IX_water_client_phone_number_WaterClientid",
                table: "water_client_phone_number",
                column: "WaterClientid");

            migrationBuilder.CreateIndex(
                name: "IX_water_contragent_WaterContragentTypeid",
                table: "water_contragent",
                column: "WaterContragentTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_water_invoice_WaterAuthid",
                table: "water_invoice",
                column: "WaterAuthid");

            migrationBuilder.CreateIndex(
                name: "IX_water_invoice_WaterUserid",
                table: "water_invoice",
                column: "WaterUserid");

            migrationBuilder.CreateIndex(
                name: "IX_water_invoice_item_WaterInvoiceid",
                table: "water_invoice_item",
                column: "WaterInvoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_water_invoice_item_WaterProductid",
                table: "water_invoice_item",
                column: "WaterProductid");

            migrationBuilder.CreateIndex(
                name: "IX_water_order_WaterClientAddressid",
                table: "water_order",
                column: "WaterClientAddressid");

            migrationBuilder.CreateIndex(
                name: "IX_water_order_WaterClientid",
                table: "water_order",
                column: "WaterClientid");

            migrationBuilder.CreateIndex(
                name: "IX_water_order_WaterUserid",
                table: "water_order",
                column: "WaterUserid");

            migrationBuilder.CreateIndex(
                name: "IX_water_order_item_WaterOrderid",
                table: "water_order_item",
                column: "WaterOrderid");

            migrationBuilder.CreateIndex(
                name: "IX_water_order_item_WaterProductid",
                table: "water_order_item",
                column: "WaterProductid");

            migrationBuilder.CreateIndex(
                name: "IX_water_product_ostatka_WaterProductid",
                table: "water_product_ostatka",
                column: "WaterProductid");

            migrationBuilder.CreateIndex(
                name: "IX_water_tuman_WaterViloyatid",
                table: "water_tuman",
                column: "WaterViloyatid");

            migrationBuilder.AddForeignKey(
                name: "FK_oquv_markaz_check_oquv_markaz_authorization_OquvMarkazAuthid",
                table: "oquv_markaz_check",
                column: "OquvMarkazAuthid",
                principalTable: "oquv_markaz_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_oquv_markaz_check_oquv_markaz_client_OquvMarkazClientid",
                table: "oquv_markaz_check",
                column: "OquvMarkazClientid",
                principalTable: "oquv_markaz_client",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_oquv_markaz_check_oquv_markaz_user_OquvMarkazUserid",
                table: "oquv_markaz_check",
                column: "OquvMarkazUserid",
                principalTable: "oquv_markaz_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_oquv_markaz_client_oquv_markaz_client_type_OquvMarkazClient~",
                table: "oquv_markaz_client",
                column: "OquvMarkazClientTypeid",
                principalTable: "oquv_markaz_client_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_oquv_markaz_client_oquv_markaz_contragent_OquvMarkazContrag~",
                table: "oquv_markaz_client",
                column: "OquvMarkazContragentid",
                principalTable: "oquv_markaz_contragent",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_oquv_markaz_salary_item_oquv_markaz_client_OquvMarkazClient~",
                table: "oquv_markaz_salary_item",
                column: "OquvMarkazClientid",
                principalTable: "oquv_markaz_client",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_oquv_markaz_salary_item_oquv_markaz_pupil_groups_OquvMarkaz~",
                table: "oquv_markaz_salary_item",
                column: "OquvMarkazPupilGroupsid",
                principalTable: "oquv_markaz_pupil_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tegirmon_invoice_tegirmon_product_TegirmonProductid",
                table: "tegirmon_invoice",
                column: "TegirmonProductid",
                principalTable: "tegirmon_product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_size_tex_size_type_TexSizeTypeid",
                table: "tex_size",
                column: "TexSizeTypeid",
                principalTable: "tex_size_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_oquv_markaz_check_oquv_markaz_authorization_OquvMarkazAuthid",
                table: "oquv_markaz_check");

            migrationBuilder.DropForeignKey(
                name: "FK_oquv_markaz_check_oquv_markaz_client_OquvMarkazClientid",
                table: "oquv_markaz_check");

            migrationBuilder.DropForeignKey(
                name: "FK_oquv_markaz_check_oquv_markaz_user_OquvMarkazUserid",
                table: "oquv_markaz_check");

            migrationBuilder.DropForeignKey(
                name: "FK_oquv_markaz_client_oquv_markaz_client_type_OquvMarkazClient~",
                table: "oquv_markaz_client");

            migrationBuilder.DropForeignKey(
                name: "FK_oquv_markaz_client_oquv_markaz_contragent_OquvMarkazContrag~",
                table: "oquv_markaz_client");

            migrationBuilder.DropForeignKey(
                name: "FK_oquv_markaz_salary_item_oquv_markaz_client_OquvMarkazClient~",
                table: "oquv_markaz_salary_item");

            migrationBuilder.DropForeignKey(
                name: "FK_oquv_markaz_salary_item_oquv_markaz_pupil_groups_OquvMarkaz~",
                table: "oquv_markaz_salary_item");

            migrationBuilder.DropForeignKey(
                name: "FK_tegirmon_invoice_tegirmon_product_TegirmonProductid",
                table: "tegirmon_invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_tex_size_tex_size_type_TexSizeTypeid",
                table: "tex_size");

            migrationBuilder.DropTable(
                name: "archive_javon");

            migrationBuilder.DropTable(
                name: "archive_quti");

            migrationBuilder.DropTable(
                name: "archive_stelaj");

            migrationBuilder.DropTable(
                name: "archive_tokcha");

            migrationBuilder.DropTable(
                name: "archive_xujjat");

            migrationBuilder.DropTable(
                name: "archive_xujjat_turi");

            migrationBuilder.DropTable(
                name: "hospital_analiz_1");

            migrationBuilder.DropTable(
                name: "hospital_analiz_10");

            migrationBuilder.DropTable(
                name: "hospital_analiz_11");

            migrationBuilder.DropTable(
                name: "hospital_analiz_12");

            migrationBuilder.DropTable(
                name: "hospital_analiz_13");

            migrationBuilder.DropTable(
                name: "hospital_analiz_14");

            migrationBuilder.DropTable(
                name: "hospital_analiz_15");

            migrationBuilder.DropTable(
                name: "hospital_analiz_16");

            migrationBuilder.DropTable(
                name: "hospital_analiz_17");

            migrationBuilder.DropTable(
                name: "hospital_analiz_2");

            migrationBuilder.DropTable(
                name: "hospital_analiz_3");

            migrationBuilder.DropTable(
                name: "hospital_analiz_4");

            migrationBuilder.DropTable(
                name: "hospital_analiz_5");

            migrationBuilder.DropTable(
                name: "hospital_analiz_6");

            migrationBuilder.DropTable(
                name: "hospital_analiz_7");

            migrationBuilder.DropTable(
                name: "hospital_analiz_8");

            migrationBuilder.DropTable(
                name: "hospital_analiz_9");

            migrationBuilder.DropTable(
                name: "hospital_bron_payments");

            migrationBuilder.DropTable(
                name: "hospital_ochred");

            migrationBuilder.DropTable(
                name: "HospitalOchredByDocotors");

            migrationBuilder.DropTable(
                name: "oquv_markaz_book_and_group_detail");

            migrationBuilder.DropTable(
                name: "oquv_markaz_client_test_result");

            migrationBuilder.DropTable(
                name: "oquv_markaz_client_type");

            migrationBuilder.DropTable(
                name: "oquv_markaz_contragent");

            migrationBuilder.DropTable(
                name: "oquv_markaz_daily_pupil_calculation_info");

            migrationBuilder.DropTable(
                name: "oquv_markaz_oquvchi_gruppaga_tolov");

            migrationBuilder.DropTable(
                name: "oquv_markaz_oquvchi_yoqlama");

            migrationBuilder.DropTable(
                name: "oquv_markaz_salary_monthly_info");

            migrationBuilder.DropTable(
                name: "OquvMarkazKassaCurrentCondition");

            migrationBuilder.DropTable(
                name: "tegirmon_client_davennost");

            migrationBuilder.DropTable(
                name: "tegirmon_client_ostatka");

            migrationBuilder.DropTable(
                name: "tegirmon_client_ostatka_item");

            migrationBuilder.DropTable(
                name: "tegirmon_product_persantage_detail");

            migrationBuilder.DropTable(
                name: "tegirmon_tortilgan_bugdoy_royxati_group_detail");

            migrationBuilder.DropTable(
                name: "TegirmonClientOstatakaSumInfo");

            migrationBuilder.DropTable(
                name: "TegirmonMoneyInfoTemp");

            migrationBuilder.DropTable(
                name: "tex_raskladki_item");

            migrationBuilder.DropTable(
                name: "tex_raskladki_model_information");

            migrationBuilder.DropTable(
                name: "tex_raskladki_model_qty_information");

            migrationBuilder.DropTable(
                name: "tex_raskladki_step_information");

            migrationBuilder.DropTable(
                name: "tex_size_type");

            migrationBuilder.DropTable(
                name: "water_check");

            migrationBuilder.DropTable(
                name: "water_client_bottle_info_detail");

            migrationBuilder.DropTable(
                name: "water_client_dolg");

            migrationBuilder.DropTable(
                name: "water_client_phone_number");

            migrationBuilder.DropTable(
                name: "water_client_type");

            migrationBuilder.DropTable(
                name: "water_contragent");

            migrationBuilder.DropTable(
                name: "water_invoice_item");

            migrationBuilder.DropTable(
                name: "water_message_log");

            migrationBuilder.DropTable(
                name: "water_order_item");

            migrationBuilder.DropTable(
                name: "water_product_ostatka");

            migrationBuilder.DropTable(
                name: "WaterCheckFakeModel");

            migrationBuilder.DropTable(
                name: "WaterOrderedProduct");

            migrationBuilder.DropTable(
                name: "WaterStatistikaFakeReport");

            migrationBuilder.DropTable(
                name: "hospital_beds_type_and_summ");

            migrationBuilder.DropTable(
                name: "oquv_markaz_book_and_group");

            migrationBuilder.DropTable(
                name: "oquv_markaz_book_unit");

            migrationBuilder.DropTable(
                name: "oquv_markaz_client_test");

            migrationBuilder.DropTable(
                name: "oquv_markaz_daily_pupil_calculation");

            migrationBuilder.DropTable(
                name: "tegirmon_product_persantage");

            migrationBuilder.DropTable(
                name: "tegirmon_tortilgan_bugdoy_royxati");

            migrationBuilder.DropTable(
                name: "tegirmon_tortilgan_bugdoy_royxati_group");

            migrationBuilder.DropTable(
                name: "tex_raskladki");

            migrationBuilder.DropTable(
                name: "water_client_bottle_info");

            migrationBuilder.DropTable(
                name: "water_contragent_type");

            migrationBuilder.DropTable(
                name: "water_invoice");

            migrationBuilder.DropTable(
                name: "water_order");

            migrationBuilder.DropTable(
                name: "oquv_markaz_book");

            migrationBuilder.DropTable(
                name: "tex_raskladki_device_information");

            migrationBuilder.DropTable(
                name: "tex_raskladki_information");

            migrationBuilder.DropTable(
                name: "tex_raskladki_model_kroy_information");

            migrationBuilder.DropTable(
                name: "tex_raskladki_model_rasxod_information");

            migrationBuilder.DropTable(
                name: "water_product");

            migrationBuilder.DropTable(
                name: "water_auth");

            migrationBuilder.DropTable(
                name: "water_client_address");

            migrationBuilder.DropTable(
                name: "water_user");

            migrationBuilder.DropTable(
                name: "water_client");

            migrationBuilder.DropTable(
                name: "water_tuman");

            migrationBuilder.DropTable(
                name: "water_viloyat");

            migrationBuilder.DropIndex(
                name: "IX_tex_size_TexSizeTypeid",
                table: "tex_size");

            migrationBuilder.DropIndex(
                name: "IX_tegirmon_invoice_TegirmonProductid",
                table: "tegirmon_invoice");

            migrationBuilder.DropIndex(
                name: "IX_oquv_markaz_salary_item_OquvMarkazClientid",
                table: "oquv_markaz_salary_item");

            migrationBuilder.DropIndex(
                name: "IX_oquv_markaz_salary_item_OquvMarkazPupilGroupsid",
                table: "oquv_markaz_salary_item");

            migrationBuilder.DropIndex(
                name: "IX_oquv_markaz_client_OquvMarkazClientTypeid",
                table: "oquv_markaz_client");

            migrationBuilder.DropIndex(
                name: "IX_oquv_markaz_client_OquvMarkazContragentid",
                table: "oquv_markaz_client");

            migrationBuilder.DropIndex(
                name: "IX_oquv_markaz_check_OquvMarkazAuthid",
                table: "oquv_markaz_check");

            migrationBuilder.DropIndex(
                name: "IX_oquv_markaz_check_OquvMarkazUserid",
                table: "oquv_markaz_check");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skud_sababli",
                table: "skud_sababli");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skud_period",
                table: "skud_period");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skud_my_department",
                table: "skud_my_department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skud_my_checkinout",
                table: "skud_my_checkinout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skud_images",
                table: "skud_images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skud_group_access",
                table: "skud_group_access");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skud_gr_for_emp",
                table: "skud_gr_for_emp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skud_for_trenajor",
                table: "skud_for_trenajor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skud_door_checkinout",
                table: "skud_door_checkinout");

            migrationBuilder.DropColumn(
                name: "TexSizeTypeid",
                table: "tex_size");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_user");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_user");

            migrationBuilder.DropColumn(
                name: "car_number",
                table: "tegirmon_user");

            migrationBuilder.DropColumn(
                name: "card_number",
                table: "tegirmon_user");

            migrationBuilder.DropColumn(
                name: "salary",
                table: "tegirmon_user");

            migrationBuilder.DropColumn(
                name: "user_face_id",
                table: "tegirmon_user");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_unit_measurment");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_unit_measurment");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_telegram_bot_message");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_telegram_bot_message");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_product");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_product");

            migrationBuilder.DropColumn(
                name: "buyed_price",
                table: "tegirmon_product");

            migrationBuilder.DropColumn(
                name: "shitrix_code",
                table: "tegirmon_product");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_payments");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_payments");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_ostatka");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_ostatka");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_invoice_type");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_invoice_type");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_invoice_item");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_invoice_item");

            migrationBuilder.DropColumn(
                name: "TegirmonProductid",
                table: "tegirmon_invoice");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_invoice");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_invoice");

            migrationBuilder.DropColumn(
                name: "client_names_list",
                table: "tegirmon_invoice");

            migrationBuilder.DropColumn(
                name: "get_money_for_bugdoy_zaxira",
                table: "tegirmon_invoice");

            migrationBuilder.DropColumn(
                name: "image_str_url",
                table: "tegirmon_invoice");

            migrationBuilder.DropColumn(
                name: "qty_real",
                table: "tegirmon_invoice");

            migrationBuilder.DropColumn(
                name: "status_inv_type_name",
                table: "tegirmon_invoice");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_distict");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_distict");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_department");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_department");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_debit_product_detail");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_debit_product_detail");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_debit_detail");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_debit_detail");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_debit");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_debit");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_credit_detail");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_credit_detail");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_credit");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_credit");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_contragent");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_contragent");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_company");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_company");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_client_group");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_client_group");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_client");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_client");

            migrationBuilder.DropColumn(
                name: "reserve",
                table: "tegirmon_client");

            migrationBuilder.DropColumn(
                name: "reserve_val",
                table: "tegirmon_client");

            migrationBuilder.DropColumn(
                name: "reserve_val_l",
                table: "tegirmon_client");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_check_in_out_detail");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_check_in_out_detail");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_check");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_check");

            migrationBuilder.DropColumn(
                name: "for_buy_tovar_rasxod",
                table: "tegirmon_check");

            migrationBuilder.DropColumn(
                name: "online",
                table: "tegirmon_check");

            migrationBuilder.DropColumn(
                name: "rasxod",
                table: "tegirmon_check");

            migrationBuilder.DropColumn(
                name: "salary",
                table: "tegirmon_check");

            migrationBuilder.DropColumn(
                name: "srogi_otganlar_uchun_rasxod",
                table: "tegirmon_check");

            migrationBuilder.DropColumn(
                name: "auth_user_creator_id",
                table: "tegirmon_authorization");

            migrationBuilder.DropColumn(
                name: "auth_user_updator_id",
                table: "tegirmon_authorization");

            migrationBuilder.DropColumn(
                name: "OquvMarkazClientid",
                table: "oquv_markaz_salary_item");

            migrationBuilder.DropColumn(
                name: "OquvMarkazPupilGroupsid",
                table: "oquv_markaz_salary_item");

            migrationBuilder.DropColumn(
                name: "bonus_summ",
                table: "oquv_markaz_fan_and_group_payment_left_lessons");

            migrationBuilder.DropColumn(
                name: "bonus_summ_for_one_lesson",
                table: "oquv_markaz_fan_and_group_payment_left_lessons");

            migrationBuilder.DropColumn(
                name: "OquvMarkazClientTypeid",
                table: "oquv_markaz_client");

            migrationBuilder.DropColumn(
                name: "OquvMarkazContragentid",
                table: "oquv_markaz_client");

            migrationBuilder.DropColumn(
                name: "free_days",
                table: "oquv_markaz_client");

            migrationBuilder.DropColumn(
                name: "free_pupil_time",
                table: "oquv_markaz_client");

            migrationBuilder.DropColumn(
                name: "free_time",
                table: "oquv_markaz_client");

            migrationBuilder.DropColumn(
                name: "note",
                table: "oquv_markaz_client");

            migrationBuilder.DropColumn(
                name: "waiting_status",
                table: "oquv_markaz_client");

            migrationBuilder.DropColumn(
                name: "OquvMarkazAuthid",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "OquvMarkazUserid",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "bonus_summ",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "cashback_card",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "cashback_summ",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "cashback_user_phone_number",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "cassir_name",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "discount",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "discount_pesantage",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "discount_summ",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "kam_chiqqan_summ",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "kassa_close_status",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "note",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "rasxod",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "reserve",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "user_name",
                table: "oquv_markaz_check");

            migrationBuilder.DropColumn(
                name: "info_1",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_10",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_11",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_12",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_13",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_14",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_15",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_16",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_17",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_18",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_19",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_2",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_20",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_21",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_22",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_23",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_3",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_4",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_5",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_6",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_7",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_8",
                table: "archive_room");

            migrationBuilder.DropColumn(
                name: "info_9",
                table: "archive_room");

            migrationBuilder.RenameTable(
                name: "skud_smenam",
                newName: "SkudSmena");

            migrationBuilder.RenameTable(
                name: "skud_sababli",
                newName: "SkudSababli");

            migrationBuilder.RenameTable(
                name: "skud_result_gr",
                newName: "SkudResultGr");

            migrationBuilder.RenameTable(
                name: "skud_picture_checkinout",
                newName: "SkudPictureCheckinout");

            migrationBuilder.RenameTable(
                name: "skud_period",
                newName: "SkudPeriod");

            migrationBuilder.RenameTable(
                name: "skud_my_department",
                newName: "SkudMyDepartments");

            migrationBuilder.RenameTable(
                name: "skud_my_checkinout",
                newName: "SkudMyCheckinout");

            migrationBuilder.RenameTable(
                name: "skud_lk",
                newName: "SkudLk");

            migrationBuilder.RenameTable(
                name: "skud_images",
                newName: "SkudImages");

            migrationBuilder.RenameTable(
                name: "skud_group_access",
                newName: "SkudGroupAccess");

            migrationBuilder.RenameTable(
                name: "skud_gr_for_emp",
                newName: "SkudGrForEmp");

            migrationBuilder.RenameTable(
                name: "skud_for_trenajor",
                newName: "SkudForTrenajor");

            migrationBuilder.RenameTable(
                name: "skud_faces",
                newName: "SkudFaces");

            migrationBuilder.RenameTable(
                name: "skud_doors",
                newName: "SkudDoors");

            migrationBuilder.RenameTable(
                name: "skud_door_checkinout",
                newName: "SkudDoorCheckinout");

            migrationBuilder.RenameIndex(
                name: "IX_skud_my_department_deptname",
                table: "SkudMyDepartments",
                newName: "IX_SkudMyDepartments_deptname");

            migrationBuilder.RenameIndex(
                name: "IX_skud_my_checkinout_userid_sana_checktime",
                table: "SkudMyCheckinout",
                newName: "IX_SkudMyCheckinout_userid_sana_checktime");

            migrationBuilder.RenameIndex(
                name: "IX_skud_lk_lkey",
                table: "SkudLk",
                newName: "IX_SkudLk_lkey");

            migrationBuilder.RenameIndex(
                name: "IX_skud_faces_nomi",
                table: "SkudFaces",
                newName: "IX_SkudFaces_nomi");

            migrationBuilder.RenameIndex(
                name: "IX_skud_faces_ip",
                table: "SkudFaces",
                newName: "IX_SkudFaces_ip");

            migrationBuilder.RenameIndex(
                name: "IX_skud_doors_dbname",
                table: "SkudDoors",
                newName: "IX_SkudDoors_dbname");

            migrationBuilder.RenameIndex(
                name: "IX_skud_door_checkinout_userid_sana_checktime",
                table: "SkudDoorCheckinout",
                newName: "IX_SkudDoorCheckinout_userid_sana_checktime");

            migrationBuilder.AlterColumn<List<double>>(
                name: "week_days",
                table: "oquv_markaz_pupil_groups",
                type: "double precision[]",
                nullable: true,
                oldClrType: typeof(List<int>),
                oldType: "integer[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OquvMarkazClientid",
                table: "oquv_markaz_check",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkudSababli",
                table: "SkudSababli",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkudPeriod",
                table: "SkudPeriod",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkudMyDepartments",
                table: "SkudMyDepartments",
                column: "deptid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkudMyCheckinout",
                table: "SkudMyCheckinout",
                column: "code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkudImages",
                table: "SkudImages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkudGroupAccess",
                table: "SkudGroupAccess",
                column: "group_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkudGrForEmp",
                table: "SkudGrForEmp",
                column: "id_emp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkudForTrenajor",
                table: "SkudForTrenajor",
                column: "userid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkudDoorCheckinout",
                table: "SkudDoorCheckinout",
                column: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_oquv_markaz_check_oquv_markaz_client_OquvMarkazClientid",
                table: "oquv_markaz_check",
                column: "OquvMarkazClientid",
                principalTable: "oquv_markaz_client",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
