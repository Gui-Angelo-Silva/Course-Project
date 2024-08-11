using Microsoft.EntityFrameworkCore;
using backend.Objects.Models.Entities;
using backend.Context.Builders;

namespace backend.Context;
public class AppDBContext : DbContext
{
    // Mapeamento Relacional dos Objetos no Bando de Dados
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    // Conjunto: Restaurante
    public DbSet<RestaurantModel> Restaurant { get; set; }
    public DbSet<TableModel> Table { get; set; }


    // Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Entidades de Restaurante:
        RestaurantBuilder.Build(modelBuilder);
        TableBuilder.Build(modelBuilder);
    }
}
