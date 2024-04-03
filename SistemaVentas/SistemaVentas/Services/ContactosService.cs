using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using System.Linq.Expressions;

namespace SistemaVentas.Services;

public class ContactosService
{
	private readonly ApplicationDbContext _contexto;

	public ContactosService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<List<Numeros>>? Listar(Expression<Func<Numeros, bool>> criterio)
	{
		return _contexto.Contactos
			.AsNoTracking()
			.Where(criterio)
			.ToList();
	}
}
