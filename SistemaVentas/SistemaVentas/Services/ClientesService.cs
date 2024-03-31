using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaVentas.Services;

public class ClientesService
{
	private readonly ApplicationDbContext _contexto;

	public ClientesService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<bool> Guardar(Clientes cliente)
	{
		if (!await Existe(cliente.ClienteId))
			return await Insertar(cliente);
		else
			return await Modificar(cliente);
	}

	private async Task<bool> Insertar(Clientes cliente)
	{
		_contexto.Clientes.Add(cliente);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Modificar(Clientes cliente)
	{
        _contexto.Update(cliente);
        var modifico = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(cliente).State = EntityState.Detached;
        return modifico;
    }

	public async Task<bool> Existe(int id)
	{
		return await _contexto.Clientes
			.AnyAsync(c => c.ClienteId == id);
	}

	public async Task<bool> Eliminar(Clientes cliente)
	{
		var cantidad = await _contexto.Clientes
			.Where(c => c.ClienteId == cliente.ClienteId)
			.ExecuteDeleteAsync();

		return cantidad > 0;
	}

	public async Task<Clientes?> BuscarId(int id)
	{
		return await _contexto.Clientes
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.ClienteId == id);
	}

	public async Task<Clientes?> BuscarNombre(string nombre)
	{
		return await _contexto.Clientes
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.Nombre.ToLower() == nombre.ToLower());
	}
	public async Task<Clientes?> BuscarEmail(string email)
	{
		return await _contexto.Clientes
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.Email.ToLower() == email.ToLower());
	}
	public async Task<List<Clientes>>? Listar(Expression<Func<Clientes, bool>> criterio)
	{
		return _contexto.Clientes
			.AsNoTracking()
			.Where(criterio)
			.ToList();
	}
}