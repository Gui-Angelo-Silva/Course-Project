﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend.Context;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backend.Objects.Models.Entities.ReservationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("idreservation");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createat");

                    b.Property<string>("DateReservation")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("datereservation");

                    b.Property<string>("HourBegin")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("hourbegin");

                    b.Property<string>("HourFinish")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("hourfinish");

                    b.Property<int>("IdTable")
                        .HasColumnType("integer");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<string>("TimeDuration")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("timeduration");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("updateat");

                    b.Property<decimal>("ValueReservation")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("valuereservation");

                    b.HasKey("Id");

                    b.HasIndex("IdTable");

                    b.HasIndex("IdUser");

                    b.ToTable("reservation");
                });

            modelBuilder.Entity("backend.Objects.Models.Entities.RestaurantModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("idrestaurant");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailRestaurant")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("emailrestaurant");

                    b.Property<string>("ImageRestaurant")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("imagerestaurant");

                    b.Property<string>("NameRestaurant")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("namerestaurant");

                    b.Property<string>("PhoneRestaurant")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("phonerestaurant");

                    b.HasKey("Id");

                    b.ToTable("restaurant");
                });

            modelBuilder.Entity("backend.Objects.Models.Entities.TableModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("idtable");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AvailableTable")
                        .HasColumnType("boolean");

                    b.Property<int>("CapacityPersons")
                        .HasColumnType("integer")
                        .HasColumnName("capacitypersons");

                    b.Property<string>("CodeTable")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("codetable");

                    b.Property<int>("IdRestaurant")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValueTable")
                        .HasColumnType("decimal(7,2)")
                        .HasColumnName("valuetable");

                    b.HasKey("Id");

                    b.HasIndex("IdRestaurant");

                    b.ToTable("table");
                });

            modelBuilder.Entity("backend.Objects.Models.Entities.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("iduser");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailUser")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("emailuser");

                    b.Property<string>("ImageUser")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("imageuser");

                    b.Property<string>("NameUser")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nameuser");

                    b.Property<string>("PasswordUser")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("passworduser");

                    b.Property<string>("PhoneUser")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("phoneuser");

                    b.HasKey("Id");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmailUser = "master@development.com",
                            ImageUser = "",
                            NameUser = "Master",
                            PasswordUser = "99db87c3278f5eaa517260eaaa2b4b376be63d7f8a79c0f43992a493a3de8fc9",
                            PhoneUser = "(00) 00000-0000"
                        });
                });

            modelBuilder.Entity("backend.Objects.Models.Entities.ReservationModel", b =>
                {
                    b.HasOne("backend.Objects.Models.Entities.TableModel", "TableModel")
                        .WithMany("ReservationsModel")
                        .HasForeignKey("IdTable")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Objects.Models.Entities.UserModel", "UserModel")
                        .WithMany("ReservationsModel")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TableModel");

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("backend.Objects.Models.Entities.TableModel", b =>
                {
                    b.HasOne("backend.Objects.Models.Entities.RestaurantModel", "RestaurantModel")
                        .WithMany("TablesModel")
                        .HasForeignKey("IdRestaurant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RestaurantModel");
                });

            modelBuilder.Entity("backend.Objects.Models.Entities.RestaurantModel", b =>
                {
                    b.Navigation("TablesModel");
                });

            modelBuilder.Entity("backend.Objects.Models.Entities.TableModel", b =>
                {
                    b.Navigation("ReservationsModel");
                });

            modelBuilder.Entity("backend.Objects.Models.Entities.UserModel", b =>
                {
                    b.Navigation("ReservationsModel");
                });
#pragma warning restore 612, 618
        }
    }
}
