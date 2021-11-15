using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class MauvaisNomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "luna_rpg_custom_property_has_custom_field");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_property_has_custom_property_user_id",
                table: "luna_rpg_custom_property_has_custom_field",
                newName: "IX_luna_rpg_custom_property_has_custom_field_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_property_has_custom_property_property_id",
                table: "luna_rpg_custom_property_has_custom_field",
                newName: "IX_luna_rpg_custom_property_has_custom_field_property_id");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_property_has_custom_property_field_id",
                table: "luna_rpg_custom_property_has_custom_field",
                newName: "IX_luna_rpg_custom_property_has_custom_field_field_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_luna_rpg_custom_property_has_custom_field",
                table: "luna_rpg_custom_property_has_custom_field",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_field_luna_rpg_custom_fi~",
                table: "luna_rpg_custom_property_has_custom_field",
                column: "field_id",
                principalTable: "luna_rpg_custom_field",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_field_luna_rpg_custom_pr~",
                table: "luna_rpg_custom_property_has_custom_field",
                column: "property_id",
                principalTable: "luna_rpg_custom_property",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_field_luna_identity_user~",
                table: "luna_rpg_custom_property_has_custom_field",
                column: "user_id",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_field_luna_rpg_custom_fi~",
                table: "luna_rpg_custom_property_has_custom_field");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_field_luna_rpg_custom_pr~",
                table: "luna_rpg_custom_property_has_custom_field");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_field_luna_identity_user~",
                table: "luna_rpg_custom_property_has_custom_field");

            migrationBuilder.DropPrimaryKey(
                name: "PK_luna_rpg_custom_property_has_custom_field",
                table: "luna_rpg_custom_property_has_custom_field");

            migrationBuilder.RenameTable(
                name: "luna_rpg_custom_property_has_custom_field",
                newName: "luna_rpg_custom_property_has_custom_property");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_property_has_custom_field_user_id",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "IX_luna_rpg_custom_property_has_custom_property_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_property_has_custom_field_property_id",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "IX_luna_rpg_custom_property_has_custom_property_property_id");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_property_has_custom_field_field_id",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "IX_luna_rpg_custom_property_has_custom_property_field_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_luna_rpg_custom_property_has_custom_property",
                table: "luna_rpg_custom_property_has_custom_property",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_property_luna_rpg_custom~",
                table: "luna_rpg_custom_property_has_custom_property",
                column: "field_id",
                principalTable: "luna_rpg_custom_field",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_property_luna_rpg_custo~1",
                table: "luna_rpg_custom_property_has_custom_property",
                column: "property_id",
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
    }
}
