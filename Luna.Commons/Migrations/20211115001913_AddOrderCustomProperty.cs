using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class AddOrderCustomProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "order",
                table: "luna_rpg_custom_property",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order",
                table: "luna_rpg_custom_property");
        }
    }
}
