using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoV_22129_22130
{
    public class ArvoreBinaria
    {
        public NoArvore Raiz { get; private set; }

        public void Inserir(Cidade cidade)
        {
            Raiz = InserirRecursivo(Raiz, cidade);
        }

        private NoArvore InserirRecursivo(NoArvore no, Cidade cidade)
        {
            if (no == null) return new NoArvore(cidade);
            if (string.Compare(cidade.Nome, no.Cidade.Nome, StringComparison.OrdinalIgnoreCase) < 0)
                no.Esquerda = InserirRecursivo(no.Esquerda, cidade);
            else
                no.Direita = InserirRecursivo(no.Direita, cidade);
            return no;
        }

        public Cidade Buscar(string nome)
        {
            return BuscarRecursivo(Raiz, nome)?.Cidade;
        }

        private NoArvore BuscarRecursivo(NoArvore no, string nome)
        {
            if (no == null || no.Cidade.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)) return no;
            if (string.Compare(nome, no.Cidade.Nome, StringComparison.OrdinalIgnoreCase) < 0)
                return BuscarRecursivo(no.Esquerda, nome);
            return BuscarRecursivo(no.Direita, nome);
        }

        public List<Cidade> ListarEmOrdem()
        {
            var lista = new List<Cidade>();
            ListarEmOrdemRecursivo(Raiz, lista);
            return lista;
        }

        private void ListarEmOrdemRecursivo(NoArvore no, List<Cidade> lista)
        {
            if (no == null) return;
            ListarEmOrdemRecursivo(no.Esquerda, lista);
            lista.Add(no.Cidade);
            ListarEmOrdemRecursivo(no.Direita, lista);
        }
    }
}
