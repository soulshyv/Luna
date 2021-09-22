using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "luna_rpg_character_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<byte[]>(type: "blob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_rpg_character_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "luna_rpg_custom_property_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<byte[]>(type: "blob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_rpg_custom_property_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "luna_rpg_race",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<byte[]>(type: "blob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_rpg_race", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "luna_rpg_character",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<byte[]>(type: "blob", nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: false),
                    race_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_rpg_character", x => x.id);
                    table.ForeignKey(
                        name: "FK_luna_rpg_character_luna_rpg_race_race_id",
                        column: x => x.race_id,
                        principalTable: "luna_rpg_race",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_luna_rpg_character_luna_rpg_character_type_type_id",
                        column: x => x.type_id,
                        principalTable: "luna_rpg_character_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "luna_rpg_custom_entity",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<byte[]>(type: "blob", nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: false),
                    character_id = table.Column<int>(type: "int", nullable: false),
                    race_id = table.Column<int>(type: "int", nullable: false),
                    valeur = table.Column<int>(type: "int", nullable: false),
                    valeur_max = table.Column<int>(type: "int", nullable: true),
                    unite = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_rpg_custom_entity", x => x.id);
                    table.ForeignKey(
                        name: "FK_luna_rpg_custom_entity_luna_rpg_character_character_id",
                        column: x => x.character_id,
                        principalTable: "luna_rpg_character",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_luna_rpg_custom_entity_luna_rpg_race_race_id",
                        column: x => x.race_id,
                        principalTable: "luna_rpg_race",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_luna_rpg_custom_entity_luna_rpg_custom_property_type_type_id",
                        column: x => x.type_id,
                        principalTable: "luna_rpg_custom_property_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_character_race_id",
                table: "luna_rpg_character",
                column: "race_id");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_character_type_id",
                table: "luna_rpg_character",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_entity_character_id",
                table: "luna_rpg_custom_entity",
                column: "character_id");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_entity_race_id",
                table: "luna_rpg_custom_entity",
                column: "race_id");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_entity_type_id",
                table: "luna_rpg_custom_entity",
                column: "type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "luna_rpg_custom_entity");

            migrationBuilder.DropTable(
                name: "luna_rpg_character");

            migrationBuilder.DropTable(
                name: "luna_rpg_custom_property_type");

            migrationBuilder.DropTable(
                name: "luna_rpg_race");

            migrationBuilder.DropTable(
                name: "luna_rpg_character_type");
        }
    }
}
