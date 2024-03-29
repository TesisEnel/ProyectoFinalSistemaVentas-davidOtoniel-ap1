using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;

namespace SistemaVentas.Services;

public class BancoService
{
	private readonly ApplicationDbContext _contexto;

    public BancoService(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

	public async Task<Banco?> BuscarId(int id)
	{
		return await _contexto.Banco
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.BancoId == id);
	}
}
