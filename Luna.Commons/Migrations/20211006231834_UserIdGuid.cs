using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class UserIdGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "luna_rpg_race",
                type: "char(32)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "luna_rpg_custom_section",
                type: "char(32)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "luna_rpg_custom_property_type",
                type: "char(32)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "luna_rpg_custom_property",
                type: "char(32)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "luna_rpg_character_type",
                type: "char(32)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "luna_rpg_character",
                type: "char(32)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Userid",
                table: "GedDocument",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "luna_rpg_race",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(32)");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "luna_rpg_custom_section",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(32)");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "luna_rpg_custom_property_type",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(32)");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "luna_rpg_custom_property",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(32)");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "luna_rpg_character_type",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(32)");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "luna_rpg_character",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(32)");

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "GedDocument",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid));
        }
    }
}
