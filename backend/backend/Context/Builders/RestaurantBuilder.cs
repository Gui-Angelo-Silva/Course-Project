using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using backend.Objects.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace backend.Context.Builders
{
    public class RestaurantBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Builder
            modelBuilder.Entity<RestaurantModel>().HasKey(r => r.Id);
            modelBuilder.Entity<RestaurantModel>().Property(r => r.NameRestaurant).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<RestaurantModel>().Property(r => r.EmailRestaurant).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<RestaurantModel>().Property(r => r.PhoneRestaurant).HasMaxLength(15).IsRequired();

            var imageRestaurantComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            modelBuilder.Entity<RestaurantModel>()
                .Property(r => r.ImageRestaurant)
                .HasConversion(
                    images => string.Join(';', images),
                    images => images.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList())
                .Metadata.SetValueComparer(imageRestaurantComparer);


            // Inserções
            //modelBuilder.Entity<RestaurantModel>().HasData(
            //    new RestaurantModel { /* Inicializar dados */ }
            //);
        }
    }
}
