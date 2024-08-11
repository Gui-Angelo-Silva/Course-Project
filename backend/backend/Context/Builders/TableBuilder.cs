using Microsoft.EntityFrameworkCore;
using backend.Objects.Models.Entities;

namespace backend.Context.Builders
{
    public class TableBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Configuração da entidade TableModel
            modelBuilder.Entity<TableModel>().HasKey(t => t.Id);
            modelBuilder.Entity<TableModel>().Property(t => t.CodeTable).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<TableModel>().Property(t => t.CapacityPersons).IsRequired();
            modelBuilder.Entity<TableModel>().Property(t => t.ValueTable).HasColumnType("decimal(7,2)").IsRequired();
            modelBuilder.Entity<TableModel>().Property(t => t.IdRestaurant).IsRequired();

            // Relacionamento: Restaurante -> Mesa
            modelBuilder.Entity<TableModel>()
                .HasOne(t => t.RestaurantModel)
                .WithMany(r => r.TablesModel)
                .HasForeignKey(t => t.IdRestaurant)
                .OnDelete(DeleteBehavior.Cascade);


            // Inserções de dados
            // modelBuilder.Entity<TableModel>().HasData(
            //
            // );
        }
    }
}
