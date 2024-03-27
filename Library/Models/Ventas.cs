using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class Ventas
{
    [Key]
    public int VentaId { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Fecha { get; set; } = DateTime.Today;
    public float SubTotal { get; set; }
    public bool Eliminado { get; set; } = false;
    public float Pago { get; set; }
    public float Devolucion { get; set; }

    [ForeignKey("VentaId")]
    public ICollection<VentasDetalle> VentaDetalle { get; set; } = new List<VentasDetalle>();
}