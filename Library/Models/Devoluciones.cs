using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Devoluciones
{
	[Key]
	public int DevolucionId { get; set; }

	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
	public DateTime FechaDevolucion { get; set; } = DateTime.Today;
	public decimal MontoDevolucion { get; set; }
	public string Observacion { get; set; }

	[ForeignKey("DevolucionId")]
	public ICollection<DevolucionesDetalle> DevolucionesDetalle { get; set; } = new List<DevolucionesDetalle>();
}
