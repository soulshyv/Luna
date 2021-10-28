using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class AddTableCustomPropertyHasCustomField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomPropertyHasCustomField_luna_rpg_custom_field_FieldId",
                table: "CustomPropertyHasCustomField");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomPropertyHasCustomField_luna_rpg_custom_property_Proper~",
                table: "CustomPropertyHasCustomField");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomPropertyHasCustomField_luna_identity_users_UserId",
                table: "CustomPropertyHasCustomField");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomPropertyHasCustomField",
                table: "CustomPropertyHasCustomField");

            migrationBuilder.DropIndex(
                name: "IX_CustomPropertyHasCustomField_PropertyId",
                table: "CustomPropertyHasCustomField");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "CustomPropertyHasCustomField");

            migrationBuilder.RenameTable(
                name: "CustomPropertyHasCustomField",
                newName: "luna_rpg_custom_property_has_custom_property");

            migrationBuilder.RenameColumn(
                name: "Valeur",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "valeur");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "FieldId",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "type_id");

            migrationBuilder.RenameIndex(
                name: "IX_CustomPropertyHasCustomField_UserId",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "IX_luna_rpg_custom_property_has_custom_property_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_CustomPropertyHasCustomField_FieldId",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "IX_luna_rpg_custom_property_has_custom_property_type_id");

            migrationBuilder.AlterColumn<byte[]>(
                name: "valeur",
                table: "luna_rpg_custom_property_has_custom_property",
                type: "blob",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified",
                table: "luna_rpg_custom_property_has_custom_property",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "luna_rpg_custom_property_has_custom_property",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_luna_rpg_custom_property_has_custom_property",
                table: "luna_rpg_custom_property_has_custom_property",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_property_luna_rpg_custom~",
                table: "luna_rpg_custom_property_has_custom_property",
                column: "type_id",
                principalTable: "luna_rpg_custom_field",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_property_luna_rpg_custo~1",
                table: "luna_rpg_custom_property_has_custom_property",
                column: "type_id",
                principalTable: "luna_rpg_custom_property",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_property_luna_identity_u~",
                table: "luna_rpg_custom_property_has_custom_property",
                column: "user_id",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_property_luna_rpg_custom~",
                table: "luna_rpg_custom_property_has_custom_property");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_property_luna_rpg_custo~1",
                table: "luna_rpg_custom_property_has_custom_property");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_property_luna_identity_u~",
                table: "luna_rpg_custom_property_has_custom_property");

            migrationBuilder.DropPrimaryKey(
                name: "PK_luna_rpg_custom_property_has_custom_property",
                table: "luna_rpg_custom_property_has_custom_property");

            migrationBuilder.RenameTable(
                name: "luna_rpg_custom_property_has_custom_property",
                newName: "CustomPropertyHasCustomField");

            migrationBuilder.RenameColumn(
                name: "valeur",
                table: "CustomPropertyHasCustomField",
                newName: "Valeur");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "CustomPropertyHasCustomField",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "CustomPropertyHasCustomField",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CustomPropertyHasCustomField",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "CustomPropertyHasCustomField",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "CustomPropertyHasCustomField",
                newName: "FieldId");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_property_has_custom_property_user_id",
                table: "CustomPropertyHasCustomField",
                newName: "IX_CustomPropertyHasCustomField_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_property_has_custom_property_type_id",
                table: "CustomPropertyHasCustomField",
                newName: "IX_CustomPropertyHasCustomField_FieldId");

            migrationBuilder.AlterColumn<string>(
                name: "Valeur",
                table: "CustomPropertyHasCustomField",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "blob");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "CustomPropertyHasCustomField",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "CustomPropertyHasCustomField",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "CustomPropertyHasCustomField",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomPropertyHasCustomField",
                table: "CustomPropertyHasCustomField",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomPropertyHasCustomField_PropertyId",
                table: "CustomPropertyHasCustomField",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomPropertyHasCustomField_luna_rpg_custom_field_FieldId",
                table: "CustomPropertyHasCustomField",
                column: "FieldId",
                principalTable: "luna_rpg_custom_field",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomPropertyHasCustomField_luna_rpg_custom_property_Proper~",
                table: "CustomPropertyHasCustomField",
                column: "PropertyId",
                principalTable: "luna_rpg_custom_property",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomPropertyHasCustomField_luna_identity_users_UserId",
                table: "CustomPropertyHasCustomField",
                column: "UserId",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
