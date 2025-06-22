using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class VentasServices(IDbContextFactory<Contexto> DbFactory)
{
    private async Task<bool> Existe(int ventaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .AnyAsync(v => v.VentaId == ventaId);
    }

    private async Task<bool> Insertar(Ventas venta)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Ventas.Add(venta);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Ventas venta)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(venta);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Ventas venta)
    {
        venta.Fecha = DateTime.SpecifyKind(venta.Fecha, DateTimeKind.Utc);

        if (!await Existe(venta.VentaId))
            return await Insertar(venta);
        else
            return await Modificar(venta);
    }

    public async Task<Ventas?> Buscar(int ventaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .FirstOrDefaultAsync(v => v.VentaId == ventaId);
    }

    public async Task<bool> Eliminar(int ventaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .AsNoTracking()
            .Where(v => v.VentaId == ventaId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Ventas>> Listar(Expression<Func<Ventas, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
