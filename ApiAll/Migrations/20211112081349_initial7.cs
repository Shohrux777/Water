using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pos_brend",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_brend", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_check",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    card_sum = table.Column<double>(type: "double precision", nullable: false),
                    cash_sum = table.Column<double>(type: "double precision", nullable: false),
                    discount_summ = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_check", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_client",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fio = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    passport_number = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    card_number = table.Column<string>(type: "text", nullable: false),
                    bot_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_client_card_type",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    discount_persantage = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_client_card_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pos_company",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    print_name = table.Column<string>(type: "text", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    bot_info = table.Column<string>(type: "text", nullable: true),
                    info_bot_key = table.Column<string>(type: "text", nullable: true),
                    order_bot_key = table.Column<string>(type: "text", nullable: true),
                    orderbot_info = table.Column<string>(type: "text", nullable: true),
                    nds = table.Column<double>(type: "double precision", nullable: true),
                    location_company = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_message_group",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    bot_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    reg_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    bot_name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_message_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_order",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_order", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_order_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_order_item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_product_tag",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_product_tag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_product_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_product_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_product_unitmeasurment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_product_unitmeasurment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fio = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    bot_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pos_card_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    card_number = table.Column<string>(type: "text", nullable: true),
                    card_type_id = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_card_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_card_detail_pos_client_card_type_card_type_id",
                        column: x => x.card_type_id,
                        principalTable: "pos_client_card_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_department",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false),
                    main_department_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_department", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_department_pos_company_company_id",
                        column: x => x.company_id,
                        principalTable: "pos_company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_department_pos_department_main_department_id",
                        column: x => x.main_department_id,
                        principalTable: "pos_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pos_message",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    pos_message_group_id = table.Column<long>(type: "bigint", nullable: false),
                    groupid = table.Column<long>(type: "bigint", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    send_or_recive_status = table.Column<bool>(type: "boolean", nullable: false),
                    readed_statatus = table.Column<bool>(type: "boolean", nullable: false),
                    sended_ower_bot_status = table.Column<bool>(type: "boolean", nullable: false),
                    answered_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_message", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_message_pos_message_group_groupid",
                        column: x => x.groupid,
                        principalTable: "pos_message_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pos_product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    print_name = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    buyed_price = table.Column<double>(type: "double precision", nullable: false),
                    image = table.Column<string>(type: "text", nullable: true),
                    product_reg_code = table.Column<string>(type: "text", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    publisher_name = table.Column<string>(type: "text", nullable: true),
                    brend_id = table.Column<long>(type: "bigint", nullable: true),
                    category_id = table.Column<long>(type: "bigint", nullable: true),
                    product_type_id = table.Column<long>(type: "bigint", nullable: true),
                    product_tag_id = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_product_pos_brend_brend_id",
                        column: x => x.brend_id,
                        principalTable: "pos_brend",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pos_product_pos_category_category_id",
                        column: x => x.category_id,
                        principalTable: "pos_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pos_product_pos_product_tag_product_tag_id",
                        column: x => x.product_tag_id,
                        principalTable: "pos_product_tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pos_product_pos_product_type_product_type_id",
                        column: x => x.product_type_id,
                        principalTable: "pos_product_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pos_authorization",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    company_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    login = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    password_not_md5 = table.Column<string>(type: "text", nullable: true),
                    access_type = table.Column<int>(type: "integer", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_authorization", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_authorization_pos_company_company_id",
                        column: x => x.company_id,
                        principalTable: "pos_company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_authorization_pos_user_user_id",
                        column: x => x.user_id,
                        principalTable: "pos_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_sklad",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    department_id = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_sklad", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_sklad_pos_department_department_id",
                        column: x => x.department_id,
                        principalTable: "pos_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_sub_department",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    department_id = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_sub_department", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_sub_department_pos_department_department_id",
                        column: x => x.department_id,
                        principalTable: "pos_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_payments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    productid = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    unit_price = table.Column<double>(type: "double precision", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    real_sum = table.Column<double>(type: "double precision", nullable: false),
                    discount_summ = table.Column<double>(type: "double precision", nullable: false),
                    PosCheckid = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_payments_pos_check_PosCheckid",
                        column: x => x.PosCheckid,
                        principalTable: "pos_check",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pos_payments_pos_product_productid",
                        column: x => x.productid,
                        principalTable: "pos_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pos_product_code",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_product_code", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_product_code_pos_product_product_id",
                        column: x => x.product_id,
                        principalTable: "pos_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_invoice",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    factura_number = table.Column<string>(type: "text", nullable: true),
                    postavshik_id = table.Column<long>(type: "bigint", nullable: true),
                    sklad_id = table.Column<long>(type: "bigint", nullable: false),
                    department_id = table.Column<long>(type: "bigint", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    debit_summ = table.Column<double>(type: "double precision", nullable: false),
                    credit_sum = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_invoice", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_invoice_pos_company_postavshik_id",
                        column: x => x.postavshik_id,
                        principalTable: "pos_company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pos_invoice_pos_department_department_id",
                        column: x => x.department_id,
                        principalTable: "pos_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_invoice_pos_sklad_sklad_id",
                        column: x => x.sklad_id,
                        principalTable: "pos_sklad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_invoice_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    unit_buyed_price = table.Column<double>(type: "double precision", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    real_qty = table.Column<double>(type: "double precision", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    finished = table.Column<bool>(type: "boolean", nullable: false),
                    PosInvoiceid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    real_company_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_invoice_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_invoice_item_pos_invoice_PosInvoiceid",
                        column: x => x.PosInvoiceid,
                        principalTable: "pos_invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_invoice_item_pos_product_product_id",
                        column: x => x.product_id,
                        principalTable: "pos_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pos_authorization_company_id",
                table: "pos_authorization",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_authorization_user_id",
                table: "pos_authorization",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_card_detail_card_type_id",
                table: "pos_card_detail",
                column: "card_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_department_company_id",
                table: "pos_department",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_department_main_department_id",
                table: "pos_department",
                column: "main_department_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_invoice_department_id",
                table: "pos_invoice",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_invoice_postavshik_id",
                table: "pos_invoice",
                column: "postavshik_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_invoice_sklad_id",
                table: "pos_invoice",
                column: "sklad_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_invoice_item_PosInvoiceid",
                table: "pos_invoice_item",
                column: "PosInvoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_invoice_item_product_id",
                table: "pos_invoice_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_message_groupid",
                table: "pos_message",
                column: "groupid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_payments_PosCheckid",
                table: "pos_payments",
                column: "PosCheckid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_payments_productid",
                table: "pos_payments",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_pos_product_brend_id",
                table: "pos_product",
                column: "brend_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_product_category_id",
                table: "pos_product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_product_product_tag_id",
                table: "pos_product",
                column: "product_tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_product_product_type_id",
                table: "pos_product",
                column: "product_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_product_code_product_id",
                table: "pos_product_code",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_sklad_department_id",
                table: "pos_sklad",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_sub_department_department_id",
                table: "pos_sub_department",
                column: "department_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pos_authorization");

            migrationBuilder.DropTable(
                name: "pos_card_detail");

            migrationBuilder.DropTable(
                name: "pos_client");

            migrationBuilder.DropTable(
                name: "pos_invoice_item");

            migrationBuilder.DropTable(
                name: "pos_message");

            migrationBuilder.DropTable(
                name: "pos_order");

            migrationBuilder.DropTable(
                name: "pos_order_item");

            migrationBuilder.DropTable(
                name: "pos_payments");

            migrationBuilder.DropTable(
                name: "pos_product_code");

            migrationBuilder.DropTable(
                name: "pos_product_unitmeasurment");

            migrationBuilder.DropTable(
                name: "pos_sub_department");

            migrationBuilder.DropTable(
                name: "pos_user");

            migrationBuilder.DropTable(
                name: "pos_client_card_type");

            migrationBuilder.DropTable(
                name: "pos_invoice");

            migrationBuilder.DropTable(
                name: "pos_message_group");

            migrationBuilder.DropTable(
                name: "pos_check");

            migrationBuilder.DropTable(
                name: "pos_product");

            migrationBuilder.DropTable(
                name: "pos_sklad");

            migrationBuilder.DropTable(
                name: "pos_brend");

            migrationBuilder.DropTable(
                name: "pos_category");

            migrationBuilder.DropTable(
                name: "pos_product_tag");

            migrationBuilder.DropTable(
                name: "pos_product_type");

            migrationBuilder.DropTable(
                name: "pos_department");

            migrationBuilder.DropTable(
                name: "pos_company");
        }
    }
}
