using Microsoft.EntityFrameworkCore;
using backend.Objects.Models.Entities;

namespace backend.Context.Builders
{
    public class ReservationBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Configuração da entidade ReservationModel
            modelBuilder.Entity<ReservationModel>().HasKey(r => r.Id);
            modelBuilder.Entity<ReservationModel>().Property(r => r.DateReservation).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<ReservationModel>().Property(r => r.HourBegin).HasMaxLength(5).IsRequired();
            modelBuilder.Entity<ReservationModel>().Property(r => r.HourFinish).HasMaxLength(5);
            modelBuilder.Entity<ReservationModel>().Property(r => r.TimeDuration).HasMaxLength(5);
            modelBuilder.Entity<ReservationModel>().Property(r => r.ValueReservation).HasColumnType("decimal(8,2)").IsRequired();
            modelBuilder.Entity<ReservationModel>().Property(r => r.IdUser).IsRequired();
            modelBuilder.Entity<ReservationModel>().Property(r => r.IdTable).IsRequired();
            modelBuilder.Entity<ReservationModel>().Property(r => r.CreateAt).HasColumnType("timestamp").IsRequired();
            modelBuilder.Entity<ReservationModel>().Property(r => r.UpdateAt).HasColumnType("timestamp").IsRequired();

            // Relacionamento: Restaurante -> Mesa
            modelBuilder.Entity<ReservationModel>()
                .HasOne(r => r.UserModel)
                .WithMany(u => u.ReservationsModel)
                .HasForeignKey(r => r.IdUser)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento: Restaurante -> Mesa
            modelBuilder.Entity<ReservationModel>()
                .HasOne(r => r.TableModel)
                .WithMany(t => t.ReservationsModel)
                .HasForeignKey(r => r.IdTable)
                .OnDelete(DeleteBehavior.Cascade);


            // Inserções de dados
            // modelBuilder.Entity<ReservationModel>().HasData(
            //    new ReservationModel { /* Inicializar dados */ }
            // );
        }
    }
}
