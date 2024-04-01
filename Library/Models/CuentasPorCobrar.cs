using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
	public class CuentasPorCobrar
	{
		[Key]
		public int CuentaPorCobrarId { get; set; }

		[ForeignKey("Ventas")]
		public int VentaId { get; set; }
		public Ventas Venta { get; set; }

		public decimal DeudaInicial { get; set; }

		public decimal DeudaRestante { get; set; }

		public string Estado { get; set; }

		[ForeignKey("CuentaPorCobrarId")]
		public ICollection<CuentasPorCobrarDetalle> CuentasPorCobrarDetalle { get; set; } = new List<CuentasPorCobrarDetalle>();
	}
}