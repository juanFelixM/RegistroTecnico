using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.Services
{
    public class TecnicosSerices(IDbContextFactory<Contexto> DbFctory)
    {
        public async Task<bool> Guardar(Tecnicos tecnicos)
        {
            tecnicos.TecnicosId = tecnicos.TecnicosId;
            if (!await Existe(tecnicos.TecnicosId))
            {
                return await Insertar(tecnicos);
            }
            else
            {
                return await Modificar(tecnicos);
            }
        }

        
    }
}
