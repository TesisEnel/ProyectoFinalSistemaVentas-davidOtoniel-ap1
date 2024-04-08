using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class PagoDetalle
{
	[Key]
	public int PagoDetalleId { get; set; }

	[ForeignKey("CuentasPorPagar")]
	public int CuentaPorPagarId { get; set; } 
	public string porciento { get; set; } 

	public DateTime FechaPago { get; set; }

	public decimal MontoPago { get; set; }
}
