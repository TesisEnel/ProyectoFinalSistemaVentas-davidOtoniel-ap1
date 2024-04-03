using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Numeros
{
	[Key]
	public int NumeroId { get; set; }

	public string TipoNumero { get; set; }
}
