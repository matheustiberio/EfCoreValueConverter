using Api.DataProtection;
using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace Api.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public virtual DbSet<ExampleEntity> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyDataProtection(modelBuilder.Model.GetEntityTypes());
        }

        protected static void ApplyDataProtection(IEnumerable<IMutableEntityType> entityTipes)
        {
            foreach (IMutableEntityType entity in entityTipes)
            {
                foreach (var property in entity.GetProperties())
                {
                    var attributes = property
                        ?.PropertyInfo
                        ?.GetCustomAttributes(typeof(SensitiveDataAttribute), false);

                    if (attributes?.Length > 0)
                        property.SetValueConverter(new DataProtectionConverter());
                }
            }
        }
    }
}
