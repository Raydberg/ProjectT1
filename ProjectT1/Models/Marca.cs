using System.ComponentModel.DataAnnotations;

namespace ProjectT1.Models
{
    public class Marca
    {
        [Key]
        public int? IdMarca { get; set; }
        public string NomMarca { get; set; }

        //public int ModeloId { get; set; }
        //public Modelo Modelo { get; set; }

        [Required(ErrorMessage ="Selecione Nombre de Marca")]
        public ICollection<Modelo> Modelos { get; set; } 
    }
}
