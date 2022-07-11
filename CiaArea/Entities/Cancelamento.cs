namespace CiaArea.Entities
{
    public class Cancelamento : Base
    {
        public string Motivo { get; set; }
        public DateTime DataHoraNotificacao { get; set; }
        public Guid VooId { get; set; }
        public Voo Voo { get; set; }

        public Cancelamento(string motivo, DateTime dataHoraNotificacao, Guid vooId)
        {
            Motivo = motivo;
            DataHoraNotificacao = dataHoraNotificacao;
            VooId = vooId;
        }
    }
}
