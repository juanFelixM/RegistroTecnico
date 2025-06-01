using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Tickets
{
    [Key]
    public int TicketId { get; set; }

    [Required(ErrorMessage = "La Fecha es Requerida")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Seleccione la Prioridad")]
    public int Prioridad { get; set; }

    [Required(ErrorMessage = "Seleccione el Cliente")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Describa el Asunto")]
    public string? Asunto { get; set; }

    [Required(ErrorMessage = "Complete el campo")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Ingrese el Tiempo Invertido")]
    public int TiempoInvertido { get; set; }

    [Required(ErrorMessage = "Seleccione el Técnico")]
    public int TecnicoId { get; set; }
}
