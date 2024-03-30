using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class DevolucionesDetalle
{
	[Key]
	public int DevolucionDetalleId { get; set; }

    public int DevolucionId { get; set; }

    [ForeignKey("Productos")]
    public int ProductoId { get; set; }

    public int CantidadDevuelta { get; set; }

    public decimal PrecioTotal { get; set; }

    public decimal PrecioUnidad { get; set; }

    public string Motivo { get; set; }

    public bool Eliminado { get; set; } = false;
}
