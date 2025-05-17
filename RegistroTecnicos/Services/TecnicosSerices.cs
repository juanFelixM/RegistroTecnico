using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.Services
{
    public class TecnicosSerices(IDbContextFactory<Contexto> DbFactory)
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
        private async Task<bool> Existe(int TecnicoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tecnicos
                .AnyAsync(t => t.TecnicoId == TecnicoId);

        }

        //Metodo Insertar

        private async Task<bool> Insertar(Tecnicos tecnicos)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Tecnicos.Add(tecnicos);
            return await contexto.SaveChangesAsync() > 0;
        }

        //Metodo Modificar
        private async Task<bool> Modificar(Tecnicos tecnicos)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Entry(tecnicos).State = EntityState.Modified;
            return await contexto
                .SaveChangesAsync() > 0;
           
        }

        //Metodo Buscar
        public async Task<Tecnicos?> Buscar(int TecnicoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tecnicos.Include(d => d.TecnicoId)
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
}
