using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class MauvaisNomsColonnes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_property_luna_rpg_custo~1",
                table: "luna_rpg_custom_property_has_custom_property");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "field_id");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_property_has_custom_property_type_id",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "IX_luna_rpg_custom_property_has_custom_property_field_id");

            migrationBuilder.AddColumn<int>(
                name: "property_id",
                table: "luna_rpg_custom_property_has_custom_property",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_property_has_custom_property_property_id",
                table: "luna_rpg_custom_property_has_custom_property",
                column: "property_id");

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_property_luna_rpg_custo~1",
                table: "luna_rpg_custom_property_has_custom_property",
                column: "property_id",
                principalTable: "luna_rpg_custom_property",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_property_luna_rpg_custo~1",
                table: "luna_rpg_custom_property_has_custom_property");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_custom_property_has_custom_property_property_id",
                table: "luna_rpg_custom_property_has_custom_property");

            migrationBuilder.DropColumn(
                name: "property_id",
                table: "luna_rpg_custom_property_has_custom_property");

            migrationBuilder.RenameColumn(
                name: "field_id",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "type_id");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_property_has_custom_property_field_id",
                table: "luna_rpg_custom_property_has_custom_property",
                newName: "IX_luna_rpg_custom_property_has_custom_property_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_has_custom_property_luna_rpg_custo~1",
                table: "luna_rpg_custom_property_has_custom_property",
                column: "type_id",
                principalTable: "luna_rpg_custom_property",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
