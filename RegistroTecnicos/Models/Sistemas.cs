using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Sistemas
{
    [Key]
    public int SistemaId { get; set; }
    [Required(ErrorMessage = "El campo descripción es requerido.")]
    [StringLength(250)]
    public string Descripcion { get; set; }
    [Required(ErrorMessage = "El campo numero es requerido.")]
    [Range(1, 100)]
    public double Complejidad { get; set; }
}
