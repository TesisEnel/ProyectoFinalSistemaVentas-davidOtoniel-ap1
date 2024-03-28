using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using System.Linq.Expressions;

namespace SistemaVentas.Services;

public class UnidadesMedidaService
{
	private readonly ApplicationDbContext _contexto;

	public UnidadesMedidaService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<List<UnidadesMedida>>? Listar(Expression<Func<UnidadesMedida, bool>> criterio)
	{
		return _contexto.UnidadesMedida
			.AsNoTracking()
			.Where(criterio)
			.ToList();
	}
}
