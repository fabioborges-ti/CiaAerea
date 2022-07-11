using CiaArea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CiaArea.EntityConfigurations
{
    public class AeronaveConfiguration : IEntityTypeConfiguration<Aeronave>
    {
        public void Configure(EntityTypeBuilder<Aeronave> builder)
        {
            builder
                .ToTable("Aeronaves");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Fabricante)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Modelo)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Codigo)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .HasMany(a => a.Manutencoes)
                .WithOne(m => m.Aeronave)
                .HasForeignKey(k => k.AeronaveId);
        }
    }
}
