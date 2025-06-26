using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class VentasDetalles
{
    [Key]
    public int DetalleId { get; set; }

    [Required(ErrorMessage = "La Venta es requerida")]
    public int VentaId { get; set; }

    [Required(ErrorMessage = "El Sistema es requerido")]
    public int SistemaId { get; set; }

    [Required(ErrorMessage = "La Cantidad es requerida")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El Precio es requerido")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "El Monto es requerido")]
    public decimal Monto { get; set; }

    [ForeignKey("VentaId")]
    [InverseProperty("ventasDetalles")]
    public virtual Ventas Venta { get; set; } = null!;

    [ForeignKey("SistemaId")]
    public virtual Sistemas? Sistema { get; set; }
}
