using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "El Nombre es requerido")]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "La Fecha de Ingreso es requerida")]
    [DataType(DataType.Date)]
    public DateTime FechaIngreso { get; set; }

    [Required(ErrorMessage = "La Direccion es requerida")]
    public string Direccion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El RNC es requerido")]
    public string RNC { get; set; } = string.Empty;

    [Required(ErrorMessage = "El Limite de Credito es requerido")]
    public double LimiteCredito { get; set; }

    [Required(ErrorMessage = "El Tecnico Encargado es requerido")]
    public int TecnicoEncargadoId { get; set; }
}
