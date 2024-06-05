using System.ComponentModel.DataAnnotations;

namespace ProjectT1.Models
{
    public class Vehiculo
    {
            [Key]
            public int IdVehiculo { get; set; }
          [Required(ErrorMessage ="Ingrese un ID")]
            public string NroPlaca { get; set; }
          [Required(ErrorMessage ="Ingrese un Numero de Placa")]
            public int ModeloId { get; set; }
            public Modelo Modelo { get; set; }
            public int Anio { get; set; }
         [Required(ErrorMessage ="Ingrese un Año")]
            public string Color { get; set; }
        [Required(ErrorMessage ="Ingrese un Color")]
            public string? EstPer { get; set; }
        

    }
}
