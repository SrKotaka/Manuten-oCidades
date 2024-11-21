using System.Collections.Generic;

namespace ProjetoV_22129_22130
{
    public class Cidade
    {
        public string Nome { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<Caminho> Caminhos { get; set; }

        public Cidade(string nome, int x, int y)
        {
            Nome = nome;
            X = x;
            Y = y;
            Caminhos = new List<Caminho>();
        }
    }

}
