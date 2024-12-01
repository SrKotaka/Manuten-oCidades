using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoV_22129_22130
{
    public partial class Form : System.Windows.Forms.Form
    {
        private List<Cidade> cidades = new List<Cidade>();
        private List<Caminho> caminhos = new List<Caminho>();
        private Dictionary<string, Point> coordenadasCidades = new Dictionary<string, Point>();
        public Form()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }

        //FEITO
        private void buttonIncluirNome_Click(object sender, EventArgs e)
        {
            string nomeCidade = textBoxNome.Text;
            int x = (int)(numericUpDownX.Value * pbMapa.Width);
            int y = (int)(numericUpDownY.Value * pbMapa.Height);

            // Cria uma nova cidade
            Cidade novaCidade = new Cidade(nomeCidade, x, y);
            cidades.Add(novaCidade);

            // Desenha a cidade no mapa
            using (Graphics g = pbMapa.CreateGraphics())
            {
                g.FillEllipse(Brushes.Red, x - 5, y - 5, 10, 10);
                g.DrawString(nomeCidade, new Font("Arial", 10), Brushes.Black, new PointF(x + 10, y - 10));
            }

            MessageBox.Show($"Cidade '{nomeCidade}' adicionada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //FEITO
        private void buttonExcluirCidade_Click(object sender, EventArgs e)
        {
            string nomeCidade = textBoxNome.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomeCidade))
            {
                MessageBox.Show("Por favor, insira o nome da cidade a ser excluída.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cidade cidadeParaExcluir = cidades.Find(c => c.Nome == nomeCidade);

            if (cidadeParaExcluir != null)
            {
                // Remove a cidade da lista
                cidades.Remove(cidadeParaExcluir);

                // Redesenha o mapa sem a cidade excluída
                pbMapa.Refresh();
                using (Graphics g = pbMapa.CreateGraphics())
                {
                    foreach (var cidade in cidades)
                    {
                        g.FillEllipse(Brushes.Red, cidade.X - 5, cidade.Y - 5, 10, 10);
                        g.DrawString(cidade.Nome, new Font("Arial", 10), Brushes.Black, new PointF(cidade.X + 10, cidade.Y - 10));
                    }
                }

                MessageBox.Show($"A cidade '{nomeCidade}' foi excluída com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cidade não encontrada no mapa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //FEITO
        private void buttonAlterarCidade_Click(object sender, EventArgs e)
        {
            string nomeCidade = textBoxNome.Text.Trim();
            int novoX = (int)(numericUpDownX.Value * pbMapa.Width);
            int novoY = (int)(numericUpDownY.Value * pbMapa.Height);

            // Encontra a cidade a ser alterada
            Cidade cidadeAlterada = cidades.Find(c => c.Nome == nomeCidade);

            if (cidadeAlterada != null)
            {
                // Atualiza as coordenadas
                cidadeAlterada.X = novoX;
                cidadeAlterada.Y = novoY;

                // Redesenha o mapa
                pbMapa.Refresh();
                using (Graphics g = pbMapa.CreateGraphics())
                {
                    foreach (var cidade in cidades)
                    {
                        g.FillEllipse(Brushes.Red, cidade.X - 5, cidade.Y - 5, 10, 10);
                        g.DrawString(cidade.Nome, new Font("Arial", 10), Brushes.Black, new PointF(cidade.X + 10, cidade.Y - 10));
                    }
                }

                MessageBox.Show("Coordenadas alteradas com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cidade não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExibirCidade_Click(object sender, EventArgs e)
        {
           
        }
        //FEITO
        private void buttonIncluirCaminhos_Click(object sender, EventArgs e)
        {
            string nomeDestino = textBoxCidadeDeDestino.Text;
            int distancia = (int)numericUpDownDistancia.Value;
            int tempo = (int)numericUpDownTempo.Value;
            int custo = (int)numericUpDownCusto.Value;

            // Verifica se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(nomeDestino))
            {
                MessageBox.Show("O nome do destino não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Encontra a cidade de origem
            Cidade cidadeOrigem = cidades.Find(c => c.Nome == textBoxNome.Text);

            if (cidadeOrigem != null)
            {
                // Cria o caminho
                Caminho novoCaminho = new Caminho(cidadeOrigem, distancia, tempo, custo);
                cidadeOrigem.Caminhos.Add(novoCaminho);

                // Atualiza o DataGridView com os caminhos
                dataGridView.Rows.Add(nomeDestino, distancia, tempo, custo);

                MessageBox.Show("Caminho incluído com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cidade de origem não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //FEITO
        private void buttonExcluirCaminhos_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Pergunta ao usuário se tem certeza que quer excluir a linha
                DialogResult resultado = MessageBox.Show("Você tem certeza que deseja excluir este caminho?", "Excluir Caminho", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    // Exclui a linha selecionada
                    foreach (DataGridViewRow linha in dataGridView.SelectedRows)
                    {
                        // Evita excluir a linha se for a linha de cabeçalho (caso a seleção inclua a linha de cabeçalho)
                        if (!linha.IsNewRow)
                        {
                            dataGridView.Rows.RemoveAt(linha.Index);
                        }
                    }
                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Caminho excluído com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Exibe mensagem caso nenhuma linha tenha sido selecionada
                MessageBox.Show("Por favor, selecione um caminho para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //FEITO
        private void buttonAlterarCaminhos_Click(object sender, EventArgs e)
        {
            // Verifica se há uma linha selecionada
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow linhaSelecionada = dataGridView.SelectedRows[0];

                // Obtém os dados da linha selecionada
                string destinoAtual = linhaSelecionada.Cells["Destino"].Value.ToString();
                int distanciaAtual = Convert.ToInt32(linhaSelecionada.Cells["Distancia"].Value);
                int tempoAtual = Convert.ToInt32(linhaSelecionada.Cells["Tempo"].Value);
                int custoAtual = Convert.ToInt32(linhaSelecionada.Cells["Custo"].Value);

                // Exibe os dados atuais nos campos de edição
                textBoxCidadeDeDestino.Text = destinoAtual;
                numericUpDownDistancia.Value = distanciaAtual;
                numericUpDownTempo.Value = tempoAtual;
                numericUpDownCusto.Value = custoAtual;

                // Alerta o usuário que ele pode alterar os dados
                MessageBox.Show("Edite os campos e clique em 'Incluir Caminhos' para confirmar as alterações.", "Alterar Caminho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Caso nenhuma linha tenha sido selecionada
                MessageBox.Show("Por favor, selecione um caminho para alterar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExibirCaminhos_Click(object sender, EventArgs e)
        {
            
        }
        //FEITO
        private void ConfigurarDataGridView()
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("Destino", "Destino");
            dataGridView.Columns.Add("Distancia", "Distância");
            dataGridView.Columns.Add("Tempo", "Tempo");
            dataGridView.Columns.Add("Custo", "Custo");

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
        }
    }
}
