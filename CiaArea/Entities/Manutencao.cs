using CiaArea.Entities.Enums;

namespace CiaArea.Entities
{
    public class Manutencao : Base
    {
        public DateTime DataHora { get; set; }
        public string Observacoes { get; set; }
        public TipoManutencao TipoManutencao { get; set; }
        public Guid AeronaveId { get; set; }
        public Aeronave Aeronave { get; set; }

        public Manutencao(DateTime dataHora, TipoManutencao tipoManutencao, Guid aeronaveId, string observacoes = null)
        {
            DataHora = dataHora;
            TipoManutencao = tipoManutencao;
            AeronaveId = aeronaveId;
            Observacoes = observacoes;
        }
    }
}
