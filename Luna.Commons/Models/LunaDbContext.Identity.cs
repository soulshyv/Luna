using System;
using Luna.Commons.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Luna.Commons.Models
{
    public partial class LunaDbContext
    {
        public DbSet<LunaIdentityUser> Users { get; set; }
        
        partial void CustomizeMapping(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LunaIdentityUser>(_ =>
            {
                _.ToTable("luna_identity_users");
                _.Property(lui => lui.IsActive).HasColumnName("is_active").HasColumnType("tinyint(1)").IsRequired();
            });
            
            modelBuilder.Entity<LunaIdentityRole>(_ =>
            {
                _.ToTable("luna_identity_roles");
            });
            
            modelBuilder.Entity<IdentityUserRole<Guid>>(_ =>
            {
                _.ToTable("luna_identity_users_roles");
                _.Property(lui => lui.UserId).HasColumnName("user_id").HasColumnType("char(36)").IsRequired();
                _.Property(lui => lui.RoleId).HasColumnName("role_id").HasColumnType("char(36)").IsRequired();
                _.HasKey(m => new { m.UserId, m.RoleId });
            });
            
            modelBuilder.Entity<IdentityUserClaim<Guid>>(_ =>
            {
                _.ToTable("luna_identity_users_claims");
                _.Property(lui => lui.UserId).HasColumnName("user_id").HasColumnType("char(36)").IsRequired();
            });
            
            modelBuilder.Entity<IdentityUserLogin<Guid>>(_ =>
            {
                _.ToTable("luna_identity_users_logins");
                _.Property(lui => lui.UserId).HasColumnName("user_id").HasColumnType("char(36)").IsRequired();
                _.HasKey(m => m.UserId);
            });
            
            modelBuilder.Entity<IdentityRoleClaim<Guid>>(_ =>
            {
                _.ToTable("luna_identity_roles_claims");
                _.Property(lui => lui.RoleId).HasColumnName("role_id").HasColumnType("char(36)").IsRequired();
            });
            
            modelBuilder.Entity<IdentityUserToken<Guid>>(_ =>
            {
                _.ToTable("luna_identity_users_tokens");
                _.Property(lui => lui.UserId).HasColumnName("user_id").HasColumnType("char(36)").IsRequired();
                _.HasKey(m => m.UserId);
            });
        }
    }
}