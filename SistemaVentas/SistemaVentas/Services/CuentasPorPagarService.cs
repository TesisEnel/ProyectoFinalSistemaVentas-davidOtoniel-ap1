using Library.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using System.Linq.Expressions;

namespace SistemaVentas.Services;

public class CuentasPorPagarService
{
    private readonly ApplicationDbContext _contexto;

    public CuentasPorPagarService(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Crear(CuentasPorPagar cuentaPorPagar)
    {
        if (!await Existe(cuentaPorPagar.CuentaPorPagarId))
            return await Insertar(cuentaPorPagar);
        else
            return await Modificar(cuentaPorPagar);
    }

    public async Task<bool> Insertar(CuentasPorPagar cuentaPorPagar)
    {
		//_contexto.CuentasPorPagar.Add(cuentaPorPagar);
		//return await _contexto.SaveChangesAsync() > 0;
		return true;
	}

    public async Task<bool> Modificar(CuentasPorPagar cuentaPorPagar)
    {
        _contexto.Update(cuentaPorPagar);
        var modifico = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(cuentaPorPagar).State = EntityState.Detached;
        return modifico;
    }

    public async Task<bool> Existe(int id)
    {
		//return await _contexto.CuentasPorPagar
		//    .AnyAsync(p => p.CuentaPorPagarId == id);
		return true;
	}

    public async Task<bool> Eliminar(int id)
    {
		//var eliminar = await _contexto.CuentasPorPagar
		//    .Where(p => p.CuentaPorPagarId == id)
		//    .ExecuteDeleteAsync();

		//return eliminar > 0;
		return true;
	}

    public async Task<CuentasPorPagar?> BuscarId(int id)
    {
        //return await _contexto.CuentasPorPagar
        //    .Include(p => p.CuentasPorPagarDetalle)
        //    .AsNoTracking()
        //    .FirstOrDefaultAsync(p => p.CuentaPorPagarId == id);
        CuentasPorPagar cuentasPorPagar = null;
        return cuentasPorPagar;
    }

    //public async Task<CuentasPorPagar?> BuscarNombre(string nombre)
    //{
    //    return await _contexto.CuentasPorPagar
    //        .AsNoTracking()
    //        .FirstOrDefaultAsync(p => p.Nombre.ToLower() == nombre.ToLower());
    //}
    //public async Task<CuentasPorPagar?> BuscarEmail(string email)
    //{
    //    return await _contexto.Proveedores
    //        .AsNoTracking()
    //        .FirstOrDefaultAsync(p => p.Email.ToLower() == email.ToLower());
    //}
    //public async Task<CuentasPorPagar?> BuscarRNC(string RNC)
    //{
    //    return await _contexto.Proveedores
    //        .AsNoTracking()
    //        .FirstOrDefaultAsync(p => p.RNC.ToLower() == RNC.ToLower());
    //}
    public async Task<List<CuentasPorPagar>>? Listar(Expression<Func<CuentasPorPagar, bool>> criterio)
    {
        //return _contexto.CuentasPorPagar
        //    .Include(p => p.CuentasPorPagarDetalle)
        //    .AsNoTracking()
        //    .Where(criterio)
        //    .ToList();
        List<CuentasPorPagar> cuentasPorPagar = null;
        return cuentasPorPagar;
    }
}
