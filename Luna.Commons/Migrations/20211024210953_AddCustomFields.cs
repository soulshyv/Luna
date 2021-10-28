using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class AddCustomFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "unite",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropColumn(
                name: "valeur",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropColumn(
                name: "valeur_max",
                table: "luna_rpg_custom_property");

            migrationBuilder.CreateTable(
                name: "luna_rpg_custom_field",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified = table.Column<DateTime>(type: "datetime", nullable: false),
                    AuthorId = table.Column<Guid>(nullable: true),
                    nom = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<byte[]>(type: "blob", nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: false),
                    valeur = table.Column<byte[]>(type: "blob", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_rpg_custom_field", x => x.id);
                    table.ForeignKey(
                        name: "FK_luna_rpg_custom_field_luna_identity_users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "luna_identity_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_luna_rpg_custom_field_luna_rpg_custom_property_type_type_id",
                        column: x => x.type_id,
                        principalTable: "luna_rpg_custom_property_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_field_AuthorId",
                table: "luna_rpg_custom_field",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_field_type_id",
                table: "luna_rpg_custom_field",
                column: "type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "luna_rpg_custom_field");

            migrationBuilder.AddColumn<string>(
                name: "unite",
                table: "luna_rpg_custom_property",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "valeur",
                table: "luna_rpg_custom_property",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "valeur_max",
                table: "luna_rpg_custom_property",
                type: "int",
                nullable: true);
        }
    }
}
