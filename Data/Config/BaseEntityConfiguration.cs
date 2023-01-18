using MasterProject.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterProject.Infrastructure.Data.Config
{
    /// <summary>
    /// This is the configuration class that will have the configuration that can we applied to the classes that are drived form BaseEntity class. 
    /// For applying these configuration, we should create entity specific configuration. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntityWithLogs
    {
        /// <summary>
        /// Define the configuration that should be applied. 
        /// </summary>
        /// <param name="builder"></param>
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(s => s.CreatedOn)
                    .HasDefaultValueSql("GETDATE()");

            builder.Property(s => s.Id)
                     .HasDefaultValueSql("NEWID()");

            builder.Property(s => s.UpdatedOn)
                .HasDefaultValue(System.DateTime.Now);
        }
    }
}
