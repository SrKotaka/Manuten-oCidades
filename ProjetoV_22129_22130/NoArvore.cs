using System;
using System.Collections.Generic;

namespace ProjetoV_22129_22130
{
    public class NoArvore
    {
        public Cidade Cidade { get; set; }
        public NoArvore Esquerda { get; set; }
        public NoArvore Direita { get; set; }

        public NoArvore(Cidade cidade)
        {
            Cidade = cidade;
            Esquerda = null;
            Direita = null;
        }
    }

    public class ArvoreBinaria
    {
        private NoArvore raiz;

        public ArvoreBinaria()
        {
            raiz = null;
        }

        // Inserir cidade na árvore
        public void Inserir(Cidade novaCidade)
        {
            raiz = InserirRecursivo(raiz, novaCidade);
        }

        private NoArvore InserirRecursivo(NoArvore no, Cidade novaCidade)
        {
            if (no == null)
                return new NoArvore(novaCidade);

            if (string.Compare(novaCidade.Nome, no.Cidade.Nome, StringComparison.OrdinalIgnoreCase) < 0)
                no.Esquerda = InserirRecursivo(no.Esquerda, novaCidade);
            else if (string.Compare(novaCidade.Nome, no.Cidade.Nome, StringComparison.OrdinalIgnoreCase) > 0)
                no.Direita = InserirRecursivo(no.Direita, novaCidade);

            return no;
        }

        // Buscar cidade pelo nome
        public Cidade Buscar(string nomeCidade)
        {
            return BuscarRecursivo(raiz, nomeCidade);
        }

        private Cidade BuscarRecursivo(NoArvore no, string nomeCidade)
        {
            if (no == null)
                return null;

            if (nomeCidade.Equals(no.Cidade.Nome, StringComparison.OrdinalIgnoreCase))
                return no.Cidade;

            if (string.Compare(nomeCidade, no.Cidade.Nome, StringComparison.OrdinalIgnoreCase) < 0)
                return BuscarRecursivo(no.Esquerda, nomeCidade);

            return BuscarRecursivo(no.Direita, nomeCidade);
        }

        // Listar cidades em ordem alfabética
        public List<Cidade> ListarEmOrdem()
        {
            var lista = new List<Cidade>();
            ListarEmOrdemRecursivo(raiz, lista);
            return lista;
        }

        private void ListarEmOrdemRecursivo(NoArvore no, List<Cidade> lista)
        {
            if (no != null)
            {
                ListarEmOrdemRecursivo(no.Esquerda, lista);
                lista.Add(no.Cidade);
                ListarEmOrdemRecursivo(no.Direita, lista);
            }
        }

        // Listar cidades por níveis (BFS)
        public List<Cidade> ListarPorNiveis()
        {
            var lista = new List<Cidade>();
            if (raiz == null)
                return lista;

            var fila = new Queue<NoArvore>();
            fila.Enqueue(raiz);

            while (fila.Count > 0)
            {
                var noAtual = fila.Dequeue();
                lista.Add(noAtual.Cidade);

                if (noAtual.Esquerda != null)
                    fila.Enqueue(noAtual.Esquerda);

                if (noAtual.Direita != null)
                    fila.Enqueue(noAtual.Direita);
            }

            return lista;
        }

        // Remover cidade da árvore
        public void Remover(string nomeCidade)
        {
            raiz = RemoverRecursivo(raiz, nomeCidade);
        }

        private NoArvore RemoverRecursivo(NoArvore no, string nomeCidade)
        {
            if (no == null)
                return null;

            if (string.Compare(nomeCidade, no.Cidade.Nome, StringComparison.OrdinalIgnoreCase) < 0)
                no.Esquerda = RemoverRecursivo(no.Esquerda, nomeCidade);
            else if (string.Compare(nomeCidade, no.Cidade.Nome, StringComparison.OrdinalIgnoreCase) > 0)
                no.Direita = RemoverRecursivo(no.Direita, nomeCidade);
            else
            {
                // Caso 1: Nó folha
                if (no.Esquerda == null && no.Direita == null)
                    return null;

                // Caso 2: Um filho
                if (no.Esquerda == null)
                    return no.Direita;
                if (no.Direita == null)
                    return no.Esquerda;

                // Caso 3: Dois filhos
                var sucessor = EncontrarMenor(no.Direita);
                no.Cidade = sucessor.Cidade;
                no.Direita = RemoverRecursivo(no.Direita, sucessor.Cidade.Nome);
            }

            return no;
        }

        private NoArvore EncontrarMenor(NoArvore no)
        {
            while (no.Esquerda != null)
                no = no.Esquerda;

            return no;
        }
    }
}
