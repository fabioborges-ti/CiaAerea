namespace CiaArea.Entities
{
    public class Piloto : Base
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public ICollection<Voo> Voos { get; set; }

        public Piloto(string nome, string matricula)
        {
            Nome = nome;
            Matricula = matricula;
        }
    }
}
