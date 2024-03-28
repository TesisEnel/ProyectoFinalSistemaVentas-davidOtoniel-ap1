using Library.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SistemaVentas.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
	public DbSet<Productos> Productos { get; set; }
	public DbSet<Categorias> Categorias { get; set; }
	public DbSet<TiposContribuyente> TiposContribuyente { get; set; }
	public DbSet<Contactos> Contactos { get; set; }
	public DbSet<Proveedores> Proveedores { get; set; }
	public DbSet<Ventas> Ventas { get; set; }
	public DbSet<Compras> Compras { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Contactos>().HasData(new List<Contactos>
		{
			new Contactos { ContactoId = 1, Descripcion = "Teléfono"},
			new Contactos { ContactoId = 2, Descripcion = "Fax"}
		});

		modelBuilder.Entity<TiposContribuyente>().HasData(new List<TiposContribuyente>
		{
			new TiposContribuyente { TipoContribuyenteId = 1, Descripcion = "Persona Física"},
			new TiposContribuyente { TipoContribuyenteId = 2, Descripcion = "Persona Jurídica"}
		});
	}
}