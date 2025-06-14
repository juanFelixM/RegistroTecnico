using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;


namespace RegistroTecnicos.Services;

public class SistemasServices(IDbContextFactory<Contexto> DbFactory)
{
    // Metodo Guardar
    public async Task<bool> Guardar(Sistemas sistema)
    {
        sistema.SistemaId = sistema.SistemaId;
        if (!await Existe(sistema.SistemaId))
        {
            return await Insertar(sistema);
        }
        else
        {
            return await Modificar(sistema);
        }
    }

    // Metodo Existe
    public async Task<bool> Existe(int SistemaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Sistemas
            .AnyAsync(t => t.SistemaId == SistemaId);

    }

    //Metodo Insertar

    public async Task<bool> Insertar(Sistemas sistema)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Sistemas.Add(sistema);
        return await contexto.SaveChangesAsync() > 0;
    }

    //Metodo Modificar
    public async Task<bool> Modificar(Sistemas sistema)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(sistema);
        return await contexto
            .SaveChangesAsync() > 0;

    }

    //Metodo Buscar
    public async Task<Sistemas?> Buscar(int SistemaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Sistemas
            .FirstOrDefaultAsync(t => t.SistemaId == SistemaId);
    }

    //Metodo Eliminar
    public async Task<bool> Eliminar(int sistemaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Sistemas
            .AsNoTracking()
            .Where(t => t.SistemaId == sistemaId)
            .ExecuteDeleteAsync() > 0;
    }

    //Metodo Listar
    public async Task<List<Sistemas>> Listar(Expression<Func<Sistemas, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Sistemas
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}