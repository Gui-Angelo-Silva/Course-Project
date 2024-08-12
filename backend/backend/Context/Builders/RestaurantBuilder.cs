using Microsoft.EntityFrameworkCore;
using backend.Objects.Models.Entities;

namespace backend.Context.Builders
{
    public class RestaurantBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Builder
            modelBuilder.Entity<RestaurantModel>().HasKey(r => r.Id);
            modelBuilder.Entity<RestaurantModel>().Property(r => r.NameFranchise).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<RestaurantModel>().Property(r => r.NameRestaurant).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<RestaurantModel>().Property(r => r.EmailRestaurant).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<RestaurantModel>().Property(r => r.PhoneRestaurant).HasMaxLength(15).IsRequired();
            modelBuilder.Entity<RestaurantModel>().Property(r => r.ImageRestaurant).HasConversion(images => string.Join(";", images), images => images.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());


            // Inserções
            //modelBuilder.Entity<RestaurantModel>().HasData(

            //);
        }
    }

}