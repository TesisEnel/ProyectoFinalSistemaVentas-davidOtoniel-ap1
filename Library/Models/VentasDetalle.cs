using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models;

public class VentasDetalle
{
	[Key]
	public int VentaDetalleId { get; set; }

	public int VentaId { get; set; }

	[ForeignKey("Productos")]
	public int ProductoId { get; set; }
	public int CantidadProducto { get; set; }

	[ForeignKey("UnidadesMedida")]
	public int UnidadMedidaId { get; set; }

	public int CantidadUnidadProducto { get; set; }

	public decimal CostoTotal { get; set; }
	public decimal CostoUnidad { get; set; }

	public decimal Itbis { get; set; }

	public decimal CostoTotalNeto { get; set; }

	public bool Eliminado { get; set; } = false;
}