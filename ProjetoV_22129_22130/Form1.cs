using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoV_22129_22130
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }

        private Dictionary<string, Point> coordenadasCidades = new Dictionary<string, Point>();

        //FEITO
        private void buttonIncluirNome_Click(object sender, EventArgs e)
        {
            string nomeCidade = textBoxNome.Text;

            // Remove a verificação da cidade no DataGridView

            // Calcula as coordenadas da cidade com base nos valores numéricos X e Y
            int x = (int)(numericUpDownX.Value * pbMapa.Width);
            int y = (int)(numericUpDownY.Value * pbMapa.Height);

            using (Graphics g = pbMapa.CreateGraphics())
            {
                // Desenha o ponto da cidade no mapa
                g.FillEllipse(Brushes.Red, x - 5, y - 5, 10, 10);
                g.DrawString(nomeCidade, new Font("Arial", 10), Brushes.Black, new PointF(x + 10, y - 10));
            }

            // Salva ou atualiza as coordenadas da cidade
            coordenadasCidades[nomeCidade] = new Point(x, y);

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

            if (coordenadasCidades.ContainsKey(nomeCidade))
            {
                // Remove a cidade do dicionário
                coordenadasCidades.Remove(nomeCidade);

                // Redesenha o PictureBox sem a cidade excluída
                pbMapa.Refresh();

                using (Graphics g = pbMapa.CreateGraphics())
                {
                    // Reinsere os pontos das cidades restantes
                    foreach (var cidade in coordenadasCidades)
                    {
                        Point ponto = cidade.Value;
                        g.FillEllipse(Brushes.Red, ponto.X - 5, ponto.Y - 5, 10, 10);
                        g.DrawString(cidade.Key, new Font("Arial", 10), Brushes.Black, new PointF(ponto.X + 10, ponto.Y - 10));
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
            string nomeCidade = textBoxNome.Text.Trim(); // Nome da cidade a ser alterada
            int novoX = (int)(numericUpDownX.Value * pbMapa.Width); // Nova coordenada X
            int novoY = (int)(numericUpDownY.Value * pbMapa.Height); // Nova coordenada Y

            // Verifica se o nome da cidade foi informado
            if (string.IsNullOrWhiteSpace(nomeCidade))
            {
                MessageBox.Show("Por favor, insira o nome da cidade a ser alterada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se a cidade existe no dicionário
            if (coordenadasCidades.ContainsKey(nomeCidade))
            {
                // Atualiza as coordenadas da cidade
                coordenadasCidades[nomeCidade] = new Point(novoX, novoY);

                // Redesenha o mapa
                pbMapa.Refresh();
                using (Graphics g = pbMapa.CreateGraphics())
                {
                    foreach (var cidade in coordenadasCidades)
                    {
                        Point ponto = cidade.Value;
                        g.FillEllipse(Brushes.Red, ponto.X - 5, ponto.Y - 5, 10, 10);
                        g.DrawString(cidade.Key, new Font("Arial", 10), Brushes.Black, new PointF(ponto.X + 10, ponto.Y - 10));
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
            // Captura os dados dos campos
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

            // Verifica se existe uma linha selecionada (caso contrário, cria uma nova linha)
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow linhaSelecionada = dataGridView.SelectedRows[0];

                // Atualiza os dados da linha selecionada com os novos valores
                linhaSelecionada.Cells["Destino"].Value = nomeDestino;
                linhaSelecionada.Cells["Distancia"].Value = distancia;
                linhaSelecionada.Cells["Tempo"].Value = tempo;
                linhaSelecionada.Cells["Custo"].Value = custo;

                // Exibe mensagem de sucesso
                MessageBox.Show("Caminho alterado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Se não houver nenhuma linha selecionada, adiciona um novo caminho
                dataGridView.Rows.Add(nomeDestino, distancia, tempo, custo);
                MessageBox.Show("Caminho incluído com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Limpa qualquer configuração anterior
            dataGridView.Columns.Clear();

            // Adiciona as colunas ao DataGridView
            dataGridView.Columns.Add("Destino", "Destino");
            dataGridView.Columns.Add("Distancia", "Distância");
            dataGridView.Columns.Add("Tempo", "Tempo");
            dataGridView.Columns.Add("Custo", "Custo");

            // Opcional: Define propriedades como largura ajustável e leitura apenas
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
        }
    }
}
