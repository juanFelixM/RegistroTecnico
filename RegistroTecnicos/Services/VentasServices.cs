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
        foreach (var detalle in venta.ventasDetalles)
        {
            var sistema = await contexto.Sistemas.FindAsync(detalle.SistemaId);
            if (sistema != null)
            {
                sistema.Existencia -= detalle.Cantidad;
                if (sistema.Existencia < 0)
                    sistema.Existencia = 0;
            }
        }
        contexto.Ventas.Add(venta);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Ventas venta)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var ventaOriginal = await contexto.Ventas
            .Include(v => v.ventasDetalles)
            .FirstOrDefaultAsync(v => v.VentaId == venta.VentaId);
        if (ventaOriginal == null)
            return false;

        foreach (var detalleOriginal in ventaOriginal.ventasDetalles)
        {
            var sistema = await contexto.Sistemas.FindAsync(detalleOriginal.SistemaId);
            if (sistema != null)
            {
                sistema.Existencia += detalleOriginal.Cantidad;
            }
        }

        contexto.RemoveRange(ventaOriginal.ventasDetalles);
        await contexto.SaveChangesAsync();

        foreach (var detalle in venta.ventasDetalles)
        {
            var sistema = await contexto.Sistemas.FindAsync(detalle.SistemaId);
            if (sistema != null)
            {
                sistema.Existencia -= detalle.Cantidad;
                if (sistema.Existencia < 0)
                    sistema.Existencia = 0;
            }
            detalle.Sistema = null;
        }
        ventaOriginal.Fecha = venta.Fecha;
        ventaOriginal.ClienteId = venta.ClienteId;
        ventaOriginal.Monto = venta.Monto;
        ventaOriginal.ventasDetalles = venta.ventasDetalles;
        contexto.Update(ventaOriginal);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Ventas venta)
    {
        if (!await Existe(venta.VentaId))
        {
            return await Insertar(venta);
        }
        else
        {
            return await Modificar(venta);
        }
    }

    public async Task<Ventas?> Buscar(int ventaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .Include(v => v.ventasDetalles)
            .FirstOrDefaultAsync(v => v.VentaId == ventaId);
    }

    public async Task<bool> Eliminar(int ventaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var venta = await contexto.Ventas
            .Include(v => v.ventasDetalles)
            .FirstOrDefaultAsync(v => v.VentaId == ventaId);
        if (venta == null)
            return false;

        foreach (var detalle in venta.ventasDetalles)
        {
            var sistema = await contexto.Sistemas.FindAsync(detalle.SistemaId);
            if (sistema != null)
            {
                sistema.Existencia += detalle.Cantidad;
            }
        }
        contexto.Ventas.Remove(venta);
        return await contexto.SaveChangesAsync() > 0;
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
