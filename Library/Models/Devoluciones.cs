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

    [ForeignKey("Clientes")]
	[Range(1, int.MaxValue, ErrorMessage = "Debe elegir un cliente")]
    public int ClienteId { get; set; }

    public decimal MontoDevolucion { get; set; }

	[StringLength(100, ErrorMessage = "El límite es de 100 caracteres.")]
	public string Observacion { get; set; }

	public bool Eliminado { get; set; } = false;

    [ForeignKey("DevolucionId")]
	public ICollection<DevolucionesDetalle> DevolucionesDetalle { get; set; } = new List<DevolucionesDetalle>();
}
