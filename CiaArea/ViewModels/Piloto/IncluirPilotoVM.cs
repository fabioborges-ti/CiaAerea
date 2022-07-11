namespace CiaArea.ViewModels.Piloto
{
    public class IncluirPilotoVM
    {
        public string Nome { get; private set; }
        public string Matricula { get; private set; }

        public IncluirPilotoVM(string nome, string matricula)
        {
            Nome = nome;
            Matricula = matricula;
        }
    }
}
