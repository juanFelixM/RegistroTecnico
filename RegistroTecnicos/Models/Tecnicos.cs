using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }
    [Required(ErrorMessage = "El Nombre es requerido")]
    public string Nombres { get; set; } = "";
    [Required(ErrorMessage = "El Sueldo es requerido")]
    public double SueldoHora { get; set; }
}
