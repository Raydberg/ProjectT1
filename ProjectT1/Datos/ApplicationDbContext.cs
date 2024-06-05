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
              new Marca { IdMarca = 1, NomMarca = "Marca1" },
              new Marca { IdMarca = 2, NomMarca = "Marca2" },
              new Marca { IdMarca = 3, NomMarca = "Marca3" },
              new Marca { IdMarca = 4, NomMarca = "Marca4" },
              new Marca { IdMarca = 5, NomMarca = "Marca5" }
              );

            modelBuilder.Entity<Modelo>().HasData(
                new Modelo { IdModelo = 1, NomModelo = "Modelo1", MarcaId = 1 },
                new Modelo { IdModelo = 2, NomModelo = "Modelo2", MarcaId = 1 },
                new Modelo { IdModelo = 3, NomModelo = "Modelo3", MarcaId = 2 },
                new Modelo { IdModelo = 4, NomModelo = "Modelo4", MarcaId = 2 },
                new Modelo { IdModelo = 5, NomModelo = "Modelo5", MarcaId = 3 }
            );

            modelBuilder.Entity<Vehiculo>().HasData(
                new Vehiculo { IdVehiculo = 1, NroPlaca = "Placa1", ModeloId = 1, Anio = 2021, Color = "Rojo", EstPer = "Bueno" },
                new Vehiculo { IdVehiculo = 2, NroPlaca = "Placa2", ModeloId = 2, Anio = 2022, Color = "Azul", EstPer = "Excelente" },
                new Vehiculo { IdVehiculo = 3, NroPlaca = "Placa3", ModeloId = 3, Anio = 2023, Color = "Amarillo", EstPer = "Regular" },
                new Vehiculo { IdVehiculo = 4, NroPlaca = "Placa4", ModeloId = 4, Anio = 2024, Color = "Rosado", EstPer = "Optimo" },
                new Vehiculo { IdVehiculo = 5, NroPlaca = "Placa5", ModeloId = 5, Anio = 2025, Color = "Verde", EstPer = "Pesimo" }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
