using Microsoft.EntityFrameworkCore;
using ProjectT1.Models;

namespace ProjectT1.Datos
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
        public DbSet<Marca> Marca { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

             modelBuilder.Entity<Marca>().HasData(
              new Marca { IdMarca = 1, NomMarca = "Toyota" },
              new Marca { IdMarca = 2, NomMarca = "Ford" },
              new Marca { IdMarca = 3, NomMarca = "Honda" }
              );

            modelBuilder.Entity<Modelo>().HasData(
                new Modelo { IdModelo = 1, NomModelo = "Camry", MarcaId = 1 },
                new Modelo { IdModelo = 2, NomModelo = "Corolla", MarcaId = 1 },
                new Modelo { IdModelo = 3, NomModelo = "RAV4", MarcaId = 1 },
                new Modelo { IdModelo = 4, NomModelo = "Focus", MarcaId = 2 },
                new Modelo { IdModelo = 5, NomModelo = "Mustang", MarcaId = 2 },
                new Modelo { IdModelo = 6, NomModelo = "Explorer", MarcaId = 2 },
                new Modelo { IdModelo = 7, NomModelo = "Civic", MarcaId = 3 },
                new Modelo { IdModelo = 8, NomModelo = "Accord", MarcaId = 3 },
                new Modelo { IdModelo = 9, NomModelo = "CR-V", MarcaId = 3 }
            );

            modelBuilder.Entity<Vehiculo>().HasData(
                new Vehiculo { IdVehiculo = 1, NroPlaca = "ABC-1234", ModeloId = 1, Anio = 2021, Color = "Rojo", EstPer="Optimo" },
                new Vehiculo { IdVehiculo = 2, NroPlaca = "MNO-3141", ModeloId = 2, Anio = 2022, Color = "Azul", EstPer= "Bueno" },
                new Vehiculo { IdVehiculo = 3, NroPlaca = "JKL-1121", ModeloId = 3, Anio = 2023, Color = "Amarillo" , EstPer="Caducado"  },
                new Vehiculo { IdVehiculo = 4, NroPlaca = "GHI-9101", ModeloId = 4, Anio = 2024, Color = "Rosado",EstPer ="Buenas Condiciones "},
                new Vehiculo { IdVehiculo = 5, NroPlaca = "XYZ-5678", ModeloId = 5, Anio = 2025, Color = "Verde" ,EstPer="Malo" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
