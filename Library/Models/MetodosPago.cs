using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class MetodosPago
{
	[Key]
	public int MetodoPagoId { get; set; }

    public string MetodoPago { get; set; }
}
