using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoV_22129_22130
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            ConfigurarGrid();
        }

        private List<Cidade> cidades = new List<Cidade>();

        private void buttonIncluirNome_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("O nome da cidade é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Criar uma nova cidade
            var cidade = new Cidade(textBoxNome.Text, (int)numericUpDownX.Value, (int)numericUpDownY.Value);
            cidades.Add(cidade);

            // Atualizar o DataGridView
            AtualizarGrid();
        }

        private void buttonExcluirCidade_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma cidade para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Remover cidade selecionada
            int indice = dataGridView.CurrentRow.Index;
            cidades.RemoveAt(indice);

            // Atualizar o DataGridView
            AtualizarGrid();
        }

        private void buttonAlterarCidade_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma cidade para alterar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obter cidade selecionada
            int indice = dataGridView.CurrentRow.Index;
            var cidade = cidades[indice];

            // Atualizar os dados
            cidade.Nome = textBoxNome.Text;
            cidade.X = (int)numericUpDownX.Value;
            cidade.Y = (int)numericUpDownY.Value;

            // Atualizar o DataGridView
            AtualizarGrid();
        }

        private void buttonExibirCidade_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
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
        private void AtualizarGrid()
        {
            // Limpar o DataGridView
            dataGridView.Rows.Clear();

            // Adicionar os dados de cidades com as coordenadas X e Y
            foreach (var cidade in cidades)
            {
                // Adiciona cada cidade e suas coordenadas
                dataGridView.Rows.Add(cidade.Nome, "", cidade.X, cidade.Y, "", "", "");
            }
        }

        private void ConfigurarGrid()
        {
            dataGridView.Columns.Clear(); // Garante que não haja colunas duplicadas

            // Adicionando as colunas de Caminhos e Coordenadas
            dataGridView.Columns.Add("colCidadeOrigem", "Cidade Origem");
            dataGridView.Columns.Add("colCidadeDestino", "Cidade Destino");
            dataGridView.Columns.Add("colXOrigem", "Coordenada X Origem");
            dataGridView.Columns.Add("colYOrigem", "Coordenada Y Origem");
            dataGridView.Columns.Add("colDistancia", "Distância");
            dataGridView.Columns.Add("colTempo", "Tempo");
            dataGridView.Columns.Add("colCusto", "Custo");

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AllowUserToAddRows = false;
        }
    }
}
