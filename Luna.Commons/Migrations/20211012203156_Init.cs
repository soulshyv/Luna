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
                name: "luna_identity_roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_identity_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "luna_identity_roles_claims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_identity_roles_claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "luna_identity_users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_identity_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "luna_identity_users_claims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_identity_users_claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "luna_identity_users_logins",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_identity_users_logins", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "luna_identity_users_roles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    role_id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_identity_users_roles", x => new { x.user_id, x.role_id });
                });

            migrationBuilder.CreateTable(
                name: "luna_identity_users_tokens",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_identity_users_tokens", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "luna_rpg_character_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified = table.Column<DateTime>(type: "datetime", nullable: false),
                    nom = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<byte[]>(type: "blob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_rpg_character_type", x => x.id);
                    table.ForeignKey(
                        name: "FK_luna_rpg_character_type_luna_identity_users_user_id",
                        column: x => x.user_id,
                        principalTable: "luna_identity_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "luna_rpg_custom_property_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified = table.Column<DateTime>(type: "datetime", nullable: false),
                    nom = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<byte[]>(type: "blob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_rpg_custom_property_type", x => x.id);
                    table.ForeignKey(
                        name: "FK_luna_rpg_custom_property_type_luna_identity_users_user_id",
                        column: x => x.user_id,
                        principalTable: "luna_identity_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "luna_rpg_race",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified = table.Column<DateTime>(type: "datetime", nullable: false),
                    nom = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<byte[]>(type: "blob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_rpg_race", x => x.id);
                    table.ForeignKey(
                        name: "FK_luna_rpg_race_luna_identity_users_user_id",
                        column: x => x.user_id,
                        principalTable: "luna_identity_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "luna_rpg_character",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified = table.Column<DateTime>(type: "datetime", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_luna_rpg_character_luna_identity_users_user_id",
                        column: x => x.user_id,
                        principalTable: "luna_identity_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "luna_rpg_custom_section",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified = table.Column<DateTime>(type: "datetime", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_luna_rpg_custom_section_luna_identity_users_user_id",
                        column: x => x.user_id,
                        principalTable: "luna_identity_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "luna_rpg_custom_property",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified = table.Column<DateTime>(type: "datetime", nullable: false),
                    nom = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<byte[]>(type: "blob", nullable: true),
                    section_id = table.Column<int>(type: "int", nullable: false),
                    type_id = table.Column<int>(type: "int", nullable: false),
                    race_id = table.Column<int>(type: "int", nullable: false),
                    valeur = table.Column<int>(type: "int", nullable: false),
                    valeur_max = table.Column<int>(type: "int", nullable: true),
                    unite = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_rpg_custom_property", x => x.id);
                    table.ForeignKey(
                        name: "FK_luna_rpg_custom_property_luna_rpg_custom_section_section_id",
                        column: x => x.section_id,
                        principalTable: "luna_rpg_custom_section",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_luna_rpg_custom_property_luna_rpg_race_race_id",
                        column: x => x.race_id,
                        principalTable: "luna_rpg_race",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_luna_rpg_custom_property_luna_rpg_custom_property_type_type_~",
                        column: x => x.type_id,
                        principalTable: "luna_rpg_custom_property_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_luna_rpg_custom_property_luna_identity_users_user_id",
                        column: x => x.user_id,
                        principalTable: "luna_identity_users",
                        principalColumn: "Id",
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
                name: "IX_luna_rpg_character_user_id",
                table: "luna_rpg_character",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_character_type_nom",
                table: "luna_rpg_character_type",
                column: "nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_character_type_user_id",
                table: "luna_rpg_character_type",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_property_section_id",
                table: "luna_rpg_custom_property",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_property_race_id",
                table: "luna_rpg_custom_property",
                column: "race_id");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_property_type_id",
                table: "luna_rpg_custom_property",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_property_user_id",
                table: "luna_rpg_custom_property",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_property_type_nom",
                table: "luna_rpg_custom_property_type",
                column: "nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_property_type_user_id",
                table: "luna_rpg_custom_property_type",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_section_character_id",
                table: "luna_rpg_custom_section",
                column: "character_id");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_section_user_id",
                table: "luna_rpg_custom_section",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_race_user_id",
                table: "luna_rpg_race",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "luna_identity_roles");

            migrationBuilder.DropTable(
                name: "luna_identity_roles_claims");

            migrationBuilder.DropTable(
                name: "luna_identity_users_claims");

            migrationBuilder.DropTable(
                name: "luna_identity_users_logins");

            migrationBuilder.DropTable(
                name: "luna_identity_users_roles");

            migrationBuilder.DropTable(
                name: "luna_identity_users_tokens");

            migrationBuilder.DropTable(
                name: "luna_rpg_custom_property");

            migrationBuilder.DropTable(
                name: "luna_rpg_custom_section");

            migrationBuilder.DropTable(
                name: "luna_rpg_custom_property_type");

            migrationBuilder.DropTable(
                name: "luna_rpg_character");

            migrationBuilder.DropTable(
                name: "luna_rpg_race");

            migrationBuilder.DropTable(
                name: "luna_rpg_character_type");

            migrationBuilder.DropTable(
                name: "luna_identity_users");
        }
    }
}
