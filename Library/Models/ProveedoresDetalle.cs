using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class ProveedoresDetalle
{
	[Key]
	public int ProveedorDetalleId { get; set; }

	public int ProveedorId { get; set; }

	[ForeignKey("Contactos")]
	public int ContactoId { get; set; }

	public string Contacto { get; set; }

	public bool Eliminado { get; set; } = false;
}
