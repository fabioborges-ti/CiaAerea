namespace CiaArea.ViewModels.Aeronave
{
    public class DetalheAeronaveVM
    {
        public Guid Id { get; private set; }
        public string Fabricante { get; private set; }
        public string Modelo { get; private set; }
        public string Codigo { get; private set; }

        public DetalheAeronaveVM(Guid id, string fabricante, string modelo, string codigo)
        {
            Id = id;
            Fabricante = fabricante;
            Modelo = modelo;
            Codigo = codigo;
        }
    }
}
