using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ProjetoV_22129_22130
{
    public partial class Form : System.Windows.Forms.Form
    {

        private ArvoreBinaria arvoreCidades;
        private List<Cidade> cidades;
        private List<Caminho> caminhos;
        public Form()
        {

            InitializeComponent();
            arvoreCidades = new ArvoreBinaria();
            cidades = new List<Cidade>();
            caminhos = new List<Caminho>();
            CarregarDadosIniciais();
            ConfigurarDataGridView();

            // Chamar o Refresh para forçar o Paint
            pbMapa.Refresh();
        }

        private void CarregarDadosIniciais()
        {
            // Carregar cidades e caminhos dos arquivos '.dat'
            CarregarCidades();
            //CarregarCaminhos();
        }

        //FEITO
        private void buttonIncluirNome_Click(object sender, EventArgs e)
        {
            string nomeCidade = textBoxNome.Text;
            int x = (int)(numericUpDownX.Value * pbMapa.Width);
            int y = (int)(numericUpDownY.Value * pbMapa.Height);

            Cidade novaCidade = new Cidade(nomeCidade, x, y);
            cidades.Add(novaCidade);
            arvoreCidades.Inserir(novaCidade);

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

            Cidade cidadeParaExcluir = cidades.Find(c => c.Nome == nomeCidade);
            if (cidadeParaExcluir != null)
            {
                cidades.Remove(cidadeParaExcluir);
                pbMapa.Refresh();
                //DesenharCidades();
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

            Cidade cidadeAlterada = cidades.Find(c => c.Nome == nomeCidade);
            if (cidadeAlterada != null)
            {
                cidadeAlterada.X = novoX;
                cidadeAlterada.Y = novoY;
                pbMapa.Refresh();
                //DesenharCidades();
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

            Cidade cidadeOrigem = cidades.Find(c => c.Nome == textBoxNome.Text);
            if (cidadeOrigem != null)
            {
                Caminho novoCaminho = new Caminho(cidadeOrigem, distancia, tempo, custo);
                cidadeOrigem.Caminhos.Add(novoCaminho);
                caminhos.Add(novoCaminho);
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
                DialogResult resultado = MessageBox.Show("Você tem certeza que deseja excluir este caminho?", "Excluir Caminho", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    foreach (DataGridViewRow linha in dataGridView.SelectedRows)
                    {
                        if (!linha.IsNewRow)
                        {
                            dataGridView.Rows.RemoveAt(linha.Index);
                        }
                    }
                    MessageBox.Show("Caminho excluído com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um caminho para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //FEITO
        private void buttonAlterarCaminhos_Click(object sender, EventArgs e)
        {
            

            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow linhaSelecionada = dataGridView.SelectedRows[0];
                string destinoAtual = linhaSelecionada.Cells["Destino"].Value.ToString();
                int distanciaAtual = Convert.ToInt32(linhaSelecionada.Cells["Distancia"].Value);
                int tempoAtual = Convert.ToInt32(linhaSelecionada.Cells["Tempo"].Value);
                int custoAtual = Convert.ToInt32(linhaSelecionada.Cells["Custo"].Value);

                textBoxCidadeDeDestino.Text = destinoAtual;
                numericUpDownDistancia.Value = distanciaAtual;
                numericUpDownTempo.Value = tempoAtual;
                numericUpDownCusto.Value = custoAtual;

                MessageBox.Show("Edite os campos e clique em 'Incluir Caminhos' para confirmar as alterações.", "Alterar Caminho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
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

        private void DesenharArvore(NoArvore no, Graphics g, int x, int y, int offset)
        {
            

            if (no == null) return;

            // Desenha a cidade
            g.FillEllipse(Brushes.Blue, x - 5, y - 5, 10, 10);
            g.DrawString(no.Cidade.Nome, new Font("Arial", 8), Brushes.Black, x + 10, y);

            // Desenha os nós filhos
            if (no.Esquerda != null)
            {
                g.DrawLine(Pens.Black, x, y, x - offset, y + 50);
                DesenharArvore(no.Esquerda, g, x - offset, y + 50, offset / 2);
            }

            if (no.Direita != null)
            {
                g.DrawLine(Pens.Black, x, y, x + offset, y + 50);
                DesenharArvore(no.Direita, g, x + offset, y + 50, offset / 2);
            }
        }

        private void CarregarCidades()
        {
            try
            {
                // Verifica se o arquivo de cidades existe
                if (!File.Exists("CidadesMarte.dat"))
                {
                    MessageBox.Show("Arquivo CidadesMarte.dat não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abre o arquivo binário
                using (FileStream fs = new FileStream("CidadesMarte.dat", FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    // Lê até o final do arquivo
                    while (fs.Position < fs.Length)
                    {
                        try
                        {
                            // Lê o nome da cidade e as coordenadas (X, Y)
                            string nome = reader.ReadString();  // Lê o nome da cidade
                            int x = reader.ReadInt32();  // Lê a coordenada X
                            int y = reader.ReadInt32();  // Lê a coordenada Y

                            // Cria o objeto cidade e adiciona à lista de cidades
                            Cidade cidade = new Cidade(nome, x, y);
                            cidades.Add(cidade);

                            // Exibe as cidades carregadas para depuração
                            MessageBox.Show($"Cidade lida: Nome={nome}, X={x}, Y={y}", "Cidade Carregada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (EndOfStreamException)
                        {
                            // Quando chegar ao final do arquivo, interrompe a leitura
                            break;
                        }
                        catch (Exception innerEx)
                        {
                            MessageBox.Show($"Erro ao ler cidade: {innerEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                }

                // Exibe uma mensagem de informações com a quantidade de cidades carregadas
                MessageBox.Show($"{cidades.Count} cidades carregadas.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Atualiza o mapa para exibir as cidades
                pbMapa.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cidades: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CarregarCaminhos()
        {
            
            try
            {
                if (!File.Exists("CaminhoEntreCidadesMarte.dat"))
                {
                    MessageBox.Show("Arquivo CaminhoEntreCidadesMarte.dat não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (FileStream fs = new FileStream("CaminhoEntreCidadesMarte.dat", FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    while (fs.Position < fs.Length)
                    {
                        try
                        {
                            string nomeOrigem = reader.ReadString();
                            string nomeDestino = reader.ReadString();
                            int distancia = reader.ReadInt32();
                            int tempo = reader.ReadInt32();
                            int custo = reader.ReadInt32();

                            Cidade cidadeOrigem = cidades.Find(c => c.Nome == nomeOrigem);
                            Cidade cidadeDestino = cidades.Find(c => c.Nome == nomeDestino);

                            if (cidadeOrigem != null && cidadeDestino != null)
                            {
                                Caminho caminho = new Caminho(cidadeDestino, distancia, tempo, custo);
                                cidadeOrigem.Caminhos.Add(caminho);
                                caminhos.Add(caminho);
                            }
                            else
                            {
                                // Log or handle cases where cities are not found
                                MessageBox.Show($"Cidades não encontradas: Origem: {nomeOrigem}, Destino: {nomeDestino}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (EndOfStreamException)
                        {
                            break;
                        }
                        catch (Exception innerEx)
                        {
                            MessageBox.Show($"Erro ao ler caminho: {innerEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                }

                MessageBox.Show($"{caminhos.Count} caminhos carregados com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar caminhos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DesenharCidades(Graphics g)
        {

            
            foreach (var cidade in cidades)
            {
                int tamanho = 10; // Tamanho do círculo
                Brush brush = Brushes.Red;

                // Verificar se a cidade está dentro dos limites da área visível
                int cidadeX = cidade.X - tamanho / 2;
                int cidadeY = cidade.Y - tamanho / 2;

                // Limitar as coordenadas para garantir que o círculo esteja visível
                cidadeX = Math.Max(0, Math.Min(cidadeX, pbMapa.Width - tamanho)); // Evitar que ultrapasse o limite esquerdo e direito
                cidadeY = Math.Max(0, Math.Min(cidadeY, pbMapa.Height - tamanho)); // Evitar que ultrapasse o limite superior e inferior

                // Desenhar a cidade (círculo)
                g.FillEllipse(brush, cidadeX, cidadeY, tamanho, tamanho);

                // Desenhar o nome da cidade
                g.DrawString(cidade.Nome, new Font("Arial", 10), Brushes.Black, new PointF(cidadeX + 12, cidadeY + 12)); // Ajustar a posição do nome
            }

        }

        private void DesenharCaminhos(Graphics g)
        {
            foreach (var cidade in cidades)
            {
                foreach (var caminho in cidade.Caminhos)
                {
                    g.DrawLine(new Pen(Color.Green, 2), cidade.X, cidade.Y, caminho.Destino.X, caminho.Destino.Y);
                }
            }
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            DesenharCidades(e.Graphics);
            DesenharCaminhos(e.Graphics);
        }

        private void pbMapa_Click(object sender, EventArgs e)
        {
           
        }


        /*
        public void LerArquivoDeRegistros(string nomeArquivo)
        {
            raiz = null;
            Dado dado = new Dado();
            var origem = new FileStream(nomeArquivo, FileMode.OpenOrCreate);
            var arquivo = new BinaryReader(origem);
            int posicaoFinal = (int)origem.Length / dado.TamanhoRegistro - 1;
            Particionar(0, posicaoFinal, ref raiz);
            origem.Close();

            void Particionar(long inicio, long fim, ref NoArvore<Dado> atual)
            {
                if (inicio <= fim)
                {
                    long meio = (inicio + fim) / 2;  // registro do meio da partição sob leitura
                    dado = new Dado();               // cria um objeto para armazenar os dados
                    dado.LerRegistro(arquivo, meio); //
                    atual = new NoArvore<Dado>(dado);
                    var novoEsq = atual.Esq;
                    Particionar(inicio, meio - 1, ref novoEsq); // Particiona à esquerda
                    atual.Esq = novoEsq;
                    var novoDir = atual.Dir;
                    Particionar(meio + 1, fim, ref novoDir); // Particiona à direita
                    atual.Dir = novoDir;
                }
            }
        }

        
        public void ExibirDado(NoArvore<Dado> no, DataGridView dgv)
        {
            if (no != null) //fim da recursão
            {
                // Exibe os dados do nó atual
                dgv.Rows.Add(no.Info.ToString().Substring(0, 15), no.Info.ToString().Substring(16, 6),
                    no.Info.ToString().Substring(23, 6)); //nome, x, y

                ExibirDado(no.Esq, dgv); // chama ExibirDado para o nó da esquerda (recursividade)

                ExibirDado(no.Dir, dgv); // chama ExibirDado para o nó da direita (recursividade)
            }
        }
        */
       
    }
}
