using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TicketsServices(IDbContextFactory<Contexto> DbFactory)
{
    private async Task<bool> Existe(int ticketId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets
            .AnyAsync(t => t.TicketId == ticketId);
    }

    private async Task<bool> Insertar(Tickets tickets)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Tickets.Add(tickets);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Tickets tickets)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(tickets);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Tickets tickets)
    {
        tickets.Fecha = DateTime.SpecifyKind(tickets.Fecha, DateTimeKind.Utc);

        if (!await Existe(tickets.TicketId))
            return await Insertar(tickets);
        else
            return await Modificar(tickets);
    }

    public async Task<Tickets?> Buscar(int ticketId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets
            .FirstOrDefaultAsync(t => t.TicketId == ticketId);
    }
    public async Task<bool> Eliminar(int ticketId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets
            .AsNoTracking()
            .Where(t => t.TicketId == ticketId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}