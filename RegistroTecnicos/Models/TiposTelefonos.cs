using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace RegistroTecnicos.Models;

public class TiposTelefonos
{
    [Key]
    public int TipoId { get; set; }

    public string Descripcion { get; set; } = "";
}
