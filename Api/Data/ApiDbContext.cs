using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<EventModel> Events { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventModel>().HasData(
            new EventModel
            {
                Id = 1,
                Title = "Teste",
                Image = "https://www.google.com",
                Description = "teste",
                Address = "São João do Pau d'Alho, Região Imediata de Dracena São Paulo, Região Sudeste, 17970-000, Brasil",
                Datetime = DateTime.Parse("2024-07-30T22:02"),
                Lat = -21.2701055,
                Lng = -51.6654978
            },
            new EventModel
            {
                Id = 2,
                Title = "Teste 2",
                Image = "https://www.google.com",
                Description = "teste 2",
                Address = "São João do Pau d'Alho, Região Imediata de Dracena São Paulo, Região Sudeste, 17970-000, Brasil",
                Datetime = DateTime.Parse("2024-07-30T22:02"),
                Lat = -21.2701055,
                Lng = -51.6654978
            }
        );
    }
   
    
}

