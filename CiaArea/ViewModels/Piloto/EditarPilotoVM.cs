namespace CiaArea.ViewModels.Piloto
{
    public class EditarPilotoVM
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Matricula { get; private set; }

        public EditarPilotoVM(Guid id, string nome, string matricula)
        {
            Id = id;
            Nome = nome;
            Matricula = matricula;
        }
    }
}
