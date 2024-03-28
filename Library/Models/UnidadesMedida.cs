using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class UnidadesMedida
{
	[Key]
	public int UnidadMedidaId { get; set; }

    public string UnidadMedida { get; set; }
}
