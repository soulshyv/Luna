using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class AddIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "luna_rpg_race",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "luna_rpg_race",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "luna_rpg_race",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "luna_rpg_race",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "luna_rpg_custom_section",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "luna_rpg_custom_section",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "luna_rpg_custom_section",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "luna_rpg_custom_section",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "luna_rpg_custom_property_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "luna_rpg_custom_property_type",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "luna_rpg_custom_property_type",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "luna_rpg_custom_property_type",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "luna_rpg_custom_property",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "luna_rpg_custom_property",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "luna_rpg_custom_property",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "luna_rpg_custom_property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "luna_rpg_character_type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "luna_rpg_character_type",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "luna_rpg_character_type",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "luna_rpg_character_type",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "luna_rpg_character",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "luna_rpg_character",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "luna_rpg_character",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "luna_rpg_character",
                nullable: false,
                defaultValue: 0);

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
                    RoleId = table.Column<Guid>(nullable: false),
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
                    UserId = table.Column<Guid>(nullable: false),
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
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_identity_users_logins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "luna_identity_users_roles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_identity_users_roles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "luna_identity_users_tokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luna_identity_users_tokens", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_race_AuthorId",
                table: "luna_rpg_race",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_section_AuthorId",
                table: "luna_rpg_custom_section",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_property_type_AuthorId",
                table: "luna_rpg_custom_property_type",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_property_AuthorId",
                table: "luna_rpg_custom_property",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_character_type_AuthorId",
                table: "luna_rpg_character_type",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_character_AuthorId",
                table: "luna_rpg_character",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_character_luna_identity_users_AuthorId",
                table: "luna_rpg_character",
                column: "AuthorId",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_character_type_luna_identity_users_AuthorId",
                table: "luna_rpg_character_type",
                column: "AuthorId",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_luna_identity_users_AuthorId",
                table: "luna_rpg_custom_property",
                column: "AuthorId",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_type_luna_identity_users_AuthorId",
                table: "luna_rpg_custom_property_type",
                column: "AuthorId",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_section_luna_identity_users_AuthorId",
                table: "luna_rpg_custom_section",
                column: "AuthorId",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_race_luna_identity_users_AuthorId",
                table: "luna_rpg_race",
                column: "AuthorId",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_character_luna_identity_users_AuthorId",
                table: "luna_rpg_character");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_character_type_luna_identity_users_AuthorId",
                table: "luna_rpg_character_type");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_luna_identity_users_AuthorId",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_type_luna_identity_users_AuthorId",
                table: "luna_rpg_custom_property_type");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_section_luna_identity_users_AuthorId",
                table: "luna_rpg_custom_section");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_race_luna_identity_users_AuthorId",
                table: "luna_rpg_race");

            migrationBuilder.DropTable(
                name: "luna_identity_roles");

            migrationBuilder.DropTable(
                name: "luna_identity_roles_claims");

            migrationBuilder.DropTable(
                name: "luna_identity_users");

            migrationBuilder.DropTable(
                name: "luna_identity_users_claims");

            migrationBuilder.DropTable(
                name: "luna_identity_users_logins");

            migrationBuilder.DropTable(
                name: "luna_identity_users_roles");

            migrationBuilder.DropTable(
                name: "luna_identity_users_tokens");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_race_AuthorId",
                table: "luna_rpg_race");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_custom_section_AuthorId",
                table: "luna_rpg_custom_section");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_custom_property_type_AuthorId",
                table: "luna_rpg_custom_property_type");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_custom_property_AuthorId",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_character_type_AuthorId",
                table: "luna_rpg_character_type");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_character_AuthorId",
                table: "luna_rpg_character");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "luna_rpg_race");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "luna_rpg_race");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "luna_rpg_race");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "luna_rpg_race");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "luna_rpg_custom_section");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "luna_rpg_custom_section");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "luna_rpg_custom_section");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "luna_rpg_custom_section");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "luna_rpg_custom_property_type");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "luna_rpg_custom_property_type");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "luna_rpg_custom_property_type");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "luna_rpg_custom_property_type");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "luna_rpg_character_type");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "luna_rpg_character_type");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "luna_rpg_character_type");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "luna_rpg_character_type");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "luna_rpg_character");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "luna_rpg_character");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "luna_rpg_character");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "luna_rpg_character");
        }
    }
}
