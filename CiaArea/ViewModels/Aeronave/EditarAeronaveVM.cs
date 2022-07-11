namespace CiaArea.ViewModels.Aeronave
{
    public class EditarAeronaveVM
    {
        public Guid Id { get; private set; }
        public string Fabricante { get; private set; }
        public string Modelo { get; private set; }
        public string Codigo { get; private set; }

        public EditarAeronaveVM(Guid id, string fabricante, string modelo, string codigo)
        {
            Id = id;
            Fabricante = fabricante;
            Modelo = modelo;
            Codigo = codigo;
        }
    }
}
