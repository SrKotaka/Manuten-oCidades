using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoV_22129_22130
{
    public class Cidade
    {
        public string Nome { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public ListaCaminhos Caminhos { get; set; }

        public Cidade(string nome, double x, double y)
        {
            Nome = nome;
            X = x;
            Y = y;
            Caminhos = new ListaCaminhos();
        }
    }

    public class Caminho
    {
        public Cidade Destino { get; set; }
        public double Distancia { get; set; }
        public double Tempo { get; set; }
        public double Custo { get; set; }

        public Caminho(Cidade destino, double distancia, double tempo, double custo)
        {
            Destino = destino;
            Distancia = distancia;
            Tempo = tempo;
            Custo = custo;
        }
    }

    public class ListaCaminhos
    {
        public List<Caminho> Caminhos { get; set; } = new List<Caminho>();

        public void AdicionarCaminho(Cidade destino, double distancia, double tempo, double custo)
        {
            Caminhos.Add(new Caminho(destino, distancia, tempo, custo));
        }
    }

    public class NoArvore
    {
        public Cidade Cidade { get; set; }
        public NoArvore Esquerdo { get; set; }
        public NoArvore Direito { get; set; }

        public NoArvore(Cidade cidade)
        {
            Cidade = cidade;
            Esquerdo = null;
            Direito = null;
        }
    }

    public class ArvoreBinaria
    {
        public NoArvore Raiz { get; private set; }

        public void Inserir(Cidade cidade)
        {
            Raiz = InserirNo(Raiz, cidade);
        }

        private NoArvore InserirNo(NoArvore noAtual, Cidade cidade)
        {
            if (noAtual == null)
                return new NoArvore(cidade);

            if (string.Compare(cidade.Nome, noAtual.Cidade.Nome) < 0)
                noAtual.Esquerdo = InserirNo(noAtual.Esquerdo, cidade);
            else if (string.Compare(cidade.Nome, noAtual.Cidade.Nome) > 0)
                noAtual.Direito = InserirNo(noAtual.Direito, cidade);

            return noAtual;
        }

        public Cidade Buscar(string nome)
        {
            return BuscarNo(Raiz, nome);
        }

        private Cidade BuscarNo(NoArvore noAtual, string nome)
        {
            if (noAtual == null)
                return null;

            if (nome == noAtual.Cidade.Nome)
                return noAtual.Cidade;

            if (string.Compare(nome, noAtual.Cidade.Nome) < 0)
                return BuscarNo(noAtual.Esquerdo, nome);
            else
                return BuscarNo(noAtual.Direito, nome);
        }

        public void ListarEmOrdem(NoArvore noAtual, List<Cidade> cidades)
        {
            if (noAtual == null) return;

            ListarEmOrdem(noAtual.Esquerdo, cidades);
            cidades.Add(noAtual.Cidade);
            ListarEmOrdem(noAtual.Direito, cidades);
        }
    }
}
