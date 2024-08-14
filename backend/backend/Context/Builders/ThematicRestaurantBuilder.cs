using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using backend.Objects.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace backend.Context.Builders
{
    public class ThematicRestaurantBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Builder
            modelBuilder.Entity<ThematicRestaurantModel>().HasKey(tr => tr.Id);
            modelBuilder.Entity<ThematicRestaurantModel>().Property(tr => tr.IdRestaurant).IsRequired();
            modelBuilder.Entity<ThematicRestaurantModel>().Property(tr => tr.IdThematic).IsRequired();

            // Relacionamento: Temática de Restaurante -> Restaraunte
            modelBuilder.Entity<ThematicRestaurantModel>()
                .HasOne(tr => tr.RestaurantModel)
                .WithMany(r => r.ThematicsRestaurantModel)
                .HasForeignKey(tr => tr.IdRestaurant)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento: Temática de Restaurante -> Temática
            modelBuilder.Entity<ThematicRestaurantModel>()
                .HasOne(tr => tr.ThematicModel)
                .WithMany(t => t.ThematicsRestaurantModel)
                .HasForeignKey(tr => tr.IdThematic)
                .OnDelete(DeleteBehavior.Cascade);


            // Inserções
            //modelBuilder.Entity<ThematicRestaurantModel>().HasData(
            //    new ThematicRestaurantModel { /* Inicializar dados */ }
            //);
        }
    }
}
