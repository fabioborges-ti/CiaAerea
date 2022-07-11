namespace CiaArea.Entities
{
    public class Voo : Base
    {
        public string Origem { get; private set; }
        public string Destino { get; private set; }
        public DateTime DataHoraPartida { get; set; }
        public DateTime DataHoraChegada { get; set; }
        public Guid AeronaveId { get; set; }
        public Guid PilotoId { get; set; }
        public Aeronave Aeronave { get; set; }
        public Piloto Piloto { get; set; }
        public Cancelamento? Cancelamento { get; set; }

        public Voo(string origem, string destino, DateTime dataHoraPartida, DateTime dataHoraChegada, Guid aeronaveId, Guid pilotoId)
        {
            Origem = origem;
            Destino = destino;
            DataHoraPartida = dataHoraPartida;
            DataHoraChegada = dataHoraChegada;
            AeronaveId = aeronaveId;
            PilotoId = pilotoId;
        }
    }
}
