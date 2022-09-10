using System.Reflection;
using Infraestrutura.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.DataBaseContext;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());    
    }
    
    public DbSet<Usuario> Usuario { get; set; } = null!;
}