
using System;
using Luna.Commons.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Luna.Commons.Models
{
    public partial class LunaDbContext
    {
        partial void CustomizeMapping(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LunaIdentityUser>(_ =>
            {
                _.ToTable("luna_identity_users");
            });
            
            modelBuilder.Entity<LunaIdentityRole>(_ =>
            {
                _.ToTable("luna_identity_roles");
            });
            
            modelBuilder.Entity<IdentityUserRole<Guid>>(_ =>
            {
                _.ToTable("luna_identity_users_roles");
                _.HasKey(m => new { m.UserId, m.RoleId });
            });
            
            modelBuilder.Entity<IdentityUserClaim<Guid>>(_ =>
            {
                _.ToTable("luna_identity_users_claims");
            });
            
            modelBuilder.Entity<IdentityUserLogin<Guid>>(_ =>
            {
                _.ToTable("luna_identity_users_logins");
                _.HasKey(m => m.UserId);
            });
            
            modelBuilder.Entity<IdentityRoleClaim<Guid>>(_ =>
            {
                _.ToTable("luna_identity_roles_claims");
            });
            
            modelBuilder.Entity<IdentityUserToken<Guid>>(_ =>
            {
                _.ToTable("luna_identity_users_tokens");
                _.HasKey(m => m.UserId);
            });
        }
    }
}