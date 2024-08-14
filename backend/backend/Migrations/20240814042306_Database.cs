using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "restaurant",
                columns: table => new
                {
                    idrestaurant = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    imagerestaurant = table.Column<string>(type: "text", nullable: false),
                    namerestaurant = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    emailrestaurant = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phonerestaurant = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurant", x => x.idrestaurant);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    iduser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    imageuser = table.Column<string>(type: "text", nullable: false),
                    nameuser = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    emailuser = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    passworduser = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    phoneuser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.iduser);
                });

            migrationBuilder.CreateTable(
                name: "table",
                columns: table => new
                {
                    idtable = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codetable = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    capacitypersons = table.Column<int>(type: "integer", nullable: false),
                    valuetable = table.Column<decimal>(type: "numeric(7,2)", nullable: false),
                    AvailableTable = table.Column<bool>(type: "boolean", nullable: false),
                    IdRestaurant = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table", x => x.idtable);
                    table.ForeignKey(
                        name: "FK_table_restaurant_IdRestaurant",
                        column: x => x.IdRestaurant,
                        principalTable: "restaurant",
                        principalColumn: "idrestaurant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    idreservation = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datereservation = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    hourbegin = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    hourfinish = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    timeduration = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    valuereservation = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    IdTable = table.Column<int>(type: "integer", nullable: false),
                    createat = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updateat = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.idreservation);
                    table.ForeignKey(
                        name: "FK_reservation_table_IdTable",
                        column: x => x.IdTable,
                        principalTable: "table",
                        principalColumn: "idtable",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservation_user_IdUser",
                        column: x => x.IdUser,
                        principalTable: "user",
                        principalColumn: "iduser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "iduser", "emailuser", "imageuser", "nameuser", "passworduser", "phoneuser" },
                values: new object[] { 1, "master@development.com", "", "Master", "99db87c3278f5eaa517260eaaa2b4b376be63d7f8a79c0f43992a493a3de8fc9", "(00) 00000-0000" });

            migrationBuilder.CreateIndex(
                name: "IX_reservation_IdTable",
                table: "reservation",
                column: "IdTable");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_IdUser",
                table: "reservation",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_table_IdRestaurant",
                table: "table",
                column: "IdRestaurant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "table");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "restaurant");
        }
    }
}
