using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Proveedores
{
	[Key]
	public int ProveedorId { get; set; }

	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
	public DateTime FechaCreacion { get; set; } = DateTime.Today;

	[Required(ErrorMessage = "Debe ingresar un nombre.")]
	[RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Este campo no acepta números ni caracteres especiales.")]
	[StringLength(25, ErrorMessage = "El límite es de 25 caracteres.")]
	public string Nombre { get; set; }

	[Required(ErrorMessage = "Debe ingresar una dirección.")]
	[StringLength(70, ErrorMessage = "El límite es de 70 caracteres.")]
	public string Direccion { get; set; }

	[Required(ErrorMessage = "Debe ingresar una ciudad.")]
	[RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Este campo no acepta números ni caracteres especiales.")]
	[StringLength(30, ErrorMessage = "El límite es de 30 caracteres.")]
	public string Ciudad { get; set; }

	[Required(ErrorMessage = "Debe ingresar un email.")]
	[EmailAddress(ErrorMessage = "El formato para el email no es válido.")]
	[RegularExpression(@"^[^\s]+@[^\s]+\.[^\s]+$", ErrorMessage = "El email no puede contener espacios.")]
	[StringLength(40, ErrorMessage = "El límite es de 40 caracteres.")]
	public string Email { get; set; }
	
	[Required(ErrorMessage = "Debe ingresar un número de cuenta bancaria")]
	[RegularExpression(@"^[0-9]{10}$",ErrorMessage = "Ingrese 10 dígitos númericos")]
	public string NumeroCuenta { get; set; }

	[Required(ErrorMessage = "Debe ingresar el nombre de un banco")]
	[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "El campo Banco solo puede contener letras y espacios.")]
	[StringLength(25, ErrorMessage = "El límite es de 25 caracteres.")]
	public string Banco { get; set; }

	[ForeignKey("TiposContribuyente")]
	[Range(0,int.MaxValue,ErrorMessage = "Debe elegir un tipo de contribuyente.")]
	public int TipoContribuyenteId { get; set; }

	[Required(ErrorMessage = "Debe ingresar un número de RNC")]
	[RegularExpression(@"^[0-9]{11}$", ErrorMessage = "El RNC debe tener exactamente 11 dígitos numéricos.")]
	public string RNC { get; set; }

	[StringLength(250, ErrorMessage = "El límite es de 250 caracteres.")]
	public string Nota { get; set; }

	public bool Eliminado { get; set; } = false;

	[ForeignKey("ProveedorId")]
	public ICollection<ProveedoresDetalle> ProveedoresDetalle { get; set; } = new List<ProveedoresDetalle>();
}
