using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Address", "Datetime", "Description", "Image", "Lat", "Lng", "Title" },
                values: new object[,]
                {
                    { 1, "São João do Pau d'Alho, Região Imediata de Dracena São Paulo, Região Sudeste, 17970-000, Brasil", new DateTime(2024, 7, 30, 22, 2, 0, 0, DateTimeKind.Unspecified), "teste", "https://www.google.com", -21.2701055, -51.665497799999997, "Teste" },
                    { 2, "São João do Pau d'Alho, Região Imediata de Dracena São Paulo, Região Sudeste, 17970-000, Brasil", new DateTime(2024, 7, 30, 22, 2, 0, 0, DateTimeKind.Unspecified), "teste 2", "https://www.google.com", -21.2701055, -51.665497799999997, "Teste 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
