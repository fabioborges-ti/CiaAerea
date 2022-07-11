namespace CiaArea.Entities
{
    public class Aeronave : Base
    {
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public string Codigo { get; set; }
        public ICollection<Manutencao> Manutencoes { get; set; }
        public ICollection<Voo> Voos { get; set; }

        public Aeronave(string fabricante, string modelo, string codigo)
        {
            Fabricante = fabricante;
            Modelo = modelo;
            Codigo = codigo;
        }
    }
}
