using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiAll.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "main_sklad_id",
                table: "tex_sklad",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "end_date",
                table: "tex_order_item",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "pantone_code",
                table: "tex_order_item",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "size_id",
                table: "tex_order_item",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "main_department_id",
                table: "tex_department",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "begin_date",
                table: "tex_batch",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "end_date",
                table: "tex_batch",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "tex_message",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    message = table.Column<string>(type: "text", nullable: true),
                    message_type = table.Column<string>(type: "text", nullable: true),
                    message_date = table.Column<DateTime>(type: "date", nullable: false),
                    message_send_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    message_receved_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    readed_status = table.Column<bool>(type: "boolean", nullable: false),
                    sender_auth_id = table.Column<long>(type: "bigint", nullable: false),
                    recevier_auth_id = table.Column<long>(type: "bigint", nullable: false),
                    friend_auth_id = table.Column<long>(type: "bigint", nullable: false),
                    owner_auth_id = table.Column<long>(type: "bigint", nullable: false),
                    main_message_id = table.Column<long>(type: "bigint", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_message", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_message_group",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    owner_auth_id = table.Column<long>(type: "bigint", nullable: false),
                    friend_auth_id = table.Column<long>(type: "bigint", nullable: false),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_message_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tex_size",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    active_status = table.Column<bool>(type: "boolean", nullable: false),
                    created_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tex_size", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tex_sklad_main_sklad_id",
                table: "tex_sklad",
                column: "main_sklad_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_order_item_size_id",
                table: "tex_order_item",
                column: "size_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_department_main_department_id",
                table: "tex_department",
                column: "main_department_id");

            migrationBuilder.CreateIndex(
                name: "IX_tex_size_name",
                table: "tex_size",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_department_tex_department_main_department_id",
                table: "tex_department",
                column: "main_department_id",
                principalTable: "tex_department",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_order_item_tex_size_size_id",
                table: "tex_order_item",
                column: "size_id",
                principalTable: "tex_size",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tex_sklad_tex_sklad_main_sklad_id",
                table: "tex_sklad",
                column: "main_sklad_id",
                principalTable: "tex_sklad",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tex_department_tex_department_main_department_id",
                table: "tex_department");

            migrationBuilder.DropForeignKey(
                name: "FK_tex_order_item_tex_size_size_id",
                table: "tex_order_item");

            migrationBuilder.DropForeignKey(
                name: "FK_tex_sklad_tex_sklad_main_sklad_id",
                table: "tex_sklad");

            migrationBuilder.DropTable(
                name: "tex_message");

            migrationBuilder.DropTable(
                name: "tex_message_group");

            migrationBuilder.DropTable(
                name: "tex_size");

            migrationBuilder.DropIndex(
                name: "IX_tex_sklad_main_sklad_id",
                table: "tex_sklad");

            migrationBuilder.DropIndex(
                name: "IX_tex_order_item_size_id",
                table: "tex_order_item");

            migrationBuilder.DropIndex(
                name: "IX_tex_department_main_department_id",
                table: "tex_department");

            migrationBuilder.DropColumn(
                name: "main_sklad_id",
                table: "tex_sklad");

            migrationBuilder.DropColumn(
                name: "end_date",
                table: "tex_order_item");

            migrationBuilder.DropColumn(
                name: "pantone_code",
                table: "tex_order_item");

            migrationBuilder.DropColumn(
                name: "size_id",
                table: "tex_order_item");

            migrationBuilder.DropColumn(
                name: "main_department_id",
                table: "tex_department");

            migrationBuilder.DropColumn(
                name: "begin_date",
                table: "tex_batch");

            migrationBuilder.DropColumn(
                name: "end_date",
                table: "tex_batch");
        }
    }
}
