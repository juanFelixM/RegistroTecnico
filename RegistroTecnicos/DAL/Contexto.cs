using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Tecnicos> Tecnicos { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Tickets> Tickets { get; set; }
    public DbSet<Sistemas> Sistemas { get; set; }
    public DbSet<ClienteDetalles> ClienteDetalles { get; set; }
    public DbSet<TiposTelefonos> TiposTelefonos { get; set; }
    public DbSet<Ventas> Ventas { get; set; }
    public DbSet<VentasDetalles> VentasDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TiposTelefonos>().HasData(new List<TiposTelefonos>()
        {
            new TiposTelefonos { TipoId = 1, Descripcion = "Telefono" },
            new TiposTelefonos { TipoId = 2, Descripcion = "Celular" },
            new TiposTelefonos { TipoId = 3, Descripcion = "Oficina" }
        }); 
        
    }

}