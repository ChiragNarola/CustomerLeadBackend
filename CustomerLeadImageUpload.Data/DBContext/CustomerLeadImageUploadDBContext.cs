using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CustomerLeadImageUpload.Data.Models;

namespace CustomerLeadImageUpload.Data.DBContext
{
    public class CustomerLeadImageUploadDBContext : IdentityDbContext
    {
        public CustomerLeadImageUploadDBContext(
            DbContextOptions<CustomerLeadImageUploadDBContext> options
            )
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        #region DbSets

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerImage> CustomerImages { get; set; } = null!;


        #endregion
       
        #region ModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Get all entity types in the model
            var entityTypes = modelBuilder.Model.GetEntityTypes();

            // Loop through each entity type
            foreach (var entityType in entityTypes)
            {
                // Loop through all the foreign keys for each entity type
                foreach (var foreignKey in entityType.GetForeignKeys())
                {
                    // Set the delete behavior to Restrict
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType.IsEnum)
                    {
                        var type = typeof(EnumToStringConverter<>).MakeGenericType(property.ClrType);
                        var converter = Activator.CreateInstance(type, new ConverterMappingHints()) as ValueConverter;

                        property.SetValueConverter(converter);
                    }
                    else if (Nullable.GetUnderlyingType(property.ClrType)?.IsEnum == true)
                    {
                        var type = typeof(EnumToStringConverter<>).MakeGenericType(Nullable.GetUnderlyingType(property.ClrType)!);
                        var converter = Activator.CreateInstance(type, new ConverterMappingHints()) as ValueConverter;

                        property.SetValueConverter(converter);
                    }
                }
            }
            
        }
        #endregion

        public int Save() => SaveChanges();
        public Task<int> SaveAsync() => SaveChangesAsync();
    }

}
