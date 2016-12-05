using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using CamadaControl;

namespace CamadaView
{
    public partial class FrmJogar : Form
    {
        //VARIÁVEIS
        private Dictionary<string, PictureBox> _picturesBoxes = new Dictionary<string, PictureBox>();
        private CJogar _jogar;
        private CChat _chat;
        private Thread _threadMensagensRecebidas;
        private StreamReader _srResposta;

        public Dictionary<string, PictureBox> PicturesBoxes
        {
            get { return _picturesBoxes; }
            set { _picturesBoxes = value; }
        }

        public CJogar Jogar
        {
            get { return _jogar; }
            set { _jogar = value; }
        }

        public CChat Chat
        {
            get { return _chat; }
            set { _chat = value; }
        }

        public Thread ThreadMensagensRecebidas
        {
            get { return _threadMensagensRecebidas; }
            set { _threadMensagensRecebidas = value; }
        }

        public StreamReader SrResposta
        {
            get { return _srResposta; }
            set { _srResposta = value; }
        }


        //DELEGATES

        private delegate void AtualizaLogMensagensCallBack(string mensagem);
        private delegate void FechaConexaoCallBack(string mensagem);
        private delegate void AtualizaLogPalavrasCallBack(string mensagem);


        //MÉTODOS

        public FrmJogar()
        {
            InitializeComponent();
        }

        private void inicializarPictureBoxes()
        {
            try
            {
                PicturesBoxes.Add("11", pictureBox1);
                PicturesBoxes.Add("12", pictureBox2);
                PicturesBoxes.Add("13", pictureBox3);
                PicturesBoxes.Add("14", pictureBox4);
                PicturesBoxes.Add("15", pictureBox5);
                PicturesBoxes.Add("16", pictureBox6);
                PicturesBoxes.Add("17", pictureBox7);
                PicturesBoxes.Add("18", pictureBox8);
                PicturesBoxes.Add("21", pictureBox16);
                PicturesBoxes.Add("22", pictureBox15);
                PicturesBoxes.Add("23", pictureBox14);
                PicturesBoxes.Add("24", pictureBox13);
                PicturesBoxes.Add("25", pictureBox12);
                PicturesBoxes.Add("26", pictureBox11);
                PicturesBoxes.Add("27", pictureBox10);
                PicturesBoxes.Add("28", pictureBox9);
                PicturesBoxes.Add("31", pictureBox24);
                PicturesBoxes.Add("32", pictureBox23);
                PicturesBoxes.Add("33", pictureBox22);
                PicturesBoxes.Add("34", pictureBox21);
                PicturesBoxes.Add("35", pictureBox20);
                PicturesBoxes.Add("36", pictureBox19);
                PicturesBoxes.Add("37", pictureBox18);
                PicturesBoxes.Add("38", pictureBox17);
                PicturesBoxes.Add("41", pictureBox32);
                PicturesBoxes.Add("42", pictureBox31);
                PicturesBoxes.Add("43", pictureBox30);
                PicturesBoxes.Add("44", pictureBox29);
                PicturesBoxes.Add("45", pictureBox28);
                PicturesBoxes.Add("46", pictureBox27);
                PicturesBoxes.Add("47", pictureBox26);
                PicturesBoxes.Add("48", pictureBox25);
                PicturesBoxes.Add("51", pictureBox40);
                PicturesBoxes.Add("52", pictureBox39);
                PicturesBoxes.Add("53", pictureBox38);
                PicturesBoxes.Add("54", pictureBox37);
                PicturesBoxes.Add("55", pictureBox36);
                PicturesBoxes.Add("56", pictureBox35);
                PicturesBoxes.Add("57", pictureBox34);
                PicturesBoxes.Add("58", pictureBox33);
                PicturesBoxes.Add("61", pictureBox48);
                PicturesBoxes.Add("62", pictureBox47);
                PicturesBoxes.Add("63", pictureBox46);
                PicturesBoxes.Add("64", pictureBox45);
                PicturesBoxes.Add("65", pictureBox44);
                PicturesBoxes.Add("66", pictureBox43);
                PicturesBoxes.Add("67", pictureBox42);
                PicturesBoxes.Add("68", pictureBox41);
                PicturesBoxes.Add("71", pictureBox56);
                PicturesBoxes.Add("72", pictureBox55);
                PicturesBoxes.Add("73", pictureBox54);
                PicturesBoxes.Add("74", pictureBox53);
                PicturesBoxes.Add("75", pictureBox52);
                PicturesBoxes.Add("76", pictureBox51);
                PicturesBoxes.Add("77", pictureBox50);
                PicturesBoxes.Add("78", pictureBox49);
                PicturesBoxes.Add("81", pictureBox64);
                PicturesBoxes.Add("82", pictureBox63);
                PicturesBoxes.Add("83", pictureBox62);
                PicturesBoxes.Add("84", pictureBox61);
                PicturesBoxes.Add("85", pictureBox60);
                PicturesBoxes.Add("86", pictureBox59);
                PicturesBoxes.Add("87", pictureBox58);
                PicturesBoxes.Add("88", pictureBox57);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO\r\n\n" + ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Bitmap SelecionarFigura(char op)
        {
            switch (Char.ToUpper(op))
            {
                case 'A':
                    {
                        return CamadaView.Properties.Resources.A;
                    }
                case 'E':
                    {
                        return CamadaView.Properties.Resources.E;
                    }
                case 'O':
                    {
                        return CamadaView.Properties.Resources.O;
                    }
                case 'I':
                    {
                        return CamadaView.Properties.Resources.I;
                    }
                case 'U':
                    {
                        return CamadaView.Properties.Resources.U;
                    }
                case 'S':
                    {
                        return CamadaView.Properties.Resources.S;
                    }
                case 'L':
                    {
                        return CamadaView.Properties.Resources.L;
                    }
                case 'R':
                    {
                        return CamadaView.Properties.Resources.R;
                    }
                case 'B':
                    {
                        return CamadaView.Properties.Resources.B;
                    }
                case 'C':
                    {
                        return CamadaView.Properties.Resources.C;
                    }
                case 'D':
                    {
                        return CamadaView.Properties.Resources.D;
                    }
                case 'M':
                    {
                        return CamadaView.Properties.Resources.M;
                    }
                case 'N':
                    {
                        return CamadaView.Properties.Resources.N;
                    }
                case 'P':
                    {
                        return CamadaView.Properties.Resources.P;
                    }
                case 'T':
                    {
                        return CamadaView.Properties.Resources.T;
                    }
                case 'V':
                    {
                        return CamadaView.Properties.Resources.V;
                    }
                case 'F':
                    {
                        return CamadaView.Properties.Resources.F;
                    }
                case 'G':
                    {
                        return CamadaView.Properties.Resources.G;
                    }
                case 'H':
                    {
                        return CamadaView.Properties.Resources.H;
                    }
                case 'J':
                    {
                        return CamadaView.Properties.Resources.J;
                    }
                case 'Q':
                    {
                        return CamadaView.Properties.Resources.Q;
                    }
                case 'X':
                    {
                        return CamadaView.Properties.Resources.X;
                    }
                case 'Z':
                    {
                        return CamadaView.Properties.Resources.Z;
                    }
                case 'Y':
                    {
                        return CamadaView.Properties.Resources.Revelado;
                    }
                default:
                    {
                        return CamadaView.Properties.Resources.Oculto;
                    }
            }
        }

        private void IniciarConexão()
        {
            Exception ex = Chat.iniciarConexao(txtUsuario.Text, txtIpServidor.Text);
            if (ex != null)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro na conexão com o servidor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.txtUsuario.Enabled = false;
            if (txtUsuario.Text.Trim().Equals(""))
            {
                this.txtUsuario.Text = "Anonymous";
            }
            this.txtIpServidor.Enabled = false;
            this.btnConectar.Text = "Conectado";
            this.btnConectar.ForeColor = SystemColors.GrayText;
            ThreadMensagensRecebidas = new Thread(new ThreadStart(MensagemRecebida)); //Thread do tipo delegate passado como parâmetro
            ThreadMensagensRecebidas.Start();
            this.btnSortear.Enabled = true;
            this.txtMensagem.Enabled = true;
            EnviarPegarQuantidadeJogadores();
        }

        private void MensagemRecebida()
        {
            SrResposta = new StreamReader(Chat.TcpServidor.GetStream());
            string resposta = SrResposta.ReadLine();

            if (resposta.Substring(0, 2).Equals("01")) //A primeira resposta que o cliente receber tem que ser 01, para estabelecer a conexão.
            {
                this.Invoke(new AtualizaLogMensagensCallBack(this.AtualizaLogMensagens), new object[] { "Conectado com sucesso!" });
            }
            else
            {
                this.Invoke(new FechaConexaoCallBack(this.FecharConexao), new object[] { "Erro de conexão: " + resposta.Substring(3, resposta.Length - 3) });
                return;
            }
            while (Chat.Conectado)
            {
                try
                {
                    resposta = SrResposta.ReadLine();
                    if (resposta.Substring(0, 2).Equals("02")) //Mensagens
                    {
                        this.Invoke(new AtualizaLogMensagensCallBack(this.AtualizaLogMensagens), new object[] { resposta.Substring(3, resposta.Length - 3) });
                    }
                    else if (resposta.Substring(0, 2).Equals("03")) //Movimentações
                    {
                        this.Invoke(new AtualizaLogMensagensCallBack(this.AtualizaLogMovimentacoes), new object[] { resposta.Substring(3, resposta.Length - 3) });
                    }
                    else if (resposta.Substring(0, 2).Equals("10")) //resultado dos dados somados
                    {
                        this.Invoke(new AtualizaLogMensagensCallBack(this.AtualizaCampoDadosSomados), new object[] { resposta.Substring(3, resposta.Length - 3) });
                    }
                    else if (resposta.Substring(0, 2).Equals("11")) //posição clicada e letra exibida
                    {
                        this.Invoke(new AtualizaLogMensagensCallBack(this.AtualizaJogada), new object[] { resposta.Substring(3, resposta.Length - 3) });
                    }
                    else if (resposta.Substring(0, 2).Equals("12")) //palavras recebidas
                    {
                        this.Invoke(new AtualizaLogMensagensCallBack(this.AtualizaLogPalavras), new object[] { resposta.Substring(3, resposta.Length - 3) });
                    }
                    else if (resposta.Substring(0, 2).Equals("17")) //quantidade jogadores
                    {
                        this.Invoke(new AtualizaLogMensagensCallBack(this.AtualizaQuantidadeJogadores), new object[] { resposta.Substring(3, resposta.Length - 3) });
                    }
                    else if (resposta.Substring(0, 2).Equals("18")) //primeiro à jogar
                    {
                        this.Invoke(new AtualizaLogMensagensCallBack(this.AtualizaPrimeiroAJogar), new object[] { resposta.Substring(3, resposta.Length - 3) });
                    }
                    else if (resposta.Substring(0, 2).Equals("19")) //próximo à jogar
                    {
                        this.Invoke(new AtualizaLogMensagensCallBack(this.AtualizaProximoAJogar), new object[] { resposta.Substring(3, resposta.Length - 3) });
                    }
                }
                catch (Exception ex)
                {
                    if (!txtUsuario.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Usuário: " + txtUsuario.Text, "Conexão encerrada!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Usuário: Anonymous", "Conexão encerrada!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        //atualiza objetos

        private void AtualizaQuantidadeJogadores(string mensagem)
        {
            lblQuantidadeJogadores.Text = mensagem;
        }

        private void AtualizaLogMensagens(string mensagem)
        {
            txtLogMensagens.AppendText(mensagem + "\r\n");
        }

        private void AtualizaLogMovimentacoes(string mensagem)
        {
            txtLogMovimentacoes.AppendText(mensagem + "\r\n");
        }

        private void AtualizaJogada(string mensagem) //O parâmetro é uma substring da resposta, com tudo antes do primeiro pipe eliminado.
        {   //A key vai ser tudo entre o primeiro e segundo pipe. E a letra selecionada está após o segundo pipe.
            PicturesBoxes[mensagem.Substring(0, 2)].Image = SelecionarFigura(mensagem[3]);
        }

        private void AtualizaLogPalavras(string mensagem)
        {
            txtLogPalavras.AppendText(mensagem + "\r\n");
        }

        private void AtualizaCampoDadosSomados(string mensagem)
        {
            txtDadosSomados.Text = mensagem;
        }

        private void AtualizaPrimeiroAJogar(string mensagem)
        {
            btnSortear.Enabled = false;
            if (txtUsuario.Text.Trim().Equals(mensagem))
            {
                btnJogar.Enabled = true;
            }
            else
            {
                btnJogar.Enabled = false;
            }
        }

        private void AtualizaProximoAJogar(string mensagem)
        {
            if (txtUsuario.Text.Trim().Equals(mensagem))
            {
                btnJogar.Enabled = true;
            }
            else
            {
                btnJogar.Enabled = false;
            }
        }

        //envia dados

        private void EnviarMensagem() // Envia msg de chat.
        {
            if (!txtMensagem.Text.Trim().Equals(""))
            {
                Chat.EnviarMensagem("02|" + txtMensagem.Text);
            }
            txtMensagem.Text = "";
        }

        private void EnviarResultadoDados() // Envia o resultado dos dois dados somados.
        {
            if (!txtDadosSomados.Text.Trim().Equals(""))
            {
                Chat.EnviarMensagem("10|" + txtDadosSomados.Text);
            }
        }

        private void EnviarJogada(string posicao) // Envia posição da peça clicada para dar o devido tratamento.
        {
            Chat.EnviarMensagem("11|" + posicao);
        }

        private void EnviarPalavra() // Envia o texto digitado no campo palavra para ser adicionado no logPalavras de todos clientes.
        {
            if (!txtPalavra.Text.Trim().Equals(""))
            {
                Chat.EnviarMensagem("12|" + txtPalavra.Text.ToUpper());
            }
            txtPalavra.Text = "";
        }

        private void EnviarPegarQuantidadeJogadores() // Requisição da quantidade de jogadores.
        {
            Chat.EnviarMensagem("17|");
        }

        private void EnviarSortearJogador() // Requisição para sortear a vez.
        {
            Chat.EnviarMensagem("18|");
        }

        private void EnviarFimJogada() // Passa a vez.
        {
            this.txtDado1.Text = "";
            this.txtDado2.Text = "";
            this.txtDadosSomados.Text = "";
            this.btnJogar.Enabled = false;
            this.txtPalavra.Enabled = false;
            this.btnAdicionar.Enabled = false;
            this.btnFinalizar.Enabled = false;
            Chat.EnviarMensagem("19|");
        }

        //--------------------------

        private void FecharConexao(string mensagem)
        {
            Chat.FecharConexao();
            SrResposta.Close();
            this.txtDado1.Text = "";
            this.txtDado2.Text = "";
            this.btnJogar.Enabled = false;
            this.txtPalavra.Enabled = false;
            this.btnAdicionar.Enabled = false;
            this.btnFinalizar.Enabled = false;
            this.txtLogMensagens.AppendText(mensagem + "\r\n");
            this.btnConectar.Text = "Conectar";
            this.btnConectar.ForeColor = SystemColors.ControlText;
        }


        //EVENTOS

        private void FrmJogar_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 510;
            txtUsuario.Select();
            //txtIpServidor.Select();
            Chat = new CChat();
            Jogar = new CJogar();
            inicializarPictureBoxes();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)13) && !Chat.Conectado) // Se pressionou a tecla Enter, então faça...
            {
                IniciarConexão();
            }
        }

        private void txtIpServidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)13) && !Chat.Conectado) // Se pressionou a tecla Enter, então faça...
            {
                IniciarConexão();
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (!Chat.Conectado)
            {
                IniciarConexão();
            }
            else
            {
                FecharConexao("Conexão ecerrada pelo usuário."); // Fecha as conexões, streams, etc...
            }
        }

        private void btnSortear_Click(object sender, EventArgs e)
        {
            EnviarSortearJogador();
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            this.btnJogar.Enabled = false;
            this.txtDado1.Text = Jogar.rolarDado();
            this.txtDado2.Text = Jogar.rolarDado();
            this.txtDadosSomados.Text = (Convert.ToInt32(this.txtDado1.Text) + Convert.ToInt32(this.txtDado2.Text)).ToString();
            //Jogar.ViradasPermitidas = Convert.ToInt32(this.txtDado1.Text) + Convert.ToInt32(this.txtDado2.Text);
            EnviarResultadoDados();
            this.txtPalavra.Enabled = true;
            this.btnAdicionar.Enabled = true;
            this.btnFinalizar.Enabled = true;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            EnviarPalavra();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            EnviarFimJogada();
        }

        private void txtMensagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Se pressionou a tecla Enter, então faça...
            {
                EnviarMensagem();
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviarMensagem();
        }

        // O tratador de evento para a saída da aplicação
        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (Chat.Conectado)
            {
                FecharConexao("Conexão ecerrada pelo usuário."); // Fecha as conexões, streams, etc...
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = SelecionarFigura(Jogar.virarLetra(11));
            EnviarJogada("11");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            EnviarJogada("12");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            EnviarJogada("13");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            EnviarJogada("14");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            EnviarJogada("15");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            EnviarJogada("16");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            EnviarJogada("17");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            EnviarJogada("18");
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            EnviarJogada("21");
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            EnviarJogada("22");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            EnviarJogada("23");
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            EnviarJogada("24");
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            EnviarJogada("25");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            EnviarJogada("26");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            EnviarJogada("27");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            EnviarJogada("28");
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            EnviarJogada("31");
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            EnviarJogada("32");
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            EnviarJogada("33");
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            EnviarJogada("34");
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            EnviarJogada("35");
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            EnviarJogada("36");
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            EnviarJogada("37");
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            EnviarJogada("38");
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            EnviarJogada("41");
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            EnviarJogada("42");
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            EnviarJogada("43");
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            EnviarJogada("44");
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            EnviarJogada("45");
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            EnviarJogada("46");
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            EnviarJogada("47");
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            EnviarJogada("48");
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            EnviarJogada("51");
        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            EnviarJogada("52");
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            EnviarJogada("53");
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            EnviarJogada("54");
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            EnviarJogada("55");
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            EnviarJogada("56");
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            EnviarJogada("57");
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            EnviarJogada("58");
        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {
            EnviarJogada("61");
        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            EnviarJogada("62");
        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {
            EnviarJogada("63");
        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            EnviarJogada("64");
        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            EnviarJogada("65");
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            EnviarJogada("66");
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            EnviarJogada("67");
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            EnviarJogada("68");
        }

        private void pictureBox56_Click(object sender, EventArgs e)
        {
            EnviarJogada("71");
        }

        private void pictureBox55_Click(object sender, EventArgs e)
        {
            EnviarJogada("72");
        }

        private void pictureBox54_Click(object sender, EventArgs e)
        {
            EnviarJogada("73");
        }

        private void pictureBox53_Click(object sender, EventArgs e)
        {
            EnviarJogada("74");
        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            EnviarJogada("75");
        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {
            EnviarJogada("76");
        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            EnviarJogada("77");
        }

        private void pictureBox49_Click(object sender, EventArgs e)
        {
            EnviarJogada("78");
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            EnviarJogada("81");
        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {
            EnviarJogada("82");
        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {
            EnviarJogada("83");
        }

        private void pictureBox61_Click(object sender, EventArgs e)
        {
            EnviarJogada("84");
        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {
            EnviarJogada("85");
        }

        private void pictureBox59_Click(object sender, EventArgs e)
        {
            EnviarJogada("86");
        }

        private void pictureBox58_Click(object sender, EventArgs e)
        {
            EnviarJogada("87");
        }

        private void pictureBox57_Click(object sender, EventArgs e)
        {
            EnviarJogada("88");
        }
    }
}
