using CiaArea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CiaArea.EntityConfigurations
{
    public class PilotoConfiguration : IEntityTypeConfiguration<Piloto>
    {
        public void Configure(EntityTypeBuilder<Piloto> builder)
        {
            builder
                .ToTable("Pilotos");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.Matricula)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .HasIndex(p => p.Matricula)
                .IsUnique();
        }
    }
}
