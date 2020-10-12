using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossCutting.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static ModelBuilder TypeDateTimeToDatetime2(this ModelBuilder modelBuilder, string ignorePrefix = "")
        {
            var propsQuery = EntityTypes(modelBuilder, ignorePrefix)
                .SelectMany(t => t.GetProperties());

            foreach (var property in propsQuery.Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?)))
            {
                string colType = property.GetColumnType();
                if (String.IsNullOrEmpty(colType))
                {
                    property.SetColumnType("datetime2");
                }
            }

            return modelBuilder;
        }

        public static ModelBuilder TypeStringToNvarchar255(this ModelBuilder modelBuilder, string ignorePrefix = "")
        {
            var propsQuery = EntityTypes(modelBuilder, ignorePrefix)
                .SelectMany(t => t.GetProperties());

            foreach (var property in propsQuery.Where(p => p.ClrType == typeof(String)))
            {
                string colType = property.GetColumnType();
                if (String.IsNullOrEmpty(colType))
                {
                    property.SetColumnType("nvarchar(255)");
                }
            }

            return modelBuilder;
        }

        public static ModelBuilder RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder, string ignorePrefix = "")
        {
            foreach (IMutableEntityType entity in EntityTypes(modelBuilder, ignorePrefix))
            {
                entity.SetTableName(entity.DisplayName());
            }

            return modelBuilder;
        }

        public static ModelBuilder SetOnDeleteBehaviorToRestrict(this ModelBuilder modelBuilder, string ignorePrefix = "")
        {
            foreach (IMutableForeignKey relationship in EntityTypes(modelBuilder, ignorePrefix).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            return modelBuilder;
        }

        private static IEnumerable<IMutableEntityType> EntityTypes(ModelBuilder modelBuilder, string ignorePrefix)
        {
            if (!String.IsNullOrEmpty(ignorePrefix))
            {
                return modelBuilder.Model.GetEntityTypes().Where(x => !x.GetTableName().StartsWith(ignorePrefix)).AsEnumerable();
            }
            return modelBuilder.Model.GetEntityTypes();
        }
    }
}
