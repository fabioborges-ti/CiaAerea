namespace CiaArea.ViewModels.Piloto
{
    public class ListarPilotoVM
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }

        public ListarPilotoVM(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
