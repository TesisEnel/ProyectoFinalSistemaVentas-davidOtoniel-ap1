using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class CuentasPorPagar
{
	[Key]
	public int CuentaPorPagarId { get; set; }

	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
	public DateTime FechaPago { get; set; } = DateTime.Today;

    public decimal Deuda { get; set; }

    public decimal Abono { get; set; }

    public string Concepto { get; set; }

    public int CompraId { get; set; }
}
