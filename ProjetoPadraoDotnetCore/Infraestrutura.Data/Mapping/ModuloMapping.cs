using Infraestrutura.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Mapping;

public class ModuloMapping : IEntityTypeConfiguration<Modulo>
{
    public void Configure(EntityTypeBuilder<Modulo> builder)
    {
        builder.ToTable("MODULO");
        
        builder.HasKey(o => o.IdModulo);
        builder.Property(t => t.Nome).HasColumnName("NOME").IsRequired();
        builder.Property(t => t.Icone).HasColumnName("ICONE").IsRequired();
        builder.Property(t => t.DescricaoLabel).HasColumnName("DESCRICAOLABEL").IsRequired();
    }
}