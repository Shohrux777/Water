using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initdgdfgfdgdf3478675fdgdfsdfdsfdsfds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "main_order_item_id",
                table: "tex_order_item_steps_detail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "product_model_id",
                table: "tex_order_item",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "started_status",
                table: "tex_order_item",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "tegirmon_client_group",
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
                    table.PrimaryKey("PK_tegirmon_client_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_company",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    bot_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_distict",
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
                    table.PrimaryKey("PK_tegirmon_distict", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_invoice_type",
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
                    table.PrimaryKey("PK_tegirmon_invoice_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_telegram_bot_message",
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
                    table.PrimaryKey("PK_tegirmon_telegram_bot_message", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_unit_measurment",
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
                    table.PrimaryKey("PK_tegirmon_unit_measurment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_order_item_recipe",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    main_order_item_id = table.Column<long>(type: "bigint", nullable: true),
                    sub_order_item_id = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_order_item_recipe", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_order_item_recipe_tex_order_item_main_order_item_id",
                        column: x => x.main_order_item_id,
                        principalTable: "tex_order_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_order_item_recipe_tex_order_item_sub_order_item_id",
                        column: x => x.sub_order_item_id,
                        principalTable: "tex_order_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_order_item_recipe_tex_product_product_id",
                        column: x => x.product_id,
                        principalTable: "tex_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_order_item_recipe_for_one_order_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    main_order_item_id = table.Column<long>(type: "bigint", nullable: true),
                    sub_order_item_id = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_order_item_recipe_for_one_order_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_order_item_recipe_for_one_order_item_tex_order_item_mai~",
                        column: x => x.main_order_item_id,
                        principalTable: "tex_order_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_order_item_recipe_for_one_order_item_tex_order_item_sub~",
                        column: x => x.sub_order_item_id,
                        principalTable: "tex_order_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_order_item_recipe_for_one_order_item_tex_product_produc~",
                        column: x => x.product_id,
                        principalTable: "tex_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_order_item_recipe_reserve",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    main_order_item_id = table.Column<long>(type: "bigint", nullable: true),
                    sub_order_item_id = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    invoice_item_id = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_order_item_recipe_reserve", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_order_item_recipe_reserve_tex_invoice_item_invoice_item~",
                        column: x => x.invoice_item_id,
                        principalTable: "tex_invoice_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tex_order_item_recipe_reserve_tex_order_item_main_order_ite~",
                        column: x => x.main_order_item_id,
                        principalTable: "tex_order_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_order_item_recipe_reserve_tex_order_item_sub_order_item~",
                        column: x => x.sub_order_item_id,
                        principalTable: "tex_order_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_product_model",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    print_name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_product_model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_department",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    TegirmonCompanyid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_department", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_department_tegirmon_company_TegirmonCompanyid",
                        column: x => x.TegirmonCompanyid,
                        principalTable: "tegirmon_company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_client",
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
                    user_face_id = table.Column<int>(type: "integer", nullable: false),
                    TegirmonDistrictid = table.Column<long>(type: "bigint", nullable: true),
                    TegirmonClientGroupid = table.Column<long>(type: "bigint", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    udate_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    passport_image_base_64 = table.Column<string>(type: "text", nullable: true),
                    passport_image_url = table.Column<string>(type: "text", nullable: true),
                    bot_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_client", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_client_tegirmon_client_group_TegirmonClientGroupid",
                        column: x => x.TegirmonClientGroupid,
                        principalTable: "tegirmon_client_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tegirmon_client_tegirmon_distict_TegirmonDistrictid",
                        column: x => x.TegirmonDistrictid,
                        principalTable: "tegirmon_distict",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_contragent",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    adddress = table.Column<string>(type: "text", nullable: true),
                    passport_number = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    contragent_company_name = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    image_base_64 = table.Column<string>(type: "text", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    car_number = table.Column<string>(type: "text", nullable: true),
                    addiotionala_information = table.Column<string>(type: "text", nullable: true),
                    user_face_id = table.Column<int>(type: "integer", nullable: false),
                    TegirmonDistrictid = table.Column<long>(type: "bigint", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    udate_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    passport_image_base_64 = table.Column<string>(type: "text", nullable: true),
                    passport_image_url = table.Column<string>(type: "text", nullable: true),
                    bot_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_contragent", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_contragent_tegirmon_distict_TegirmonDistrictid",
                        column: x => x.TegirmonDistrictid,
                        principalTable: "tegirmon_distict",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    print_name = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    image_base_64 = table.Column<string>(type: "text", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TegirmonUnitMeasurmentid = table.Column<long>(type: "bigint", nullable: false),
                    bot_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_product_tegirmon_unit_measurment_TegirmonUnitMeasu~",
                        column: x => x.TegirmonUnitMeasurmentid,
                        principalTable: "tegirmon_unit_measurment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TegirmonDepartmentid = table.Column<long>(type: "bigint", nullable: false),
                    fio = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    born_date = table.Column<string>(type: "text", nullable: true),
                    image_base_64 = table.Column<string>(type: "text", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    passport_image_base_64 = table.Column<string>(type: "text", nullable: true),
                    passport_image_url = table.Column<string>(type: "text", nullable: true),
                    bot_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_user_tegirmon_department_TegirmonDepartmentid",
                        column: x => x.TegirmonDepartmentid,
                        principalTable: "tegirmon_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_debit",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    money_summ = table.Column<double>(type: "double precision", nullable: false),
                    real_summ = table.Column<double>(type: "double precision", nullable: false),
                    TegirmonClientid = table.Column<long>(type: "bigint", nullable: false),
                    finish = table.Column<bool>(type: "boolean", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_debit", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_debit_tegirmon_client_TegirmonClientid",
                        column: x => x.TegirmonClientid,
                        principalTable: "tegirmon_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_credit",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    real_summ = table.Column<double>(type: "double precision", nullable: false),
                    TegirmonContragentid = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    reg_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_credit", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_credit_tegirmon_contragent_TegirmonContragentid",
                        column: x => x.TegirmonContragentid,
                        principalTable: "tegirmon_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_ostatka",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TegirmonProductid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_ostatka", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_ostatka_tegirmon_product_TegirmonProductid",
                        column: x => x.TegirmonProductid,
                        principalTable: "tegirmon_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_authorization",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    login = table.Column<string>(type: "text", nullable: true),
                    pasword = table.Column<string>(type: "text", nullable: true),
                    TegirmonUserid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_authorization", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_authorization_tegirmon_user_TegirmonUserid",
                        column: x => x.TegirmonUserid,
                        principalTable: "tegirmon_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_check_in_out_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    reg_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    reg_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    check_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    check_date = table.Column<DateTime>(type: "date", nullable: false),
                    TegirmonClientid = table.Column<long>(type: "bigint", nullable: true),
                    TegirmonUserid = table.Column<long>(type: "bigint", nullable: true),
                    id_ev = table.Column<int>(type: "integer", nullable: false),
                    image_base_64 = table.Column<string>(type: "text", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_check_in_out_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_check_in_out_detail_tegirmon_client_TegirmonClient~",
                        column: x => x.TegirmonClientid,
                        principalTable: "tegirmon_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tegirmon_check_in_out_detail_tegirmon_user_TegirmonUserid",
                        column: x => x.TegirmonUserid,
                        principalTable: "tegirmon_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_debit_product_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TegirmonProductid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    TegirmonDebitid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_debit_product_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_debit_product_detail_tegirmon_debit_TegirmonDebitid",
                        column: x => x.TegirmonDebitid,
                        principalTable: "tegirmon_debit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tegirmon_debit_product_detail_tegirmon_product_TegirmonProd~",
                        column: x => x.TegirmonProductid,
                        principalTable: "tegirmon_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_check",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TegirmonClientid = table.Column<long>(type: "bigint", nullable: true),
                    card = table.Column<double>(type: "double precision", nullable: false),
                    cash = table.Column<double>(type: "double precision", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    profit_summ = table.Column<double>(type: "double precision", nullable: false),
                    real_sum = table.Column<double>(type: "double precision", nullable: false),
                    humo = table.Column<double>(type: "double precision", nullable: false),
                    uz_card = table.Column<double>(type: "double precision", nullable: false),
                    perchisleniya = table.Column<double>(type: "double precision", nullable: false),
                    dolg = table.Column<double>(type: "double precision", nullable: false),
                    dolg_payed = table.Column<double>(type: "double precision", nullable: false),
                    creadit_payed = table.Column<double>(type: "double precision", nullable: false),
                    reg_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    change_status = table.Column<bool>(type: "boolean", nullable: false),
                    image_base_64 = table.Column<string>(type: "text", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    TegirmonContragentid = table.Column<long>(type: "bigint", nullable: true),
                    TegirmonCreditid = table.Column<long>(type: "bigint", nullable: true),
                    dolg_status = table.Column<bool>(type: "boolean", nullable: false),
                    credit_status = table.Column<bool>(type: "boolean", nullable: false),
                    TegirmonAuthid = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_check", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_check_tegirmon_authorization_TegirmonAuthid",
                        column: x => x.TegirmonAuthid,
                        principalTable: "tegirmon_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tegirmon_check_tegirmon_client_TegirmonClientid",
                        column: x => x.TegirmonClientid,
                        principalTable: "tegirmon_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tegirmon_check_tegirmon_contragent_TegirmonContragentid",
                        column: x => x.TegirmonContragentid,
                        principalTable: "tegirmon_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tegirmon_check_tegirmon_credit_TegirmonCreditid",
                        column: x => x.TegirmonCreditid,
                        principalTable: "tegirmon_credit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_invoice",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    note = table.Column<string>(type: "text", nullable: true),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    dolg_summ = table.Column<double>(type: "double precision", nullable: false),
                    credit_sum = table.Column<double>(type: "double precision", nullable: false),
                    TegirmonContragentid = table.Column<long>(type: "bigint", nullable: true),
                    TegirmonClientid = table.Column<long>(type: "bigint", nullable: true),
                    TegirmonAuthid = table.Column<long>(type: "bigint", nullable: true),
                    TegirmonCompanyid = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_invoice", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_invoice_tegirmon_authorization_TegirmonAuthid",
                        column: x => x.TegirmonAuthid,
                        principalTable: "tegirmon_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tegirmon_invoice_tegirmon_client_TegirmonClientid",
                        column: x => x.TegirmonClientid,
                        principalTable: "tegirmon_client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tegirmon_invoice_tegirmon_company_TegirmonCompanyid",
                        column: x => x.TegirmonCompanyid,
                        principalTable: "tegirmon_company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tegirmon_invoice_tegirmon_contragent_TegirmonContragentid",
                        column: x => x.TegirmonContragentid,
                        principalTable: "tegirmon_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_payments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TegirmonProductid = table.Column<long>(type: "bigint", nullable: false),
                    TegirmonCheckid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    summa = table.Column<double>(type: "double precision", nullable: false),
                    profit_summ = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_payments_tegirmon_check_TegirmonCheckid",
                        column: x => x.TegirmonCheckid,
                        principalTable: "tegirmon_check",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tegirmon_payments_tegirmon_product_TegirmonProductid",
                        column: x => x.TegirmonProductid,
                        principalTable: "tegirmon_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_credit_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    note = table.Column<string>(type: "text", nullable: true),
                    TegirmonCreditid = table.Column<long>(type: "bigint", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TegirmonInvoiceid = table.Column<long>(type: "bigint", nullable: false),
                    auth_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_credit_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_credit_detail_tegirmon_credit_TegirmonCreditid",
                        column: x => x.TegirmonCreditid,
                        principalTable: "tegirmon_credit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tegirmon_credit_detail_tegirmon_invoice_TegirmonInvoiceid",
                        column: x => x.TegirmonInvoiceid,
                        principalTable: "tegirmon_invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_debit_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TegirmonDebitid = table.Column<long>(type: "bigint", nullable: false),
                    TegirmonInvoiceid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_debit_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_debit_detail_tegirmon_debit_TegirmonDebitid",
                        column: x => x.TegirmonDebitid,
                        principalTable: "tegirmon_debit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tegirmon_debit_detail_tegirmon_invoice_TegirmonInvoiceid",
                        column: x => x.TegirmonInvoiceid,
                        principalTable: "tegirmon_invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tegirmon_invoice_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TegirmonInvoiceid = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    TegirmonProductid = table.Column<long>(type: "bigint", nullable: false),
                    sum = table.Column<double>(type: "double precision", nullable: false),
                    real_sum = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    inv_accepted_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tegirmon_invoice_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_tegirmon_invoice_item_tegirmon_invoice_TegirmonInvoiceid",
                        column: x => x.TegirmonInvoiceid,
                        principalTable: "tegirmon_invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tegirmon_invoice_item_tegirmon_product_TegirmonProductid",
                        column: x => x.TegirmonProductid,
                        principalTable: "tegirmon_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_steps_detail_main_order_item_id",
                table: "tex_order_item_steps_detail",
                column: "main_order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_product_model_id",
                table: "tex_order_item",
                column: "product_model_id");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_authorization_TegirmonUserid",
                table: "tegirmon_authorization",
                column: "TegirmonUserid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_check_TegirmonAuthid",
                table: "tegirmon_check",
                column: "TegirmonAuthid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_check_TegirmonClientid",
                table: "tegirmon_check",
                column: "TegirmonClientid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_check_TegirmonContragentid",
                table: "tegirmon_check",
                column: "TegirmonContragentid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_check_TegirmonCreditid",
                table: "tegirmon_check",
                column: "TegirmonCreditid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_check_in_out_detail_TegirmonClientid",
                table: "tegirmon_check_in_out_detail",
                column: "TegirmonClientid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_check_in_out_detail_TegirmonUserid",
                table: "tegirmon_check_in_out_detail",
                column: "TegirmonUserid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_client_TegirmonClientGroupid",
                table: "tegirmon_client",
                column: "TegirmonClientGroupid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_client_TegirmonDistrictid",
                table: "tegirmon_client",
                column: "TegirmonDistrictid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_contragent_TegirmonDistrictid",
                table: "tegirmon_contragent",
                column: "TegirmonDistrictid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_credit_TegirmonContragentid",
                table: "tegirmon_credit",
                column: "TegirmonContragentid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_credit_detail_TegirmonCreditid",
                table: "tegirmon_credit_detail",
                column: "TegirmonCreditid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_credit_detail_TegirmonInvoiceid",
                table: "tegirmon_credit_detail",
                column: "TegirmonInvoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_debit_TegirmonClientid",
                table: "tegirmon_debit",
                column: "TegirmonClientid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_debit_detail_TegirmonDebitid",
                table: "tegirmon_debit_detail",
                column: "TegirmonDebitid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_debit_detail_TegirmonInvoiceid",
                table: "tegirmon_debit_detail",
                column: "TegirmonInvoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_debit_product_detail_TegirmonDebitid",
                table: "tegirmon_debit_product_detail",
                column: "TegirmonDebitid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_debit_product_detail_TegirmonProductid",
                table: "tegirmon_debit_product_detail",
                column: "TegirmonProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_department_TegirmonCompanyid",
                table: "tegirmon_department",
                column: "TegirmonCompanyid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_invoice_TegirmonAuthid",
                table: "tegirmon_invoice",
                column: "TegirmonAuthid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_invoice_TegirmonClientid",
                table: "tegirmon_invoice",
                column: "TegirmonClientid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_invoice_TegirmonCompanyid",
                table: "tegirmon_invoice",
                column: "TegirmonCompanyid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_invoice_TegirmonContragentid",
                table: "tegirmon_invoice",
                column: "TegirmonContragentid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_invoice_item_TegirmonInvoiceid",
                table: "tegirmon_invoice_item",
                column: "TegirmonInvoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_invoice_item_TegirmonProductid",
                table: "tegirmon_invoice_item",
                column: "TegirmonProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_ostatka_TegirmonProductid",
                table: "tegirmon_ostatka",
                column: "TegirmonProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_payments_TegirmonCheckid",
                table: "tegirmon_payments",
                column: "TegirmonCheckid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_payments_TegirmonProductid",
                table: "tegirmon_payments",
                column: "TegirmonProductid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_product_TegirmonUnitMeasurmentid",
                table: "tegirmon_product",
                column: "TegirmonUnitMeasurmentid");

            migrationBuilder.CreateIndex(
                name: "IX_tegirmon_user_TegirmonDepartmentid",
                table: "tegirmon_user",
                column: "TegirmonDepartmentid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_recipe_main_order_item_id",
                table: "tex_order_item_recipe",
                column: "main_order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_recipe_product_id",
                table: "tex_order_item_recipe",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_recipe_sub_order_item_id",
                table: "tex_order_item_recipe",
                column: "sub_order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_recipe_for_one_order_item_main_order_item_id",
                table: "tex_order_item_recipe_for_one_order_item",
                column: "main_order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_recipe_for_one_order_item_product_id",
                table: "tex_order_item_recipe_for_one_order_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_recipe_for_one_order_item_sub_order_item_id",
                table: "tex_order_item_recipe_for_one_order_item",
                column: "sub_order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_recipe_reserve_invoice_item_id",
                table: "tex_order_item_recipe_reserve",
                column: "invoice_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_recipe_reserve_main_order_item_id",
                table: "tex_order_item_recipe_reserve",
                column: "main_order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_recipe_reserve_sub_order_item_id",
                table: "tex_order_item_recipe_reserve",
                column: "sub_order_item_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tex_order_item_tex_product_model_product_model_id",
                table: "tex_order_item",
                column: "product_model_id",
                principalTable: "tex_product_model",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_order_item_steps_detail_tex_order_item_main_order_item_~",
                table: "tex_order_item_steps_detail",
                column: "main_order_item_id",
                principalTable: "tex_order_item",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tex_order_item_tex_product_model_product_model_id",
                table: "tex_order_item");

            migrationBuilder.DropForeignKey(
                name: "FK_tex_order_item_steps_detail_tex_order_item_main_order_item_~",
                table: "tex_order_item_steps_detail");

            migrationBuilder.DropTable(
                name: "tegirmon_check_in_out_detail");

            migrationBuilder.DropTable(
                name: "tegirmon_credit_detail");

            migrationBuilder.DropTable(
                name: "tegirmon_debit_detail");

            migrationBuilder.DropTable(
                name: "tegirmon_debit_product_detail");

            migrationBuilder.DropTable(
                name: "tegirmon_invoice_item");

            migrationBuilder.DropTable(
                name: "tegirmon_invoice_type");

            migrationBuilder.DropTable(
                name: "tegirmon_ostatka");

            migrationBuilder.DropTable(
                name: "tegirmon_payments");

            migrationBuilder.DropTable(
                name: "tegirmon_telegram_bot_message");

            migrationBuilder.DropTable(
                name: "tex_order_item_recipe");

            migrationBuilder.DropTable(
                name: "tex_order_item_recipe_for_one_order_item");

            migrationBuilder.DropTable(
                name: "tex_order_item_recipe_reserve");

            migrationBuilder.DropTable(
                name: "tex_product_model");

            migrationBuilder.DropTable(
                name: "tegirmon_debit");

            migrationBuilder.DropTable(
                name: "tegirmon_invoice");

            migrationBuilder.DropTable(
                name: "tegirmon_check");

            migrationBuilder.DropTable(
                name: "tegirmon_product");

            migrationBuilder.DropTable(
                name: "tegirmon_authorization");

            migrationBuilder.DropTable(
                name: "tegirmon_client");

            migrationBuilder.DropTable(
                name: "tegirmon_credit");

            migrationBuilder.DropTable(
                name: "tegirmon_unit_measurment");

            migrationBuilder.DropTable(
                name: "tegirmon_user");

            migrationBuilder.DropTable(
                name: "tegirmon_client_group");

            migrationBuilder.DropTable(
                name: "tegirmon_contragent");

            migrationBuilder.DropTable(
                name: "tegirmon_department");

            migrationBuilder.DropTable(
                name: "tegirmon_distict");

            migrationBuilder.DropTable(
                name: "tegirmon_company");

            migrationBuilder.DropIndex(
                name: "IX_tex_order_item_steps_detail_main_order_item_id",
                table: "tex_order_item_steps_detail");

            migrationBuilder.DropIndex(
                name: "IX_tex_order_item_product_model_id",
                table: "tex_order_item");

            migrationBuilder.DropColumn(
                name: "main_order_item_id",
                table: "tex_order_item_steps_detail");

            migrationBuilder.DropColumn(
                name: "product_model_id",
                table: "tex_order_item");

            migrationBuilder.DropColumn(
                name: "started_status",
                table: "tex_order_item");
        }
    }
}
