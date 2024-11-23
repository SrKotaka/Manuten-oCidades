using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoV_22129_22130
{
    public partial class Form : System.Windows.Forms.Form
    {
        private ArvoreBinaria arvore;
        private Cidade cidadeSelecionada;
        public Form()
        {
            InitializeComponent();
            arvore = ManipuladorArquivos.CarregarCidades();
            ManipuladorCaminhos.CarregarCaminhos(arvore);
            AtualizarListaCidades();
        }


        private void buttonIncluirNome_Click(object sender, EventArgs e)
        {
            string nome = textBoxNome.Text.Trim();
            int x, y;

            if (!string.IsNullOrEmpty(nome) && int.TryParse(numericUpDownX.Text, out x) && int.TryParse(numericUpDownY.Text, out y))
            {
                var novaCidade = new Cidade(nome, x, y);
                arvore.Inserir(novaCidade);
                AtualizarListaCidades();
                MessageBox.Show("Cidade adicionada com sucesso!");
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos corretamente.");
            }
        }

        private void buttonExcluirCidade_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                string nome = dataGridView.SelectedRows[0].Cells["Nome"].Value.ToString();

                if (arvore.Buscar(nome) != null)
                {
                    arvore.Remover(nome);
                    AtualizarListaCidades();
                    MessageBox.Show("Cidade removida com sucesso!");
                }
                else
                {
                    MessageBox.Show("Cidade não encontrada.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma cidade para remover.");
            }
        }

        private void buttonAlterarCidade_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonExibirCidade_Click(object sender, EventArgs e)
        {
            string nome = textBoxNome.Text.Trim();
            var cidade = arvore.Buscar(nome);

            if (cidade != null)
            {
                numericUpDownX.Text = cidade.X.ToString();
                numericUpDownY.Text = cidade.Y.ToString();
                AtualizarListaCaminhos(cidade);
            }
            else
            {
                MessageBox.Show("Cidade não encontrada.");
            }
        }

        private void buttonIncluirCaminhos_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonExcluirCaminhos_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonAlterarCaminhos_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonExibirCaminhos_Click(object sender, EventArgs e)
        {
          
        }
        private void AtualizarListaCidades()
        {
            dataGridView.Rows.Clear();
            var cidades = arvore.ListarEmOrdem();

            foreach (var cidade in cidades)
            {
                dataGridView.Rows.Add(cidade.Nome, cidade.X, cidade.Y);
            }
        }
        private void AtualizarListaCaminhos(Cidade cidade)
        {
            dataGridView.Rows.Clear();
            foreach (var caminho in cidade.Caminhos)
            {
                dataGridView.Rows.Add(cidade.Nome, caminho.Destino.Nome, caminho.Distancia, caminho.Tempo, caminho.Custo);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ManipuladorArquivos.SalvarCidades(arvore);
            ManipuladorCaminhos.SalvarCaminhos(arvore);
            MessageBox.Show("Dados salvos com sucesso!");
        }

        private void pbMapa_Click(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            // Ajuste proporcional para o tamanho do mapa
            int mapaLargura = pbMapa.Width;
            int mapaAltura = pbMapa.Height;
            const int mapaOriginalLargura = 4096;
            const int mapaOriginalAltura = 2048;

            // Escalas
            float escalaX = (float)mapaLargura / mapaOriginalLargura;
            float escalaY = (float)mapaAltura / mapaOriginalAltura;

            // Desenhar cidades
            var cidades = arvore.ListarEmOrdem();
            foreach (var cidade in cidades)
            {
                // Coordenadas ajustadas
                int x = (int)(cidade.X * escalaX);
                int y = (int)(cidade.Y * escalaY);

                // Ponto representando a cidade
                graphics.FillEllipse(Brushes.Red, x - 5, y - 5, 10, 10);

                // Nome da cidade
                graphics.DrawString(cidade.Nome, DefaultFont, Brushes.Black, x + 10, y - 10);
            }

            // Desenhar caminhos
            if (cidadeSelecionada != null)
            {
                int xSelecionado = (int)(cidadeSelecionada.X * escalaX);
                int ySelecionado = (int)(cidadeSelecionada.Y * escalaY);

                // Destacar a cidade selecionada
                graphics.FillEllipse(Brushes.Yellow, xSelecionado - 7, ySelecionado - 7, 14, 14);

                // Destacar os caminhos
                foreach (var caminho in cidadeSelecionada.Caminhos)
                {
                    int xDestino = (int)(caminho.Destino.X * escalaX);
                    int yDestino = (int)(caminho.Destino.Y * escalaY);

                    graphics.DrawLine(Pens.Green, xSelecionado, ySelecionado, xDestino, yDestino);
                }
            }

        }
        private void pbMapa_Click(object sender, EventArgs e)
        {
            var mouseArgs = (MouseEventArgs)e;
            int xClicado = mouseArgs.X;
            int yClicado = mouseArgs.Y;

            // Identificar cidade mais próxima (exemplo simples):
            Cidade cidadeMaisProxima = null;
            double menorDistancia = double.MaxValue;

            var cidades = arvore.ListarEmOrdem();
            foreach (var cidade in cidades)
            {
                int xCidade = (int)(cidade.X * pbMapa.Width / 4096.0);
                int yCidade = (int)(cidade.Y * pbMapa.Height / 2048.0);

                double distancia = Math.Sqrt(Math.Pow(xCidade - xClicado, 2) + Math.Pow(yCidade - yClicado, 2));
                if (distancia < menorDistancia)
                {
                    menorDistancia = distancia;
                    cidadeMaisProxima = cidade;
                }
            }

            if (cidadeMaisProxima != null && menorDistancia < 15) // Limite de proximidade
            {
                MessageBox.Show($"Cidade mais próxima: {cidadeMaisProxima.Nome}");
            }
            else
            {
                MessageBox.Show("Nenhuma cidade próxima ao ponto clicado.");
            }
        }

        private void AtualizarMapa()
        {
            pbMapa.Invalidate();
        }
        private void SelecionarCidade(string nomeCidade)
        {
            cidadeSelecionada = arvore.Buscar(nomeCidade);
            AtualizarMapa();
        }
    }
}
