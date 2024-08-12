using Microsoft.EntityFrameworkCore;
using backend.Objects.Models.Entities;
using System.Text;

namespace backend.Context.Builders
{
    public class UserBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Builder
            modelBuilder.Entity<UserModel>().HasKey(u => u.Id);
            modelBuilder.Entity<UserModel>().Property(u => u.ImageUser).IsRequired();
            modelBuilder.Entity<UserModel>().Property(u => u.NameUser).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<UserModel>().Property(u => u.EmailUser).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<UserModel>().Property(u => u.PasswordUser).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<UserModel>().Property(u => u.PhoneUser).HasMaxLength(15).IsRequired();


            // Inserções
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = 1, NameUser = "Master", EmailUser = "master@development.com", PasswordUser = "71f780a111c4a0c1e744c31a1ae05299a3bd32467dd60caddf4a961ff793d181", PhoneUser = "(00) 00000-0000", ImageUser = "" }
            );
        }
    }

}