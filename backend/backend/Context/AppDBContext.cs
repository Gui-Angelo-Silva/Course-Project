﻿using Microsoft.EntityFrameworkCore;
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
    public DbSet<ThematicModel> Thematic { get; set; }
    public DbSet<ThematicRestaurantModel> ThematicRestaurant { get; set; }

    // Conjunto: Usuário
    public DbSet<UserModel> User { get; set; }
    public DbSet<ReservationModel> Reservation { get; set; }

    // Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Entidades de Restaurante:
        RestaurantBuilder.Build(modelBuilder);
        TableBuilder.Build(modelBuilder);
        ThematicBuilder.Build(modelBuilder);
        ThematicRestaurantBuilder.Build(modelBuilder);

        // Entidades de Usuário:
        UserBuilder.Build(modelBuilder);
        ReservationBuilder.Build(modelBuilder);
    }
}
