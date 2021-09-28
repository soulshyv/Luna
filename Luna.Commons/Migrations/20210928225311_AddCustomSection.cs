using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class AddCustomSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_entity_luna_rpg_character_character_id",
                table: "luna_rpg_custom_entity");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_entity_luna_rpg_race_race_id",
                table: "luna_rpg_custom_entity");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_entity_luna_rpg_custom_property_type_type_id",
                table: "luna_rpg_custom_entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_luna_rpg_custom_entity",
                table: "luna_rpg_custom_entity");

            migrationBuilder.RenameTable(
                name: "luna_rpg_custom_entity",
                newName: "luna_rpg_custom_property");

            migrationBuilder.RenameColumn(
                name: "character_id",
                table: "luna_rpg_custom_property",
                newName: "section_id");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_entity_type_id",
                table: "luna_rpg_custom_property",
                newName: "IX_luna_rpg_custom_property_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_entity_race_id",
                table: "luna_rpg_custom_property",
                newName: "IX_luna_rpg_custom_property_race_id");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_entity_character_id",
                table: "luna_rpg_custom_property",
                newName: "IX_luna_rpg_custom_property_section_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_luna_rpg_custom_property",
                table: "luna_rpg_custom_property",
                column: "id");

            migrationBuilder.CreateTable(
                name: "luna_rpg_custom_section",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<byte[]>(type: "blob", nullable: true),
                    character_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_rpg_custom_section", x => x.id);
                    table.ForeignKey(
                        name: "FK_luna_rpg_custom_section_luna_rpg_character_character_id",
                        column: x => x.character_id,
                        principalTable: "luna_rpg_character",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_section_character_id",
                table: "luna_rpg_custom_section",
                column: "character_id");

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_luna_rpg_custom_section_section_id",
                table: "luna_rpg_custom_property",
                column: "section_id",
                principalTable: "luna_rpg_custom_section",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_luna_rpg_race_race_id",
                table: "luna_rpg_custom_property",
                column: "race_id",
                principalTable: "luna_rpg_race",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_luna_rpg_custom_property_type_type_~",
                table: "luna_rpg_custom_property",
                column: "type_id",
                principalTable: "luna_rpg_custom_property_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_luna_rpg_custom_section_section_id",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_luna_rpg_race_race_id",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_luna_rpg_custom_property_type_type_~",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropTable(
                name: "luna_rpg_custom_section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_luna_rpg_custom_property",
                table: "luna_rpg_custom_property");

            migrationBuilder.RenameTable(
                name: "luna_rpg_custom_property",
                newName: "luna_rpg_custom_entity");

            migrationBuilder.RenameColumn(
                name: "section_id",
                table: "luna_rpg_custom_entity",
                newName: "character_id");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_property_type_id",
                table: "luna_rpg_custom_entity",
                newName: "IX_luna_rpg_custom_entity_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_property_race_id",
                table: "luna_rpg_custom_entity",
                newName: "IX_luna_rpg_custom_entity_race_id");

            migrationBuilder.RenameIndex(
                name: "IX_luna_rpg_custom_property_section_id",
                table: "luna_rpg_custom_entity",
                newName: "IX_luna_rpg_custom_entity_character_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_luna_rpg_custom_entity",
                table: "luna_rpg_custom_entity",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_entity_luna_rpg_character_character_id",
                table: "luna_rpg_custom_entity",
                column: "character_id",
                principalTable: "luna_rpg_character",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_entity_luna_rpg_race_race_id",
                table: "luna_rpg_custom_entity",
                column: "race_id",
                principalTable: "luna_rpg_race",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_entity_luna_rpg_custom_property_type_type_id",
                table: "luna_rpg_custom_entity",
                column: "type_id",
                principalTable: "luna_rpg_custom_property_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
