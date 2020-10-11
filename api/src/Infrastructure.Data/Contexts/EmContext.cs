using CrossCutting.Data.Extensions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Contexts
{
    public class EmContext : DbContext, IEmContext
    {
        public virtual DbSet<Book> Books { get; set; }

        public EmContext(DbContextOptions<EmContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmContext).Assembly);

            modelBuilder.TypeDateTimeToDatetime2();
            modelBuilder.TypeStringToNvarchar255();
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.SetOnDeleteBehaviorToRestrict();

            base.OnModelCreating(modelBuilder);
        }
    }
}
