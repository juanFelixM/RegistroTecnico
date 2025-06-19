using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Ventas
{
    [Key]
    public int VentaId { get; set; }
    public DateTime Fecha { get; set; }
    public string ClienteId { get; set; } = "";
    public double Monto { get; set; }

}
