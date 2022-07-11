namespace CiaArea.ViewModels.Aeronave
{
    public class ListarAeronaveVM
    {
        public Guid Id { get; private set; }
        public string Modelo { get; private set; }
        public string Codigo { get; private set; }

        public ListarAeronaveVM(Guid id, string modelo, string codigo)
        {
            Id = id;
            Modelo = modelo;
            Codigo = codigo;
        }
    }
}
