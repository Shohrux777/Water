using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class indrd534534543 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tex_sub_proccess_tex_device_TexDeviceid",
                table: "tex_sub_proccess");

            migrationBuilder.DropIndex(
                name: "IX_tex_sub_proccess_TexDeviceid",
                table: "tex_sub_proccess");

            migrationBuilder.DropColumn(
                name: "TexDeviceid",
                table: "tex_sub_proccess");

            migrationBuilder.CreateTable(
                name: "hospital_bioximya_krov",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    alt = table.Column<string>(type: "text", nullable: true),
                    act = table.Column<string>(type: "text", nullable: true),
                    tb = table.Column<string>(type: "text", nullable: true),
                    db = table.Column<string>(type: "text", nullable: true),
                    tp = table.Column<string>(type: "text", nullable: true),
                    glu = table.Column<string>(type: "text", nullable: true),
                    krea = table.Column<string>(type: "text", nullable: true),
                    bun = table.Column<string>(type: "text", nullable: true),
                    tc = table.Column<string>(type: "text", nullable: true),
                    hdl_c = table.Column<string>(type: "text", nullable: true),
                    ldl_c = table.Column<string>(type: "text", nullable: true),
                    ca = table.Column<string>(type: "text", nullable: true),
                    amylase = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_bioximya_krov", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_bioximya_krov_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_covid_express",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    result = table.Column<string>(type: "text", nullable: true),
                    date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_covid_express", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_covid_express_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_covid_qon",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    method_check = table.Column<string>(type: "text", nullable: true),
                    result_lgg = table.Column<string>(type: "text", nullable: true),
                    result_lgm = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_covid_qon", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_covid_qon_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_express_gepatit_bc",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    gepatit_b = table.Column<string>(type: "text", nullable: true),
                    gepatit_c = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_express_gepatit_bc", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_express_gepatit_bc_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_gepatit_bc",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    hbsag = table.Column<string>(type: "text", nullable: true),
                    anti_hgv = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_gepatit_bc", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_gepatit_bc_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_koagulogramma",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    index_pt = table.Column<string>(type: "text", nullable: true),
                    vremya_pt = table.Column<string>(type: "text", nullable: true),
                    isi = table.Column<string>(type: "text", nullable: true),
                    fib = table.Column<string>(type: "text", nullable: true),
                    achtb = table.Column<string>(type: "text", nullable: true),
                    tt = table.Column<string>(type: "text", nullable: true),
                    diametr = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_koagulogramma", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_koagulogramma_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_mazok",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    leykositi_vagina = table.Column<string>(type: "text", nullable: true),
                    ploskiy_epiteliy_vagina = table.Column<string>(type: "text", nullable: true),
                    gonokokki_vagina = table.Column<string>(type: "text", nullable: true),
                    trixomonadi_vagina = table.Column<string>(type: "text", nullable: true),
                    kluchoviy_kletki_vagina = table.Column<string>(type: "text", nullable: true),
                    drojji_vagina = table.Column<string>(type: "text", nullable: true),
                    mikroflora_vagina = table.Column<string>(type: "text", nullable: true),
                    sliz_vagina = table.Column<string>(type: "text", nullable: true),
                    leykositi_serviks = table.Column<string>(type: "text", nullable: true),
                    ploskiy_epiteliy_serviks = table.Column<string>(type: "text", nullable: true),
                    gonokokki_serviks = table.Column<string>(type: "text", nullable: true),
                    trixomonadi_serviks = table.Column<string>(type: "text", nullable: true),
                    kluchoviy_kletki_serviks = table.Column<string>(type: "text", nullable: true),
                    drojji_serviks = table.Column<string>(type: "text", nullable: true),
                    mikroflora_serviks = table.Column<string>(type: "text", nullable: true),
                    sliz_serviks = table.Column<string>(type: "text", nullable: true),
                    leykositi_uretra = table.Column<string>(type: "text", nullable: true),
                    ploskiy_epiteliy_uretra = table.Column<string>(type: "text", nullable: true),
                    gonokokki_uretra = table.Column<string>(type: "text", nullable: true),
                    trixomonadi_uretra = table.Column<string>(type: "text", nullable: true),
                    kluchoviy_kletki_uretra = table.Column<string>(type: "text", nullable: true),
                    drojji_uretra = table.Column<string>(type: "text", nullable: true),
                    mikroflora_uretra = table.Column<string>(type: "text", nullable: true),
                    sliz_uretra = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_mazok", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_mazok_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_nechiporenko",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    leykositi = table.Column<string>(type: "text", nullable: true),
                    eritrositi = table.Column<string>(type: "text", nullable: true),
                    silindri = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_nechiporenko", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_nechiporenko_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_onkomarker",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    pca = table.Column<string>(type: "text", nullable: true),
                    ca_15_3 = table.Column<string>(type: "text", nullable: true),
                    ca_125 = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_onkomarker", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_onkomarker_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_peshob",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    kolichestva = table.Column<string>(type: "text", nullable: true),
                    svet = table.Column<string>(type: "text", nullable: true),
                    leykositi = table.Column<string>(type: "text", nullable: true),
                    nitriti = table.Column<string>(type: "text", nullable: true),
                    urobilinogen = table.Column<string>(type: "text", nullable: true),
                    belot = table.Column<string>(type: "text", nullable: true),
                    kislotnost = table.Column<string>(type: "text", nullable: true),
                    krov = table.Column<string>(type: "text", nullable: true),
                    udalleniy_ves = table.Column<string>(type: "text", nullable: true),
                    aseton = table.Column<string>(type: "text", nullable: true),
                    bilirubin = table.Column<string>(type: "text", nullable: true),
                    glyukoza = table.Column<string>(type: "text", nullable: true),
                    askorbinnaya_kislota = table.Column<string>(type: "text", nullable: true),
                    epitoliy_ploskiy = table.Column<string>(type: "text", nullable: true),
                    epitoliy_pochechniy = table.Column<string>(type: "text", nullable: true),
                    epiteliy_promujechotniy = table.Column<string>(type: "text", nullable: true),
                    leykositi2 = table.Column<string>(type: "text", nullable: true),
                    eritoriseti_ne_izminenne = table.Column<string>(type: "text", nullable: true),
                    silindri_geolinoviy = table.Column<string>(type: "text", nullable: true),
                    silindri_zernosti = table.Column<string>(type: "text", nullable: true),
                    silindri_voskovidniy = table.Column<string>(type: "text", nullable: true),
                    sliz = table.Column<string>(type: "text", nullable: true),
                    bakteri = table.Column<string>(type: "text", nullable: true),
                    soli = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_peshob", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_peshob_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_qondagi_garmonlar",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    ttg = table.Column<string>(type: "text", nullable: true),
                    t_4 = table.Column<string>(type: "text", nullable: true),
                    t_4_svabodno = table.Column<string>(type: "text", nullable: true),
                    testosteron = table.Column<string>(type: "text", nullable: true),
                    estradiol = table.Column<string>(type: "text", nullable: true),
                    prolaktin = table.Column<string>(type: "text", nullable: true),
                    fcg = table.Column<string>(type: "text", nullable: true),
                    lg = table.Column<string>(type: "text", nullable: true),
                    progesteron = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_qondagi_garmonlar", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_qondagi_garmonlar_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_remoproba",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    srb = table.Column<string>(type: "text", nullable: true),
                    rf = table.Column<string>(type: "text", nullable: true),
                    aslo = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_remoproba", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_remoproba_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_rv",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    syplhilis_rpr = table.Column<string>(type: "text", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_rv", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_rv_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_torch",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    xlomidin = table.Column<string>(type: "text", nullable: true),
                    toksoplazma = table.Column<string>(type: "text", nullable: true),
                    smb = table.Column<string>(type: "text", nullable: true),
                    vpg = table.Column<string>(type: "text", nullable: true),
                    musorplazma = table.Column<string>(type: "text", nullable: true),
                    rubbella = table.Column<string>(type: "text", nullable: true),
                    ureaplazma = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_torch", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_torch_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_umumiy_qon_taxlili",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    leykositi = table.Column<string>(type: "text", nullable: true),
                    neytrofili = table.Column<string>(type: "text", nullable: true),
                    limfotsi = table.Column<string>(type: "text", nullable: true),
                    monofisitsi = table.Column<string>(type: "text", nullable: true),
                    eozinofili = table.Column<string>(type: "text", nullable: true),
                    bazofili = table.Column<string>(type: "text", nullable: true),
                    neytrofili_2 = table.Column<string>(type: "text", nullable: true),
                    limfotsi_2 = table.Column<string>(type: "text", nullable: true),
                    monofisitsi_2 = table.Column<string>(type: "text", nullable: true),
                    eozinofili_2 = table.Column<string>(type: "text", nullable: true),
                    bazofili_2 = table.Column<string>(type: "text", nullable: true),
                    eritrositi = table.Column<string>(type: "text", nullable: true),
                    gemoglabin = table.Column<string>(type: "text", nullable: true),
                    gemotokrit = table.Column<string>(type: "text", nullable: true),
                    sr_obyom_er = table.Column<string>(type: "text", nullable: true),
                    sr_sod_gem_er = table.Column<string>(type: "text", nullable: true),
                    sr_kons_gem_er = table.Column<string>(type: "text", nullable: true),
                    shir_ras_er_gem = table.Column<string>(type: "text", nullable: true),
                    shir_ras_er_po_obyom = table.Column<string>(type: "text", nullable: true),
                    trobositi = table.Column<string>(type: "text", nullable: true),
                    sredniy_obyom_trombositov = table.Column<string>(type: "text", nullable: true),
                    shir_rasm_tromb_po_obyom = table.Column<string>(type: "text", nullable: true),
                    trombokrit = table.Column<string>(type: "text", nullable: true),
                    aly = table.Column<string>(type: "text", nullable: true),
                    lic = table.Column<string>(type: "text", nullable: true),
                    aly_2 = table.Column<string>(type: "text", nullable: true),
                    lic_2 = table.Column<string>(type: "text", nullable: true),
                    skorst_osedaniy_eritrositov = table.Column<string>(type: "text", nullable: true),
                    qon_ivish_begin_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    qon_ivish_end_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_umumiy_qon_taxlili", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_umumiy_qon_taxlili_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_vsk",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_name = table.Column<string>(type: "text", nullable: true),
                    h = table.Column<string>(type: "text", nullable: true),
                    k = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientsId = table.Column<long>(type: "bigint", nullable: false),
                    doctor_name = table.Column<string>(type: "text", nullable: true),
                    creator_doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_vsk", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospital_vsk_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tex_product_category_id",
                table: "tex_product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_bioximya_krov_PatientsId",
                table: "hospital_bioximya_krov",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_covid_express_PatientsId",
                table: "hospital_covid_express",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_covid_qon_PatientsId",
                table: "hospital_covid_qon",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_express_gepatit_bc_PatientsId",
                table: "hospital_express_gepatit_bc",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_gepatit_bc_PatientsId",
                table: "hospital_gepatit_bc",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_koagulogramma_PatientsId",
                table: "hospital_koagulogramma",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_mazok_PatientsId",
                table: "hospital_mazok",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_nechiporenko_PatientsId",
                table: "hospital_nechiporenko",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_onkomarker_PatientsId",
                table: "hospital_onkomarker",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_peshob_PatientsId",
                table: "hospital_peshob",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_qondagi_garmonlar_PatientsId",
                table: "hospital_qondagi_garmonlar",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_remoproba_PatientsId",
                table: "hospital_remoproba",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_rv_PatientsId",
                table: "hospital_rv",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_torch_PatientsId",
                table: "hospital_torch",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_umumiy_qon_taxlili_PatientsId",
                table: "hospital_umumiy_qon_taxlili",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_vsk_PatientsId",
                table: "hospital_vsk",
                column: "PatientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_tex_product_tex_category_category_id",
                table: "tex_product",
                column: "category_id",
                principalTable: "tex_category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tex_product_tex_category_category_id",
                table: "tex_product");

            migrationBuilder.DropTable(
                name: "hospital_bioximya_krov");

            migrationBuilder.DropTable(
                name: "hospital_covid_express");

            migrationBuilder.DropTable(
                name: "hospital_covid_qon");

            migrationBuilder.DropTable(
                name: "hospital_express_gepatit_bc");

            migrationBuilder.DropTable(
                name: "hospital_gepatit_bc");

            migrationBuilder.DropTable(
                name: "hospital_koagulogramma");

            migrationBuilder.DropTable(
                name: "hospital_mazok");

            migrationBuilder.DropTable(
                name: "hospital_nechiporenko");

            migrationBuilder.DropTable(
                name: "hospital_onkomarker");

            migrationBuilder.DropTable(
                name: "hospital_peshob");

            migrationBuilder.DropTable(
                name: "hospital_qondagi_garmonlar");

            migrationBuilder.DropTable(
                name: "hospital_remoproba");

            migrationBuilder.DropTable(
                name: "hospital_rv");

            migrationBuilder.DropTable(
                name: "hospital_torch");

            migrationBuilder.DropTable(
                name: "hospital_umumiy_qon_taxlili");

            migrationBuilder.DropTable(
                name: "hospital_vsk");

            migrationBuilder.DropIndex(
                name: "IX_tex_product_category_id",
                table: "tex_product");

            migrationBuilder.AddColumn<long>(
                name: "TexDeviceid",
                table: "tex_sub_proccess",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tex_sub_proccess_TexDeviceid",
                table: "tex_sub_proccess",
                column: "TexDeviceid");

            migrationBuilder.AddForeignKey(
                name: "FK_tex_sub_proccess_tex_device_TexDeviceid",
                table: "tex_sub_proccess",
                column: "TexDeviceid",
                principalTable: "tex_device",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
