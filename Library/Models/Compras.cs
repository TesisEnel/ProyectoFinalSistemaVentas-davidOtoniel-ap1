using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Compras
{
	[Key]
	public int CompraId { get; set; }

	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
	public DateTime FechaCreacion { get; set; } = DateTime.Today;

	[Required(ErrorMessage = "Debe ingresar un nombre.")]
	[RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Este campo no acepta números ni caracteres especiales.")]
	[StringLength(25, ErrorMessage = "El límite es de 25 caracteres.")]
	public string UsuarioResponsable { get; set; }

    [ForeignKey("Proveedores")]
	[Required(ErrorMessage = "Debe elegir un proveedor para la compra.")]
	public int ProveedorId { get; set; }

	//public string DireccionProveedor { get; set; }

	//public string TipoContribuyente { get; set; }

	//public string RNC { get; set; }

	[ForeignKey("MetodosPago")]
	[Required(ErrorMessage = "Debe elegir un tipo de contribuyente.")]
	public int MetodoPagoId { get; set; }

	public decimal SubTotal { get; set; }
    public decimal TotalITIBS { get; set; }
    public decimal Total { get; set; }
    public decimal MontoPagado { get; set; }
    public decimal Devuelta { get; set; }
    public decimal Debo { get; set; }


    [StringLength(250, ErrorMessage = "El límite es de 250 caracteres.")]
	public string Nota { get; set; }

	public bool Eliminado { get; set; } = false;
	public string Estado { get; set; }

    [ForeignKey("CompraId")]
    public ICollection<ComprasDetalle> ComprasDetalle { get; set; } = new List<ComprasDetalle>();
}
