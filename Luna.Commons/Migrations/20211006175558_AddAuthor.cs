using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class AddAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "AuthorId",
                table: "luna_rpg_custom_section");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "luna_rpg_custom_property_type");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "luna_rpg_character_type");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "luna_rpg_character");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "luna_rpg_race",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "luna_rpg_race",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "luna_rpg_race",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "luna_rpg_custom_section",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "luna_rpg_custom_section",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "luna_rpg_custom_section",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "luna_rpg_custom_property_type",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "luna_rpg_custom_property_type",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "luna_rpg_custom_property_type",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "luna_rpg_custom_property",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "luna_rpg_custom_property",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "luna_rpg_custom_property",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "luna_rpg_character_type",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "luna_rpg_character_type",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "luna_rpg_character_type",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "luna_rpg_character",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "luna_rpg_character",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "luna_rpg_character",
                newName: "created");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "luna_rpg_race",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified",
                table: "luna_rpg_race",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "luna_rpg_race",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "luna_rpg_race",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "luna_rpg_custom_section",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified",
                table: "luna_rpg_custom_section",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "luna_rpg_custom_section",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "luna_rpg_custom_section",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "luna_rpg_custom_property_type",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified",
                table: "luna_rpg_custom_property_type",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "luna_rpg_custom_property_type",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "luna_rpg_custom_property_type",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "luna_rpg_custom_property",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified",
                table: "luna_rpg_custom_property",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "luna_rpg_custom_property",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "luna_rpg_custom_property",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "luna_rpg_character_type",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified",
                table: "luna_rpg_character_type",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "luna_rpg_character_type",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "luna_rpg_character_type",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "luna_rpg_character",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified",
                table: "luna_rpg_character",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "luna_rpg_character",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "luna_rpg_character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GedDocument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Userid = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PublicId = table.Column<Guid>(nullable: false),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GedDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GedDocument_luna_identity_users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "luna_identity_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_race_UserId",
                table: "luna_rpg_race",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_section_UserId",
                table: "luna_rpg_custom_section",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_property_type_UserId",
                table: "luna_rpg_custom_property_type",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_custom_property_UserId",
                table: "luna_rpg_custom_property",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_character_type_UserId",
                table: "luna_rpg_character_type",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_luna_rpg_character_UserId",
                table: "luna_rpg_character",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GedDocument_AuthorId",
                table: "GedDocument",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_character_luna_identity_users_UserId",
                table: "luna_rpg_character",
                column: "UserId",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_character_type_luna_identity_users_UserId",
                table: "luna_rpg_character_type",
                column: "UserId",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_luna_identity_users_UserId",
                table: "luna_rpg_custom_property",
                column: "UserId",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_property_type_luna_identity_users_UserId",
                table: "luna_rpg_custom_property_type",
                column: "UserId",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_custom_section_luna_identity_users_UserId",
                table: "luna_rpg_custom_section",
                column: "UserId",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_luna_rpg_race_luna_identity_users_UserId",
                table: "luna_rpg_race",
                column: "UserId",
                principalTable: "luna_identity_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_character_luna_identity_users_UserId",
                table: "luna_rpg_character");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_character_type_luna_identity_users_UserId",
                table: "luna_rpg_character_type");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_luna_identity_users_UserId",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_property_type_luna_identity_users_UserId",
                table: "luna_rpg_custom_property_type");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_custom_section_luna_identity_users_UserId",
                table: "luna_rpg_custom_section");

            migrationBuilder.DropForeignKey(
                name: "FK_luna_rpg_race_luna_identity_users_UserId",
                table: "luna_rpg_race");

            migrationBuilder.DropTable(
                name: "GedDocument");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_race_UserId",
                table: "luna_rpg_race");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_custom_section_UserId",
                table: "luna_rpg_custom_section");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_custom_property_type_UserId",
                table: "luna_rpg_custom_property_type");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_custom_property_UserId",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_character_type_UserId",
                table: "luna_rpg_character_type");

            migrationBuilder.DropIndex(
                name: "IX_luna_rpg_character_UserId",
                table: "luna_rpg_character");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "luna_rpg_race");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "luna_rpg_custom_section");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "luna_rpg_custom_property_type");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "luna_rpg_custom_property");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "luna_rpg_character_type");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "luna_rpg_character");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "luna_rpg_race",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "luna_rpg_race",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "luna_rpg_race",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "luna_rpg_custom_section",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "luna_rpg_custom_section",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "luna_rpg_custom_section",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "luna_rpg_custom_property_type",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "luna_rpg_custom_property_type",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "luna_rpg_custom_property_type",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "luna_rpg_custom_property",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "luna_rpg_custom_property",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "luna_rpg_custom_property",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "luna_rpg_character_type",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "luna_rpg_character_type",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "luna_rpg_character_type",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "luna_rpg_character",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "luna_rpg_character",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "luna_rpg_character",
                newName: "Created");

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "luna_rpg_race",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "luna_rpg_race",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "luna_rpg_race",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "luna_rpg_race",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "luna_rpg_custom_section",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "luna_rpg_custom_section",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "luna_rpg_custom_section",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "luna_rpg_custom_section",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "luna_rpg_custom_property_type",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "luna_rpg_custom_property_type",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "luna_rpg_custom_property_type",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "luna_rpg_custom_property_type",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "luna_rpg_custom_property",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "luna_rpg_custom_property",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "luna_rpg_custom_property",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "luna_rpg_custom_property",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "luna_rpg_character_type",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "luna_rpg_character_type",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "luna_rpg_character_type",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "luna_rpg_character_type",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "luna_rpg_character",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "luna_rpg_character",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "luna_rpg_character",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "luna_rpg_character",
                type: "char(36)",
                nullable: true);

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
    }
}
