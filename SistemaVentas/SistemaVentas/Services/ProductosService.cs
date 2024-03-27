using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using System.Linq.Expressions;

namespace SistemaVentas.Services;

public class ProductosService
{
	private readonly ApplicationDbContext _contexto;

	public ProductosService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<bool> Guardar(Productos producto)
	{
		if (!await Existe(producto.ProductoId))
			return await Insertar(producto);
		else
			return await Modificar(producto);
	}

	private async Task<bool> Insertar(Productos producto)
	{
		_contexto.Productos.Add(producto);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Modificar(Productos producto)
	{
		_contexto.Update(producto);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Existe(int id)
	{
		return await _contexto.Productos
			.AnyAsync(p => p.ProductoId == id);
	}

	public async Task<bool> Eliminar(Productos producto)
	{
		var cantidad = await _contexto.Productos
			.Where(p => p.ProductoId == producto.ProductoId)
			.ExecuteDeleteAsync();

		return cantidad > 0;
	}

	public async Task<Productos?> BuscarId(int id)
	{
		return await _contexto.Productos
			.AsNoTracking()
			.FirstOrDefaultAsync(p => p.ProductoId == id);
	}

	public async Task<Productos?> BuscarNombre(string nombre)
	{
		return await _contexto.Productos
			.AsNoTracking()
			.FirstOrDefaultAsync(p => p.Nombre.ToLower() == nombre.ToLower());
	}
	public async Task<Productos?> BuscarDescripcion(string descripcion)
	{
		return await _contexto.Productos
			.AsNoTracking()
			.FirstOrDefaultAsync(p => p.Descripcion.ToLower() == descripcion.ToLower());
	}
	public async Task<List<Productos>>? Listar(Expression<Func<Productos, bool>> criterio)
	{
		return _contexto.Productos
			.AsNoTracking()
			.Where(criterio)
			.ToList();
	}
}