using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RegistroTecnicos.Models;

public class ClienteDetalles
{
    [Key]
    public int DetalleId { get; set; }
    
    public int ClienteId { get; set; }
    
    public int TipoId { get; set; }

    public string Telefono { get; set; } = "";
}
