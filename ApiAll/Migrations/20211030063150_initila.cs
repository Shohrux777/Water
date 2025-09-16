using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initila : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "access_levels",
                columns: table => new
                {
                    acc_name = table.Column<string>(type: "text", nullable: false),
                    name_devices = table.Column<string>(type: "text", nullable: true),
                    time_zones = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true),
                    line = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    client = table.Column<bool>(type: "boolean", nullable: false),
                    supplier = table.Column<bool>(type: "boolean", nullable: false),
                    maincompany = table.Column<bool>(type: "boolean", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customContragentReports",
                columns: table => new
                {
                    phone = table.Column<string>(type: "text", nullable: true),
                    fio = table.Column<string>(type: "text", nullable: true),
                    datereg = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    mrt = table.Column<long>(type: "bigint", nullable: false),
                    mskt = table.Column<long>(type: "bigint", nullable: false),
                    sum = table.Column<double>(type: "double precision", nullable: false),
                    regionName = table.Column<string>(type: "text", nullable: true),
                    contragentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "datchiks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    serialNumber = table.Column<string>(type: "text", nullable: true),
                    model = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    min = table.Column<double>(type: "double precision", nullable: false),
                    max = table.Column<double>(type: "double precision", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datchiks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    mac_address = table.Column<string>(type: "text", nullable: true),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    ip_address = table.Column<string>(type: "text", nullable: false),
                    sn = table.Column<string>(type: "text", nullable: true),
                    tip = table.Column<string>(type: "text", nullable: true),
                    bor = table.Column<string>(type: "text", nullable: true),
                    main_door = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ErpBatchNumberSequnce",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Number = table.Column<long>(type: "bigint", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpBatchNumberSequnce", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpBatchprocess",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpBatchprocess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpCalcType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpCalcType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpCharacteristics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameForPrint = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpCharacteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpColorDepth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    maxcolorpercent = table.Column<double>(type: "double precision", nullable: false),
                    mincolorpercent = table.Column<double>(type: "double precision", nullable: false),
                    dyingType = table.Column<int>(type: "integer", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpColorDepth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpColorGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    GeneratedValue = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpColorGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpColorGustota",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpColorGustota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpColorVariantType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    GCode = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpColorVariantType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpCurrency",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Nominal = table.Column<string>(type: "text", nullable: true),
                    Forbuy = table.Column<string>(type: "text", nullable: true),
                    Forsale = table.Column<string>(type: "text", nullable: true),
                    CurrentDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Difference = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpCurrency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpDesignVariant",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpDesignVariant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpExtraWork",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpExtraWork", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpInvoiceStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpInvoiceStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpInvoiceType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpInvoiceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpLanguage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpPaymentType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpPaymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpPlanningType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpPlanningType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpProccess",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpProccess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpProccessDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpProccessDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpProccessStage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpProccessStage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpProductType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpPruductionType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpPruductionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpServiceType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpServiceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpSort",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpSort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpSuroviyVid",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpSuroviyVid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpUnitmeasurment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpUnitmeasurment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpUpakopka",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpUpakopka", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FIleChecker",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    imageUrl = table.Column<string>(type: "text", nullable: true),
                    src = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIleChecker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalDailyKassirReport",
                columns: table => new
                {
                    naqt = table.Column<double>(type: "double precision", nullable: true),
                    plastik = table.Column<double>(type: "double precision", nullable: true),
                    rasxod = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "HospitalFullInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    hospitalContacInfoStr = table.Column<string>(type: "text", nullable: true),
                    hospitalServiceInfo = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalFullInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalServiceTypeGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalServiceTypeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalServiceTypeGroupContragentReports",
                columns: table => new
                {
                    groupnomi = table.Column<string>(type: "text", nullable: true),
                    tumannomi = table.Column<string>(type: "text", nullable: true),
                    soni = table.Column<long>(type: "bigint", nullable: true),
                    plastik = table.Column<double>(type: "double precision", nullable: true),
                    naqt = table.Column<double>(type: "double precision", nullable: true),
                    vrachnomi = table.Column<string>(type: "text", nullable: true),
                    vrachxizmati = table.Column<double>(type: "double precision", nullable: true),
                    vaqti = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "HospitalTelegramBotManager",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    messageStr = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalTelegramBotManager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ilnesses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ilnesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketAgent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fullName = table.Column<string>(type: "text", nullable: true),
                    phoneNumber = table.Column<string>(type: "text", nullable: true),
                    companyName = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    specialCode = table.Column<string>(type: "text", nullable: true),
                    bornDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketAgent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketLimitCustomItem",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: true),
                    auth_id = table.Column<long>(type: "bigint", nullable: true),
                    auth_name = table.Column<string>(type: "text", nullable: true),
                    begin_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    product_name = table.Column<string>(type: "text", nullable: true),
                    limit_qty = table.Column<double>(type: "double precision", nullable: true),
                    real_qty = table.Column<double>(type: "double precision", nullable: true),
                    realSumm = table.Column<double>(type: "double precision", nullable: true),
                    reservedSumm = table.Column<double>(type: "double precision", nullable: true),
                    limitFinished = table.Column<bool>(type: "boolean", nullable: true),
                    byProduct = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MarketOrderFullOrderedProducts",
                columns: table => new
                {
                    soni = table.Column<double>(type: "double precision", nullable: true),
                    summa = table.Column<double>(type: "double precision", nullable: true),
                    nomi = table.Column<string>(type: "text", nullable: true),
                    codi = table.Column<string>(type: "text", nullable: true),
                    olchovi = table.Column<string>(type: "text", nullable: true),
                    kompanya_nomi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MarketProductGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PictureStr = table.Column<string>(type: "text", nullable: true),
                    MarketProductGroupId = table.Column<long>(type: "bigint", nullable: true),
                    marketProductGroupId = table.Column<long>(type: "bigint", nullable: true),
                    MainProductGroup = table.Column<bool>(type: "boolean", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketProductGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketProductGroup_MarketProductGroup_marketProductGroupId",
                        column: x => x.marketProductGroupId,
                        principalTable: "MarketProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarketProfitCustomReport",
                columns: table => new
                {
                    saled_price = table.Column<double>(type: "double precision", nullable: true),
                    buyed_price = table.Column<double>(type: "double precision", nullable: true),
                    profit_price = table.Column<double>(type: "double precision", nullable: true),
                    company_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MarketUnitMeasurment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketUnitMeasurment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "menuItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    LinkStr = table.Column<string>(type: "text", nullable: true),
                    IconStr = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    LinkStr = table.Column<string>(type: "text", nullable: true),
                    IconStr = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "patientServiceTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "patientTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "provinces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roomColectionInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    number = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    count = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomColectionInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkudDoorCheckinout",
                columns: table => new
                {
                    code = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    sana = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    checktime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    checktype = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    door_name = table.Column<string>(type: "text", nullable: true),
                    begona = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkudDoorCheckinout", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "SkudDoors",
                columns: table => new
                {
                    dbname = table.Column<string>(type: "text", nullable: true),
                    device = table.Column<string>(type: "text", nullable: true),
                    drivertime = table.Column<string>(type: "text", nullable: true),
                    detectortime = table.Column<int>(type: "integer", nullable: true),
                    intertime = table.Column<int>(type: "integer", nullable: true),
                    sensortype = table.Column<string>(type: "text", nullable: true),
                    nomer = table.Column<int>(type: "integer", nullable: true),
                    acc_name = table.Column<string>(type: "text", nullable: true),
                    door_opentzid = table.Column<int>(type: "integer", nullable: false),
                    inout = table.Column<string>(type: "text", nullable: true),
                    login = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SkudFaces",
                columns: table => new
                {
                    ip = table.Column<string>(type: "text", nullable: true),
                    nomi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SkudForTrenajor",
                columns: table => new
                {
                    userid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    active_days = table.Column<int>(type: "integer", nullable: false),
                    b_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    e_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkudForTrenajor", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "SkudGrForEmp",
                columns: table => new
                {
                    id_emp = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    gr_nomi = table.Column<string>(type: "text", nullable: true),
                    _begin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    _end = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkudGrForEmp", x => x.id_emp);
                });

            migrationBuilder.CreateTable(
                name: "SkudGroupAccess",
                columns: table => new
                {
                    group_name = table.Column<string>(type: "text", nullable: false),
                    door = table.Column<string>(type: "text", nullable: true),
                    acc_level = table.Column<string>(type: "text", nullable: true),
                    _index = table.Column<int>(type: "integer", nullable: false),
                    doorno = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkudGroupAccess", x => x.group_name);
                });

            migrationBuilder.CreateTable(
                name: "SkudImages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    rasm = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkudImages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SkudLk",
                columns: table => new
                {
                    lkey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SkudMyCheckinout",
                columns: table => new
                {
                    code = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    sana = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    checktime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    checktype = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    door_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkudMyCheckinout", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "SkudMyDepartments",
                columns: table => new
                {
                    deptid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    deptname = table.Column<string>(type: "text", nullable: true),
                    supdeptid = table.Column<long>(type: "bigint", nullable: true),
                    code = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkudMyDepartments", x => x.deptid);
                });

            migrationBuilder.CreateTable(
                name: "SkudPeriod",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    b_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    e_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkudPeriod", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SkudPictureCheckinout",
                columns: table => new
                {
                    userid = table.Column<long>(type: "bigint", nullable: true),
                    sana = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    checktime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    rasm = table.Column<byte>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SkudResultGr",
                columns: table => new
                {
                    ish_b = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ish_t = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    obed_b = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    obed_t = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    kech_keldi = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    vox_ketdi = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    g_nomi = table.Column<string>(type: "text", nullable: true),
                    kun_nomi = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SkudSababli",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    sababi = table.Column<string>(type: "text", nullable: true),
                    _begin = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    _end = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    b_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    e_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkudSababli", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SkudSmena",
                columns: table => new
                {
                    smena_nomi = table.Column<string>(type: "text", nullable: true),
                    boshlanishi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    tugashi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    obed_b = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    obed_t = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    kech_keldi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    vox_ketdi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SkudTablename",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    _data = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkudTablename", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_column_config_raw",
                columns: table => new
                {
                    column_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tex_contragent",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    type_client = table.Column<bool>(type: "boolean", nullable: false),
                    type_postavshik = table.Column<bool>(type: "boolean", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    type_maincompany = table.Column<bool>(type: "boolean", nullable: false),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_contragent", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_real_product_remain",
                columns: table => new
                {
                    invoice_item_id = table.Column<long>(type: "bigint", nullable: true),
                    product_name = table.Column<string>(type: "text", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    ostatka = table.Column<double>(type: "double precision", nullable: true),
                    color_name = table.Column<string>(type: "text", nullable: true),
                    color_id = table.Column<long>(type: "bigint", nullable: true),
                    unitmeasurment_name = table.Column<string>(type: "text", nullable: true),
                    unitmeasurment_id = table.Column<long>(type: "bigint", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: true),
                    suroviy_vid_name = table.Column<string>(type: "text", nullable: true),
                    suroviy_vid_id = table.Column<long>(type: "bigint", nullable: true),
                    real_product_name = table.Column<string>(type: "text", nullable: true),
                    date_str = table.Column<string>(type: "text", nullable: true),
                    guscolor_name = table.Column<string>(type: "text", nullable: true),
                    guscolor_id = table.Column<long>(type: "bigint", nullable: true),
                    extra_work_name = table.Column<string>(type: "text", nullable: true),
                    extra_work_id = table.Column<long>(type: "bigint", nullable: true),
                    main_proccess_name = table.Column<string>(type: "text", nullable: true),
                    main_proccess_id = table.Column<long>(type: "bigint", nullable: true),
                    upakovka_name = table.Column<string>(type: "text", nullable: true),
                    upakovka_id = table.Column<long>(type: "bigint", nullable: true),
                    sort_name = table.Column<string>(type: "text", nullable: true),
                    sort_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "VozvratAlreadyPaidPaymentList",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    patientName = table.Column<string>(type: "text", nullable: true),
                    SerivceTypeName = table.Column<string>(type: "text", nullable: true),
                    ServiceGroupName = table.Column<string>(type: "text", nullable: true),
                    dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    paymentCreatorId = table.Column<long>(type: "bigint", nullable: true),
                    paymentDeletorId = table.Column<long>(type: "bigint", nullable: true),
                    summa = table.Column<long>(type: "bigint", nullable: false),
                    contragentName = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VozvratAlreadyPaidPaymentList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departments_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpCharacteristicsDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameForPrint = table.Column<string>(type: "text", nullable: true),
                    ErpCharacteristicsId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpCharacteristicsDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpCharacteristicsDetail_ErpCharacteristics_ErpCharacterist~",
                        column: x => x.ErpCharacteristicsId,
                        principalTable: "ErpCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpColor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    ErpColorGroupId = table.Column<long>(type: "bigint", nullable: false),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    PantoneCode = table.Column<string>(type: "text", nullable: true),
                    DieingCode = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpColor_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpColor_ErpColorGroup_ErpColorGroupId",
                        column: x => x.ErpColorGroupId,
                        principalTable: "ErpColorGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpProccessAndProccessStage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ErpProccessId = table.Column<long>(type: "bigint", nullable: false),
                    ErpProccessStageId = table.Column<long>(type: "bigint", nullable: false),
                    sort = table.Column<int>(type: "integer", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpProccessAndProccessStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpProccessAndProccessStage_ErpProccess_ErpProccessId",
                        column: x => x.ErpProccessId,
                        principalTable: "ErpProccess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpProccessAndProccessStage_ErpProccessStage_ErpProccessSta~",
                        column: x => x.ErpProccessStageId,
                        principalTable: "ErpProccessStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ErpProductTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpCategory_ErpProductType_ErpProductTypeId",
                        column: x => x.ErpProductTypeId,
                        principalTable: "ErpProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalServiceTypeByGroupPermission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    HospitalServiceTypeGroupId = table.Column<long>(type: "bigint", nullable: false),
                    withoutReturnStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalServiceTypeByGroupPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalServiceTypeByGroupPermission_HospitalServiceTypeGro~",
                        column: x => x.HospitalServiceTypeGroupId,
                        principalTable: "HospitalServiceTypeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "serviceTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    calculateWithPersentage = table.Column<bool>(type: "boolean", nullable: false),
                    persantage = table.Column<double>(type: "double precision", nullable: false),
                    HospitalServiceTypeGroupId = table.Column<long>(type: "bigint", nullable: false),
                    contragentPrice = table.Column<double>(type: "double precision", nullable: false),
                    paymentable = table.Column<bool>(type: "boolean", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_serviceTypes_HospitalServiceTypeGroup_HospitalServiceTypeGr~",
                        column: x => x.HospitalServiceTypeGroupId,
                        principalTable: "HospitalServiceTypeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameForPrint = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Specs = table.Column<string>(type: "text", nullable: true),
                    ManifacturerName = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    MarketUnitMeasurmentId = table.Column<long>(type: "bigint", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketProduct_MarketUnitMeasurment_MarketUnitMeasurmentId",
                        column: x => x.MarketUnitMeasurmentId,
                        principalTable: "MarketUnitMeasurment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_districts_provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpEquipment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpEquipment_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpEquipment_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ErpPackaging",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    cardnumber = table.Column<string>(type: "text", nullable: true),
                    length = table.Column<double>(type: "double precision", nullable: false),
                    max_length = table.Column<double>(type: "double precision", nullable: false),
                    min_length = table.Column<double>(type: "double precision", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpPackaging", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpPackaging_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpWarehouse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpWarehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpWarehouse_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    BedsCount = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rooms_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpCategoryDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ErpCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    ErpCharacteristicsId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpCategoryDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpCategoryDetail_ErpCategory_ErpCategoryId",
                        column: x => x.ErpCategoryId,
                        principalTable: "ErpCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpCategoryDetail_ErpCharacteristics_ErpCharacteristicsId",
                        column: x => x.ErpCharacteristicsId,
                        principalTable: "ErpCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ErpCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    ErpPruductionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ErpUnitmeasurmentId = table.Column<long>(type: "bigint", nullable: false),
                    ErpUnitmeasurment2Id = table.Column<long>(type: "bigint", nullable: false),
                    PictureStr = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpProduct_ErpCategory_ErpCategoryId",
                        column: x => x.ErpCategoryId,
                        principalTable: "ErpCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpProduct_ErpPruductionType_ErpPruductionTypeId",
                        column: x => x.ErpPruductionTypeId,
                        principalTable: "ErpPruductionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpProduct_ErpUnitmeasurment_ErpUnitmeasurment2Id",
                        column: x => x.ErpUnitmeasurment2Id,
                        principalTable: "ErpUnitmeasurment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpProduct_ErpUnitmeasurment_ErpUnitmeasurmentId",
                        column: x => x.ErpUnitmeasurmentId,
                        principalTable: "ErpUnitmeasurment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitelRequiredServiceTypesAllPatcientsAndNotPatcients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitelRequiredServiceTypesAllPatcientsAndNotPatcients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitelRequiredServiceTypesAllPatcientsAndNotPatcients_ser~",
                        column: x => x.ServiceTypeId,
                        principalTable: "serviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalServiceRecipe",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    MarketProductId = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalServiceRecipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalServiceRecipe_MarketProduct_MarketProductId",
                        column: x => x.MarketProductId,
                        principalTable: "MarketProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalServiceRecipe_serviceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "serviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketProductGroupDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MarketProductId = table.Column<long>(type: "bigint", nullable: false),
                    MarketProductGroupId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketProductGroupDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketProductGroupDetail_MarketProduct_MarketProductId",
                        column: x => x.MarketProductId,
                        principalTable: "MarketProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketProductGroupDetail_MarketProductGroup_MarketProductGr~",
                        column: x => x.MarketProductGroupId,
                        principalTable: "MarketProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketProductRealQty",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    realQty = table.Column<double>(type: "double precision", nullable: false),
                    MarketProductId = table.Column<long>(type: "bigint", nullable: false),
                    minValue = table.Column<double>(type: "double precision", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketProductRealQty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketProductRealQty_MarketProduct_MarketProductId",
                        column: x => x.MarketProductId,
                        principalTable: "MarketProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contragents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    client = table.Column<bool>(type: "boolean", nullable: false),
                    supplier = table.Column<bool>(type: "boolean", nullable: false),
                    maincompany = table.Column<bool>(type: "boolean", nullable: false),
                    DistrictsId = table.Column<long>(type: "bigint", nullable: true),
                    chatBotId = table.Column<long>(type: "bigint", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contragents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contragents_districts_DistrictsId",
                        column: x => x.DistrictsId,
                        principalTable: "districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FIO = table.Column<string>(type: "text", nullable: true),
                    PassportSerialNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    BornDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RegistratedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PolType = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    WorkAddress = table.Column<string>(type: "text", nullable: true),
                    UnregistratedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReasonUnregistrated = table.Column<string>(type: "text", nullable: true),
                    TreatmentPlaces = table.Column<string>(type: "text", nullable: true),
                    TreatmentPlacesCurrentPlaces = table.Column<string>(type: "text", nullable: true),
                    TreatmentPlacesOtherPlaces = table.Column<string>(type: "text", nullable: true),
                    DistrictsId = table.Column<long>(type: "bigint", nullable: false),
                    chatBotId = table.Column<long>(type: "bigint", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_districts_DistrictsId",
                        column: x => x.DistrictsId,
                        principalTable: "districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpBatchRecipeUnion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: true),
                    ratio = table.Column<double>(type: "double precision", nullable: false),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ErpEquipmentId = table.Column<long>(type: "bigint", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpBatchRecipeUnion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpBatchRecipeUnion_ErpEquipment_ErpEquipmentId",
                        column: x => x.ErpEquipmentId,
                        principalTable: "ErpEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "datchikItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RoomsId = table.Column<long>(type: "bigint", nullable: false),
                    ColorId = table.Column<long>(type: "bigint", nullable: false),
                    DatchikId = table.Column<long>(type: "bigint", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datchikItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_datchikItems_colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_datchikItems_datchiks_DatchikId",
                        column: x => x.DatchikId,
                        principalTable: "datchiks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_datchikItems_rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "datchikRealValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SerialNumber = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    CurrentDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RoomsId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datchikRealValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_datchikRealValues_rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FIO = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<long>(type: "bigint", nullable: true),
                    roomsId = table.Column<long>(type: "bigint", nullable: true),
                    DepartmenId = table.Column<long>(type: "bigint", nullable: false),
                    departmentId = table.Column<long>(type: "bigint", nullable: true),
                    PositionId = table.Column<long>(type: "bigint", nullable: true),
                    PolType = table.Column<int>(type: "integer", nullable: false),
                    userRegistratedBotId = table.Column<long>(type: "bigint", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_rooms_roomsId",
                        column: x => x.roomsId,
                        principalTable: "rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ErpCharacteristicsProductDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ErpProductId = table.Column<long>(type: "bigint", nullable: false),
                    ErpCharacteristicsDetailId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpCharacteristicsProductDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpCharacteristicsProductDetail_ErpCharacteristicsDetail_Er~",
                        column: x => x.ErpCharacteristicsDetailId,
                        principalTable: "ErpCharacteristicsDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpCharacteristicsProductDetail_ErpProduct_ErpProductId",
                        column: x => x.ErpProductId,
                        principalTable: "ErpProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpColorVariant",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    ColorId = table.Column<long>(type: "bigint", nullable: true),
                    ColorGustotaId = table.Column<long>(type: "bigint", nullable: true),
                    ErpColorVariantTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ErpProductId = table.Column<long>(type: "bigint", nullable: true),
                    parentColorVariantId = table.Column<long>(type: "bigint", nullable: true),
                    rpt_sequence = table.Column<int>(type: "integer", nullable: false),
                    ErpProccessId = table.Column<long>(type: "bigint", nullable: true),
                    dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    color_no = table.Column<int>(type: "integer", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpColorVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpColorVariant_ErpColor_ColorId",
                        column: x => x.ColorId,
                        principalTable: "ErpColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpColorVariant_ErpColorGustota_ColorGustotaId",
                        column: x => x.ColorGustotaId,
                        principalTable: "ErpColorGustota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpColorVariant_ErpColorVariant_parentColorVariantId",
                        column: x => x.parentColorVariantId,
                        principalTable: "ErpColorVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpColorVariant_ErpColorVariantType_ErpColorVariantTypeId",
                        column: x => x.ErpColorVariantTypeId,
                        principalTable: "ErpColorVariantType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpColorVariant_ErpProccess_ErpProccessId",
                        column: x => x.ErpProccessId,
                        principalTable: "ErpProccess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpColorVariant_ErpProduct_ErpProductId",
                        column: x => x.ErpProductId,
                        principalTable: "ErpProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ErpPlanningTypeProductDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ErpProductId = table.Column<long>(type: "bigint", nullable: false),
                    ErpPlanningTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpPlanningTypeProductDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpPlanningTypeProductDetail_ErpPlanningType_ErpPlanningTyp~",
                        column: x => x.ErpPlanningTypeId,
                        principalTable: "ErpPlanningType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpPlanningTypeProductDetail_ErpProduct_ErpProductId",
                        column: x => x.ErpProductId,
                        principalTable: "ErpProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContragentAdditionalPaymentBefohandFullInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ContragentId = table.Column<long>(type: "bigint", nullable: false),
                    qtySumm = table.Column<double>(type: "double precision", nullable: false),
                    realQty = table.Column<double>(type: "double precision", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContragentAdditionalPaymentBefohandFullInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContragentAdditionalPaymentBefohandFullInfo_contragents_Con~",
                        column: x => x.ContragentId,
                        principalTable: "contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContragentServiceTypeBonusAdditanaly",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ContragentId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    bonusSumm = table.Column<double>(type: "double precision", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContragentServiceTypeBonusAdditanaly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContragentServiceTypeBonusAdditanaly_contragents_Contragent~",
                        column: x => x.ContragentId,
                        principalTable: "contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContragentServiceTypeBonusAdditanaly_serviceTypes_ServiceTy~",
                        column: x => x.ServiceTypeId,
                        principalTable: "serviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalContragentDebitPaymentReport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    createdDate = table.Column<DateTime>(type: "date", nullable: false),
                    contragentName = table.Column<string>(type: "text", nullable: true),
                    serviceTypeName = table.Column<string>(type: "text", nullable: true),
                    contragentPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    contragentAddress = table.Column<string>(type: "text", nullable: true),
                    regionName = table.Column<string>(type: "text", nullable: true),
                    serviceGroupName = table.Column<string>(type: "text", nullable: true),
                    paymentPayedStatus = table.Column<bool>(type: "boolean", nullable: false),
                    districtsId = table.Column<long>(type: "bigint", nullable: false),
                    contragentId = table.Column<long>(type: "bigint", nullable: true),
                    summa = table.Column<double>(type: "double precision", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalContragentDebitPaymentReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalContragentDebitPaymentReport_contragents_contragent~",
                        column: x => x.contragentId,
                        principalTable: "contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalContragentDebitPaymentReport_districts_districtsId",
                        column: x => x.districtsId,
                        principalTable: "districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalContragentNotifierReport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ContragentId = table.Column<long>(type: "bigint", nullable: false),
                    notActiveDays = table.Column<int>(type: "integer", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalContragentNotifierReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalContragentNotifierReport_contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalizAgglyutinatsionTest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CPRstr = table.Column<string>(type: "text", nullable: true),
                    ACOstr = table.Column<string>(type: "text", nullable: true),
                    PFstr = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalizAgglyutinatsionTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalizAgglyutinatsionTest_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analizBakterioskopiyas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    bakterios = table.Column<string>(type: "text", nullable: true),
                    leykosit = table.Column<string>(type: "text", nullable: true),
                    epitkletka = table.Column<string>(type: "text", nullable: true),
                    gonokokki = table.Column<string>(type: "text", nullable: true),
                    trixomonad = table.Column<string>(type: "text", nullable: true),
                    mikflora = table.Column<string>(type: "text", nullable: true),
                    ureplazma = table.Column<string>(type: "text", nullable: true),
                    xlamidoz = table.Column<string>(type: "text", nullable: true),
                    gardnerelez = table.Column<string>(type: "text", nullable: true),
                    gribok = table.Column<string>(type: "text", nullable: true),
                    vposeve = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analizBakterioskopiyas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_analizBakterioskopiyas_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalizCovid",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    lgMstr = table.Column<string>(type: "text", nullable: true),
                    lgGstr = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalizCovid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalizCovid_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalizCovidMazok",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AntigenTest = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalizCovidMazok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalizCovidMazok_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analizDemodices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    result = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analizDemodices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_analizDemodices_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analizKalas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    count = table.Column<string>(type: "text", nullable: true),
                    zichlik = table.Column<string>(type: "text", nullable: true),
                    shakli = table.Column<string>(type: "text", nullable: true),
                    rang = table.Column<string>(type: "text", nullable: true),
                    reaksiya = table.Column<string>(type: "text", nullable: true),
                    xid = table.Column<string>(type: "text", nullable: true),
                    ovqat_qoldiqlari = table.Column<string>(type: "text", nullable: true),
                    konsistensiya = table.Column<string>(type: "text", nullable: true),
                    sliz = table.Column<string>(type: "text", nullable: true),
                    qon = table.Column<string>(type: "text", nullable: true),
                    yiring = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analizKalas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_analizKalas_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analizLeyshmaniys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    result = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analizLeyshmaniys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_analizLeyshmaniys_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analizLks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    result = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analizLks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_analizLks_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analizMachis",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    miqdori = table.Column<string>(type: "text", nullable: true),
                    rangi = table.Column<string>(type: "text", nullable: true),
                    tiniqligi = table.Column<string>(type: "text", nullable: true),
                    nis_zichligi = table.Column<string>(type: "text", nullable: true),
                    reaksiyasi = table.Column<string>(type: "text", nullable: true),
                    oqsil = table.Column<string>(type: "text", nullable: true),
                    glyukoza = table.Column<string>(type: "text", nullable: true),
                    keton = table.Column<string>(type: "text", nullable: true),
                    qon_ba = table.Column<string>(type: "text", nullable: true),
                    bilurbin = table.Column<string>(type: "text", nullable: true),
                    urobil = table.Column<string>(type: "text", nullable: true),
                    ut_kislot = table.Column<string>(type: "text", nullable: true),
                    indikan = table.Column<string>(type: "text", nullable: true),
                    yassi = table.Column<string>(type: "text", nullable: true),
                    utuvchi = table.Column<string>(type: "text", nullable: true),
                    buyrak = table.Column<string>(type: "text", nullable: true),
                    leykosit = table.Column<string>(type: "text", nullable: true),
                    ozgarmagan = table.Column<string>(type: "text", nullable: true),
                    ozgargan = table.Column<string>(type: "text", nullable: true),
                    gialin = table.Column<string>(type: "text", nullable: true),
                    donador = table.Column<string>(type: "text", nullable: true),
                    mumsimon = table.Column<string>(type: "text", nullable: true),
                    epiteliol = table.Column<string>(type: "text", nullable: true),
                    leykosit_sl = table.Column<string>(type: "text", nullable: true),
                    eritrosit_sl = table.Column<string>(type: "text", nullable: true),
                    pigmentli = table.Column<string>(type: "text", nullable: true),
                    shilliq = table.Column<string>(type: "text", nullable: true),
                    tuzlar = table.Column<string>(type: "text", nullable: true),
                    bakteriya = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analizMachis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_analizMachis_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analizMikroskopiyas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    mish_volokna = table.Column<string>(type: "text", nullable: true),
                    soed_tkan = table.Column<string>(type: "text", nullable: true),
                    jir_kislota = table.Column<string>(type: "text", nullable: true),
                    mila = table.Column<string>(type: "text", nullable: true),
                    kletachka = table.Column<string>(type: "text", nullable: true),
                    kraxmal = table.Column<string>(type: "text", nullable: true),
                    epiteliy = table.Column<string>(type: "text", nullable: true),
                    leykosit = table.Column<string>(type: "text", nullable: true),
                    eritrosit = table.Column<string>(type: "text", nullable: true),
                    deytrit = table.Column<string>(type: "text", nullable: true),
                    prosteyshiy = table.Column<string>(type: "text", nullable: true),
                    yaglist = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analizMikroskopiyas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_analizMikroskopiyas_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analizMuhimbelgilars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    result = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analizMuhimbelgilars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_analizMuhimbelgilars_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalizQondagiGarmonlar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TTGstr = table.Column<string>(type: "text", nullable: true),
                    T3str = table.Column<string>(type: "text", nullable: true),
                    T4str = table.Column<string>(type: "text", nullable: true),
                    TestestronStr = table.Column<string>(type: "text", nullable: true),
                    ProlaktinStr = table.Column<string>(type: "text", nullable: true),
                    LGstr = table.Column<string>(type: "text", nullable: true),
                    FSGstr = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalizQondagiGarmonlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalizQondagiGarmonlar_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analizQontahlilis",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    gemoglobin = table.Column<string>(type: "text", nullable: true),
                    eritrosit = table.Column<string>(type: "text", nullable: true),
                    rangli_korsatkich = table.Column<string>(type: "text", nullable: true),
                    gem_miqdori = table.Column<string>(type: "text", nullable: true),
                    retikulositlar = table.Column<string>(type: "text", nullable: true),
                    trombosit = table.Column<string>(type: "text", nullable: true),
                    leykosit = table.Column<string>(type: "text", nullable: true),
                    mielosit = table.Column<string>(type: "text", nullable: true),
                    metamielosit = table.Column<string>(type: "text", nullable: true),
                    tayoqcha_yadrolilar = table.Column<string>(type: "text", nullable: true),
                    sigmentyadrolilar = table.Column<string>(type: "text", nullable: true),
                    eozinofil = table.Column<string>(type: "text", nullable: true),
                    bazofil = table.Column<string>(type: "text", nullable: true),
                    limfosit = table.Column<string>(type: "text", nullable: true),
                    monosit = table.Column<string>(type: "text", nullable: true),
                    plazmatik_xujayra = table.Column<string>(type: "text", nullable: true),
                    eritrosit_chokish_tezligi = table.Column<string>(type: "text", nullable: true),
                    anizotsitoz = table.Column<string>(type: "text", nullable: true),
                    poykilositoz = table.Column<string>(type: "text", nullable: true),
                    bazofil_donador = table.Column<string>(type: "text", nullable: true),
                    polixromafiliya = table.Column<string>(type: "text", nullable: true),
                    kebot_xalqa = table.Column<string>(type: "text", nullable: true),
                    eritro_normoblast = table.Column<string>(type: "text", nullable: true),
                    megaloblast = table.Column<string>(type: "text", nullable: true),
                    yadro_gipersigmentatsiyasi = table.Column<string>(type: "text", nullable: true),
                    taksogen_donadorlik = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analizQontahlilis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_analizQontahlilis_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analizRws",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Result = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analizRws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_analizRws_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analizSarcoptes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Result = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analizSarcoptes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_analizSarcoptes_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analizZamburugs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Result = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analizZamburugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_analizZamburugs_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContragentAdditionalPaymentBefohandDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ContragentId = table.Column<long>(type: "bigint", nullable: false),
                    summa = table.Column<double>(type: "double precision", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    limitSummLeft = table.Column<double>(type: "double precision", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContragentAdditionalPaymentBefohandDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContragentAdditionalPaymentBefohandDetail_contragents_Contr~",
                        column: x => x.ContragentId,
                        principalTable: "contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContragentAdditionalPaymentBefohandDetail_Patients_Patients~",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContragentAdditionalPaymentBefohandDetail_serviceTypes_Serv~",
                        column: x => x.ServiceTypeId,
                        principalTable: "serviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalMrtSorovNoma",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    patientFio = table.Column<string>(type: "text", nullable: true),
                    dateOfBirthday = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    phoneNumber = table.Column<string>(type: "text", nullable: true),
                    contragentName = table.Column<string>(type: "text", nullable: true),
                    contragentPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    kardioSimulator = table.Column<bool>(type: "boolean", nullable: false),
                    eshitishAparatiImplanti = table.Column<bool>(type: "boolean", nullable: false),
                    kozdagiYotMetal = table.Column<bool>(type: "boolean", nullable: false),
                    neyrosimulator = table.Column<bool>(type: "boolean", nullable: false),
                    insulinliPompa = table.Column<bool>(type: "boolean", nullable: false),
                    qontomirStentlari = table.Column<bool>(type: "boolean", nullable: false),
                    protezlar = table.Column<bool>(type: "boolean", nullable: false),
                    xomiladorlikUchOyligi = table.Column<bool>(type: "boolean", nullable: false),
                    umurtqaPogonasidaMetalFixsator = table.Column<bool>(type: "boolean", nullable: false),
                    breketlar = table.Column<bool>(type: "boolean", nullable: false),
                    tutqonoqOtkazganmisz = table.Column<bool>(type: "boolean", nullable: false),
                    nurTerapiya = table.Column<bool>(type: "boolean", nullable: false),
                    ximiyaTerapiya = table.Column<bool>(type: "boolean", nullable: false),
                    jarohatOlganmisz = table.Column<string>(type: "text", nullable: true),
                    shikoyatlaringz = table.Column<string>(type: "text", nullable: true),
                    tekshiriladigonAzolar = table.Column<string>(type: "text", nullable: true),
                    summa = table.Column<double>(type: "double precision", nullable: false),
                    ContragentId = table.Column<long>(type: "bigint", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalMrtSorovNoma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalMrtSorovNoma_contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalMrtSorovNoma_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patientRegistrationInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ReasonPatient = table.Column<string>(type: "text", nullable: true),
                    PatientServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    PatientTypeId = table.Column<long>(type: "bigint", nullable: false),
                    RegistrationDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientRegistrationInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_patientRegistrationInfos_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_patientRegistrationInfos_patientServiceTypes_PatientService~",
                        column: x => x.PatientServiceTypeId,
                        principalTable: "patientServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_patientRegistrationInfos_patientTypes_PatientTypeId",
                        column: x => x.PatientTypeId,
                        principalTable: "patientTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRooms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RegistretedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RoomsId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Summ = table.Column<long>(type: "bigint", nullable: false),
                    BeginBookRoomDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndBookRoomDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRooms_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentRooms_rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomBooking",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ReqistratedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BeginDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatetedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RoomsId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomBooking_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomBooking_rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "authorizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_authorizations_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_authorizations_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketPrePaidMoney",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    realSumm = table.Column<double>(type: "double precision", nullable: false),
                    reservedSumm = table.Column<double>(type: "double precision", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketPrePaidMoney", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketPrePaidMoney_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientRecipeByDoctor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    patinetRecipeStr = table.Column<string>(type: "text", nullable: true),
                    patientRecipeTitle = table.Column<string>(type: "text", nullable: true),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    registratedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRecipeByDoctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRecipeByDoctor_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientRecipeByDoctor_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypeDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypeDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTypeDetail_serviceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "serviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTypeDetail_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRoomsItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PaymentRoomsId = table.Column<long>(type: "bigint", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRoomsItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRoomsItem_PaymentRooms_PaymentRoomsId",
                        column: x => x.PaymentRoomsId,
                        principalTable: "PaymentRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRoomsServiceTypesItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PaymentRoomsId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceTypeName = table.Column<string>(type: "text", nullable: true),
                    PatientName = table.Column<string>(type: "text", nullable: true),
                    RealCountService = table.Column<long>(type: "bigint", nullable: false),
                    UsedCountService = table.Column<long>(type: "bigint", nullable: false),
                    Summ = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    regDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRoomsServiceTypesItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRoomsServiceTypesItem_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentRoomsServiceTypesItem_PaymentRooms_PaymentRoomsId",
                        column: x => x.PaymentRoomsId,
                        principalTable: "PaymentRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentRoomsServiceTypesItem_serviceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "serviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accessMenus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MenuId = table.Column<long>(type: "bigint", nullable: false),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accessMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accessMenus_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accessMenus_menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContragentAdditionalPaymentBefohand",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    noteStr = table.Column<string>(type: "text", nullable: true),
                    ContragentId = table.Column<long>(type: "bigint", nullable: false),
                    PayedUserInfo = table.Column<string>(type: "text", nullable: true),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    summa = table.Column<double>(type: "double precision", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContragentAdditionalPaymentBefohand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContragentAdditionalPaymentBefohand_authorizations_Authoriz~",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContragentAdditionalPaymentBefohand_contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpBatch",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    batchNumber = table.Column<string>(type: "text", nullable: true),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: true),
                    years = table.Column<int>(type: "integer", nullable: false),
                    ErpColorId = table.Column<long>(type: "bigint", nullable: true),
                    ErpColorVariantId = table.Column<long>(type: "bigint", nullable: true),
                    ErpEquipmentId = table.Column<long>(type: "bigint", nullable: false),
                    printedCount = table.Column<long>(type: "bigint", nullable: true),
                    printedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    printedUserId = table.Column<long>(type: "bigint", nullable: true),
                    createdUserId = table.Column<long>(type: "bigint", nullable: true),
                    editedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpBatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpBatch_authorizations_createdUserId",
                        column: x => x.createdUserId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatch_authorizations_editedUserId",
                        column: x => x.editedUserId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatch_authorizations_printedUserId",
                        column: x => x.printedUserId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatch_ErpColor_ErpColorId",
                        column: x => x.ErpColorId,
                        principalTable: "ErpColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatch_ErpColorVariant_ErpColorVariantId",
                        column: x => x.ErpColorVariantId,
                        principalTable: "ErpColorVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatch_ErpEquipment_ErpEquipmentId",
                        column: x => x.ErpEquipmentId,
                        principalTable: "ErpEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpColorVariantRecipe",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedAuthId = table.Column<long>(type: "bigint", nullable: false),
                    ErpProductId = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    ErpUnitmeasurmentId = table.Column<long>(type: "bigint", nullable: true),
                    ErpColorVariantId = table.Column<long>(type: "bigint", nullable: true),
                    colorvariant_recipestage_id = table.Column<int>(type: "integer", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpColorVariantRecipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpColorVariantRecipe_authorizations_CreatedAuthId",
                        column: x => x.CreatedAuthId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpColorVariantRecipe_ErpColorVariant_ErpColorVariantId",
                        column: x => x.ErpColorVariantId,
                        principalTable: "ErpColorVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpColorVariantRecipe_ErpProduct_ErpProductId",
                        column: x => x.ErpProductId,
                        principalTable: "ErpProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpColorVariantRecipe_ErpUnitmeasurment_ErpUnitmeasurmentId",
                        column: x => x.ErpUnitmeasurmentId,
                        principalTable: "ErpUnitmeasurment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ErpColumnConfig",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    tableName = table.Column<string>(type: "text", nullable: true),
                    columnListJson = table.Column<string>(type: "jsonb", nullable: true),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpColumnConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpColumnConfig_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpInvoice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InvcompanyId = table.Column<long>(type: "bigint", nullable: true),
                    ErpCurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    currencyValue = table.Column<double>(type: "double precision", nullable: false),
                    ErpWarehouseId = table.Column<long>(type: "bigint", nullable: true),
                    filialCompanyId = table.Column<long>(type: "bigint", nullable: true),
                    summ = table.Column<double>(type: "double precision", nullable: true),
                    count = table.Column<double>(type: "double precision", nullable: true),
                    realCount = table.Column<double>(type: "double precision", nullable: true),
                    ErpServiceTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ErpPaymentTypeId = table.Column<long>(type: "bigint", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    ErpCalcTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ErpInvoiceTypeId = table.Column<long>(type: "bigint", nullable: true),
                    mainWarehouseId = table.Column<long>(type: "bigint", nullable: true),
                    mainDepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    mainCompanyId = table.Column<long>(type: "bigint", nullable: true),
                    ErpInvoiceStatusId = table.Column<long>(type: "bigint", nullable: true),
                    acceptedUser = table.Column<bool>(type: "boolean", nullable: true),
                    invoiceTypeStr = table.Column<string>(type: "text", nullable: true),
                    invoiceStatusStr = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_authorizations_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_authorizations_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_companies_filialCompanyId",
                        column: x => x.filialCompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_companies_InvcompanyId",
                        column: x => x.InvcompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_companies_mainCompanyId",
                        column: x => x.mainCompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_departments_mainDepartmentId",
                        column: x => x.mainDepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_ErpCalcType_ErpCalcTypeId",
                        column: x => x.ErpCalcTypeId,
                        principalTable: "ErpCalcType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_ErpCurrency_ErpCurrencyId",
                        column: x => x.ErpCurrencyId,
                        principalTable: "ErpCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_ErpInvoiceStatus_ErpInvoiceStatusId",
                        column: x => x.ErpInvoiceStatusId,
                        principalTable: "ErpInvoiceStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_ErpInvoiceType_ErpInvoiceTypeId",
                        column: x => x.ErpInvoiceTypeId,
                        principalTable: "ErpInvoiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_ErpPaymentType_ErpPaymentTypeId",
                        column: x => x.ErpPaymentTypeId,
                        principalTable: "ErpPaymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_ErpServiceType_ErpServiceTypeId",
                        column: x => x.ErpServiceTypeId,
                        principalTable: "ErpServiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_ErpWarehouse_ErpWarehouseId",
                        column: x => x.ErpWarehouseId,
                        principalTable: "ErpWarehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoice_ErpWarehouse_mainWarehouseId",
                        column: x => x.mainWarehouseId,
                        principalTable: "ErpWarehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ErpOrder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    beginDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    clientCompanyId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    ErpCurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    currencyValue = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    orderNumber = table.Column<string>(type: "text", nullable: true),
                    createdAuthId = table.Column<long>(type: "bigint", nullable: false),
                    updateAuthId = table.Column<long>(type: "bigint", nullable: false),
                    mainCompanyId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpOrder_authorizations_createdAuthId",
                        column: x => x.createdAuthId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpOrder_authorizations_updateAuthId",
                        column: x => x.updateAuthId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpOrder_companies_clientCompanyId",
                        column: x => x.clientCompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpOrder_companies_mainCompanyId",
                        column: x => x.mainCompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpOrder_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpOrder_ErpCurrency_ErpCurrencyId",
                        column: x => x.ErpCurrencyId,
                        principalTable: "ErpCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalManagerReport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    HospitalServiceTypeGroupName = table.Column<string>(type: "text", nullable: true),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    cashSumm = table.Column<double>(type: "double precision", nullable: false),
                    cardSumm = table.Column<double>(type: "double precision", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "date", nullable: false),
                    count = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalManagerReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalManagerReport_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalRegistrationPermissionDoctors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    registraterAuthId = table.Column<long>(type: "bigint", nullable: false),
                    doctorAuthId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalRegistrationPermissionDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalRegistrationPermissionDoctors_authorizations_doctor~",
                        column: x => x.doctorAuthId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalRegistrationPermissionDoctors_authorizations_regist~",
                        column: x => x.registraterAuthId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketAuthLimitByMoney",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    beginDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    realSumm = table.Column<double>(type: "double precision", nullable: false),
                    reservedSumm = table.Column<double>(type: "double precision", nullable: false),
                    limitFinished = table.Column<bool>(type: "boolean", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketAuthLimitByMoney", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketAuthLimitByMoney_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketAuthLimitByProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    beginDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MarketProductId = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    realQty = table.Column<double>(type: "double precision", nullable: false),
                    limitFinished = table.Column<bool>(type: "boolean", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketAuthLimitByProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketAuthLimitByProduct_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketAuthLimitByProduct_MarketProduct_MarketProductId",
                        column: x => x.MarketProductId,
                        principalTable: "MarketProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketClientInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    userFullName = table.Column<string>(type: "text", nullable: true),
                    Statya = table.Column<string>(type: "text", nullable: true),
                    part = table.Column<string>(type: "text", nullable: true),
                    codeStr = table.Column<string>(type: "text", nullable: true),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketClientInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketClientInfo_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketInvoice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    MarketAgentId = table.Column<long>(type: "bigint", nullable: false),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    InvoceNumber = table.Column<string>(type: "text", nullable: true),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketInvoice_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketInvoice_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketInvoice_MarketAgent_MarketAgentId",
                        column: x => x.MarketAgentId,
                        principalTable: "MarketAgent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketOrder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    acceptedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    acceptedStatus = table.Column<bool>(type: "boolean", nullable: false),
                    rejectedStatus = table.Column<bool>(type: "boolean", nullable: false),
                    userFullName = table.Column<string>(type: "text", nullable: true),
                    orderNumber = table.Column<string>(type: "text", nullable: true),
                    Statya = table.Column<string>(type: "text", nullable: true),
                    part = table.Column<string>(type: "text", nullable: true),
                    codeStr = table.Column<string>(type: "text", nullable: true),
                    limitSumm = table.Column<double>(type: "double precision", nullable: false),
                    orderDeliveriedStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketOrder_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketProductPrice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MarketProductId = table.Column<long>(type: "bigint", nullable: false),
                    discountStatus = table.Column<bool>(type: "boolean", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    discountPrice = table.Column<double>(type: "double precision", nullable: false),
                    dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketProductPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketProductPrice_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketProductPrice_MarketProduct_MarketProductId",
                        column: x => x.MarketProductId,
                        principalTable: "MarketProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ServiceName = table.Column<string>(type: "text", nullable: true),
                    PatientName = table.Column<string>(type: "text", nullable: true),
                    ServiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Summ = table.Column<long>(type: "bigint", nullable: false),
                    ReserveSumm = table.Column<long>(type: "bigint", nullable: false),
                    PaymentInCash = table.Column<long>(type: "bigint", nullable: false),
                    PaymentInCard = table.Column<long>(type: "bigint", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    Finish = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    ContragentId = table.Column<long>(type: "bigint", nullable: false),
                    RegistratedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FinishPayment = table.Column<bool>(type: "boolean", nullable: false),
                    acceptanceDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PayedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    creatorAuthId = table.Column<long>(type: "bigint", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payments_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payments_contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payments_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payments_serviceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "serviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "returnMoney",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<long>(type: "bigint", nullable: false),
                    RegistratedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_returnMoney", x => x.Id);
                    table.ForeignKey(
                        name: "FK_returnMoney_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_returnMoney_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRoomsServiceTypesItemInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PaymentRoomsServiceTypesItemId = table.Column<long>(type: "bigint", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    RegistretedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRoomsServiceTypesItemInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRoomsServiceTypesItemInfo_PaymentRoomsServiceTypesIt~",
                        column: x => x.PaymentRoomsServiceTypesItemId,
                        principalTable: "PaymentRoomsServiceTypesItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accessMenuItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AccessMenuId = table.Column<long>(type: "bigint", nullable: false),
                    MenuItemId = table.Column<long>(type: "bigint", nullable: false),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accessMenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accessMenuItems_accessMenus_AccessMenuId",
                        column: x => x.AccessMenuId,
                        principalTable: "accessMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accessMenuItems_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accessMenuItems_menuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "menuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpBatchDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cardnumber = table.Column<string>(type: "text", nullable: true),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    gramm = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    packs = table.Column<double>(type: "double precision", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    qty4 = table.Column<double>(type: "double precision", nullable: false),
                    qty5 = table.Column<double>(type: "double precision", nullable: false),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    width = table.Column<double>(type: "double precision", nullable: false),
                    ErpBatchId = table.Column<long>(type: "bigint", nullable: false),
                    ErpBatchprocessId = table.Column<long>(type: "bigint", nullable: true),
                    ErpColorDepthId = table.Column<long>(type: "bigint", nullable: true),
                    unitmeasurmentId = table.Column<long>(type: "bigint", nullable: true),
                    unitmeasurment2Id = table.Column<long>(type: "bigint", nullable: true),
                    unitmeasurment3Id = table.Column<long>(type: "bigint", nullable: true),
                    ErpProductId = table.Column<long>(type: "bigint", nullable: false),
                    moved = table.Column<string>(type: "text", nullable: true),
                    ErpPackagingId = table.Column<long>(type: "bigint", nullable: true),
                    feine = table.Column<double>(type: "double precision", nullable: true),
                    pus = table.Column<double>(type: "double precision", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpBatchDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpBatchDetail_ErpBatch_ErpBatchId",
                        column: x => x.ErpBatchId,
                        principalTable: "ErpBatch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpBatchDetail_ErpBatchprocess_ErpBatchprocessId",
                        column: x => x.ErpBatchprocessId,
                        principalTable: "ErpBatchprocess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchDetail_ErpColorDepth_ErpColorDepthId",
                        column: x => x.ErpColorDepthId,
                        principalTable: "ErpColorDepth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchDetail_ErpPackaging_ErpPackagingId",
                        column: x => x.ErpPackagingId,
                        principalTable: "ErpPackaging",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchDetail_ErpProduct_ErpProductId",
                        column: x => x.ErpProductId,
                        principalTable: "ErpProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpBatchDetail_ErpUnitmeasurment_unitmeasurment2Id",
                        column: x => x.unitmeasurment2Id,
                        principalTable: "ErpUnitmeasurment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchDetail_ErpUnitmeasurment_unitmeasurment3Id",
                        column: x => x.unitmeasurment3Id,
                        principalTable: "ErpUnitmeasurment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchDetail_ErpUnitmeasurment_unitmeasurmentId",
                        column: x => x.unitmeasurmentId,
                        principalTable: "ErpUnitmeasurment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ErpBatchStage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    autoCreated = table.Column<bool>(type: "boolean", nullable: false),
                    batchstagegramm = table.Column<double>(type: "double precision", nullable: false),
                    batchstagesort = table.Column<long>(type: "bigint", nullable: false),
                    confirmStatus = table.Column<bool>(type: "boolean", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    iRepairStatus = table.Column<bool>(type: "boolean", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: true),
                    payStatus = table.Column<bool>(type: "boolean", nullable: false),
                    pressing = table.Column<double>(type: "double precision", nullable: false),
                    ratio = table.Column<double>(type: "double precision", nullable: false),
                    speed = table.Column<double>(type: "double precision", nullable: false),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    valume = table.Column<double>(type: "double precision", nullable: false),
                    ErpBatchId = table.Column<long>(type: "bigint", nullable: false),
                    ErpProccessStageId = table.Column<long>(type: "bigint", nullable: false),
                    ErpColorVariantId = table.Column<long>(type: "bigint", nullable: true),
                    ErpEquipmentId = table.Column<long>(type: "bigint", nullable: true),
                    ErpBatchRecipeUnionId = table.Column<long>(type: "bigint", nullable: true),
                    printedCount = table.Column<long>(type: "bigint", nullable: true),
                    printedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    printedAuthId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpBatchStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpBatchStage_authorizations_printedAuthId",
                        column: x => x.printedAuthId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpBatchStage_ErpBatch_ErpBatchId",
                        column: x => x.ErpBatchId,
                        principalTable: "ErpBatch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpBatchStage_ErpBatchRecipeUnion_ErpBatchRecipeUnionId",
                        column: x => x.ErpBatchRecipeUnionId,
                        principalTable: "ErpBatchRecipeUnion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchStage_ErpColorVariant_ErpColorVariantId",
                        column: x => x.ErpColorVariantId,
                        principalTable: "ErpColorVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchStage_ErpEquipment_ErpEquipmentId",
                        column: x => x.ErpEquipmentId,
                        principalTable: "ErpEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchStage_ErpProccessStage_ErpProccessStageId",
                        column: x => x.ErpProccessStageId,
                        principalTable: "ErpProccessStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpInvoiceItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ErpInvoiceId = table.Column<long>(type: "bigint", nullable: true),
                    ErpInvoiceItemId = table.Column<long>(type: "bigint", nullable: true),
                    erpInvoiceItemId = table.Column<long>(type: "bigint", nullable: true),
                    itemStatusStr = table.Column<string>(type: "text", nullable: true),
                    ErpInvoiceStatusId = table.Column<long>(type: "bigint", nullable: true),
                    ErpProductId = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    realCount = table.Column<double>(type: "double precision", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    priceSale = table.Column<double>(type: "double precision", nullable: false),
                    pus = table.Column<string>(type: "text", nullable: true),
                    fein = table.Column<string>(type: "text", nullable: true),
                    shirina = table.Column<string>(type: "text", nullable: true),
                    gramm = table.Column<string>(type: "text", nullable: true),
                    metraj = table.Column<string>(type: "text", nullable: true),
                    qty2 = table.Column<string>(type: "text", nullable: true),
                    ErpColorId = table.Column<long>(type: "bigint", nullable: true),
                    brack = table.Column<double>(type: "double precision", nullable: false),
                    ugar = table.Column<bool>(type: "boolean", nullable: false),
                    brutto = table.Column<double>(type: "double precision", nullable: false),
                    netto = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    ErpColorVariantId = table.Column<long>(type: "bigint", nullable: true),
                    ErpColorGustotaId = table.Column<long>(type: "bigint", nullable: true),
                    ErpSuroviyVidId = table.Column<long>(type: "bigint", nullable: true),
                    ErpProccessId = table.Column<long>(type: "bigint", nullable: true),
                    ErpExtraWorkId = table.Column<long>(type: "bigint", nullable: true),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    ErpSortId = table.Column<long>(type: "bigint", nullable: true),
                    ErpUpakopkaId = table.Column<long>(type: "bigint", nullable: true),
                    ErpOrderId = table.Column<long>(type: "bigint", nullable: true),
                    ErpInvoiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpInvoiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpColor_ErpColorId",
                        column: x => x.ErpColorId,
                        principalTable: "ErpColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpColorGustota_ErpColorGustotaId",
                        column: x => x.ErpColorGustotaId,
                        principalTable: "ErpColorGustota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpColorVariant_ErpColorVariantId",
                        column: x => x.ErpColorVariantId,
                        principalTable: "ErpColorVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpExtraWork_ErpExtraWorkId",
                        column: x => x.ErpExtraWorkId,
                        principalTable: "ErpExtraWork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpInvoice_ErpInvoiceId",
                        column: x => x.ErpInvoiceId,
                        principalTable: "ErpInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpInvoiceItem_erpInvoiceItemId",
                        column: x => x.erpInvoiceItemId,
                        principalTable: "ErpInvoiceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpInvoiceStatus_ErpInvoiceStatusId",
                        column: x => x.ErpInvoiceStatusId,
                        principalTable: "ErpInvoiceStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpInvoiceType_ErpInvoiceTypeId",
                        column: x => x.ErpInvoiceTypeId,
                        principalTable: "ErpInvoiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpOrder_ErpOrderId",
                        column: x => x.ErpOrderId,
                        principalTable: "ErpOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpProccess_ErpProccessId",
                        column: x => x.ErpProccessId,
                        principalTable: "ErpProccess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpProduct_ErpProductId",
                        column: x => x.ErpProductId,
                        principalTable: "ErpProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpSort_ErpSortId",
                        column: x => x.ErpSortId,
                        principalTable: "ErpSort",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpSuroviyVid_ErpSuroviyVidId",
                        column: x => x.ErpSuroviyVidId,
                        principalTable: "ErpSuroviyVid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpInvoiceItem_ErpUpakopka_ErpUpakopkaId",
                        column: x => x.ErpUpakopkaId,
                        principalTable: "ErpUpakopka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarketInvoiceItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MarketProductId = table.Column<long>(type: "bigint", nullable: false),
                    exiparedDateTimeBegin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    exiparedDateTimeEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    realQty = table.Column<double>(type: "double precision", nullable: false),
                    unitprice = table.Column<double>(type: "double precision", nullable: false),
                    MarketInvoiceId = table.Column<long>(type: "bigint", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketInvoiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketInvoiceItem_MarketInvoice_MarketInvoiceId",
                        column: x => x.MarketInvoiceId,
                        principalTable: "MarketInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketInvoiceItem_MarketProduct_MarketProductId",
                        column: x => x.MarketProductId,
                        principalTable: "MarketProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketNeedToPayToAgents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MarketInvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    realSumm = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MarketAgentId = table.Column<long>(type: "bigint", nullable: false),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketNeedToPayToAgents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketNeedToPayToAgents_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketNeedToPayToAgents_MarketAgent_MarketAgentId",
                        column: x => x.MarketAgentId,
                        principalTable: "MarketAgent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketNeedToPayToAgents_MarketInvoice_MarketInvoiceId",
                        column: x => x.MarketInvoiceId,
                        principalTable: "MarketInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketAuthLimitByMoneyDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    MarketAuthLimitByMoneyId = table.Column<long>(type: "bigint", nullable: false),
                    MarketOrderId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketAuthLimitByMoneyDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketAuthLimitByMoneyDetail_MarketAuthLimitByMoney_MarketA~",
                        column: x => x.MarketAuthLimitByMoneyId,
                        principalTable: "MarketAuthLimitByMoney",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketAuthLimitByMoneyDetail_MarketOrder_MarketOrderId",
                        column: x => x.MarketOrderId,
                        principalTable: "MarketOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketAuthLimitByProductDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    MarketAuthLimitByProductId = table.Column<long>(type: "bigint", nullable: false),
                    MarketOrderId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketAuthLimitByProductDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketAuthLimitByProductDetail_MarketAuthLimitByProduct_Mar~",
                        column: x => x.MarketAuthLimitByProductId,
                        principalTable: "MarketAuthLimitByProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketAuthLimitByProductDetail_MarketOrder_MarketOrderId",
                        column: x => x.MarketOrderId,
                        principalTable: "MarketOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketOrderDeliveriedInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    MarketOrderId = table.Column<long>(type: "bigint", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketOrderDeliveriedInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketOrderDeliveriedInfo_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketOrderDeliveriedInfo_MarketOrder_MarketOrderId",
                        column: x => x.MarketOrderId,
                        principalTable: "MarketOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketOrderDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MarketOrderId = table.Column<long>(type: "bigint", nullable: false),
                    MarketProductId = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    realQty = table.Column<double>(type: "double precision", nullable: false),
                    summ = table.Column<long>(type: "bigint", nullable: false),
                    discountSumm = table.Column<long>(type: "bigint", nullable: false),
                    productName = table.Column<string>(type: "text", nullable: true),
                    productCode = table.Column<string>(type: "text", nullable: true),
                    productUnitMeasurmentName = table.Column<string>(type: "text", nullable: true),
                    productPrice = table.Column<long>(type: "bigint", nullable: false),
                    dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketOrderDetail_MarketOrder_MarketOrderId",
                        column: x => x.MarketOrderId,
                        principalTable: "MarketOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketOrderDetail_MarketProduct_MarketProductId",
                        column: x => x.MarketProductId,
                        principalTable: "MarketProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErpBatchStageDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    autoCreate = table.Column<bool>(type: "boolean", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    device = table.Column<long>(type: "bigint", nullable: true),
                    entryDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    entryQty = table.Column<double>(type: "double precision", nullable: false),
                    exitDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    exitQty = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ErpBatchDetailId = table.Column<long>(type: "bigint", nullable: true),
                    ErpBatchStageId = table.Column<long>(type: "bigint", nullable: true),
                    ErpColorVariantId = table.Column<long>(type: "bigint", nullable: true),
                    ErpDesignVariantId = table.Column<long>(type: "bigint", nullable: true),
                    entryUserId = table.Column<long>(type: "bigint", nullable: true),
                    ErpEquipmentId = table.Column<long>(type: "bigint", nullable: true),
                    exitUserId = table.Column<long>(type: "bigint", nullable: true),
                    updatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    externalautomaticsystemstatus = table.Column<int>(type: "integer", nullable: true),
                    externalInfo = table.Column<string>(type: "text", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpBatchStageDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpBatchStageDetail_authorizations_entryUserId",
                        column: x => x.entryUserId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchStageDetail_authorizations_exitUserId",
                        column: x => x.exitUserId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchStageDetail_authorizations_updatedUserId",
                        column: x => x.updatedUserId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpBatchStageDetail_ErpBatchDetail_ErpBatchDetailId",
                        column: x => x.ErpBatchDetailId,
                        principalTable: "ErpBatchDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchStageDetail_ErpBatchStage_ErpBatchStageId",
                        column: x => x.ErpBatchStageId,
                        principalTable: "ErpBatchStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchStageDetail_ErpColorVariant_ErpColorVariantId",
                        column: x => x.ErpColorVariantId,
                        principalTable: "ErpColorVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchStageDetail_ErpDesignVariant_ErpDesignVariantId",
                        column: x => x.ErpDesignVariantId,
                        principalTable: "ErpDesignVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErpBatchStageDetail_ErpEquipment_ErpEquipmentId",
                        column: x => x.ErpEquipmentId,
                        principalTable: "ErpEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ErpOrderItemReserve",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ErpOrderId = table.Column<long>(type: "bigint", nullable: false),
                    orderdedMainItemId = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    reservedInvoiceItemId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpOrderItemReserve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErpOrderItemReserve_ErpInvoiceItem_orderdedMainItemId",
                        column: x => x.orderdedMainItemId,
                        principalTable: "ErpInvoiceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpOrderItemReserve_ErpInvoiceItem_reservedInvoiceItemId",
                        column: x => x.reservedInvoiceItemId,
                        principalTable: "ErpInvoiceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErpOrderItemReserve_ErpOrder_ErpOrderId",
                        column: x => x.ErpOrderId,
                        principalTable: "ErpOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketNeedToPayToAgentDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MarketNeedToPayToAgentsId = table.Column<long>(type: "bigint", nullable: false),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    paymentTypeStr = table.Column<string>(type: "text", nullable: true),
                    dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketNeedToPayToAgentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketNeedToPayToAgentDetail_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketNeedToPayToAgentDetail_MarketNeedToPayToAgents_Market~",
                        column: x => x.MarketNeedToPayToAgentsId,
                        principalTable: "MarketNeedToPayToAgents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketPayments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MarketProductId = table.Column<long>(type: "bigint", nullable: false),
                    productName = table.Column<string>(type: "text", nullable: true),
                    productCode = table.Column<string>(type: "text", nullable: true),
                    MarketInvoiceItemId = table.Column<long>(type: "bigint", nullable: false),
                    saledPrice = table.Column<double>(type: "double precision", nullable: false),
                    buyedPrice = table.Column<double>(type: "double precision", nullable: false),
                    profitPrice = table.Column<double>(type: "double precision", nullable: false),
                    persantage = table.Column<double>(type: "double precision", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    companyName = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    departmentName = table.Column<string>(type: "text", nullable: true),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    userName = table.Column<string>(type: "text", nullable: true),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    authPasswordAsCode = table.Column<string>(type: "text", nullable: true),
                    MarketOrderId = table.Column<long>(type: "bigint", nullable: false),
                    MarketOrderDetailId = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketPayments_authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketPayments_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketPayments_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketPayments_MarketInvoiceItem_MarketInvoiceItemId",
                        column: x => x.MarketInvoiceItemId,
                        principalTable: "MarketInvoiceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketPayments_MarketOrder_MarketOrderId",
                        column: x => x.MarketOrderId,
                        principalTable: "MarketOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketPayments_MarketOrderDetail_MarketOrderDetailId",
                        column: x => x.MarketOrderDetailId,
                        principalTable: "MarketOrderDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketPayments_MarketProduct_MarketProductId",
                        column: x => x.MarketProductId,
                        principalTable: "MarketProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketPayments_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketProductRealQtyTemp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MarketOrderDetailId = table.Column<long>(type: "bigint", nullable: false),
                    MarketProductId = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketProductRealQtyTemp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketProductRealQtyTemp_MarketOrderDetail_MarketOrderDetai~",
                        column: x => x.MarketOrderDetailId,
                        principalTable: "MarketOrderDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketProductRealQtyTemp_MarketProduct_MarketProductId",
                        column: x => x.MarketProductId,
                        principalTable: "MarketProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tex_batch",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    color_id = table.Column<long>(type: "bigint", nullable: true),
                    gus_color_id = table.Column<long>(type: "bigint", nullable: true),
                    color_variant_id = table.Column<long>(type: "bigint", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    device_id = table.Column<long>(type: "bigint", nullable: true),
                    order_item_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_batch", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_batchprocess",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_batchprocess", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_calctype",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_calctype", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    print_name = table.Column<string>(type: "text", nullable: true),
                    producttype_id = table.Column<long>(type: "bigint", nullable: false),
                    measurment_type_id = table.Column<long>(type: "bigint", nullable: true),
                    kg = table.Column<double>(type: "double precision", nullable: true),
                    brutto = table.Column<double>(type: "double precision", nullable: true),
                    litr = table.Column<double>(type: "double precision", nullable: true),
                    metr = table.Column<double>(type: "double precision", nullable: true),
                    count = table.Column<double>(type: "double precision", nullable: true),
                    xarakteristika_id = table.Column<List<long>>(type: "bigint[]", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_color",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    color_code = table.Column<string>(type: "text", nullable: true),
                    contraget_id = table.Column<long>(type: "bigint", nullable: true),
                    color_group_id = table.Column<long>(type: "bigint", nullable: true),
                    pantone_code = table.Column<string>(type: "text", nullable: true),
                    dieing_code = table.Column<string>(type: "text", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_color", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_color_tex_contragent_contraget_id",
                        column: x => x.contraget_id,
                        principalTable: "tex_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_color_group",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    generated_value = table.Column<string>(type: "text", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_color_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_color_proccess",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_color_proccess", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_color_variant_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    gcode = table.Column<string>(type: "text", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_color_variant_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_colorvariant",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    color_id = table.Column<long>(type: "bigint", nullable: true),
                    guscolor_id = table.Column<long>(type: "bigint", nullable: true),
                    color_variant_type_id = table.Column<long>(type: "bigint", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    rpt_sequence = table.Column<long>(type: "bigint", nullable: true),
                    parent_colorvariant_id = table.Column<long>(type: "bigint", nullable: true),
                    batchprocess_id = table.Column<long>(type: "bigint", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    color_number = table.Column<int>(type: "integer", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_colorvariant", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_colorvariant_tex_batchprocess_batchprocess_id",
                        column: x => x.batchprocess_id,
                        principalTable: "tex_batchprocess",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_colorvariant_tex_color_color_id",
                        column: x => x.color_id,
                        principalTable: "tex_color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_colorvariant_tex_color_variant_type_color_variant_type_~",
                        column: x => x.color_variant_type_id,
                        principalTable: "tex_color_variant_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_colorvariant_tex_colorvariant_parent_colorvariant_id",
                        column: x => x.parent_colorvariant_id,
                        principalTable: "tex_colorvariant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_column_config",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    table_name = table.Column<string>(type: "text", nullable: true),
                    columns = table.Column<string>(type: "jsonb", nullable: true),
                    auth_id = table.Column<long>(type: "bigint", nullable: false),
                    authorizationid = table.Column<long>(type: "bigint", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_column_config", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_department",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false),
                    code = table.Column<int>(type: "integer", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_department", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_department_tex_contragent_company_id",
                        column: x => x.company_id,
                        principalTable: "tex_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tex_device",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    ip = table.Column<string>(type: "text", nullable: true),
                    device_type_id = table.Column<long>(type: "bigint", nullable: false),
                    department_id = table.Column<long>(type: "bigint", nullable: false),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_device", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_device_tex_department_department_id",
                        column: x => x.department_id,
                        principalTable: "tex_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tex_sub_proccess",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    TexDeviceid = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_sub_proccess", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_sub_proccess_tex_device_TexDeviceid",
                        column: x => x.TexDeviceid,
                        principalTable: "tex_device",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_device_sub_proccess_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TexSubProccessid = table.Column<long>(type: "bigint", nullable: false),
                    TexDeviceid = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_device_sub_proccess_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_device_sub_proccess_detail_tex_device_TexDeviceid",
                        column: x => x.TexDeviceid,
                        principalTable: "tex_device",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tex_device_sub_proccess_detail_tex_sub_proccess_TexSubProcc~",
                        column: x => x.TexSubProccessid,
                        principalTable: "tex_sub_proccess",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tex_device_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_device_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_extra_work",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_extra_work", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_guscolor",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_guscolor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_invoice",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    contraget_id = table.Column<long>(type: "bigint", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    valyuta_id = table.Column<long>(type: "bigint", nullable: true),
                    kurs_valyut = table.Column<double>(type: "double precision", nullable: true),
                    sklad_id = table.Column<long>(type: "bigint", nullable: true),
                    filial_id = table.Column<long>(type: "bigint", nullable: true),
                    summa = table.Column<double>(type: "double precision", nullable: true),
                    count = table.Column<double>(type: "double precision", nullable: true),
                    service_type_id = table.Column<long>(type: "bigint", nullable: true),
                    payment_type_id = table.Column<long>(type: "bigint", nullable: true),
                    department_id = table.Column<long>(type: "bigint", nullable: true),
                    calc_type_id = table.Column<long>(type: "bigint", nullable: true),
                    invoice_type_id = table.Column<long>(type: "bigint", nullable: true),
                    main_sklad_id = table.Column<long>(type: "bigint", nullable: true),
                    main_department_id = table.Column<long>(type: "bigint", nullable: true),
                    main_company_id = table.Column<long>(type: "bigint", nullable: true),
                    accepted_user = table.Column<bool>(type: "boolean", nullable: false),
                    status_type_name = table.Column<string>(type: "text", nullable: true),
                    begin_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    end_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    invoice_filter_status = table.Column<string>(type: "text", nullable: true),
                    receved_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_invoice", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_invoice_tex_calctype_calc_type_id",
                        column: x => x.calc_type_id,
                        principalTable: "tex_calctype",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_invoice_tex_contragent_contraget_id",
                        column: x => x.contraget_id,
                        principalTable: "tex_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_invoice_tex_contragent_filial_id",
                        column: x => x.filial_id,
                        principalTable: "tex_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_invoice_tex_contragent_main_company_id",
                        column: x => x.main_company_id,
                        principalTable: "tex_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_invoice_tex_department_department_id",
                        column: x => x.department_id,
                        principalTable: "tex_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_invoice_tex_department_main_department_id",
                        column: x => x.main_department_id,
                        principalTable: "tex_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_invoice_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    invoice_id = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: true),
                    qty2 = table.Column<double>(type: "double precision", nullable: true),
                    summ = table.Column<double>(type: "double precision", nullable: true),
                    ostatka = table.Column<double>(type: "double precision", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: true),
                    price_real = table.Column<double>(type: "double precision", nullable: true),
                    pus = table.Column<string>(type: "text", nullable: true),
                    fein = table.Column<string>(type: "text", nullable: true),
                    shirina = table.Column<double>(type: "double precision", nullable: true),
                    grammaj = table.Column<double>(type: "double precision", nullable: true),
                    metraj = table.Column<double>(type: "double precision", nullable: true),
                    ugar = table.Column<bool>(type: "boolean", nullable: false),
                    brutto = table.Column<double>(type: "double precision", nullable: true),
                    netto = table.Column<double>(type: "double precision", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    brak = table.Column<bool>(type: "boolean", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    color_id = table.Column<long>(type: "bigint", nullable: true),
                    gus_color_id = table.Column<long>(type: "bigint", nullable: true),
                    color_variant_id = table.Column<long>(type: "bigint", nullable: true),
                    main_proccess_id = table.Column<long>(type: "bigint", nullable: true),
                    extra_work_id = table.Column<long>(type: "bigint", nullable: true),
                    suroviy_vid_id = table.Column<long>(type: "bigint", nullable: true),
                    main_item_id = table.Column<long>(type: "bigint", nullable: true),
                    simple_prod_main_id = table.Column<long>(type: "bigint", nullable: true),
                    item_status_id = table.Column<long>(type: "bigint", nullable: false),
                    sort_id = table.Column<long>(type: "bigint", nullable: true),
                    invoice_type_id = table.Column<long>(type: "bigint", nullable: true),
                    upakovka_id = table.Column<long>(type: "bigint", nullable: true),
                    status_type_name = table.Column<string>(type: "text", nullable: true),
                    lot = table.Column<string>(type: "text", nullable: true),
                    order_item_id = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_invoice_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_invoice_item_tex_color_color_id",
                        column: x => x.color_id,
                        principalTable: "tex_color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_invoice_item_tex_colorvariant_color_variant_id",
                        column: x => x.color_variant_id,
                        principalTable: "tex_colorvariant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_invoice_item_tex_extra_work_extra_work_id",
                        column: x => x.extra_work_id,
                        principalTable: "tex_extra_work",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_invoice_item_tex_guscolor_gus_color_id",
                        column: x => x.gus_color_id,
                        principalTable: "tex_guscolor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_invoice_item_tex_invoice_invoice_id",
                        column: x => x.invoice_id,
                        principalTable: "tex_invoice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_invoice_item_tex_invoice_item_main_item_id",
                        column: x => x.main_item_id,
                        principalTable: "tex_invoice_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_invoice_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_invoice_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_language",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    user_auth_id = table.Column<long>(type: "bigint", nullable: false),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_language", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_main_prossess",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    proccess_id = table.Column<List<long>>(type: "bigint[]", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_main_prossess", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_measurment_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_measurment_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_order",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    begin_datetime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_datetime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    client_id = table.Column<long>(type: "bigint", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: true),
                    department_id = table.Column<long>(type: "bigint", nullable: true),
                    kurs = table.Column<string>(type: "text", nullable: true),
                    valuta_id = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    order_number = table.Column<string>(type: "text", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_order_tex_contragent_client_id",
                        column: x => x.client_id,
                        principalTable: "tex_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_order_tex_contragent_company_id",
                        column: x => x.company_id,
                        principalTable: "tex_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_order_tex_department_department_id",
                        column: x => x.department_id,
                        principalTable: "tex_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_order_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    production_type_id = table.Column<long>(type: "bigint", nullable: true),
                    service_type_id = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: true),
                    trb_grm_ot = table.Column<double>(type: "double precision", nullable: true),
                    trb_grm_do = table.Column<double>(type: "double precision", nullable: true),
                    trb_shir_ot = table.Column<double>(type: "double precision", nullable: true),
                    trb_shir_do = table.Column<double>(type: "double precision", nullable: true),
                    ugar = table.Column<bool>(type: "boolean", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    pus = table.Column<string>(type: "text", nullable: true),
                    fein = table.Column<string>(type: "text", nullable: true),
                    shirina = table.Column<double>(type: "double precision", nullable: true),
                    grammaj = table.Column<double>(type: "double precision", nullable: true),
                    metraj = table.Column<double>(type: "double precision", nullable: true),
                    lot = table.Column<string>(type: "text", nullable: true),
                    artikul = table.Column<long>(type: "bigint", nullable: true),
                    extra_work_price = table.Column<double>(type: "double precision", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    color_id = table.Column<long>(type: "bigint", nullable: true),
                    gus_color_id = table.Column<long>(type: "bigint", nullable: true),
                    color_variant_id = table.Column<long>(type: "bigint", nullable: true),
                    main_proccess_id = table.Column<long>(type: "bigint", nullable: true),
                    extra_work_id = table.Column<long>(type: "bigint", nullable: true),
                    suroviy_vid_id = table.Column<long>(type: "bigint", nullable: true),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_order_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_order_item_tex_color_color_id",
                        column: x => x.color_id,
                        principalTable: "tex_color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_order_item_tex_colorvariant_color_variant_id",
                        column: x => x.color_variant_id,
                        principalTable: "tex_colorvariant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_order_item_tex_extra_work_extra_work_id",
                        column: x => x.extra_work_id,
                        principalTable: "tex_extra_work",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_order_item_tex_guscolor_gus_color_id",
                        column: x => x.gus_color_id,
                        principalTable: "tex_guscolor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_order_item_tex_main_prossess_main_proccess_id",
                        column: x => x.main_proccess_id,
                        principalTable: "tex_main_prossess",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_order_item_tex_order_order_id",
                        column: x => x.order_id,
                        principalTable: "tex_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tex_payment_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_payment_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_planning_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_planning_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_position",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_position", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fio = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    cardnumber = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    custom_user_number = table.Column<long>(type: "bigint", nullable: true),
                    born_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    department_id = table.Column<long>(type: "bigint", nullable: false),
                    position_id = table.Column<long>(type: "bigint", nullable: true),
                    pol_type = table.Column<int>(type: "integer", nullable: false),
                    bot_id = table.Column<long>(type: "bigint", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    passport_number = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_user_tex_department_department_id",
                        column: x => x.department_id,
                        principalTable: "tex_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tex_user_tex_position_position_id",
                        column: x => x.position_id,
                        principalTable: "tex_position",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_authorization",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    login = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    password_not_md5 = table.Column<string>(type: "text", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    user_type = table.Column<int>(type: "integer", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_authorization", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_authorization_tex_contragent_company_id",
                        column: x => x.company_id,
                        principalTable: "tex_contragent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tex_authorization_tex_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tex_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tex_production_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_production_type", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_production_type_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_production_type_tex_authorization_updated_user_id",
                        column: x => x.updated_user_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_service_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_service_type", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_service_type_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_service_type_tex_authorization_updated_user_id",
                        column: x => x.updated_user_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_sklad",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    department_id = table.Column<long>(type: "bigint", nullable: false),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_sklad", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_sklad_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sklad_tex_authorization_updated_user_id",
                        column: x => x.updated_user_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sklad_tex_department_department_id",
                        column: x => x.department_id,
                        principalTable: "tex_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tex_sort",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_sort", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_sort_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_sort_tex_authorization_updated_user_id",
                        column: x => x.updated_user_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_status",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_status", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_status_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_status_tex_authorization_updated_user_id",
                        column: x => x.updated_user_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_suroviy_vid",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_suroviy_vid", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_suroviy_vid_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_suroviy_vid_tex_authorization_updated_user_id",
                        column: x => x.updated_user_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_unit_measurment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_unit_measurment", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_unit_measurment_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_unit_measurment_tex_authorization_updated_user_id",
                        column: x => x.updated_user_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_upakovka",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_upakovka", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_upakovka_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_upakovka_tex_authorization_updated_user_id",
                        column: x => x.updated_user_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_valyuta",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    nominal = table.Column<double>(type: "double precision", nullable: false),
                    forbuy = table.Column<double>(type: "double precision", nullable: false),
                    forsale = table.Column<double>(type: "double precision", nullable: false),
                    difference = table.Column<double>(type: "double precision", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_valyuta", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_valyuta_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_valyuta_tex_authorization_updated_user_id",
                        column: x => x.updated_user_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_xarakteristika",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    print_name = table.Column<string>(type: "text", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_xarakteristika", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_xarakteristika_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_xarakteristika_tex_authorization_updated_user_id",
                        column: x => x.updated_user_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "type_product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_type_product_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_type_product_tex_authorization_updated_user_id",
                        column: x => x.updated_user_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    print_name = table.Column<string>(type: "text", nullable: true),
                    barcode = table.Column<long>(type: "bigint", nullable: true),
                    category_id = table.Column<long>(type: "bigint", nullable: true),
                    selected_xarakteristika_ids = table.Column<List<long>>(type: "bigint[]", nullable: true),
                    planning_type_id = table.Column<List<long>>(type: "bigint[]", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    code_2 = table.Column<string>(type: "text", nullable: true),
                    unitmeasurment_id = table.Column<long>(type: "bigint", nullable: true),
                    unitmeasurment_id_2 = table.Column<long>(type: "bigint", nullable: true),
                    production_type_id = table.Column<long>(type: "bigint", nullable: true),
                    kg = table.Column<double>(type: "double precision", nullable: true),
                    brutto = table.Column<double>(type: "double precision", nullable: true),
                    litr = table.Column<double>(type: "double precision", nullable: true),
                    metr = table.Column<double>(type: "double precision", nullable: true),
                    count = table.Column<double>(type: "double precision", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_product_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_product_tex_authorization_updated_user_id",
                        column: x => x.updated_user_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_product_tex_production_type_production_type_id",
                        column: x => x.production_type_id,
                        principalTable: "tex_production_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_product_tex_unit_measurment_unitmeasurment_id",
                        column: x => x.unitmeasurment_id,
                        principalTable: "tex_unit_measurment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_product_tex_unit_measurment_unitmeasurment_id_2",
                        column: x => x.unitmeasurment_id_2,
                        principalTable: "tex_unit_measurment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_xaraktersitika_tool",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    print_name = table.Column<string>(type: "text", nullable: true),
                    xarakteristika_id = table.Column<long>(type: "bigint", nullable: true),
                    created_auth_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_xaraktersitika_tool", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_xaraktersitika_tool_tex_authorization_created_auth_id",
                        column: x => x.created_auth_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_xaraktersitika_tool_tex_authorization_updated_user_id",
                        column: x => x.updated_user_id,
                        principalTable: "tex_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_xaraktersitika_tool_tex_xarakteristika_xarakteristika_id",
                        column: x => x.xarakteristika_id,
                        principalTable: "tex_xarakteristika",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tex_colorvariant_recipe",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    unitmeasurment_id = table.Column<long>(type: "bigint", nullable: true),
                    color_variant_id = table.Column<long>(type: "bigint", nullable: true),
                    color_proccess_id = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_colorvariant_recipe", x => x.id);
                    table.ForeignKey(
                        name: "FK_tex_colorvariant_recipe_tex_color_proccess_color_proccess_id",
                        column: x => x.color_proccess_id,
                        principalTable: "tex_color_proccess",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_colorvariant_recipe_tex_colorvariant_color_variant_id",
                        column: x => x.color_variant_id,
                        principalTable: "tex_colorvariant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_colorvariant_recipe_tex_product_product_id",
                        column: x => x.product_id,
                        principalTable: "tex_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tex_colorvariant_recipe_tex_unit_measurment_unitmeasurment_~",
                        column: x => x.unitmeasurment_id,
                        principalTable: "tex_unit_measurment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accessMenuItems_AccessMenuId",
                table: "accessMenuItems",
                column: "AccessMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_accessMenuItems_AuthorizationId",
                table: "accessMenuItems",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_accessMenuItems_MenuItemId",
                table: "accessMenuItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_accessMenus_AuthorizationId",
                table: "accessMenus",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_accessMenus_MenuId",
                table: "accessMenus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalizAgglyutinatsionTest_PatientsId",
                table: "AnalizAgglyutinatsionTest",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_analizBakterioskopiyas_PatientsId",
                table: "analizBakterioskopiyas",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalizCovid_PatientsId",
                table: "AnalizCovid",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalizCovidMazok_PatientsId",
                table: "AnalizCovidMazok",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_analizDemodices_PatientsId",
                table: "analizDemodices",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_analizKalas_PatientsId",
                table: "analizKalas",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_analizLeyshmaniys_PatientsId",
                table: "analizLeyshmaniys",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_analizLks_PatientsId",
                table: "analizLks",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_analizMachis_PatientsId",
                table: "analizMachis",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_analizMikroskopiyas_PatientsId",
                table: "analizMikroskopiyas",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_analizMuhimbelgilars_PatientsId",
                table: "analizMuhimbelgilars",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalizQondagiGarmonlar_PatientsId",
                table: "AnalizQondagiGarmonlar",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_analizQontahlilis_PatientsId",
                table: "analizQontahlilis",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_analizRws_PatientsId",
                table: "analizRws",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_analizSarcoptes_PatientsId",
                table: "analizSarcoptes",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_analizZamburugs_PatientsId",
                table: "analizZamburugs",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_authorizations_CompanyId",
                table: "authorizations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_authorizations_UsersId",
                table: "authorizations",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ContragentAdditionalPaymentBefohand_AuthorizationId",
                table: "ContragentAdditionalPaymentBefohand",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContragentAdditionalPaymentBefohand_ContragentId",
                table: "ContragentAdditionalPaymentBefohand",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContragentAdditionalPaymentBefohandDetail_ContragentId",
                table: "ContragentAdditionalPaymentBefohandDetail",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContragentAdditionalPaymentBefohandDetail_PatientsId",
                table: "ContragentAdditionalPaymentBefohandDetail",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContragentAdditionalPaymentBefohandDetail_ServiceTypeId",
                table: "ContragentAdditionalPaymentBefohandDetail",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContragentAdditionalPaymentBefohandFullInfo_ContragentId",
                table: "ContragentAdditionalPaymentBefohandFullInfo",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_contragents_DistrictsId",
                table: "contragents",
                column: "DistrictsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContragentServiceTypeBonusAdditanaly_ContragentId",
                table: "ContragentServiceTypeBonusAdditanaly",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContragentServiceTypeBonusAdditanaly_ServiceTypeId",
                table: "ContragentServiceTypeBonusAdditanaly",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_datchikItems_ColorId",
                table: "datchikItems",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_datchikItems_DatchikId",
                table: "datchikItems",
                column: "DatchikId");

            migrationBuilder.CreateIndex(
                name: "IX_datchikItems_RoomsId",
                table: "datchikItems",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_datchikRealValues_RoomsId",
                table: "datchikRealValues",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_departments_CompanyId",
                table: "departments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_devices_device_name",
                table: "devices",
                column: "device_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_districts_ProvinceId",
                table: "districts",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatch_createdUserId",
                table: "ErpBatch",
                column: "createdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatch_editedUserId",
                table: "ErpBatch",
                column: "editedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatch_ErpColorId",
                table: "ErpBatch",
                column: "ErpColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatch_ErpColorVariantId",
                table: "ErpBatch",
                column: "ErpColorVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatch_ErpEquipmentId",
                table: "ErpBatch",
                column: "ErpEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatch_printedUserId",
                table: "ErpBatch",
                column: "printedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchDetail_ErpBatchId",
                table: "ErpBatchDetail",
                column: "ErpBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchDetail_ErpBatchprocessId",
                table: "ErpBatchDetail",
                column: "ErpBatchprocessId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchDetail_ErpColorDepthId",
                table: "ErpBatchDetail",
                column: "ErpColorDepthId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchDetail_ErpPackagingId",
                table: "ErpBatchDetail",
                column: "ErpPackagingId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchDetail_ErpProductId",
                table: "ErpBatchDetail",
                column: "ErpProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchDetail_unitmeasurment2Id",
                table: "ErpBatchDetail",
                column: "unitmeasurment2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchDetail_unitmeasurment3Id",
                table: "ErpBatchDetail",
                column: "unitmeasurment3Id");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchDetail_unitmeasurmentId",
                table: "ErpBatchDetail",
                column: "unitmeasurmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchRecipeUnion_ErpEquipmentId",
                table: "ErpBatchRecipeUnion",
                column: "ErpEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStage_ErpBatchId",
                table: "ErpBatchStage",
                column: "ErpBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStage_ErpBatchRecipeUnionId",
                table: "ErpBatchStage",
                column: "ErpBatchRecipeUnionId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStage_ErpColorVariantId",
                table: "ErpBatchStage",
                column: "ErpColorVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStage_ErpEquipmentId",
                table: "ErpBatchStage",
                column: "ErpEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStage_ErpProccessStageId",
                table: "ErpBatchStage",
                column: "ErpProccessStageId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStage_printedAuthId",
                table: "ErpBatchStage",
                column: "printedAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStageDetail_entryUserId",
                table: "ErpBatchStageDetail",
                column: "entryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStageDetail_ErpBatchDetailId",
                table: "ErpBatchStageDetail",
                column: "ErpBatchDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStageDetail_ErpBatchStageId",
                table: "ErpBatchStageDetail",
                column: "ErpBatchStageId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStageDetail_ErpColorVariantId",
                table: "ErpBatchStageDetail",
                column: "ErpColorVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStageDetail_ErpDesignVariantId",
                table: "ErpBatchStageDetail",
                column: "ErpDesignVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStageDetail_ErpEquipmentId",
                table: "ErpBatchStageDetail",
                column: "ErpEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStageDetail_exitUserId",
                table: "ErpBatchStageDetail",
                column: "exitUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpBatchStageDetail_updatedUserId",
                table: "ErpBatchStageDetail",
                column: "updatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpCategory_ErpProductTypeId",
                table: "ErpCategory",
                column: "ErpProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpCategoryDetail_ErpCategoryId",
                table: "ErpCategoryDetail",
                column: "ErpCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpCategoryDetail_ErpCharacteristicsId",
                table: "ErpCategoryDetail",
                column: "ErpCharacteristicsId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpCharacteristicsDetail_ErpCharacteristicsId",
                table: "ErpCharacteristicsDetail",
                column: "ErpCharacteristicsId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpCharacteristicsProductDetail_ErpCharacteristicsDetailId",
                table: "ErpCharacteristicsProductDetail",
                column: "ErpCharacteristicsDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpCharacteristicsProductDetail_ErpProductId",
                table: "ErpCharacteristicsProductDetail",
                column: "ErpProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpColor_CompanyId",
                table: "ErpColor",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpColor_ErpColorGroupId",
                table: "ErpColor",
                column: "ErpColorGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpColorVariant_ColorGustotaId",
                table: "ErpColorVariant",
                column: "ColorGustotaId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpColorVariant_ColorId",
                table: "ErpColorVariant",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpColorVariant_ErpColorVariantTypeId",
                table: "ErpColorVariant",
                column: "ErpColorVariantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpColorVariant_ErpProccessId",
                table: "ErpColorVariant",
                column: "ErpProccessId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpColorVariant_ErpProductId",
                table: "ErpColorVariant",
                column: "ErpProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpColorVariant_parentColorVariantId",
                table: "ErpColorVariant",
                column: "parentColorVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpColorVariantRecipe_CreatedAuthId",
                table: "ErpColorVariantRecipe",
                column: "CreatedAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpColorVariantRecipe_ErpColorVariantId",
                table: "ErpColorVariantRecipe",
                column: "ErpColorVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpColorVariantRecipe_ErpProductId",
                table: "ErpColorVariantRecipe",
                column: "ErpProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpColorVariantRecipe_ErpUnitmeasurmentId",
                table: "ErpColorVariantRecipe",
                column: "ErpUnitmeasurmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpColumnConfig_AuthorizationId",
                table: "ErpColumnConfig",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpEquipment_CompanyId",
                table: "ErpEquipment",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpEquipment_DepartmentId",
                table: "ErpEquipment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_CreatedUserId",
                table: "ErpInvoice",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_DepartmentId",
                table: "ErpInvoice",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_ErpCalcTypeId",
                table: "ErpInvoice",
                column: "ErpCalcTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_ErpCurrencyId",
                table: "ErpInvoice",
                column: "ErpCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_ErpInvoiceStatusId",
                table: "ErpInvoice",
                column: "ErpInvoiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_ErpInvoiceTypeId",
                table: "ErpInvoice",
                column: "ErpInvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_ErpPaymentTypeId",
                table: "ErpInvoice",
                column: "ErpPaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_ErpServiceTypeId",
                table: "ErpInvoice",
                column: "ErpServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_ErpWarehouseId",
                table: "ErpInvoice",
                column: "ErpWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_filialCompanyId",
                table: "ErpInvoice",
                column: "filialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_InvcompanyId",
                table: "ErpInvoice",
                column: "InvcompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_mainCompanyId",
                table: "ErpInvoice",
                column: "mainCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_mainDepartmentId",
                table: "ErpInvoice",
                column: "mainDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_mainWarehouseId",
                table: "ErpInvoice",
                column: "mainWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoice_UpdatedUserId",
                table: "ErpInvoice",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_ErpColorGustotaId",
                table: "ErpInvoiceItem",
                column: "ErpColorGustotaId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_ErpColorId",
                table: "ErpInvoiceItem",
                column: "ErpColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_ErpColorVariantId",
                table: "ErpInvoiceItem",
                column: "ErpColorVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_ErpExtraWorkId",
                table: "ErpInvoiceItem",
                column: "ErpExtraWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_ErpInvoiceId",
                table: "ErpInvoiceItem",
                column: "ErpInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_erpInvoiceItemId",
                table: "ErpInvoiceItem",
                column: "erpInvoiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_ErpInvoiceStatusId",
                table: "ErpInvoiceItem",
                column: "ErpInvoiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_ErpInvoiceTypeId",
                table: "ErpInvoiceItem",
                column: "ErpInvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_ErpOrderId",
                table: "ErpInvoiceItem",
                column: "ErpOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_ErpProccessId",
                table: "ErpInvoiceItem",
                column: "ErpProccessId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_ErpProductId",
                table: "ErpInvoiceItem",
                column: "ErpProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_ErpSortId",
                table: "ErpInvoiceItem",
                column: "ErpSortId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_ErpSuroviyVidId",
                table: "ErpInvoiceItem",
                column: "ErpSuroviyVidId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpInvoiceItem_ErpUpakopkaId",
                table: "ErpInvoiceItem",
                column: "ErpUpakopkaId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpOrder_clientCompanyId",
                table: "ErpOrder",
                column: "clientCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpOrder_createdAuthId",
                table: "ErpOrder",
                column: "createdAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpOrder_DepartmentId",
                table: "ErpOrder",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpOrder_ErpCurrencyId",
                table: "ErpOrder",
                column: "ErpCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpOrder_mainCompanyId",
                table: "ErpOrder",
                column: "mainCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpOrder_updateAuthId",
                table: "ErpOrder",
                column: "updateAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpOrderItemReserve_ErpOrderId",
                table: "ErpOrderItemReserve",
                column: "ErpOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpOrderItemReserve_orderdedMainItemId",
                table: "ErpOrderItemReserve",
                column: "orderdedMainItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpOrderItemReserve_reservedInvoiceItemId",
                table: "ErpOrderItemReserve",
                column: "reservedInvoiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpPackaging_DepartmentId",
                table: "ErpPackaging",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpPlanningTypeProductDetail_ErpPlanningTypeId",
                table: "ErpPlanningTypeProductDetail",
                column: "ErpPlanningTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpPlanningTypeProductDetail_ErpProductId",
                table: "ErpPlanningTypeProductDetail",
                column: "ErpProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpProccessAndProccessStage_ErpProccessId",
                table: "ErpProccessAndProccessStage",
                column: "ErpProccessId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpProccessAndProccessStage_ErpProccessStageId",
                table: "ErpProccessAndProccessStage",
                column: "ErpProccessStageId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpProduct_ErpCategoryId",
                table: "ErpProduct",
                column: "ErpCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpProduct_ErpPruductionTypeId",
                table: "ErpProduct",
                column: "ErpPruductionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpProduct_ErpUnitmeasurment2Id",
                table: "ErpProduct",
                column: "ErpUnitmeasurment2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ErpProduct_ErpUnitmeasurmentId",
                table: "ErpProduct",
                column: "ErpUnitmeasurmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ErpWarehouse_DepartmentId",
                table: "ErpWarehouse",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalContragentDebitPaymentReport_contragentId",
                table: "HospitalContragentDebitPaymentReport",
                column: "contragentId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalContragentDebitPaymentReport_districtsId",
                table: "HospitalContragentDebitPaymentReport",
                column: "districtsId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalContragentNotifierReport_ContragentId",
                table: "HospitalContragentNotifierReport",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalManagerReport_AuthorizationId",
                table: "HospitalManagerReport",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalMrtSorovNoma_ContragentId",
                table: "HospitalMrtSorovNoma",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalMrtSorovNoma_PatientsId",
                table: "HospitalMrtSorovNoma",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalRegistrationPermissionDoctors_doctorAuthId",
                table: "HospitalRegistrationPermissionDoctors",
                column: "doctorAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalRegistrationPermissionDoctors_registraterAuthId",
                table: "HospitalRegistrationPermissionDoctors",
                column: "registraterAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalServiceRecipe_MarketProductId",
                table: "HospitalServiceRecipe",
                column: "MarketProductId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalServiceRecipe_ServiceTypeId",
                table: "HospitalServiceRecipe",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalServiceTypeByGroupPermission_HospitalServiceTypeGro~",
                table: "HospitalServiceTypeByGroupPermission",
                column: "HospitalServiceTypeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitelRequiredServiceTypesAllPatcientsAndNotPatcients_Ser~",
                table: "HospitelRequiredServiceTypesAllPatcientsAndNotPatcients",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketAuthLimitByMoney_AuthorizationId",
                table: "MarketAuthLimitByMoney",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketAuthLimitByMoneyDetail_MarketAuthLimitByMoneyId",
                table: "MarketAuthLimitByMoneyDetail",
                column: "MarketAuthLimitByMoneyId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketAuthLimitByMoneyDetail_MarketOrderId",
                table: "MarketAuthLimitByMoneyDetail",
                column: "MarketOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketAuthLimitByProduct_AuthorizationId",
                table: "MarketAuthLimitByProduct",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketAuthLimitByProduct_MarketProductId",
                table: "MarketAuthLimitByProduct",
                column: "MarketProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketAuthLimitByProductDetail_MarketAuthLimitByProductId",
                table: "MarketAuthLimitByProductDetail",
                column: "MarketAuthLimitByProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketAuthLimitByProductDetail_MarketOrderId",
                table: "MarketAuthLimitByProductDetail",
                column: "MarketOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketClientInfo_AuthorizationId",
                table: "MarketClientInfo",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketInvoice_AuthorizationId",
                table: "MarketInvoice",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketInvoice_CompanyId",
                table: "MarketInvoice",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketInvoice_MarketAgentId",
                table: "MarketInvoice",
                column: "MarketAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketInvoiceItem_MarketInvoiceId",
                table: "MarketInvoiceItem",
                column: "MarketInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketInvoiceItem_MarketProductId",
                table: "MarketInvoiceItem",
                column: "MarketProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketNeedToPayToAgentDetail_AuthorizationId",
                table: "MarketNeedToPayToAgentDetail",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketNeedToPayToAgentDetail_MarketNeedToPayToAgentsId",
                table: "MarketNeedToPayToAgentDetail",
                column: "MarketNeedToPayToAgentsId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketNeedToPayToAgents_AuthorizationId",
                table: "MarketNeedToPayToAgents",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketNeedToPayToAgents_MarketAgentId",
                table: "MarketNeedToPayToAgents",
                column: "MarketAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketNeedToPayToAgents_MarketInvoiceId",
                table: "MarketNeedToPayToAgents",
                column: "MarketInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketOrder_AuthorizationId",
                table: "MarketOrder",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketOrderDeliveriedInfo_AuthorizationId",
                table: "MarketOrderDeliveriedInfo",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketOrderDeliveriedInfo_MarketOrderId",
                table: "MarketOrderDeliveriedInfo",
                column: "MarketOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketOrderDetail_MarketOrderId",
                table: "MarketOrderDetail",
                column: "MarketOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketOrderDetail_MarketProductId",
                table: "MarketOrderDetail",
                column: "MarketProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPayments_AuthorizationId",
                table: "MarketPayments",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPayments_CompanyId",
                table: "MarketPayments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPayments_DepartmentId",
                table: "MarketPayments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPayments_MarketInvoiceItemId",
                table: "MarketPayments",
                column: "MarketInvoiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPayments_MarketOrderDetailId",
                table: "MarketPayments",
                column: "MarketOrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPayments_MarketOrderId",
                table: "MarketPayments",
                column: "MarketOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPayments_MarketProductId",
                table: "MarketPayments",
                column: "MarketProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPayments_UsersId",
                table: "MarketPayments",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPrePaidMoney_UsersId",
                table: "MarketPrePaidMoney",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProduct_MarketUnitMeasurmentId",
                table: "MarketProduct",
                column: "MarketUnitMeasurmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProductGroup_marketProductGroupId",
                table: "MarketProductGroup",
                column: "marketProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProductGroupDetail_MarketProductGroupId",
                table: "MarketProductGroupDetail",
                column: "MarketProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProductGroupDetail_MarketProductId",
                table: "MarketProductGroupDetail",
                column: "MarketProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProductPrice_AuthorizationId",
                table: "MarketProductPrice",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProductPrice_MarketProductId",
                table: "MarketProductPrice",
                column: "MarketProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProductRealQty_MarketProductId",
                table: "MarketProductRealQty",
                column: "MarketProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProductRealQtyTemp_MarketOrderDetailId",
                table: "MarketProductRealQtyTemp",
                column: "MarketOrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProductRealQtyTemp_MarketProductId",
                table: "MarketProductRealQtyTemp",
                column: "MarketProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRecipeByDoctor_DoctorId",
                table: "PatientRecipeByDoctor",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRecipeByDoctor_PatientsId",
                table: "PatientRecipeByDoctor",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_patientRegistrationInfos_PatientServiceTypeId",
                table: "patientRegistrationInfos",
                column: "PatientServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_patientRegistrationInfos_PatientsId",
                table: "patientRegistrationInfos",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_patientRegistrationInfos_PatientTypeId",
                table: "patientRegistrationInfos",
                column: "PatientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DistrictsId",
                table: "Patients",
                column: "DistrictsId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRooms_PatientsId",
                table: "PaymentRooms",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRooms_RoomsId",
                table: "PaymentRooms",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRoomsItem_PaymentRoomsId",
                table: "PaymentRoomsItem",
                column: "PaymentRoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRoomsServiceTypesItem_PatientsId",
                table: "PaymentRoomsServiceTypesItem",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRoomsServiceTypesItem_PaymentRoomsId",
                table: "PaymentRoomsServiceTypesItem",
                column: "PaymentRoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRoomsServiceTypesItem_ServiceTypeId",
                table: "PaymentRoomsServiceTypesItem",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRoomsServiceTypesItemInfo_PaymentRoomsServiceTypesIt~",
                table: "PaymentRoomsServiceTypesItemInfo",
                column: "PaymentRoomsServiceTypesItemId");

            migrationBuilder.CreateIndex(
                name: "IX_payments_AuthorizationId",
                table: "payments",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_payments_ContragentId",
                table: "payments",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_payments_PatientsId",
                table: "payments",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_payments_ServiceTypeId",
                table: "payments",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_returnMoney_AuthorizationId",
                table: "returnMoney",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_returnMoney_UsersId",
                table: "returnMoney",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_PatientsId",
                table: "RoomBooking",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_RoomsId",
                table: "RoomBooking",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_DepartmentId",
                table: "rooms",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeDetail_ServiceTypeId",
                table: "ServiceTypeDetail",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeDetail_UsersId",
                table: "ServiceTypeDetail",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceTypes_HospitalServiceTypeGroupId",
                table: "serviceTypes",
                column: "HospitalServiceTypeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SkudDoorCheckinout_userid_sana_checktime",
                table: "SkudDoorCheckinout",
                columns: new[] { "userid", "sana", "checktime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkudDoors_dbname",
                table: "SkudDoors",
                column: "dbname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkudFaces_ip",
                table: "SkudFaces",
                column: "ip",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkudFaces_nomi",
                table: "SkudFaces",
                column: "nomi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkudLk_lkey",
                table: "SkudLk",
                column: "lkey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkudMyCheckinout_userid_sana_checktime",
                table: "SkudMyCheckinout",
                columns: new[] { "userid", "sana", "checktime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkudMyDepartments_deptname",
                table: "SkudMyDepartments",
                column: "deptname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_authorization_company_id",
                table: "tex_authorization",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_authorization_login",
                table: "tex_authorization",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_authorization_user_id",
                table: "tex_authorization",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_batch_color_id",
                table: "tex_batch",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_batch_color_variant_id",
                table: "tex_batch",
                column: "color_variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_batch_created_auth_id",
                table: "tex_batch",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_batch_device_id",
                table: "tex_batch",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_batch_gus_color_id",
                table: "tex_batch",
                column: "gus_color_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_batch_order_item_id",
                table: "tex_batch",
                column: "order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_batch_updated_user_id",
                table: "tex_batch",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_batchprocess_created_auth_id",
                table: "tex_batchprocess",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_batchprocess_updated_user_id",
                table: "tex_batchprocess",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_calctype_created_auth_id",
                table: "tex_calctype",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_calctype_updated_user_id",
                table: "tex_calctype",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_category_created_auth_id",
                table: "tex_category",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_category_measurment_type_id",
                table: "tex_category",
                column: "measurment_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_category_name",
                table: "tex_category",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_category_producttype_id",
                table: "tex_category",
                column: "producttype_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_category_updated_user_id",
                table: "tex_category",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_color_group_id",
                table: "tex_color",
                column: "color_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_contraget_id",
                table: "tex_color",
                column: "contraget_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_created_auth_id",
                table: "tex_color",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_name",
                table: "tex_color",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_updated_user_id",
                table: "tex_color",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_group_created_auth_id",
                table: "tex_color_group",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_group_name",
                table: "tex_color_group",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_group_updated_user_id",
                table: "tex_color_group",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_proccess_created_auth_id",
                table: "tex_color_proccess",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_proccess_name",
                table: "tex_color_proccess",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_proccess_updated_user_id",
                table: "tex_color_proccess",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_variant_type_created_auth_id",
                table: "tex_color_variant_type",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_variant_type_name",
                table: "tex_color_variant_type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_color_variant_type_updated_user_id",
                table: "tex_color_variant_type",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_colorvariant_batchprocess_id",
                table: "tex_colorvariant",
                column: "batchprocess_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_colorvariant_color_id",
                table: "tex_colorvariant",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_colorvariant_color_variant_type_id",
                table: "tex_colorvariant",
                column: "color_variant_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_colorvariant_created_auth_id",
                table: "tex_colorvariant",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_colorvariant_guscolor_id",
                table: "tex_colorvariant",
                column: "guscolor_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_colorvariant_name",
                table: "tex_colorvariant",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_colorvariant_parent_colorvariant_id",
                table: "tex_colorvariant",
                column: "parent_colorvariant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_colorvariant_product_id",
                table: "tex_colorvariant",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_colorvariant_updated_user_id",
                table: "tex_colorvariant",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_colorvariant_recipe_color_proccess_id",
                table: "tex_colorvariant_recipe",
                column: "color_proccess_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_colorvariant_recipe_color_variant_id",
                table: "tex_colorvariant_recipe",
                column: "color_variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_colorvariant_recipe_product_id",
                table: "tex_colorvariant_recipe",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_colorvariant_recipe_unitmeasurment_id",
                table: "tex_colorvariant_recipe",
                column: "unitmeasurment_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_column_config_authorizationid",
                table: "tex_column_config",
                column: "authorizationid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_column_config_created_auth_id",
                table: "tex_column_config",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_column_config_updated_user_id",
                table: "tex_column_config",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_contragent_name",
                table: "tex_contragent",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_department_company_id",
                table: "tex_department",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_department_created_auth_id",
                table: "tex_department",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_department_name",
                table: "tex_department",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_department_updated_user_id",
                table: "tex_department",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_device_code",
                table: "tex_device",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_device_created_auth_id",
                table: "tex_device",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_device_department_id",
                table: "tex_device",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_device_device_type_id",
                table: "tex_device",
                column: "device_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_device_ip",
                table: "tex_device",
                column: "ip",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_device_name",
                table: "tex_device",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_device_updated_user_id",
                table: "tex_device",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_device_sub_proccess_detail_TexDeviceid",
                table: "tex_device_sub_proccess_detail",
                column: "TexDeviceid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_device_sub_proccess_detail_TexSubProccessid",
                table: "tex_device_sub_proccess_detail",
                column: "TexSubProccessid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_device_type_created_auth_id",
                table: "tex_device_type",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_device_type_name",
                table: "tex_device_type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_device_type_updated_user_id",
                table: "tex_device_type",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_extra_work_created_auth_id",
                table: "tex_extra_work",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_extra_work_name",
                table: "tex_extra_work",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_extra_work_updated_user_id",
                table: "tex_extra_work",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_guscolor_created_auth_id",
                table: "tex_guscolor",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_guscolor_name",
                table: "tex_guscolor",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_guscolor_updated_user_id",
                table: "tex_guscolor",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_calc_type_id",
                table: "tex_invoice",
                column: "calc_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_contraget_id",
                table: "tex_invoice",
                column: "contraget_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_created_auth_id",
                table: "tex_invoice",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_department_id",
                table: "tex_invoice",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_filial_id",
                table: "tex_invoice",
                column: "filial_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_invoice_type_id",
                table: "tex_invoice",
                column: "invoice_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_main_company_id",
                table: "tex_invoice",
                column: "main_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_main_department_id",
                table: "tex_invoice",
                column: "main_department_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_main_sklad_id",
                table: "tex_invoice",
                column: "main_sklad_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_order_id",
                table: "tex_invoice",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_payment_type_id",
                table: "tex_invoice",
                column: "payment_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_receved_auth_id",
                table: "tex_invoice",
                column: "receved_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_service_type_id",
                table: "tex_invoice",
                column: "service_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_sklad_id",
                table: "tex_invoice",
                column: "sklad_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_updated_auth_id",
                table: "tex_invoice",
                column: "updated_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_valyuta_id",
                table: "tex_invoice",
                column: "valyuta_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_color_id",
                table: "tex_invoice_item",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_color_variant_id",
                table: "tex_invoice_item",
                column: "color_variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_created_auth_id",
                table: "tex_invoice_item",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_extra_work_id",
                table: "tex_invoice_item",
                column: "extra_work_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_gus_color_id",
                table: "tex_invoice_item",
                column: "gus_color_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_invoice_id",
                table: "tex_invoice_item",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_invoice_type_id",
                table: "tex_invoice_item",
                column: "invoice_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_item_status_id",
                table: "tex_invoice_item",
                column: "item_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_main_item_id",
                table: "tex_invoice_item",
                column: "main_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_main_proccess_id",
                table: "tex_invoice_item",
                column: "main_proccess_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_order_item_id",
                table: "tex_invoice_item",
                column: "order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_product_id",
                table: "tex_invoice_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_sort_id",
                table: "tex_invoice_item",
                column: "sort_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_suroviy_vid_id",
                table: "tex_invoice_item",
                column: "suroviy_vid_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_upakovka_id",
                table: "tex_invoice_item",
                column: "upakovka_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_item_updated_user_id",
                table: "tex_invoice_item",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_type_created_auth_id",
                table: "tex_invoice_type",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_type_name",
                table: "tex_invoice_type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_invoice_type_updated_user_id",
                table: "tex_invoice_type",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_language_created_auth_id",
                table: "tex_language",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_language_name_user_auth_id",
                table: "tex_language",
                columns: new[] { "name", "user_auth_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_language_updated_user_id",
                table: "tex_language",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_language_user_auth_id",
                table: "tex_language",
                column: "user_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_main_prossess_created_auth_id",
                table: "tex_main_prossess",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_main_prossess_name",
                table: "tex_main_prossess",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_main_prossess_updated_user_id",
                table: "tex_main_prossess",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_measurment_type_created_auth_id",
                table: "tex_measurment_type",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_measurment_type_name",
                table: "tex_measurment_type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_measurment_type_updated_user_id",
                table: "tex_measurment_type",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_client_id",
                table: "tex_order",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_company_id",
                table: "tex_order",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_created_auth_id",
                table: "tex_order",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_department_id",
                table: "tex_order",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_updated_user_id",
                table: "tex_order",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_valuta_id",
                table: "tex_order",
                column: "valuta_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_color_id",
                table: "tex_order_item",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_color_variant_id",
                table: "tex_order_item",
                column: "color_variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_created_auth_id",
                table: "tex_order_item",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_extra_work_id",
                table: "tex_order_item",
                column: "extra_work_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_gus_color_id",
                table: "tex_order_item",
                column: "gus_color_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_main_proccess_id",
                table: "tex_order_item",
                column: "main_proccess_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_order_id",
                table: "tex_order_item",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_product_id",
                table: "tex_order_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_production_type_id",
                table: "tex_order_item",
                column: "production_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_service_type_id",
                table: "tex_order_item",
                column: "service_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_suroviy_vid_id",
                table: "tex_order_item",
                column: "suroviy_vid_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_updated_user_id",
                table: "tex_order_item",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_payment_type_created_auth_id",
                table: "tex_payment_type",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_payment_type_name",
                table: "tex_payment_type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_payment_type_updated_user_id",
                table: "tex_payment_type",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_type_created_auth_id",
                table: "tex_planning_type",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_type_name",
                table: "tex_planning_type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_planning_type_updated_user_id",
                table: "tex_planning_type",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_position_created_auth_id",
                table: "tex_position",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_position_name",
                table: "tex_position",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_position_updated_user_id",
                table: "tex_position",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_product_created_auth_id",
                table: "tex_product",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_product_name",
                table: "tex_product",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_product_production_type_id",
                table: "tex_product",
                column: "production_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_product_unitmeasurment_id",
                table: "tex_product",
                column: "unitmeasurment_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_product_unitmeasurment_id_2",
                table: "tex_product",
                column: "unitmeasurment_id_2");

            migrationBuilder.CreateIndex(
                name: "IX_tex_product_updated_user_id",
                table: "tex_product",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_production_type_created_auth_id",
                table: "tex_production_type",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_production_type_name",
                table: "tex_production_type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_production_type_updated_user_id",
                table: "tex_production_type",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_service_type_created_auth_id",
                table: "tex_service_type",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_service_type_name",
                table: "tex_service_type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_service_type_updated_user_id",
                table: "tex_service_type",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sklad_created_auth_id",
                table: "tex_sklad",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sklad_department_id",
                table: "tex_sklad",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sklad_name",
                table: "tex_sklad",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_sklad_updated_user_id",
                table: "tex_sklad",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sort_created_auth_id",
                table: "tex_sort",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sort_name",
                table: "tex_sort",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_sort_updated_user_id",
                table: "tex_sort",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_status_created_auth_id",
                table: "tex_status",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_status_updated_user_id",
                table: "tex_status",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_sub_proccess_TexDeviceid",
                table: "tex_sub_proccess",
                column: "TexDeviceid");

            migrationBuilder.CreateIndex(
                name: "IX_tex_suroviy_vid_created_auth_id",
                table: "tex_suroviy_vid",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_suroviy_vid_updated_user_id",
                table: "tex_suroviy_vid",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_unit_measurment_created_auth_id",
                table: "tex_unit_measurment",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_unit_measurment_name",
                table: "tex_unit_measurment",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_unit_measurment_updated_user_id",
                table: "tex_unit_measurment",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_upakovka_created_auth_id",
                table: "tex_upakovka",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_upakovka_name",
                table: "tex_upakovka",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_upakovka_updated_user_id",
                table: "tex_upakovka",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_user_department_id",
                table: "tex_user",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_user_passport_number",
                table: "tex_user",
                column: "passport_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_user_position_id",
                table: "tex_user",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_valyuta_created_auth_id",
                table: "tex_valyuta",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_valyuta_updated_user_id",
                table: "tex_valyuta",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_xarakteristika_created_auth_id",
                table: "tex_xarakteristika",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_xarakteristika_name",
                table: "tex_xarakteristika",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_xarakteristika_updated_user_id",
                table: "tex_xarakteristika",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_xaraktersitika_tool_created_auth_id",
                table: "tex_xaraktersitika_tool",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_xaraktersitika_tool_name",
                table: "tex_xaraktersitika_tool",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_xaraktersitika_tool_updated_user_id",
                table: "tex_xaraktersitika_tool",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_xaraktersitika_tool_xarakteristika_id",
                table: "tex_xaraktersitika_tool",
                column: "xarakteristika_id");

            migrationBuilder.CreateIndex(
                name: "IX_type_product_created_auth_id",
                table: "type_product",
                column: "created_auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_type_product_name",
                table: "type_product",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_type_product_updated_user_id",
                table: "type_product",
                column: "updated_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_departmentId",
                table: "Users",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PositionId",
                table: "Users",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roomsId",
                table: "Users",
                column: "roomsId");

            migrationBuilder.AddForeignKey(
                name: "FK_tex_batch_tex_authorization_created_auth_id",
                table: "tex_batch",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_batch_tex_authorization_updated_user_id",
                table: "tex_batch",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_batch_tex_color_color_id",
                table: "tex_batch",
                column: "color_id",
                principalTable: "tex_color",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_batch_tex_colorvariant_color_variant_id",
                table: "tex_batch",
                column: "color_variant_id",
                principalTable: "tex_colorvariant",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_batch_tex_device_device_id",
                table: "tex_batch",
                column: "device_id",
                principalTable: "tex_device",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_batch_tex_guscolor_gus_color_id",
                table: "tex_batch",
                column: "gus_color_id",
                principalTable: "tex_guscolor",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_batch_tex_order_item_order_item_id",
                table: "tex_batch",
                column: "order_item_id",
                principalTable: "tex_order_item",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_batchprocess_tex_authorization_created_auth_id",
                table: "tex_batchprocess",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_batchprocess_tex_authorization_updated_user_id",
                table: "tex_batchprocess",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_calctype_tex_authorization_created_auth_id",
                table: "tex_calctype",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_calctype_tex_authorization_updated_user_id",
                table: "tex_calctype",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_category_tex_authorization_created_auth_id",
                table: "tex_category",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_category_tex_authorization_updated_user_id",
                table: "tex_category",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_category_tex_measurment_type_measurment_type_id",
                table: "tex_category",
                column: "measurment_type_id",
                principalTable: "tex_measurment_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_category_type_product_producttype_id",
                table: "tex_category",
                column: "producttype_id",
                principalTable: "type_product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_color_tex_authorization_created_auth_id",
                table: "tex_color",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_color_tex_authorization_updated_user_id",
                table: "tex_color",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_color_tex_color_group_color_group_id",
                table: "tex_color",
                column: "color_group_id",
                principalTable: "tex_color_group",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_color_group_tex_authorization_created_auth_id",
                table: "tex_color_group",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_color_group_tex_authorization_updated_user_id",
                table: "tex_color_group",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_color_proccess_tex_authorization_created_auth_id",
                table: "tex_color_proccess",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_color_proccess_tex_authorization_updated_user_id",
                table: "tex_color_proccess",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_color_variant_type_tex_authorization_created_auth_id",
                table: "tex_color_variant_type",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_color_variant_type_tex_authorization_updated_user_id",
                table: "tex_color_variant_type",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_colorvariant_tex_authorization_created_auth_id",
                table: "tex_colorvariant",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_colorvariant_tex_authorization_updated_user_id",
                table: "tex_colorvariant",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_colorvariant_tex_guscolor_guscolor_id",
                table: "tex_colorvariant",
                column: "guscolor_id",
                principalTable: "tex_guscolor",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_colorvariant_tex_product_product_id",
                table: "tex_colorvariant",
                column: "product_id",
                principalTable: "tex_product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_column_config_tex_authorization_authorizationid",
                table: "tex_column_config",
                column: "authorizationid",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_column_config_tex_authorization_created_auth_id",
                table: "tex_column_config",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_column_config_tex_authorization_updated_user_id",
                table: "tex_column_config",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_department_tex_authorization_created_auth_id",
                table: "tex_department",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_department_tex_authorization_updated_user_id",
                table: "tex_department",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_device_tex_authorization_created_auth_id",
                table: "tex_device",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_device_tex_authorization_updated_user_id",
                table: "tex_device",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_device_tex_device_type_device_type_id",
                table: "tex_device",
                column: "device_type_id",
                principalTable: "tex_device_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_device_type_tex_authorization_created_auth_id",
                table: "tex_device_type",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_device_type_tex_authorization_updated_user_id",
                table: "tex_device_type",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_extra_work_tex_authorization_created_auth_id",
                table: "tex_extra_work",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_extra_work_tex_authorization_updated_user_id",
                table: "tex_extra_work",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_guscolor_tex_authorization_created_auth_id",
                table: "tex_guscolor",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_guscolor_tex_authorization_updated_user_id",
                table: "tex_guscolor",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_tex_authorization_created_auth_id",
                table: "tex_invoice",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_tex_authorization_receved_auth_id",
                table: "tex_invoice",
                column: "receved_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_tex_authorization_updated_auth_id",
                table: "tex_invoice",
                column: "updated_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_tex_invoice_type_invoice_type_id",
                table: "tex_invoice",
                column: "invoice_type_id",
                principalTable: "tex_invoice_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_tex_order_order_id",
                table: "tex_invoice",
                column: "order_id",
                principalTable: "tex_order",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_tex_payment_type_payment_type_id",
                table: "tex_invoice",
                column: "payment_type_id",
                principalTable: "tex_payment_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_tex_service_type_service_type_id",
                table: "tex_invoice",
                column: "service_type_id",
                principalTable: "tex_service_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_tex_sklad_main_sklad_id",
                table: "tex_invoice",
                column: "main_sklad_id",
                principalTable: "tex_sklad",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_tex_sklad_sklad_id",
                table: "tex_invoice",
                column: "sklad_id",
                principalTable: "tex_sklad",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_tex_valyuta_valyuta_id",
                table: "tex_invoice",
                column: "valyuta_id",
                principalTable: "tex_valyuta",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_item_tex_authorization_created_auth_id",
                table: "tex_invoice_item",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_item_tex_authorization_updated_user_id",
                table: "tex_invoice_item",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_item_tex_invoice_type_invoice_type_id",
                table: "tex_invoice_item",
                column: "invoice_type_id",
                principalTable: "tex_invoice_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_item_tex_main_prossess_main_proccess_id",
                table: "tex_invoice_item",
                column: "main_proccess_id",
                principalTable: "tex_main_prossess",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_item_tex_order_item_order_item_id",
                table: "tex_invoice_item",
                column: "order_item_id",
                principalTable: "tex_order_item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_item_tex_product_product_id",
                table: "tex_invoice_item",
                column: "product_id",
                principalTable: "tex_product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_item_tex_sort_sort_id",
                table: "tex_invoice_item",
                column: "sort_id",
                principalTable: "tex_sort",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_item_tex_status_item_status_id",
                table: "tex_invoice_item",
                column: "item_status_id",
                principalTable: "tex_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_item_tex_suroviy_vid_suroviy_vid_id",
                table: "tex_invoice_item",
                column: "suroviy_vid_id",
                principalTable: "tex_suroviy_vid",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_item_tex_upakovka_upakovka_id",
                table: "tex_invoice_item",
                column: "upakovka_id",
                principalTable: "tex_upakovka",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_type_tex_authorization_created_auth_id",
                table: "tex_invoice_type",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_invoice_type_tex_authorization_updated_user_id",
                table: "tex_invoice_type",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_language_tex_authorization_created_auth_id",
                table: "tex_language",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_language_tex_authorization_updated_user_id",
                table: "tex_language",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_language_tex_authorization_user_auth_id",
                table: "tex_language",
                column: "user_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_main_prossess_tex_authorization_created_auth_id",
                table: "tex_main_prossess",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_main_prossess_tex_authorization_updated_user_id",
                table: "tex_main_prossess",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_measurment_type_tex_authorization_created_auth_id",
                table: "tex_measurment_type",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_measurment_type_tex_authorization_updated_user_id",
                table: "tex_measurment_type",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_order_tex_authorization_created_auth_id",
                table: "tex_order",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_order_tex_authorization_updated_user_id",
                table: "tex_order",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_order_tex_valyuta_valuta_id",
                table: "tex_order",
                column: "valuta_id",
                principalTable: "tex_valyuta",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_order_item_tex_authorization_created_auth_id",
                table: "tex_order_item",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_order_item_tex_authorization_updated_user_id",
                table: "tex_order_item",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_order_item_tex_product_product_id",
                table: "tex_order_item",
                column: "product_id",
                principalTable: "tex_product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_order_item_tex_production_type_production_type_id",
                table: "tex_order_item",
                column: "production_type_id",
                principalTable: "tex_production_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_order_item_tex_service_type_service_type_id",
                table: "tex_order_item",
                column: "service_type_id",
                principalTable: "tex_service_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_order_item_tex_suroviy_vid_suroviy_vid_id",
                table: "tex_order_item",
                column: "suroviy_vid_id",
                principalTable: "tex_suroviy_vid",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_payment_type_tex_authorization_created_auth_id",
                table: "tex_payment_type",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_payment_type_tex_authorization_updated_user_id",
                table: "tex_payment_type",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_planning_type_tex_authorization_created_auth_id",
                table: "tex_planning_type",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_planning_type_tex_authorization_updated_user_id",
                table: "tex_planning_type",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_position_tex_authorization_created_auth_id",
                table: "tex_position",
                column: "created_auth_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_position_tex_authorization_updated_user_id",
                table: "tex_position",
                column: "updated_user_id",
                principalTable: "tex_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tex_authorization_tex_contragent_company_id",
                table: "tex_authorization");

            migrationBuilder.DropForeignKey(
                name: "FK_tex_department_tex_contragent_company_id",
                table: "tex_department");

            migrationBuilder.DropForeignKey(
                name: "FK_tex_authorization_tex_user_user_id",
                table: "tex_authorization");

            migrationBuilder.DropTable(
                name: "access_levels");

            migrationBuilder.DropTable(
                name: "accessMenuItems");

            migrationBuilder.DropTable(
                name: "AnalizAgglyutinatsionTest");

            migrationBuilder.DropTable(
                name: "analizBakterioskopiyas");

            migrationBuilder.DropTable(
                name: "AnalizCovid");

            migrationBuilder.DropTable(
                name: "AnalizCovidMazok");

            migrationBuilder.DropTable(
                name: "analizDemodices");

            migrationBuilder.DropTable(
                name: "analizKalas");

            migrationBuilder.DropTable(
                name: "analizLeyshmaniys");

            migrationBuilder.DropTable(
                name: "analizLks");

            migrationBuilder.DropTable(
                name: "analizMachis");

            migrationBuilder.DropTable(
                name: "analizMikroskopiyas");

            migrationBuilder.DropTable(
                name: "analizMuhimbelgilars");

            migrationBuilder.DropTable(
                name: "AnalizQondagiGarmonlar");

            migrationBuilder.DropTable(
                name: "analizQontahlilis");

            migrationBuilder.DropTable(
                name: "analizRws");

            migrationBuilder.DropTable(
                name: "analizSarcoptes");

            migrationBuilder.DropTable(
                name: "analizZamburugs");

            migrationBuilder.DropTable(
                name: "ContragentAdditionalPaymentBefohand");

            migrationBuilder.DropTable(
                name: "ContragentAdditionalPaymentBefohandDetail");

            migrationBuilder.DropTable(
                name: "ContragentAdditionalPaymentBefohandFullInfo");

            migrationBuilder.DropTable(
                name: "ContragentServiceTypeBonusAdditanaly");

            migrationBuilder.DropTable(
                name: "customContragentReports");

            migrationBuilder.DropTable(
                name: "datchikItems");

            migrationBuilder.DropTable(
                name: "datchikRealValues");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "ErpBatchNumberSequnce");

            migrationBuilder.DropTable(
                name: "ErpBatchStageDetail");

            migrationBuilder.DropTable(
                name: "ErpCategoryDetail");

            migrationBuilder.DropTable(
                name: "ErpCharacteristicsProductDetail");

            migrationBuilder.DropTable(
                name: "ErpColorVariantRecipe");

            migrationBuilder.DropTable(
                name: "ErpColumnConfig");

            migrationBuilder.DropTable(
                name: "ErpLanguage");

            migrationBuilder.DropTable(
                name: "ErpOrderItemReserve");

            migrationBuilder.DropTable(
                name: "ErpPlanningTypeProductDetail");

            migrationBuilder.DropTable(
                name: "ErpProccessAndProccessStage");

            migrationBuilder.DropTable(
                name: "ErpProccessDetail");

            migrationBuilder.DropTable(
                name: "FIleChecker");

            migrationBuilder.DropTable(
                name: "HospitalContragentDebitPaymentReport");

            migrationBuilder.DropTable(
                name: "HospitalContragentNotifierReport");

            migrationBuilder.DropTable(
                name: "HospitalDailyKassirReport");

            migrationBuilder.DropTable(
                name: "HospitalFullInfo");

            migrationBuilder.DropTable(
                name: "HospitalManagerReport");

            migrationBuilder.DropTable(
                name: "HospitalMrtSorovNoma");

            migrationBuilder.DropTable(
                name: "HospitalRegistrationPermissionDoctors");

            migrationBuilder.DropTable(
                name: "HospitalServiceRecipe");

            migrationBuilder.DropTable(
                name: "HospitalServiceTypeByGroupPermission");

            migrationBuilder.DropTable(
                name: "HospitalServiceTypeGroupContragentReports");

            migrationBuilder.DropTable(
                name: "HospitalTelegramBotManager");

            migrationBuilder.DropTable(
                name: "HospitelRequiredServiceTypesAllPatcientsAndNotPatcients");

            migrationBuilder.DropTable(
                name: "ilnesses");

            migrationBuilder.DropTable(
                name: "MarketAuthLimitByMoneyDetail");

            migrationBuilder.DropTable(
                name: "MarketAuthLimitByProductDetail");

            migrationBuilder.DropTable(
                name: "MarketClientInfo");

            migrationBuilder.DropTable(
                name: "MarketLimitCustomItem");

            migrationBuilder.DropTable(
                name: "MarketNeedToPayToAgentDetail");

            migrationBuilder.DropTable(
                name: "MarketOrderDeliveriedInfo");

            migrationBuilder.DropTable(
                name: "MarketOrderFullOrderedProducts");

            migrationBuilder.DropTable(
                name: "MarketPayments");

            migrationBuilder.DropTable(
                name: "MarketPrePaidMoney");

            migrationBuilder.DropTable(
                name: "MarketProductGroupDetail");

            migrationBuilder.DropTable(
                name: "MarketProductPrice");

            migrationBuilder.DropTable(
                name: "MarketProductRealQty");

            migrationBuilder.DropTable(
                name: "MarketProductRealQtyTemp");

            migrationBuilder.DropTable(
                name: "MarketProfitCustomReport");

            migrationBuilder.DropTable(
                name: "PatientRecipeByDoctor");

            migrationBuilder.DropTable(
                name: "patientRegistrationInfos");

            migrationBuilder.DropTable(
                name: "PaymentRoomsItem");

            migrationBuilder.DropTable(
                name: "PaymentRoomsServiceTypesItemInfo");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "returnMoney");

            migrationBuilder.DropTable(
                name: "RoomBooking");

            migrationBuilder.DropTable(
                name: "roomColectionInformations");

            migrationBuilder.DropTable(
                name: "ServiceTypeDetail");

            migrationBuilder.DropTable(
                name: "SkudDoorCheckinout");

            migrationBuilder.DropTable(
                name: "SkudDoors");

            migrationBuilder.DropTable(
                name: "SkudFaces");

            migrationBuilder.DropTable(
                name: "SkudForTrenajor");

            migrationBuilder.DropTable(
                name: "SkudGrForEmp");

            migrationBuilder.DropTable(
                name: "SkudGroupAccess");

            migrationBuilder.DropTable(
                name: "SkudImages");

            migrationBuilder.DropTable(
                name: "SkudLk");

            migrationBuilder.DropTable(
                name: "SkudMyCheckinout");

            migrationBuilder.DropTable(
                name: "SkudMyDepartments");

            migrationBuilder.DropTable(
                name: "SkudPeriod");

            migrationBuilder.DropTable(
                name: "SkudPictureCheckinout");

            migrationBuilder.DropTable(
                name: "SkudResultGr");

            migrationBuilder.DropTable(
                name: "SkudSababli");

            migrationBuilder.DropTable(
                name: "SkudSmena");

            migrationBuilder.DropTable(
                name: "SkudTablename");

            migrationBuilder.DropTable(
                name: "tex_batch");

            migrationBuilder.DropTable(
                name: "tex_category");

            migrationBuilder.DropTable(
                name: "tex_colorvariant_recipe");

            migrationBuilder.DropTable(
                name: "tex_column_config");

            migrationBuilder.DropTable(
                name: "tex_column_config_raw");

            migrationBuilder.DropTable(
                name: "tex_device_sub_proccess_detail");

            migrationBuilder.DropTable(
                name: "tex_invoice_item");

            migrationBuilder.DropTable(
                name: "tex_language");

            migrationBuilder.DropTable(
                name: "tex_planning_type");

            migrationBuilder.DropTable(
                name: "tex_real_product_remain");

            migrationBuilder.DropTable(
                name: "tex_xaraktersitika_tool");

            migrationBuilder.DropTable(
                name: "VozvratAlreadyPaidPaymentList");

            migrationBuilder.DropTable(
                name: "accessMenus");

            migrationBuilder.DropTable(
                name: "menuItems");

            migrationBuilder.DropTable(
                name: "colors");

            migrationBuilder.DropTable(
                name: "datchiks");

            migrationBuilder.DropTable(
                name: "ErpBatchDetail");

            migrationBuilder.DropTable(
                name: "ErpBatchStage");

            migrationBuilder.DropTable(
                name: "ErpDesignVariant");

            migrationBuilder.DropTable(
                name: "ErpCharacteristicsDetail");

            migrationBuilder.DropTable(
                name: "ErpInvoiceItem");

            migrationBuilder.DropTable(
                name: "ErpPlanningType");

            migrationBuilder.DropTable(
                name: "MarketAuthLimitByMoney");

            migrationBuilder.DropTable(
                name: "MarketAuthLimitByProduct");

            migrationBuilder.DropTable(
                name: "MarketNeedToPayToAgents");

            migrationBuilder.DropTable(
                name: "MarketInvoiceItem");

            migrationBuilder.DropTable(
                name: "MarketProductGroup");

            migrationBuilder.DropTable(
                name: "MarketOrderDetail");

            migrationBuilder.DropTable(
                name: "patientServiceTypes");

            migrationBuilder.DropTable(
                name: "patientTypes");

            migrationBuilder.DropTable(
                name: "PaymentRoomsServiceTypesItem");

            migrationBuilder.DropTable(
                name: "contragents");

            migrationBuilder.DropTable(
                name: "tex_measurment_type");

            migrationBuilder.DropTable(
                name: "type_product");

            migrationBuilder.DropTable(
                name: "tex_color_proccess");

            migrationBuilder.DropTable(
                name: "tex_sub_proccess");

            migrationBuilder.DropTable(
                name: "tex_invoice");

            migrationBuilder.DropTable(
                name: "tex_order_item");

            migrationBuilder.DropTable(
                name: "tex_sort");

            migrationBuilder.DropTable(
                name: "tex_status");

            migrationBuilder.DropTable(
                name: "tex_upakovka");

            migrationBuilder.DropTable(
                name: "tex_xarakteristika");

            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "ErpBatchprocess");

            migrationBuilder.DropTable(
                name: "ErpColorDepth");

            migrationBuilder.DropTable(
                name: "ErpPackaging");

            migrationBuilder.DropTable(
                name: "ErpBatch");

            migrationBuilder.DropTable(
                name: "ErpBatchRecipeUnion");

            migrationBuilder.DropTable(
                name: "ErpProccessStage");

            migrationBuilder.DropTable(
                name: "ErpCharacteristics");

            migrationBuilder.DropTable(
                name: "ErpExtraWork");

            migrationBuilder.DropTable(
                name: "ErpInvoice");

            migrationBuilder.DropTable(
                name: "ErpOrder");

            migrationBuilder.DropTable(
                name: "ErpSort");

            migrationBuilder.DropTable(
                name: "ErpSuroviyVid");

            migrationBuilder.DropTable(
                name: "ErpUpakopka");

            migrationBuilder.DropTable(
                name: "MarketInvoice");

            migrationBuilder.DropTable(
                name: "MarketOrder");

            migrationBuilder.DropTable(
                name: "MarketProduct");

            migrationBuilder.DropTable(
                name: "PaymentRooms");

            migrationBuilder.DropTable(
                name: "serviceTypes");

            migrationBuilder.DropTable(
                name: "tex_device");

            migrationBuilder.DropTable(
                name: "tex_calctype");

            migrationBuilder.DropTable(
                name: "tex_invoice_type");

            migrationBuilder.DropTable(
                name: "tex_payment_type");

            migrationBuilder.DropTable(
                name: "tex_sklad");

            migrationBuilder.DropTable(
                name: "tex_colorvariant");

            migrationBuilder.DropTable(
                name: "tex_extra_work");

            migrationBuilder.DropTable(
                name: "tex_main_prossess");

            migrationBuilder.DropTable(
                name: "tex_order");

            migrationBuilder.DropTable(
                name: "tex_service_type");

            migrationBuilder.DropTable(
                name: "tex_suroviy_vid");

            migrationBuilder.DropTable(
                name: "ErpColorVariant");

            migrationBuilder.DropTable(
                name: "ErpEquipment");

            migrationBuilder.DropTable(
                name: "ErpCalcType");

            migrationBuilder.DropTable(
                name: "ErpInvoiceStatus");

            migrationBuilder.DropTable(
                name: "ErpInvoiceType");

            migrationBuilder.DropTable(
                name: "ErpPaymentType");

            migrationBuilder.DropTable(
                name: "ErpServiceType");

            migrationBuilder.DropTable(
                name: "ErpWarehouse");

            migrationBuilder.DropTable(
                name: "ErpCurrency");

            migrationBuilder.DropTable(
                name: "MarketAgent");

            migrationBuilder.DropTable(
                name: "authorizations");

            migrationBuilder.DropTable(
                name: "MarketUnitMeasurment");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "HospitalServiceTypeGroup");

            migrationBuilder.DropTable(
                name: "tex_device_type");

            migrationBuilder.DropTable(
                name: "tex_batchprocess");

            migrationBuilder.DropTable(
                name: "tex_color");

            migrationBuilder.DropTable(
                name: "tex_color_variant_type");

            migrationBuilder.DropTable(
                name: "tex_guscolor");

            migrationBuilder.DropTable(
                name: "tex_product");

            migrationBuilder.DropTable(
                name: "tex_valyuta");

            migrationBuilder.DropTable(
                name: "ErpColor");

            migrationBuilder.DropTable(
                name: "ErpColorGustota");

            migrationBuilder.DropTable(
                name: "ErpColorVariantType");

            migrationBuilder.DropTable(
                name: "ErpProccess");

            migrationBuilder.DropTable(
                name: "ErpProduct");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropTable(
                name: "tex_color_group");

            migrationBuilder.DropTable(
                name: "tex_production_type");

            migrationBuilder.DropTable(
                name: "tex_unit_measurment");

            migrationBuilder.DropTable(
                name: "ErpColorGroup");

            migrationBuilder.DropTable(
                name: "ErpCategory");

            migrationBuilder.DropTable(
                name: "ErpPruductionType");

            migrationBuilder.DropTable(
                name: "ErpUnitmeasurment");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "provinces");

            migrationBuilder.DropTable(
                name: "ErpProductType");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "tex_contragent");

            migrationBuilder.DropTable(
                name: "tex_user");

            migrationBuilder.DropTable(
                name: "tex_department");

            migrationBuilder.DropTable(
                name: "tex_position");

            migrationBuilder.DropTable(
                name: "tex_authorization");
        }
    }
}
