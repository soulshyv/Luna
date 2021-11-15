using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class ColonneInexistante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "luna_rpg_custom_property_has_custom_field");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
