using Infraestrutura.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Mapping;

public class UsarioMapping : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("USUARIO");
        
        builder.HasKey(o => o.IdUsuario);
        builder.Property(t => t.Nome)
            .IsRequired();
        builder.Property(t => t.Idade)
            .IsRequired();
    }
}