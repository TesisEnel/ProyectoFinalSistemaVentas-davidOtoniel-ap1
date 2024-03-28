using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using System.Linq.Expressions;

namespace SistemaVentas.Services;

public class ComprasService
{
	private readonly ApplicationDbContext _contexto;

	public ComprasService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<bool> Crear(Compras compra)
	{
		if (!await Existe(compra.CompraId))
			return await Insertar(compra);
		else
			return await Modificar(compra);
	}

	public async Task<bool> Insertar(Compras compra)
	{
		_contexto.Compras.Add(compra);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Modificar(Compras compra)
	{
		_contexto.Update(compra);
		var modifico = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(compra).State = EntityState.Detached;
		return modifico;
	}

	public async Task<bool> Existe(int id)
	{
		return await _contexto.Compras
			.AnyAsync(c => c.CompraId == id);
	}

	public async Task<bool> Eliminar(int id)
	{
		var eliminar = await _contexto.Compras
			.Where(c => c.CompraId == id)
			.ExecuteDeleteAsync();

		return eliminar > 0;
	}

	public async Task<Compras?> BuscarId(int id)
	{
		return await _contexto.Compras
			.Include(c => c.ComprasDetalle.Where(d => d.Eliminado == false))
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.CompraId == id);
	}

	//public async Task<Compras?> BuscarNombre(string nombre)
	//{
	//	return await _contexto.Compras
	//		.AsNoTracking()
	//		.FirstOrDefaultAsync(p => p.NombrePro.ToLower() == nombre.ToLower());
	//}

	//public async Task<Compras?> BuscarRNC(string RNC)
	//{
	//	return await _contexto.Proveedores
	//		.AsNoTracking()
	//		.FirstOrDefaultAsync(p => p.RNC.ToLower() == RNC.ToLower());
	//}
	public async Task<List<Compras>>? Listar(Expression<Func<Compras, bool>> criterio)
	{
		return _contexto.Compras
			.Include(p => p.ComprasDetalle.Where(d => d.Eliminado == false))
			.AsNoTracking()
			.Where(criterio)
			.ToList();
	}
}
