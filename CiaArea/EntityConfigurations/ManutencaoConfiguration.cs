using CiaArea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CiaArea.EntityConfigurations
{
    public class ManutencaoConfiguration : IEntityTypeConfiguration<Manutencao>
    {
        public void Configure(EntityTypeBuilder<Manutencao> builder)
        {
            builder
                .ToTable("Manutencao");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.DataHora)
                .IsRequired();

            builder
                .HasIndex(p => p.TipoManutencao)
                .IsUnique();

            builder
                .Property(x => x.Observacoes)
                .HasMaxLength(100);
        }
    }
}
