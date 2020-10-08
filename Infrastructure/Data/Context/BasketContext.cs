using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infrastructure.Data.Context
{
    public class BasketContext : DbContext
    {
        public BasketContext(DbContextOptions<BasketContext> options) : base(options)
        {

        }

        public DbSet<CustomerBasket> CustomerBaskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFramework.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType
                    == typeof(decimal));
                  
                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name)
                            .HasConversion<double>();
                    }
                }
            }

            modelBuilder.Entity<BasketItem>(entity => 
            {
                entity.HasKey(e => e.Id)
                   .HasName("PK__BasketItem__Id");

                entity.Property(e => e.BasketItemId)
                .ValueGeneratedNever();
            });
        }
    }
}
