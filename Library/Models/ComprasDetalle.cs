using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class ComprasDetalle
{
    [Key]
    public int CompraDetalleId { get; set; }

	public int CompraId { get; set; }

    [ForeignKey("Productos")]
	public int ProductoId { get; set; }
	public int CantidadProducto { get; set; }

    [ForeignKey("UnidadesMedida")]
    public int UnidadMedidaId { get; set; }

    public int CantidadUnidadProducto { get; set; }

    public decimal CostoTotal { get; set; }
    public decimal CostoUnidad { get; set; }

    public decimal Itbis { get; set; }

    public decimal CostoTotalNeto { get; set; }

    public bool Eliminado { get; set; }
}
