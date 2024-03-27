using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaVentas.Services;

public class CategoriasService
{
	private readonly ApplicationDbContext _contexto;

	public CategoriasService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<bool> Guardar(Categorias categoria)
	{
		if (!await Existe(categoria.CategoriaId))
			return await Insertar(categoria);
		else
			return await Modificar(categoria);
	}

	private async Task<bool> Insertar(Categorias categoria)
	{
		_contexto.Categorias.Add(categoria);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Modificar(Categorias categoria)
	{
		_contexto.Update(categoria);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Existe(int id)
	{
		return await _contexto.Categorias
			.AnyAsync(c => c.CategoriaId == id);
	}

	public async Task<bool> Eliminar(Categorias categoria)
	{
		var cantidad = await _contexto.Categorias
			.Where(c => c.CategoriaId == categoria.CategoriaId)
			.ExecuteDeleteAsync();

		return cantidad > 0;
	}

	public async Task<Categorias?> BuscarId(int id)
	{
		return await _contexto.Categorias
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.CategoriaId == id);
	}

	public async Task<Categorias?> BuscarDescripcion(string descripcion)
	{
		return await _contexto.Categorias
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.Descripcion.ToLower() == descripcion.ToLower());
	}
	public async Task<List<Categorias>>? Listar(Expression<Func<Categorias, bool>> criterio)
	{
		return _contexto.Categorias
			.AsNoTracking()
			.Where(criterio)
			.ToList();
	}
}