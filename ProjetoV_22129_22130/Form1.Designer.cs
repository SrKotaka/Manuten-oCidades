namespace ProjetoV_22129_22130
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageCadastro = new System.Windows.Forms.TabPage();
            this.tabPageArvore = new System.Windows.Forms.TabPage();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonIncluirNome = new System.Windows.Forms.Button();
            this.buttonExcluirCidade = new System.Windows.Forms.Button();
            this.buttonAlterarCidade = new System.Windows.Forms.Button();
            this.buttonExibirCidade = new System.Windows.Forms.Button();
            this.textBoxCidadeDeDestino = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownDistancia = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTempo = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCusto = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonExibirCaminhos = new System.Windows.Forms.Button();
            this.buttonAlterarCaminhos = new System.Windows.Forms.Button();
            this.buttonExcluirCaminhos = new System.Windows.Forms.Button();
            this.buttonIncluirCaminhos = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabPageCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cidade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageCadastro);
            this.tabControl.Controls.Add(this.tabPageArvore);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1134, 636);
            this.tabControl.TabIndex = 2;
            // 
            // tabPageCadastro
            // 
            this.tabPageCadastro.Controls.Add(this.dataGridView1);
            this.tabPageCadastro.Controls.Add(this.buttonExibirCaminhos);
            this.tabPageCadastro.Controls.Add(this.buttonAlterarCaminhos);
            this.tabPageCadastro.Controls.Add(this.buttonExcluirCaminhos);
            this.tabPageCadastro.Controls.Add(this.buttonIncluirCaminhos);
            this.tabPageCadastro.Controls.Add(this.label9);
            this.tabPageCadastro.Controls.Add(this.label8);
            this.tabPageCadastro.Controls.Add(this.numericUpDownCusto);
            this.tabPageCadastro.Controls.Add(this.numericUpDownTempo);
            this.tabPageCadastro.Controls.Add(this.numericUpDownDistancia);
            this.tabPageCadastro.Controls.Add(this.label7);
            this.tabPageCadastro.Controls.Add(this.textBoxCidadeDeDestino);
            this.tabPageCadastro.Controls.Add(this.buttonExibirCidade);
            this.tabPageCadastro.Controls.Add(this.buttonAlterarCidade);
            this.tabPageCadastro.Controls.Add(this.buttonExcluirCidade);
            this.tabPageCadastro.Controls.Add(this.buttonIncluirNome);
            this.tabPageCadastro.Controls.Add(this.label6);
            this.tabPageCadastro.Controls.Add(this.label5);
            this.tabPageCadastro.Controls.Add(this.pictureBox);
            this.tabPageCadastro.Controls.Add(this.label4);
            this.tabPageCadastro.Controls.Add(this.label3);
            this.tabPageCadastro.Controls.Add(this.numericUpDownY);
            this.tabPageCadastro.Controls.Add(this.numericUpDownX);
            this.tabPageCadastro.Controls.Add(this.textBoxNome);
            this.tabPageCadastro.Controls.Add(this.label1);
            this.tabPageCadastro.Controls.Add(this.label2);
            this.tabPageCadastro.Location = new System.Drawing.Point(4, 22);
            this.tabPageCadastro.Name = "tabPageCadastro";
            this.tabPageCadastro.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCadastro.Size = new System.Drawing.Size(1126, 610);
            this.tabPageCadastro.TabIndex = 0;
            this.tabPageCadastro.Text = "Cadastro";
            this.tabPageCadastro.UseVisualStyleBackColor = true;
            // 
            // tabPageArvore
            // 
            this.tabPageArvore.Location = new System.Drawing.Point(4, 22);
            this.tabPageArvore.Name = "tabPageArvore";
            this.tabPageArvore.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArvore.Size = new System.Drawing.Size(1126, 610);
            this.tabPageArvore.TabIndex = 1;
            this.tabPageArvore.Text = "Árvore";
            this.tabPageArvore.UseVisualStyleBackColor = true;
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(22, 73);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(318, 20);
            this.textBoxNome.TabIndex = 2;
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(346, 73);
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownX.TabIndex = 3;
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(472, 73);
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownY.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(343, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(469, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Y";
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::ProjetoV_22129_22130.Properties.Resources.Mapa_Marte_sem_rotas;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(598, 26);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(512, 274);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Caminhos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Cidade De Destino";
            // 
            // buttonIncluirNome
            // 
            this.buttonIncluirNome.Location = new System.Drawing.Point(22, 100);
            this.buttonIncluirNome.Name = "buttonIncluirNome";
            this.buttonIncluirNome.Size = new System.Drawing.Size(75, 23);
            this.buttonIncluirNome.TabIndex = 10;
            this.buttonIncluirNome.Text = "Incluir";
            this.buttonIncluirNome.UseVisualStyleBackColor = true;
            // 
            // buttonExcluirCidade
            // 
            this.buttonExcluirCidade.Location = new System.Drawing.Point(103, 100);
            this.buttonExcluirCidade.Name = "buttonExcluirCidade";
            this.buttonExcluirCidade.Size = new System.Drawing.Size(75, 23);
            this.buttonExcluirCidade.TabIndex = 11;
            this.buttonExcluirCidade.Text = "Excluir";
            this.buttonExcluirCidade.UseVisualStyleBackColor = true;
            // 
            // buttonAlterarCidade
            // 
            this.buttonAlterarCidade.Location = new System.Drawing.Point(184, 100);
            this.buttonAlterarCidade.Name = "buttonAlterarCidade";
            this.buttonAlterarCidade.Size = new System.Drawing.Size(75, 23);
            this.buttonAlterarCidade.TabIndex = 12;
            this.buttonAlterarCidade.Text = "Alterar";
            this.buttonAlterarCidade.UseVisualStyleBackColor = true;
            // 
            // buttonExibirCidade
            // 
            this.buttonExibirCidade.Location = new System.Drawing.Point(265, 99);
            this.buttonExibirCidade.Name = "buttonExibirCidade";
            this.buttonExibirCidade.Size = new System.Drawing.Size(75, 23);
            this.buttonExibirCidade.TabIndex = 13;
            this.buttonExibirCidade.Text = "Exibir";
            this.buttonExibirCidade.UseVisualStyleBackColor = true;
            // 
            // textBoxCidadeDeDestino
            // 
            this.textBoxCidadeDeDestino.Location = new System.Drawing.Point(22, 257);
            this.textBoxCidadeDeDestino.Name = "textBoxCidadeDeDestino";
            this.textBoxCidadeDeDestino.Size = new System.Drawing.Size(318, 20);
            this.textBoxCidadeDeDestino.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Distância";
            // 
            // numericUpDownDistancia
            // 
            this.numericUpDownDistancia.Location = new System.Drawing.Point(20, 303);
            this.numericUpDownDistancia.Name = "numericUpDownDistancia";
            this.numericUpDownDistancia.Size = new System.Drawing.Size(189, 20);
            this.numericUpDownDistancia.TabIndex = 16;
            // 
            // numericUpDownTempo
            // 
            this.numericUpDownTempo.Location = new System.Drawing.Point(215, 303);
            this.numericUpDownTempo.Name = "numericUpDownTempo";
            this.numericUpDownTempo.Size = new System.Drawing.Size(189, 20);
            this.numericUpDownTempo.TabIndex = 17;
            // 
            // numericUpDownCusto
            // 
            this.numericUpDownCusto.Location = new System.Drawing.Point(410, 303);
            this.numericUpDownCusto.Name = "numericUpDownCusto";
            this.numericUpDownCusto.Size = new System.Drawing.Size(182, 20);
            this.numericUpDownCusto.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(212, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Tempo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(407, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Custo";
            // 
            // buttonExibirCaminhos
            // 
            this.buttonExibirCaminhos.Location = new System.Drawing.Point(265, 328);
            this.buttonExibirCaminhos.Name = "buttonExibirCaminhos";
            this.buttonExibirCaminhos.Size = new System.Drawing.Size(75, 23);
            this.buttonExibirCaminhos.TabIndex = 24;
            this.buttonExibirCaminhos.Text = "Exibir";
            this.buttonExibirCaminhos.UseVisualStyleBackColor = true;
            // 
            // buttonAlterarCaminhos
            // 
            this.buttonAlterarCaminhos.Location = new System.Drawing.Point(184, 329);
            this.buttonAlterarCaminhos.Name = "buttonAlterarCaminhos";
            this.buttonAlterarCaminhos.Size = new System.Drawing.Size(75, 23);
            this.buttonAlterarCaminhos.TabIndex = 23;
            this.buttonAlterarCaminhos.Text = "Alterar";
            this.buttonAlterarCaminhos.UseVisualStyleBackColor = true;
            // 
            // buttonExcluirCaminhos
            // 
            this.buttonExcluirCaminhos.Location = new System.Drawing.Point(103, 329);
            this.buttonExcluirCaminhos.Name = "buttonExcluirCaminhos";
            this.buttonExcluirCaminhos.Size = new System.Drawing.Size(75, 23);
            this.buttonExcluirCaminhos.TabIndex = 22;
            this.buttonExcluirCaminhos.Text = "Excluir";
            this.buttonExcluirCaminhos.UseVisualStyleBackColor = true;
            // 
            // buttonIncluirCaminhos
            // 
            this.buttonIncluirCaminhos.Location = new System.Drawing.Point(22, 329);
            this.buttonIncluirCaminhos.Name = "buttonIncluirCaminhos";
            this.buttonIncluirCaminhos.Size = new System.Drawing.Size(75, 23);
            this.buttonIncluirCaminhos.TabIndex = 21;
            this.buttonIncluirCaminhos.Text = "Incluir";
            this.buttonIncluirCaminhos.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 359);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(572, 245);
            this.dataGridView1.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 660);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.tabPageCadastro.ResumeLayout(false);
            this.tabPageCadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageCadastro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TabPage tabPageArvore;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonIncluirNome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownCusto;
        private System.Windows.Forms.NumericUpDown numericUpDownTempo;
        private System.Windows.Forms.NumericUpDown numericUpDownDistancia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCidadeDeDestino;
        private System.Windows.Forms.Button buttonExibirCidade;
        private System.Windows.Forms.Button buttonAlterarCidade;
        private System.Windows.Forms.Button buttonExcluirCidade;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonExibirCaminhos;
        private System.Windows.Forms.Button buttonAlterarCaminhos;
        private System.Windows.Forms.Button buttonExcluirCaminhos;
        private System.Windows.Forms.Button buttonIncluirCaminhos;
    }
}

