using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SistemaVentas.Data;
using System.Linq.Expressions;

namespace SistemaVentas.Services;

public class VentasService
{
	private readonly ApplicationDbContext _contexto;

	public VentasService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<bool> Guardar(Ventas venta)
	{
		if (!await Existe(venta.VentaId))
			return await Insertar(venta);
		else
			return await Modificar(venta);
	}

	public async Task<bool> Insertar(Ventas venta)
	{
		_contexto.Ventas.Add(venta);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Modificar(Ventas venta)
	{
		_contexto.Update(venta);
		var modifico = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(venta).State = EntityState.Detached;
		return modifico;
	}

	public async Task<bool> Existe(int id)
	{
		return await _contexto.Ventas
			.AnyAsync(v => v.VentaId == id);
	}

	public async Task<bool> Eliminar(int id)
	{
		var eliminar = await _contexto.Ventas
			.Where(v => v.VentaId == id)
			.ExecuteDeleteAsync();

		return eliminar > 0;
	}

	public async Task<Ventas?> BuscarId(int id)
	{
		return await _contexto.Ventas
			.Include(v => v.VentasDetalle.Where(v => v.Eliminado == false))
			.AsNoTracking()
			.FirstOrDefaultAsync(v => v.VentaId == id);
	}
	public async Task<List<Ventas>>? Listar(Expression<Func<Ventas, bool>> criterio)
	{
		return _contexto.Ventas
			.Include(v => v.VentasDetalle.Where(v => v.Eliminado == false))
			.AsNoTracking()
			.Where(criterio)
			.ToList();
	}
}