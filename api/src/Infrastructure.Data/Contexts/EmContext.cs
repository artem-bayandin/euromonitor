using CrossCutting.Data.Extensions;
using Domain.Auth;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Contexts
{
    public class EmContext : IdentityDbContext<ApplicationUser>, IEmContext
    {
        private const string _aspNetTablePrefix = "AspNet";

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }

        public EmContext(DbContextOptions<EmContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmContext).Assembly);

            MapIdentityTableNames(modelBuilder);

            modelBuilder.TypeDateTimeToDatetime2(_aspNetTablePrefix);
            modelBuilder.TypeStringToNvarchar255(_aspNetTablePrefix);
            //modelBuilder.RemovePluralizingTableNameConvention(_aspNetTablePrefix);
            modelBuilder.SetOnDeleteBehaviorToRestrict(_aspNetTablePrefix);

            base.OnModelCreating(modelBuilder);
        }

        private void MapIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: $"{_aspNetTablePrefix}Users");
                entity.Property(x => x.Id).HasColumnType("nvarchar(36)"); // hack
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: $"{_aspNetTablePrefix}Roles");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable($"{_aspNetTablePrefix}UserRoles");
                //in case you chagned the TKey type
                //  entity.HasKey(key => new { key.UserId, key.RoleId });
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable($"{_aspNetTablePrefix}UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable($"{_aspNetTablePrefix}UserLogins");
                //in case you chagned the TKey type
                //  entity.HasKey(key => new { key.ProviderKey, key.LoginProvider });       
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable($"{_aspNetTablePrefix}RoleClaims");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable($"{_aspNetTablePrefix}UserTokens");
                //in case you chagned the TKey type
                // entity.HasKey(key => new { key.UserId, key.LoginProvider, key.Name });
            });
        }
    }
}
