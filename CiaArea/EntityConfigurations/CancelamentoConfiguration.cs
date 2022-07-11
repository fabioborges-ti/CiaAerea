using CiaArea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CiaArea.EntityConfigurations
{
    public class CancelamentoConfiguration : IEntityTypeConfiguration<Cancelamento>
    {
        public void Configure(EntityTypeBuilder<Cancelamento> builder)
        {
            builder
                .ToTable("Cancelamentos");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Motivo)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.DataHoraNotificacao)
                .IsRequired();
        }
    }
}
