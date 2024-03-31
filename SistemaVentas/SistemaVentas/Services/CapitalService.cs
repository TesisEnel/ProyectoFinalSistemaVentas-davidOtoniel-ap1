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

	public async Task<bool> Modificar(Capital capital)
	{
		_contexto.Update(capital);
		var modifico = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(capital).State = EntityState.Detached;
		return modifico;
	}
}
