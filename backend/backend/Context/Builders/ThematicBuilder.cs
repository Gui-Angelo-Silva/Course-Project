using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using backend.Objects.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace backend.Context.Builders
{
    public class ThematicBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Builder
            modelBuilder.Entity<ThematicModel>().HasKey(t => t.Id);
            modelBuilder.Entity<ThematicModel>().Property(t => t.NameThematic).HasMaxLength(100).IsRequired();


            // Inserções
            //modelBuilder.Entity<ThematicModel>().HasData(
            //    new ThematicModel { /* Inicializar dados */ }
            //);
        }
    }
}
