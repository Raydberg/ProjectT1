using System.ComponentModel.DataAnnotations;

namespace ProjectT1.Models
{
    public class Marca
    {
        [Key]
        public int? IdMarca { get; set; }
        public string NomMarca { get; set; }

        [Required(ErrorMessage ="Selecione Nombre de Marca")]
        public ICollection<Modelo> Modelos { get; set; } 
    }
}
