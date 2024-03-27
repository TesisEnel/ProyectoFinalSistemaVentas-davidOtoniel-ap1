using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class Categorias
{
	[Key]
	public int CategoriaId { get; set; }
	[Required(ErrorMessage = "Este campo es obligatorio.")]
	public string Descripcion { get; set; } = string.Empty;
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
	public DateTime FechaCreacion { get; set; } = DateTime.Today;
	public bool Eliminado { get; set; } = false;
	[ForeignKey("CategoriaId")]
	public ICollection<Productos> Productos { get; set; } = new List<Productos>();
}