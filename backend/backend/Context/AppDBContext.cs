using Microsoft.EntityFrameworkCore;
//using SGED.Context.Builders;
//using SGED.Objects.Models.Entities;

namespace SGED.Context;
public class AppDBContext : DbContext
{
	public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    // Mapeamento Relacional dos Objetos no Bando de Dados


    // Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
    }
}
