namespace RegistroTecnicos.Models;
using System.ComponentModel.DataAnnotations;

public class VentasDetalles
{
    [Key]
    public int Id { get; set; }
    public int VentaId { get; set; }
    public int SistemaId { get; set; }
    public int Cantidad { get; set; }
    public double Precio { get; set; }
}
