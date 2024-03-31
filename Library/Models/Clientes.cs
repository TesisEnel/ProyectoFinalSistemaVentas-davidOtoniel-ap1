using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FechaCreacion { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Debe ingresar un nombre.")]
    [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Este campo no acepta números ni caracteres especiales.")]
    [StringLength(25, ErrorMessage = "El límite es de 25 caracteres.")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "Debe ingresar un email.")]
    [EmailAddress(ErrorMessage = "El formato para el email no es válido.")]
    [RegularExpression(@"^[^\s]+@[^\s]+\.[^\s]+$", ErrorMessage = "El email no puede contener espacios.")]
    [StringLength(40, ErrorMessage = "El límite es de 40 caracteres.")]
    public string Email { get; set; }
    [StringLength(250, ErrorMessage = "El límite es de 250 caracteres.")]
    public string Nota { get; set; } = string.Empty;

    public bool Eliminado { get; set; } = false;
}