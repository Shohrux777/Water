using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ErpColorGroup");

            migrationBuilder.DropTable(
                name: "ErpCategory");

            migrationBuilder.DropTable(
                name: "ErpPruductionType");

            migrationBuilder.DropTable(
                name: "ErpUnitmeasurment");

            migrationBuilder.DropTable(
                name: "ErpProductType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErpBatchNumberSequnce",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Number = table.Column<long>(type: "bigint", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameForPrint = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    dyingType = table.Column<int>(type: "integer", nullable: false),
                    maxcolorpercent = table.Column<double>(type: "double precision", nullable: false),
                    mincolorpercent = table.Column<double>(type: "double precision", nullable: false)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    GeneratedValue = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    GCode = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpColorVariantType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpColumnConfig",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorizationId = table.Column<long>(type: "bigint", nullable: false),
                    columnListJson = table.Column<string>(type: "jsonb", nullable: true),
                    tableName = table.Column<string>(type: "text", nullable: true)
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
                name: "ErpCurrency",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    CurrentDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Difference = table.Column<string>(type: "text", nullable: true),
                    Forbuy = table.Column<string>(type: "text", nullable: true),
                    Forsale = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Nominal = table.Column<string>(type: "text", nullable: true)
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
                name: "ErpEquipment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                name: "ErpExtraWork",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpPackaging",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    cardnumber = table.Column<string>(type: "text", nullable: true),
                    length = table.Column<double>(type: "double precision", nullable: false),
                    max_length = table.Column<double>(type: "double precision", nullable: false),
                    min_length = table.Column<double>(type: "double precision", nullable: false)
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
                name: "ErpPaymentType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpUpakopka", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErpWarehouse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                name: "ErpCharacteristicsDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpCharacteristicsId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameForPrint = table.Column<string>(type: "text", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ColorCode = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    DieingCode = table.Column<string>(type: "text", nullable: true),
                    ErpColorGroupId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PantoneCode = table.Column<string>(type: "text", nullable: true)
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
                name: "ErpOrder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    ErpCurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    beginDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    clientCompanyId = table.Column<long>(type: "bigint", nullable: false),
                    createdAuthId = table.Column<long>(type: "bigint", nullable: false),
                    currencyValue = table.Column<double>(type: "double precision", nullable: false),
                    endDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    mainCompanyId = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    orderNumber = table.Column<string>(type: "text", nullable: true),
                    updateAuthId = table.Column<long>(type: "bigint", nullable: false)
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
                name: "ErpBatchRecipeUnion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpEquipmentId = table.Column<long>(type: "bigint", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ratio = table.Column<double>(type: "double precision", nullable: false),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                name: "ErpProccessAndProccessStage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpProccessId = table.Column<long>(type: "bigint", nullable: false),
                    ErpProccessStageId = table.Column<long>(type: "bigint", nullable: false),
                    sort = table.Column<int>(type: "integer", nullable: false)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpProductTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                name: "ErpInvoice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    ErpCalcTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ErpCurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    ErpInvoiceStatusId = table.Column<long>(type: "bigint", nullable: true),
                    ErpInvoiceTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ErpPaymentTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ErpServiceTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ErpWarehouseId = table.Column<long>(type: "bigint", nullable: true),
                    InvcompanyId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    acceptedUser = table.Column<bool>(type: "boolean", nullable: true),
                    count = table.Column<double>(type: "double precision", nullable: true),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    currencyValue = table.Column<double>(type: "double precision", nullable: false),
                    dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    filialCompanyId = table.Column<long>(type: "bigint", nullable: true),
                    invoiceStatusStr = table.Column<string>(type: "text", nullable: true),
                    invoiceTypeStr = table.Column<string>(type: "text", nullable: true),
                    mainCompanyId = table.Column<long>(type: "bigint", nullable: true),
                    mainDepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    mainWarehouseId = table.Column<long>(type: "bigint", nullable: true),
                    realCount = table.Column<double>(type: "double precision", nullable: true),
                    summ = table.Column<double>(type: "double precision", nullable: true)
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
                name: "ErpCategoryDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    ErpCharacteristicsId = table.Column<long>(type: "bigint", nullable: false)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    ErpPruductionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ErpUnitmeasurment2Id = table.Column<long>(type: "bigint", nullable: false),
                    ErpUnitmeasurmentId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PictureStr = table.Column<string>(type: "text", nullable: true)
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
                name: "ErpCharacteristicsProductDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpCharacteristicsDetailId = table.Column<long>(type: "bigint", nullable: false),
                    ErpProductId = table.Column<long>(type: "bigint", nullable: false)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ColorGustotaId = table.Column<long>(type: "bigint", nullable: true),
                    ColorId = table.Column<long>(type: "bigint", nullable: true),
                    ErpColorVariantTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ErpProccessId = table.Column<long>(type: "bigint", nullable: true),
                    ErpProductId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    color_no = table.Column<int>(type: "integer", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    dateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    parentColorVariantId = table.Column<long>(type: "bigint", nullable: true),
                    rpt_sequence = table.Column<int>(type: "integer", nullable: false),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpPlanningTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ErpProductId = table.Column<long>(type: "bigint", nullable: false)
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
                name: "ErpBatch",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpColorId = table.Column<long>(type: "bigint", nullable: true),
                    ErpColorVariantId = table.Column<long>(type: "bigint", nullable: true),
                    ErpEquipmentId = table.Column<long>(type: "bigint", nullable: false),
                    batchNumber = table.Column<string>(type: "text", nullable: true),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdUserId = table.Column<long>(type: "bigint", nullable: true),
                    editedUserId = table.Column<long>(type: "bigint", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true),
                    printedCount = table.Column<long>(type: "bigint", nullable: true),
                    printedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    printedUserId = table.Column<long>(type: "bigint", nullable: true),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    years = table.Column<int>(type: "integer", nullable: false)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAuthId = table.Column<long>(type: "bigint", nullable: false),
                    ErpColorVariantId = table.Column<long>(type: "bigint", nullable: true),
                    ErpProductId = table.Column<long>(type: "bigint", nullable: true),
                    ErpUnitmeasurmentId = table.Column<long>(type: "bigint", nullable: true),
                    colorvariant_recipestage_id = table.Column<int>(type: "integer", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false)
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
                name: "ErpInvoiceItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpColorGustotaId = table.Column<long>(type: "bigint", nullable: true),
                    ErpColorId = table.Column<long>(type: "bigint", nullable: true),
                    ErpColorVariantId = table.Column<long>(type: "bigint", nullable: true),
                    ErpExtraWorkId = table.Column<long>(type: "bigint", nullable: true),
                    ErpInvoiceId = table.Column<long>(type: "bigint", nullable: true),
                    ErpInvoiceItemId = table.Column<long>(type: "bigint", nullable: true),
                    ErpInvoiceStatusId = table.Column<long>(type: "bigint", nullable: true),
                    ErpInvoiceTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ErpOrderId = table.Column<long>(type: "bigint", nullable: true),
                    ErpProccessId = table.Column<long>(type: "bigint", nullable: true),
                    ErpProductId = table.Column<long>(type: "bigint", nullable: true),
                    ErpSortId = table.Column<long>(type: "bigint", nullable: true),
                    ErpSuroviyVidId = table.Column<long>(type: "bigint", nullable: true),
                    ErpUpakopkaId = table.Column<long>(type: "bigint", nullable: true),
                    brack = table.Column<double>(type: "double precision", nullable: false),
                    brutto = table.Column<double>(type: "double precision", nullable: false),
                    erpInvoiceItemId = table.Column<long>(type: "bigint", nullable: true),
                    fein = table.Column<string>(type: "text", nullable: true),
                    gramm = table.Column<string>(type: "text", nullable: true),
                    itemStatusStr = table.Column<string>(type: "text", nullable: true),
                    metraj = table.Column<string>(type: "text", nullable: true),
                    netto = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    priceSale = table.Column<double>(type: "double precision", nullable: false),
                    pus = table.Column<string>(type: "text", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    qty2 = table.Column<string>(type: "text", nullable: true),
                    realCount = table.Column<double>(type: "double precision", nullable: false),
                    shirina = table.Column<string>(type: "text", nullable: true),
                    summ = table.Column<double>(type: "double precision", nullable: false),
                    ugar = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "ErpBatchDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpBatchId = table.Column<long>(type: "bigint", nullable: false),
                    ErpBatchprocessId = table.Column<long>(type: "bigint", nullable: true),
                    ErpColorDepthId = table.Column<long>(type: "bigint", nullable: true),
                    ErpPackagingId = table.Column<long>(type: "bigint", nullable: true),
                    ErpProductId = table.Column<long>(type: "bigint", nullable: false),
                    cardnumber = table.Column<string>(type: "text", nullable: true),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    feine = table.Column<double>(type: "double precision", nullable: true),
                    gramm = table.Column<double>(type: "double precision", nullable: false),
                    moved = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    packs = table.Column<double>(type: "double precision", nullable: false),
                    pus = table.Column<double>(type: "double precision", nullable: true),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    qty4 = table.Column<double>(type: "double precision", nullable: false),
                    qty5 = table.Column<double>(type: "double precision", nullable: false),
                    unitmeasurment2Id = table.Column<long>(type: "bigint", nullable: true),
                    unitmeasurment3Id = table.Column<long>(type: "bigint", nullable: true),
                    unitmeasurmentId = table.Column<long>(type: "bigint", nullable: true),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    width = table.Column<double>(type: "double precision", nullable: false)
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
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpBatchId = table.Column<long>(type: "bigint", nullable: false),
                    ErpBatchRecipeUnionId = table.Column<long>(type: "bigint", nullable: true),
                    ErpColorVariantId = table.Column<long>(type: "bigint", nullable: true),
                    ErpEquipmentId = table.Column<long>(type: "bigint", nullable: true),
                    ErpProccessStageId = table.Column<long>(type: "bigint", nullable: false),
                    autoCreated = table.Column<bool>(type: "boolean", nullable: false),
                    batchstagegramm = table.Column<double>(type: "double precision", nullable: false),
                    batchstagesort = table.Column<long>(type: "bigint", nullable: false),
                    confirmStatus = table.Column<bool>(type: "boolean", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    iRepairStatus = table.Column<bool>(type: "boolean", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: true),
                    payStatus = table.Column<bool>(type: "boolean", nullable: false),
                    pressing = table.Column<double>(type: "double precision", nullable: false),
                    printedAuthId = table.Column<long>(type: "bigint", nullable: false),
                    printedCount = table.Column<long>(type: "bigint", nullable: true),
                    printedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ratio = table.Column<double>(type: "double precision", nullable: false),
                    speed = table.Column<double>(type: "double precision", nullable: false),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    valume = table.Column<double>(type: "double precision", nullable: false)
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
                name: "ErpOrderItemReserve",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpOrderId = table.Column<long>(type: "bigint", nullable: false),
                    orderdedMainItemId = table.Column<long>(type: "bigint", nullable: false),
                    qty = table.Column<double>(type: "double precision", nullable: false),
                    reservedInvoiceItemId = table.Column<long>(type: "bigint", nullable: false)
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
                name: "ErpBatchStageDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ErpBatchDetailId = table.Column<long>(type: "bigint", nullable: true),
                    ErpBatchStageId = table.Column<long>(type: "bigint", nullable: true),
                    ErpColorVariantId = table.Column<long>(type: "bigint", nullable: true),
                    ErpDesignVariantId = table.Column<long>(type: "bigint", nullable: true),
                    ErpEquipmentId = table.Column<long>(type: "bigint", nullable: true),
                    autoCreate = table.Column<bool>(type: "boolean", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    device = table.Column<long>(type: "bigint", nullable: true),
                    entryDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    entryQty = table.Column<double>(type: "double precision", nullable: false),
                    entryUserId = table.Column<long>(type: "bigint", nullable: true),
                    exitDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    exitQty = table.Column<double>(type: "double precision", nullable: false),
                    exitUserId = table.Column<long>(type: "bigint", nullable: true),
                    externalInfo = table.Column<string>(type: "text", nullable: true),
                    externalautomaticsystemstatus = table.Column<int>(type: "integer", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true),
                    updateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedUserId = table.Column<long>(type: "bigint", nullable: false)
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
        }
    }
}
