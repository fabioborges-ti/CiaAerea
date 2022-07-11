using CiaArea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CiaArea.EntityConfigurations
{
    public class VooConfiguration : IEntityTypeConfiguration<Voo>
    {
        public void Configure(EntityTypeBuilder<Voo> builder)
        {
            builder
                .ToTable("Voos");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Origem)
                .IsRequired()
                .HasMaxLength(3);

            builder
                .Property(x => x.Destino)
                .IsRequired()
                .HasMaxLength(3);

            builder
                .Property(x => x.DataHoraPartida)
                .IsRequired();

            builder
                .Property(x => x.DataHoraChegada)
                .IsRequired();

            builder
                .HasOne(v => v.Piloto)
                .WithMany(p => p.Voos)
                .HasForeignKey(v => v.PilotoId);

            builder
                .HasOne(v => v.Aeronave)
                .WithMany(a => a.Voos)
                .HasForeignKey(v => v.AeronaveId);

            builder
                .HasOne(v => v.Cancelamento)
                .WithOne(a => a.Voo)
                .HasForeignKey<Cancelamento>(c => c.VooId);
        }
    }
}
