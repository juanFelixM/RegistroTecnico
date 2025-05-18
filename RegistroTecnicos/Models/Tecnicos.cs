using System.ComponentModel.DataAnnotations;

namespace GestorTecnicos.Models
{
    public class Tecnicos
    {
        [Key]
        public int TecnicoId { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "En este campo solo se permiten letras. ")]
        public string? Nombres { get; set; } = null;
        [Required(ErrorMessage = "El Sueldo es requerido")]
        [Range(minimum: 0.1, maximum: 5000, ErrorMessage = "Por favor, ingrese una cantidad mayor a 0 y menor o igual a 5000 ")]
        public double SueldoHora { get; set; }
    }
}