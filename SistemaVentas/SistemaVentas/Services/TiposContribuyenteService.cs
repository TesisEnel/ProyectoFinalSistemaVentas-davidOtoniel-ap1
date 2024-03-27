using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using System.Linq.Expressions;

namespace SistemaVentas.Services;

public class TiposContribuyenteService
{
	private readonly ApplicationDbContext _contexto;

    public TiposContribuyenteService(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

	public async Task<List<TiposContribuyente>>? Listar(Expression<Func<TiposContribuyente, bool>> criterio)
	{
		return _contexto.TiposContribuyente
			.AsNoTracking()
			.Where(criterio)
			.ToList();
	}
}
