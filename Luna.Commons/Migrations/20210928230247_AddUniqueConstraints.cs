using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class AddUniqueConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_property_type_nom",
                table: "luna_rpg_custom_property_type",
                column: "nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_character_type_nom",
                table: "luna_rpg_character_type",
                column: "nom",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_custom_property_type_nom",
                table: "luna_rpg_custom_property_type");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_character_type_nom",
                table: "luna_rpg_character_type");
        }
    }
}
