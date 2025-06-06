﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.Services;

public class TecnicosServices(IDbContextFactory<Contexto> DbFactory)
{
    // Metodo Guardar
    public async Task<bool> Guardar(Tecnicos tecnico)
    {
        tecnico.TecnicoId = tecnico.TecnicoId;
        if (!await Existe(tecnico.TecnicoId))
        {
            return await Insertar(tecnico);
        }
        else
        {
            return await Modificar(tecnico);
        }
    }

    // Metodo Existe
    public async Task<bool> Existe(int TecnicoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos
            .AnyAsync(t => t.TecnicoId == TecnicoId);

    }

    //Metodo Insertar

    public async Task<bool> Insertar(Tecnicos tecnico)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Tecnicos.Add(tecnico);
        return await contexto.SaveChangesAsync() > 0;
    }

    //Metodo Modificar
    public async Task<bool> Modificar(Tecnicos tecnico)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(tecnico);
        return await contexto
            .SaveChangesAsync() > 0;
       
    }

    //Metodo Buscar
    public async Task<Tecnicos?> Buscar(int TecnicoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos
            .FirstOrDefaultAsync(t => t.TecnicoId == TecnicoId);
    }
    
    //Metodo Eliminar
    public async Task<bool> Eliminar(int tecnicoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos
            .AsNoTracking()
            .Where(t => t.TecnicoId == tecnicoId)
            .ExecuteDeleteAsync() > 0;  
    }

    //Metodo Listar
    public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
