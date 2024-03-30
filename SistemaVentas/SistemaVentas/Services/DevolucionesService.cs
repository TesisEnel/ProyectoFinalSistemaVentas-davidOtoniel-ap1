using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using System.Linq.Expressions;

namespace SistemaVentas.Services;

public class DevolucionesService
{
	private readonly ApplicationDbContext _contexto;

	public DevolucionesService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<bool> Crear(Devoluciones devolucion)
	{
		if (!await Existe(devolucion.DevolucionId))
			return await Insertar(devolucion);
		else
			return await Modificar(devolucion);
	}

	public async Task<bool> Insertar(Devoluciones devolucion)
	{
		_contexto.Devoluciones.Add(devolucion);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Modificar(Devoluciones devolucion)
	{
		_contexto.Update(devolucion);
		var modifico = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(devolucion).State = EntityState.Detached;
		return modifico;
	}

	public async Task<bool> Existe(int id)
	{
		return await _contexto.Devoluciones
			.AnyAsync(d => d.DevolucionId == id);
	}

	public async Task<bool> Eliminar(int id)
	{
		var eliminar = await _contexto.Devoluciones
			.Where(d => d.DevolucionId == id)
			.ExecuteDeleteAsync();

		return eliminar > 0;
	}

	public async Task<Devoluciones?> BuscarId(int id)
	{
		return await _contexto.Devoluciones
			.Include(d => d.DevolucionesDetalle.Where(dd => dd.Eliminado == false))
			.AsNoTracking()
			.FirstOrDefaultAsync(p => p.DevolucionId == id);
	}

	//public async Task<Devoluciones?> BuscarNombre(string nombre)
	//{
	//	return await _contexto.Devoluciones
	//		.AsNoTracking()
	//		.FirstOrDefaultAsync(p => p.Nombre.ToLower() == nombre.ToLower());
	//}
	//public async Task<Devoluciones?> BuscarEmail(string email)
	//{
	//	return await _contexto.Devoluciones
	//		.AsNoTracking()
	//		.FirstOrDefaultAsync(p => p.Email.ToLower() == email.ToLower());
	//}
	//public async Task<Devoluciones?> BuscarRNC(string RNC)
	//{
	//	return await _contexto.Devoluciones
	//		.AsNoTracking()
	//		.FirstOrDefaultAsync(p => p.RNC.ToLower() == RNC.ToLower());
	//}
	public async Task<List<Devoluciones>>? Listar(Expression<Func<Devoluciones, bool>> criterio)
	{
		return _contexto.Devoluciones
			.Include(d => d.DevolucionesDetalle.Where(dd => dd.Eliminado == false))
			.AsNoTracking()
			.Where(criterio)
			.ToList();
	}
}
