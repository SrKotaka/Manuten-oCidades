using System;
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


        private void buttonIncluirNome_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonExcluirCidade_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonAlterarCidade_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonExibirCidade_Click(object sender, EventArgs e)
        {
            // Captura os dados da cidade e coordenadas
            string nomeCidade = textBoxNome.Text;

            // Procura a cidade no DataGridView
            bool cidadeEncontrada = false;
            foreach (DataGridViewRow linha in dataGridView.Rows)
            {
                if (linha.Cells["Destino"].Value != null && linha.Cells["Destino"].Value.ToString() == nomeCidade)
                {
                    cidadeEncontrada = true;
                    break;
                }
            }

            if (cidadeEncontrada)
            {
                // Quando a cidade é encontrada, desenha o ponto no mapa

                // Supondo que a PictureBox chamada pictureBoxMapa é onde o mapa é exibido
                using (Graphics g = pbMapa.CreateGraphics())
                {
                    // Defina as coordenadas da cidade, dependendo do valor em X e Y
                    // O X e Y aqui são valores que você usaria para desenhar a cidade no mapa.
                    // Como exemplo, estou considerando que X e Y estão normalizados.
                    int x = (int)(numericUpDownX.Value * pbMapa.Width);
                    int y = (int)(numericUpDownY.Value * pbMapa.Height);

                    // Desenhar o ponto vermelho
                    g.FillEllipse(Brushes.Red, x - 5, y - 5, 10, 10);

                    // Desenhar o nome da cidade
                    g.DrawString(nomeCidade, new Font("Arial", 10), Brushes.Black, new PointF(x + 10, y - 10));
                }
            }
            else
            {
                // Caso a cidade não tenha sido encontrada
                MessageBox.Show("Cidade não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
