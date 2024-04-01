using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class Ventas
{
	[Key]
	public int VentaId { get; set; }

	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
	public DateTime FechaCreacion { get; set; } = DateTime.Today;

	[Required(ErrorMessage = "Debe ingresar un nombre.")]
	[RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Este campo no acepta números ni caracteres especiales.")]
	[StringLength(25, ErrorMessage = "El límite es de 25 caracteres.")]
	public string EmpleadoResponsable { get; set; }

	[ForeignKey("Clientes")]
	[Range(1, int.MaxValue, ErrorMessage = "Debe elegir un cliente para la venta.")]
	public int ClienteId { get; set; }

	[ForeignKey("MetodosPago")]
	[Range(1, int.MaxValue, ErrorMessage = "Debe elegir un método de pago.")]
	public int MetodoPagoId { get; set; }

	public decimal SubTotal { get; set; } = 0;
	public decimal TotalItbis { get; set; } = 0;
	public decimal TotalNeto { get; set; } = 0;
	public decimal MontoPagado { get; set; } = 0;
	public decimal Devuelta { get; set; } = 0;
	public decimal Deuda { get; set; } = 0;


	[StringLength(250, ErrorMessage = "El límite es de 250 caracteres.")]
	public string Nota { get; set; }

	public string Estado { get; set; }

	public bool Eliminado { get; set; } = false;

	[ForeignKey("VentaId")]
	public ICollection<VentasDetalle> VentasDetalle { get; set; } = new List<VentasDetalle>();

	public CuentasPorCobrar CuentaPorCobrar { get; set; }
}