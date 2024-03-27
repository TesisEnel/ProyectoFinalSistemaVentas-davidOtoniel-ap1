using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class VentasDetalle
{
    [Key]
    public int VentaDetalleId { get; set; }
    public int VentaId { get; set; }
    public int ProductoId { get; set; }
    [Range(0, 100000, ErrorMessage = "El campo {0} debe ser mayor que 0 y menor que 100000.")]
    public float Cantidad { get; set; }
    public bool Eliminado { get; set; } = false;
}