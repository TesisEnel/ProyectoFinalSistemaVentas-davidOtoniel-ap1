using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using System.Linq.Expressions;

namespace SistemaVentas.Services;

public class CuentasPorCobrarService
{
    private readonly ApplicationDbContext _contexto;

    public CuentasPorCobrarService(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Crear(CuentasPorCobrar cuentaPorCobrar)
    {
        if (!await Existe(cuentaPorCobrar.CuentaPorCobrarId))
            return await Insertar(cuentaPorCobrar);
        else
            return await Modificar(cuentaPorCobrar);
    }

    public async Task<bool> Insertar(CuentasPorCobrar cuentaPorCobrar)
    {
        _contexto.CuentasPorCobrar.Add(cuentaPorCobrar);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(CuentasPorCobrar cuentaPorCobrar)
    {
        _contexto.Update(cuentaPorCobrar);
        var modifico = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(cuentaPorCobrar).State = EntityState.Detached;
        return modifico;
    }

    public async Task<bool> Existe(int id)
    {
        return await _contexto.CuentasPorCobrar
            .AnyAsync(p => p.CuentaPorCobrarId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var eliminar = await _contexto.CuentasPorCobrar
            .Where(p => p.CuentaPorCobrarId == id)
            .ExecuteDeleteAsync();

        return eliminar > 0;
    }

    public async Task<CuentasPorCobrar?> BuscarId(int id)
    {
        return await _contexto.CuentasPorCobrar
            .Include(p => p.CuentasPorCobrarDetalle)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.CuentaPorCobrarId == id);
    }
    public async Task<List<CuentasPorCobrar>>? Listar(Expression<Func<CuentasPorCobrar, bool>> criterio)
    {
        return _contexto.CuentasPorCobrar
            .Include(p => p.CuentasPorCobrarDetalle)
            .AsNoTracking()
            .Where(criterio)
            .ToList();
    }
}