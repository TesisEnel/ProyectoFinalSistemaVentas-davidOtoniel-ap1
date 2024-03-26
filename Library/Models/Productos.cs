using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
	public class Productos
	{
		[Key]
		public int ProductoId { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio.")]
		public string Nombre { get; set; } = string.Empty;

		[Required(ErrorMessage = "Este campo es obligatorio.")]
		public string Descripcion { get; set; } = string.Empty;
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime FechaCreacion { get; set; } = DateTime.Today;
		[Required(ErrorMessage = "Debe elegir una categoria.")]
		public string Categoria { get; set; } = string.Empty;
		[Required(ErrorMessage = "Este campo es obligatorio.")]
		[Range(1, 100000, ErrorMessage = "El campo {0} debe ser mayor que 0 y menor que 100000.")]
		public float Precio { get; set; }
		[Required(ErrorMessage = "Este campo es obligatorio.")]
		[Range(1, 100000, ErrorMessage = "El campo {0} debe ser mayor que 0 y menor que 100000.")]
		public int Existencia { get; set; }
		public bool Eliminado { get; set; } = false;
		public string Nota { get; set; } = string.Empty;
	}
}