namespace CiaArea.ViewModels.Aeronave
{
    public class IncluirAeronaveVM
    {
        public string Fabricante { get; private set; }
        public string Modelo { get; private set; }
        public string Codigo { get; private set; }

        public IncluirAeronaveVM(string fabricante, string modelo, string codigo)
        {
            Fabricante = fabricante;
            Modelo = modelo;
            Codigo = codigo;
        }
    }
}
