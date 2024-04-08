using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class CuentasPorPagar
{
	[Key]
	public int CuentaPorPagarId { get; set; }

	[ForeignKey("Compras")]
	public int CompraId { get; set; }
    public Compras Compra { get; set; }

	public decimal DeudaInicial { get; set; }

    public decimal DeudaRestante { get; set; }

    public string Estado { get; set; }

	[ForeignKey("CuentaPorPagarId")]
	public ICollection<CuentasPorPagarDetalle> CuentasPorPagarDetalle { get; set; } = new List<CuentasPorPagarDetalle>();

	[ForeignKey("CuentaPorPagarId")]
	public ICollection<PagoDetalle> PagoDetalle { get; set; } = new List<PagoDetalle>();
}
