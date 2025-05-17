using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    public int TecnicosId { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public string Conceptos { get; set; } = null!;
}
