using Library.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace SistemaVentas.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
	public DbSet<Productos> Productos { get; set; }
	public DbSet<Categorias> Categorias { get; set; }
	public DbSet<TiposContribuyente> TiposContribuyente { get; set; }
	public DbSet<Numeros> Contactos { get; set; }
	public DbSet<Proveedores> Proveedores { get; set; }
	public DbSet<Ventas> Ventas { get; set; }
	public DbSet<Compras> Compras { get; set; }
	public DbSet<MetodosPago> MetodosPago { get; set; }
	public DbSet<UnidadesMedida> UnidadesMedida { get; set; }
	public DbSet<Banco> Banco { get; set; }
	public DbSet<Capital> Capital { get; set; }
	public DbSet<CuentasPorPagar> CuentasPorPagar { get; set; }
	public DbSet<Devoluciones> Devoluciones { get; set; }
	public DbSet<Clientes> Clientes { get; set; }
	public DbSet<CuentasPorCobrar> CuentasPorCobrar { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Numeros>().HasData(new List<Numeros>
		{
			new Numeros { NumeroId = 1, TipoNumero = "Teléfono"},
			new Numeros { NumeroId = 2, TipoNumero = "Fax"}
		});

		modelBuilder.Entity<TiposContribuyente>().HasData(new List<TiposContribuyente>
		{
			new TiposContribuyente { TipoContribuyenteId = 1, TipoContribuyente = "Persona Fisica"},
			new TiposContribuyente { TipoContribuyenteId = 2, TipoContribuyente = "Persona Juridica"}
		});

		modelBuilder.Entity<Compras>()
			.Property(c => c.SubTotal)
			.HasPrecision(18, 2);

		modelBuilder.Entity<Compras>()
			.Property(c => c.TotalItbis)
			.HasPrecision(18, 2);

		modelBuilder.Entity<Compras>()
			.Property(c => c.TotalNeto)
			.HasPrecision(18, 2);

		modelBuilder.Entity<Compras>()
			.Property(cd => cd.MontoPagado)
			.HasPrecision(18, 2);

		modelBuilder.Entity<Compras>()
			.Property(cd => cd.Devuelta)
			.HasPrecision(18, 2);

		modelBuilder.Entity<Compras>()
			.Property(cd => cd.Deuda)
			.HasPrecision(18, 2);

		modelBuilder.Entity<ComprasDetalle>()
			.Property(cd => cd.Itbis)
			.HasPrecision(18, 2);

		modelBuilder.Entity<ComprasDetalle>()
			.Property(cd => cd.CostoTotal)
			.HasPrecision(18, 2);

		modelBuilder.Entity<ComprasDetalle>()
			.Property(cd => cd.CostoUnidad)
			.HasPrecision(18, 2);

		modelBuilder.Entity<ComprasDetalle>()
			.Property(cd => cd.CostoTotalNeto)
			.HasPrecision(18, 2);

		modelBuilder.Entity<Ventas>()
			.Property(v => v.SubTotal)
			.HasPrecision(18, 2);

		modelBuilder.Entity<Ventas>()
			.Property(v => v.TotalItbis)
			.HasPrecision(18, 2);

		modelBuilder.Entity<Ventas>()
			.Property(v => v.TotalNeto)
			.HasPrecision(18, 2);

		modelBuilder.Entity<Ventas>()
			.Property(vd => vd.MontoPagado)
			.HasPrecision(18, 2);

		modelBuilder.Entity<Ventas>()
			.Property(vd => vd.Devuelta)
			.HasPrecision(18, 2);

		modelBuilder.Entity<Ventas>()
			.Property(vd => vd.Deuda)
			.HasPrecision(18, 2);

		modelBuilder.Entity<VentasDetalle>()
			.Property(vd => vd.Itbis)
			.HasPrecision(18, 2);

		modelBuilder.Entity<VentasDetalle>()
			.Property(vd => vd.CostoTotal)
			.HasPrecision(18, 2);

		modelBuilder.Entity<VentasDetalle>()
			.Property(vd => vd.CostoUnidad)
			.HasPrecision(18, 2);

		modelBuilder.Entity<VentasDetalle>()
			.Property(vd => vd.CostoTotalNeto)
			.HasPrecision(18, 2);


		modelBuilder.Entity<MetodosPago>().HasData(new List<MetodosPago>
		{
			new MetodosPago { MetodoPagoId = 1, MetodoPago = "Efectivo"},
			new MetodosPago { MetodoPagoId = 2, MetodoPago = "Crédito"},
			new MetodosPago { MetodoPagoId = 3, MetodoPago = "Transferencia"}
		});

		modelBuilder.Entity<UnidadesMedida>().HasData(new List<UnidadesMedida>
		{
			new UnidadesMedida { UnidadMedidaId = 1, UnidadMedida = "Caja"},
			new UnidadesMedida { UnidadMedidaId = 2, UnidadMedida = "Pieza"},
			new UnidadesMedida { UnidadMedidaId = 3, UnidadMedida = "Gramo"},
			new UnidadesMedida { UnidadMedidaId = 4, UnidadMedida = "Metro"},
			new UnidadesMedida { UnidadMedidaId = 5, UnidadMedida = "Libra"}
		});

		modelBuilder.Entity<Banco>()
			.Property(cd => cd.Monto)
			.HasPrecision(18, 2);

		modelBuilder.Entity<Banco>().HasData(new List<Banco>
		{
			new Banco 
				{ 
					BancoId = 1, 
					Usuario = "Admin", 
					NumeroTarjeta = "1122334455667788",
					FechaVencimiento = DateTime.ParseExact("2/05/2026", "d/MM/yyyy", CultureInfo.InvariantCulture),
					CodigoSeguridad = 123,
					Monto = 500000000,
				}
		});

		modelBuilder.Entity<Capital>()
			.Property(cd => cd.Efectivo)
			.HasPrecision(18, 2);

		modelBuilder.Entity<Capital>().HasData(new List<Capital>
		{
			new Capital { CapitalId = 1, Efectivo = 500000000}
		});

		modelBuilder.Entity<Devoluciones>()
			.Property(cd => cd.MontoDevolucion)
			.HasPrecision(18, 2);

		modelBuilder.Entity<DevolucionesDetalle>()
			.Property(cd => cd.PrecioTotal)
			.HasPrecision(18, 2);

		modelBuilder.Entity<DevolucionesDetalle>()
			.Property(cd => cd.PrecioUnidad)
			.HasPrecision(18, 2);


		modelBuilder.Entity<CuentasPorPagar>()
			.Property(cd => cd.DeudaRestante)
			.HasPrecision(18, 2);

		modelBuilder.Entity<CuentasPorPagar>()
			.Property(cd => cd.DeudaInicial)
			.HasPrecision(18, 2);

		modelBuilder.Entity<CuentasPorPagarDetalle>()
			.Property(cd => cd.Abono)
			.HasPrecision(18, 2);
	}
}