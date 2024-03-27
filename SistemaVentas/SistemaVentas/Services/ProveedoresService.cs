using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SistemaVentas.Data;
using System.Linq.Expressions;

namespace SistemaVentas.Services;

public class ProveedoresService
{
	private readonly ApplicationDbContext _contexto;

	public ProveedoresService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<bool> Crear(Proveedores proveedor)
	{
		if (!await Existe(proveedor.ProveedorId))
			return await Insertar(proveedor);
		else
			return await Modificar(proveedor);
	}

	public async Task<bool> Insertar(Proveedores proveedor)
	{
		_contexto.Proveedores.Add(proveedor);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Modificar(Proveedores proveedor)
	{
		_contexto.Update(proveedor);
		var modifico = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(proveedor).State = EntityState.Detached;
		return modifico;
	}

	public async Task<bool> Existe(int id)
	{
		return await _contexto.Proveedores
			.AnyAsync(p => p.ProveedorId == id);
	}

	public async Task<bool> Eliminar(int id)
	{
		var eliminar = await _contexto.Proveedores
			.Where(p => p.ProveedorId == id)
			.ExecuteDeleteAsync();

		return eliminar > 0;
	}

	public async Task<Proveedores?> BuscarId(int id)
	{
		return await _contexto.Proveedores
			.Include(p => p.ProveedoresDetalle.Where(d => d.Eliminado == false))
			.AsNoTracking()
			.FirstOrDefaultAsync(p => p.ProveedorId == id);
	}

	public async Task<Proveedores?> BuscarNombre(string nombre)
	{
		return await _contexto.Proveedores
			.AsNoTracking()
			.FirstOrDefaultAsync(p => p.Nombre.ToLower() == nombre.ToLower());
	}
	public async Task<Proveedores?> BuscarEmail(string email)
	{
		return await _contexto.Proveedores
			.AsNoTracking()
			.FirstOrDefaultAsync(p => p.Email.ToLower() == email.ToLower());
	}
	public async Task<Proveedores?> BuscarRNC(string RNC)
	{
		return await _contexto.Proveedores
			.AsNoTracking()
			.FirstOrDefaultAsync(p => p.RNC.ToLower() == RNC.ToLower());
	}
	public async Task<List<Proveedores>>? Listar(Expression<Func<Proveedores, bool>> criterio)
	{
		return _contexto.Proveedores
			.Include(p => p.ProveedoresDetalle.Where(d => d.Eliminado == false))
			.AsNoTracking()
			.Where(criterio)
			.ToList();
	}
}
