using System.ComponentModel.DataAnnotations;

namespace ProjectT1.Models
{
    public class Modelo
    {
        [Key]
        public int? IdModelo { get; set; }
        public string NomModelo { get; set; }
        public int? IdMarca { get; set; }
        public Marca? Marca { get; set; }
        public ICollection<Vehiculo> Vehiculos { get; set; }
    }
} 
