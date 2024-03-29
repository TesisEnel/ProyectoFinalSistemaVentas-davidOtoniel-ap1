using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;

namespace SistemaVentas.Services;

public class CapitalService
{
	private readonly ApplicationDbContext _contexto;

	public CapitalService(ApplicationDbContext contexto)
	{
		_contexto = contexto;
	}

	public async Task<Capital?> BuscarId(int id)
	{
		return await _contexto.Capital
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.CapitalId == id);
	}
}
