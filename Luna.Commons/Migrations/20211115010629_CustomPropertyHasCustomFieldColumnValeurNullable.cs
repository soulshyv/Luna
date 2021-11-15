using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class CustomPropertyHasCustomFieldColumnValeurNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "valeur",
                table: "luna_rpg_custom_property_has_custom_field",
                type: "blob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "blob");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "valeur",
                table: "luna_rpg_custom_property_has_custom_field",
                type: "blob",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "blob",
                oldNullable: true);
        }
    }
}
