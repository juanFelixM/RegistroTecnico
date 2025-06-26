using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Sistemas
{
    [Key]
    public int SistemaId { get; set; }

    [Required(ErrorMessage = "La Descripción es requerida")]
    public string Descripcion { get; set; } = null!;

    [Required(ErrorMessage = "La Complejidad es requerida")]
    public double Complejidad { get; set; }

    [Required(ErrorMessage = "La Existencia es requerida")]
    public int Existencia { get; set; }

    [Required(ErrorMessage = "El Precio es requerido")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "El Monto es requerido")]
    public decimal Monto { get; set; }
}
