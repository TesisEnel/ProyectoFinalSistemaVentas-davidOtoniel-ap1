using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using System.Linq.Expressions;

namespace SistemaVentas.Services;

public class MetodosPagoService
{
	private readonly ApplicationDbContext _contexto;

	public MetodosPagoService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<List<MetodosPago>>? Listar(Expression<Func<MetodosPago, bool>> criterio)
	{
		return _contexto.MetodosPago
			.AsNoTracking()
			.Where(criterio)
			.ToList();
	}
}
