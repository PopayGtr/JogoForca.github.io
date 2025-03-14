namespace JogoDaForcaGUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            lblPalavra = new Label();
            txtLetra = new TextBox();
            btnTentar = new Button();
            lblErros = new Label();
            lblTentativas = new Label();
            panelLetras = new Panel();
            pbBoneco = new PictureBox();
            btnDica = new Button();
            lblDica = new Label();
            ((System.ComponentModel.ISupportInitialize)pbBoneco).BeginInit();
            SuspendLayout();
            // 
            // lblPalavra
            // 
            lblPalavra.AutoSize = true;
            lblPalavra.Location = new Point(521, 116);
            lblPalavra.Name = "lblPalavra";
            lblPalavra.Size = new Size(58, 15);
            lblPalavra.TabIndex = 0;
            lblPalavra.Tag = "";
            lblPalavra.Text = "lblPalavra";
            lblPalavra.Click += lblPalavra_Click;
            // 
            // txtLetra
            // 
            txtLetra.Location = new Point(993, 137);
            txtLetra.Name = "txtLetra";
            txtLetra.Size = new Size(164, 23);
            txtLetra.TabIndex = 1;
            txtLetra.KeyPress += txtLetra_KeyPress_1;
            // 
            // btnTentar
            // 
            btnTentar.Location = new Point(993, 202);
            btnTentar.Name = "btnTentar";
            btnTentar.Size = new Size(164, 23);
            btnTentar.TabIndex = 2;
            btnTentar.Text = "Tentar";
            btnTentar.UseVisualStyleBackColor = true;
            btnTentar.Click += btnTentar_Click;
            // 
            // lblErros
            // 
            lblErros.AutoSize = true;
            lblErros.Location = new Point(602, 541);
            lblErros.Name = "lblErros";
            lblErros.Size = new Size(45, 15);
            lblErros.TabIndex = 3;
            lblErros.Text = "Erros: 0";
            // 
            // lblTentativas
            // 
            lblTentativas.AutoSize = true;
            lblTentativas.Location = new Point(565, 499);
            lblTentativas.Name = "lblTentativas";
            lblTentativas.Size = new Size(121, 15);
            lblTentativas.TabIndex = 4;
            lblTentativas.Text = "TentativasRestantes: 0";
            lblTentativas.Click += lblTentativas_Click;
            // 
            // panelLetras
            // 
            panelLetras.Location = new Point(41, 90);
            panelLetras.Name = "panelLetras";
            panelLetras.Size = new Size(272, 466);
            panelLetras.TabIndex = 5;
            // 
            // pbBoneco
            // 
            pbBoneco.Location = new Point(552, 240);
            pbBoneco.Name = "pbBoneco";
            pbBoneco.Size = new Size(192, 194);
            pbBoneco.TabIndex = 6;
            pbBoneco.TabStop = false;
            // 
            // btnDica
            // 
            btnDica.Location = new Point(993, 299);
            btnDica.Name = "btnDica";
            btnDica.Size = new Size(75, 23);
            btnDica.TabIndex = 7;
            btnDica.Text = "Dica";
            btnDica.UseVisualStyleBackColor = true;
            btnDica.Click += btnDica_Click;
            // 
            // lblDica
            // 
            lblDica.AutoSize = true;
            lblDica.Location = new Point(750, 240);
            lblDica.Name = "lblDica";
            lblDica.Size = new Size(38, 15);
            lblDica.TabIndex = 8;
            lblDica.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(lblDica);
            Controls.Add(btnDica);
            Controls.Add(pbBoneco);
            Controls.Add(panelLetras);
            Controls.Add(lblTentativas);
            Controls.Add(lblErros);
            Controls.Add(btnTentar);
            Controls.Add(txtLetra);
            Controls.Add(lblPalavra);
            Name = "Form1";
            Text = "Jogo da Forca";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbBoneco).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPalavra;
        private TextBox txtLetra;
        private Button btnTentar;
        private Label lblErros;
        private Label lblTentativas;

        // Método para o evento Load do Form
        private void Form1_Load(object sender, EventArgs e)
        {
            IniciarJogo();

            panelLetras.Size = new Size(272, 466);
            panelLetras.Location = new Point(50, 100);  // Exemplo de posição

            // Configurar os botões
            btnTentar.Text = "Tentar";
            btnTentar.Size = new Size(120, 40);
            btnTentar.Location = new Point(350, 300); // Ajuste a posição como desejar

            btnDica.Text = "Dica";
            btnDica.Size = new Size(120, 40);
            btnDica.Location = new Point(350, 360); // Ajuste a posição como desejar

            // Configurar a imagem do boneco
            pbBoneco.Size = new Size(227, 184);
            pbBoneco.Location = new Point(550, 240); // Ajuste a posição como desejar

            // Configurar os labels de erro e tentativas
            lblErros.Text = "Erros: 0";
            lblTentativas.Text = "Tentativas: 0";
            lblErros.Location = new Point(600, 500);  // Ajuste a posição
            lblTentativas.Location = new Point(600, 530);  // Ajuste a posição

            // Configurar a dica
            lblDica.Text = "Aqui vai uma dica!";
            lblDica.Location = new Point(750, 240); // Ajuste a posição

             //Configurando o fundo do formulário
            this.BackColor = Color.LightBlue;

            // Personalizando o label da palavra
            lblPalavra.Font = new Font("Arial", 16, FontStyle.Bold);
            lblPalavra.ForeColor = Color.Green;

            // Personalizando o botão "Tentar"
            btnTentar.BackColor = Color.LightGreen;
            btnTentar.ForeColor = Color.Black;

            // Personalizando o botão "Dica"
            btnDica.BackColor = Color.LightCoral;
            btnDica.ForeColor = Color.White;

            // Configurar o texto e posição de outros elementos
            lblErros.Text = "Erros: 0";
            lblTentativas.Text = "Tentativas: 0";
            lblDica.Text = "Aqui vai uma dica!";
            pbBoneco.Visible = true;
        }
            // Método para o evento Click do lblPalavra
            private void lblPalavra_Click(object sender, EventArgs e)
        {
            // Ação ao clicar no label, se necessário
        }

        // Método para o evento Click do btnTentar
        private void btnTentar_click(object sender, EventArgs e)
        {
            // Lógica para tentar adivinhar a letra
            // Exemplo: Atualizar lblErros e lblTentativas
        }

        private Panel panelLetras;
        private PictureBox pbBoneco;
        private Button btnDica;
        private Label lblDica;
    }
}