using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class ComprasDetalle
{
    [Key]
    public int DetalleId { get; set; }

	public int ProductoId { get; set; }
	public int CantidadProducto { get; set; }

    public int UnidadMedidaId { get; set; }

    public int CantidadUnidadProducto { get; set; }

    //borrar precio mas tarde
    public decimal Precio { get; set; }

    public decimal CostoTotal { get; set; }
    public decimal CostoUnidad { get; set; }

    public decimal Itbis { get; set; }

    public decimal Valor { get; set; }

    public int CompraId { get; set; }

    public bool Eliminado { get; set; }
}
