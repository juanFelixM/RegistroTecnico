using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class Ventas
{
    [Key]
    public int VentaId { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "El Cliente es requerido")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "El Monto es requerido")]
    public decimal Monto { get; set; }

    [InverseProperty("Venta")]
    public virtual ICollection<VentasDetalles> ventasDetalles { get; set; } = new List<VentasDetalles>();

    [ForeignKey("ClienteId")]
    [InverseProperty("Ventas")]
    public virtual Clientes Cliente { get; set; } = null!;
}
