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
	[Range(1, int.MaxValue,ErrorMessage = "Debe elegir un proveedor para la compra.")]
	public int ProveedorId { get; set; }

	[ForeignKey("MetodosPago")]
	[Range(1, int.MaxValue,ErrorMessage = "Debe elegir un método de pago.")]
	public int MetodoPagoId { get; set; }

	public decimal SubTotal { get; set; } = 0;
    public decimal TotalItbis { get; set; } = 0;
	public decimal TotalNeto { get; set; } = 0;
	public decimal MontoPagado { get; set; } = 0;
	public decimal Devuelta { get; set; } = 0;
	public decimal Deuda { get; set; } = 0;


	[StringLength(250, ErrorMessage = "El límite es de 250 caracteres.")]
	public string Nota { get; set; }

    public bool Estado { get; set; }

    public bool Eliminado { get; set; } = false;

    [ForeignKey("CompraId")]
    public ICollection<ComprasDetalle> ComprasDetalle { get; set; } = new List<ComprasDetalle>();

    public CuentasPorPagar CuentaPorPagar { get; set; }
}
