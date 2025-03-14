using System;
using System.Windows.Forms;
using System.Drawing;

namespace JogoDaForcaGUI
{
    public partial class Form1 : Form
    {
        private JogoDaForca jogo;

        public Form1()
        {
            InitializeComponent();

            this.ClientSize = new Size(1280, 720); // Define o tamanho exato
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Evita redimensionamento
            this.StartPosition = FormStartPosition.CenterScreen; // Centraliza na tela

            CriarBotoesLetras();
            IniciarJogo();
        }

        private void CriarBotoesLetras()
        {
            panelLetras.Controls.Clear(); // Limpa antes de recriar os botões

            char[] alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int x = 10, y = 10;

            foreach (char letra in alfabeto)
            {
                Button botao = new Button();
                botao.Text = letra.ToString();
                botao.Width = 60; 
                botao.Height = 60;
                botao.Left = x;
                botao.Top = y;
                botao.Click += BotaoLetra_Click;
                panelLetras.Controls.Add(botao);

                x += 65; 

                if (x > panelLetras.Width - 65) // Quebra a linha se precisar
                {
                    x = 10;
                    y += 65;
                }
            }
        }
        private void RecriarBotoes()
        {
            panelLetras.Controls.Clear(); // Remove todos os botões antigos

            char[] alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int x = 10, y = 10;

            foreach (char letra in alfabeto)
            {
                Button botao = new Button
                {
                    Text = letra.ToString(),
                    Width = 60,
                    Height = 60,
                    Left = x,
                    Top = y,
                    Enabled = true // Garante que todos os botões começam ativos
                };
                botao.Click += BotaoLetra_Click; // Associa o evento de clique
                panelLetras.Controls.Add(botao);

                x += 65; // Espaçamento entre os botões

                if (x > panelLetras.Width - 65)
                {
                    x = 10;
                    y += 65;
                }
            }
        }
        // Inicializa um novo jogo, escolhendo uma palavra aleatória.
        private List<string> palavrasDisponiveis = new List<string>
        {
             "OBJETO", "COMPUTADOR", "PROGRAMACAO", "ALGORITMO", "CELSO",
             "CLASSE", "CONSTRUTORES", "METODO", "ANDREI", "NATAN", "DAVI",
             "WENDEL", "CLAUDINEY", "GABINETE", "MONITOR", "TECLADO", "MOUSE",
             "CAIQUE"
        };
        private HashSet<string> palavrasUsadas = new HashSet<string>();

        private void IniciarJogo()
        {
            if (palavrasDisponiveis.Count == 0)
            {
                // Se todas as palavras foram usadas, reiniciamos a lista
                palavrasDisponiveis.AddRange(palavrasUsadas);
                palavrasUsadas.Clear();
            }

            Random random = new Random();
            int index = random.Next(palavrasDisponiveis.Count);
            string palavra = palavrasDisponiveis[index];

            palavrasDisponiveis.RemoveAt(index); // Remove do conjunto de palavras disponíveis
            palavrasUsadas.Add(palavra); // Adiciona ao conjunto de palavras usadas

            jogo = new JogoDaForca(palavra);

            lblPalavra.Font = new Font("Arial", 25);
            lblTentativas.Font = new Font("Arial", 20);
            lblErros.Font = new Font("Arial", 20);

            btnDica.Size = new Size(150, 50);
            txtLetra.Size = new Size(50, 50);
            txtLetra.Font = new Font("Arial", 24);
            btnTentar.Size = new Size(150, 50);
            lblDica.Font = new Font("Arial", 14);

            RecriarBotoes();

            lblDica.Text = "";
            btnDica.Enabled = true;

            AtualizarTela();
        }
        // Atualiza a interface gráfica com o progresso do jogo.
        private void AtualizarTela()
        {
            lblPalavra.Text = "";
            foreach (char letra in jogo.palavraPerdida)
            {
                lblPalavra.Text += jogo.letrasAcertadas.Contains(letra) ? letra + " " : "_ ";
            }

            lblErros.Text = "Erros: " + string.Join(", ", jogo.letrasErradas);
            lblTentativas.Text = "Tentativas restantes: " + jogo.tentativas;

            DesenharBoneco(); // Atualiza o boneco corretamente

            // Reativa e redefine todos os botões de letras no painel
            foreach (Control ctrl in panelLetras.Controls)
            {
                if (ctrl is Button botao)
                {
                    botao.Enabled = !jogo.letrasAcertadas.Contains(botao.Text[0]) &&
                                    !jogo.letrasErradas.Contains(botao.Text[0]); // Habilita apenas se a letra não foi usada
                    botao.BackColor = SystemColors.Control; // Restaura a cor padrão
                }
            }

            // Verifica se o jogo terminou e exibe a mensagem
            if (jogo.jogoFinalizado())
            {
                DialogResult resultado;
                if (jogo.tentativas > 0)
                {
                    resultado = MessageBox.Show("Parabéns! Você venceu! 🎉\n\nDeseja jogar novamente?", "Jogo da Forca", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    resultado = MessageBox.Show($"Você perdeu! 😢 A palavra era: {jogo.palavraPerdida}\n\nDeseja jogar novamente?", "Jogo da Forca", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }

                if (resultado == DialogResult.Yes)
                {
                    IniciarJogo(); // Reinicia o jogo se o jogador escolher "Sim"
                }
                else
                {
                    this.Close(); // Fecha o jogo se o jogador escolher "Não"
                }
            }
        }
        // Evento acionado ao clicar no botão "Tentar".
        // Processa a jogada do jogador.
        private void btnTentar_Click(object sender, EventArgs e)
        {
            if (txtLetra.Text.Length == 1)
            {
                char tentativa = txtLetra.Text.ToUpper()[0];
                jogo.fazerJogada(tentativa);
                AtualizarTela();
            }

            txtLetra.Text = ""; // Limpa a caixa de texto após a tentativa
        }
        private void BotaoLetra_Click(object sender, EventArgs e)
        {
            Button botao = sender as Button;
            if (botao != null)
            {
                char letra = botao.Text[0];
                jogo.fazerJogada(letra); // Envia a tentativa para a lógica do jogo
                AtualizarTela();
                botao.Enabled = false; // Desativa o botão após o clique
            }
        }
        private void txtLetra_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtLetra.Text))
                {
                    char letra = txtLetra.Text.ToUpper()[0];
                    jogo.fazerJogada(letra);
                    AtualizarTela();
                    txtLetra.Clear();
                }
                e.Handled = true; // Impede o som do Enter
            }
        }
        private void DesenharBoneco()
        {
            if (pbBoneco.Image != null)
                pbBoneco.Image.Dispose(); // Limpa a imagem anterior

            Bitmap bmp = new Bitmap(pbBoneco.Width, pbBoneco.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Pen caneta = new Pen(Color.Black, 3);

                
                g.DrawLine(caneta, 20, 180, 120, 180);
                g.DrawLine(caneta, 70, 180, 70, 20);
                g.DrawLine(caneta, 70, 20, 140, 20);
                g.DrawLine(caneta, 140, 20, 140, 50);

                // vai desenhar o bonecos quando errar
                int erros = jogo.letrasErradas.Count;
                if (erros > 0) g.DrawEllipse(caneta, 125, 50, 30, 30); // Cabeça
                if (erros > 1) g.DrawLine(caneta, 140, 80, 140, 130); // Corpo
                if (erros > 2) g.DrawLine(caneta, 140, 90, 120, 110); // Braço esquerdo
                if (erros > 3) g.DrawLine(caneta, 140, 90, 160, 110); // Braço direito
                if (erros > 4) g.DrawLine(caneta, 140, 130, 120, 160); // Perna esquerda
                if (erros > 5) g.DrawLine(caneta, 140, 130, 160, 160); // Perna direita
            }

            pbBoneco.Image = bmp; // Atualiza o PictureBox com a imagem desenhada
        }
        private Dictionary<string, string> dicas = new Dictionary<string, string>
        {
            { "OBJETO", "É um conceito fundamental na programação orientada a objetos." },
            { "COMPUTADOR", "Máquina usada para processar informações eletronicamente." },
            { "PROGRAMACAO", "Atividade de escrever código para criar softwares." },
            { "ALGORITMO", "Sequência lógica de passos para resolver um problema." },
            { "CELSO", "O Professor mais amado do Brasil." },
            { "CLASSE", "Estrutura que define um objeto na programação." },
            { "CONSTRUTORES", "Métodos especiais usados para inicializar objetos." },
            { "METODO", "Função dentro de uma classe em programação orientada a objetos." },
            { "ANDREI","Aluno que faz parte do Trio Ternura da sala." },
            { "DAVI", "Aluno mais conhecido da sala." },
            { "NATAN", "Aluno musico da sala." },
            { "WENDEL", "Garoto que joga com molinho." },
            { "CLAUDINEY"," O lider." },
            { "GABINETE", "Componente onde ficam as partes internas de um computador." },
            { "MONITOR", "Onde é reproduzido as imagens de uma maquina." },
            { "TECLADO", "Serve para escrever em uma maquina." },
            { "MOUSE", "RATO." },
            { "CAIQUE", "O Homem mais Gosotoooooooso Desse Brasil." }
        };
        private void lblTentativas_Click(object sender, EventArgs e)
        {

        }
        private void btnDica_Click(object sender, EventArgs e)
        {
            
            
                if (dicas.ContainsKey(jogo.palavraPerdida))
                {
                    lblDica.Text = "Dica: " + dicas[jogo.palavraPerdida];
                }
                else
                {
                    lblDica.Text = "Dica: Nenhuma dica disponível.";
                }

                btnDica.Enabled = false; // Impede que o jogador peça outra dica
            
        }
    }

}

