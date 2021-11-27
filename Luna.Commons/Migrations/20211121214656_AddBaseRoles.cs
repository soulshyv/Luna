using System;
using Luna.Commons.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Commons.Migrations
{
    public partial class AddBaseRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "luna_identity_roles",
                new[] {"Id", "NormalizedName", "Name", "DisplayName"},
                new object[,]
                {
                    { Guid.NewGuid(), LunaApplicationRole.Admin.ToUpper(), LunaApplicationRole.Admin, LunaApplicationRole.Admin },
                    { Guid.NewGuid(), LunaApplicationRole.Mj.ToUpper(),LunaApplicationRole.Mj, LunaApplicationRole.Mj },
                    { Guid.NewGuid(), LunaApplicationRole.Joueur.ToUpper(),LunaApplicationRole.Joueur, LunaApplicationRole.Joueur }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("luna_identity_roles", "Name", LunaApplicationRole.Admin);
            migrationBuilder.DeleteData("luna_identity_roles", "Name", LunaApplicationRole.Mj);
            migrationBuilder.DeleteData("luna_identity_roles", "Name", LunaApplicationRole.Joueur);
        }
    }
}