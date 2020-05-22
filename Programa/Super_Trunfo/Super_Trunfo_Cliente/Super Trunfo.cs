using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Super_Trunfo_Cliente
{
    public partial class Tela : Form
    {
        private Itens_Compartilhados.Carta[] cartas;
        private int posicao;
        private Boolean status_servico;
        private Boolean bloqueioEnv;
        private Itens_Compartilhados.Funcoes funcoes;
        private Cliente cliente;
        private Thread threadServidor;
        private Boolean primeiraJogada = false;
        public Tela()
        {
            InitializeComponent();
            status_servico = false;
            bloqueioEnv = true;
            cliente = new Cliente();
        }

        private void Tela_Load(object sender, EventArgs e)
        {
            funcoes = new Itens_Compartilhados.Funcoes();
            carregaCartas();
            inicia_Informacoes();
            Super_Trunfo_Servidor.Execucao server = new Super_Trunfo_Servidor.Execucao();
            threadServidor = new Thread(() => server.executar());
            toolStripStatusLabel3.Text = "IP: " + funcoes.retornaIP();
        }

        private void inicia_Informacoes()
        {
            int auxX;
            int auxY;

            pb_final.Dock = DockStyle.Fill;
            pb_final.BackColor = Color.White;

            p_information.Parent = pb_fundo;
            pb_ganhou.Parent = pb_fundo;
            pb_perdeu.Parent = pb_fundo;

            pb_semaforo.Height = statusBar.Height - 2;
            pb_semaforo.Width = (int)((double)(pb_semaforo.Height) * 2.3);
            auxX = pb_semaforo.Location.X;
            auxY = statusBar.Location.Y;
            pb_semaforo.Location = new Point(auxX, auxY);

            pb_setaDireita.Parent = p_information;
            pb_setaEsquerda.Parent = p_information;
            pb_escolha.Parent = p_information;
            pb_start_stop.Parent = p_information;
            pb_jogar.Parent = p_information;
            rb_altura.Parent = p_information;
            rb_comprimento.Parent = p_information;
            rb_peso.Parent = p_information;
            rb_idade.Parent = p_information;

            l_cod_01.Parent = pb_fundo;
            l_nome_01.Parent = pb_fundo;
            l_tipo_01.Parent = pb_fundo;
            l_altura_01.Parent = pb_fundo;
            l_comprimento_01.Parent = pb_fundo;
            l_peso_01.Parent = pb_fundo;
            l_idade_01.Parent = pb_fundo;

            l_cod_02.Parent = pb_fundo;
            l_nome_02.Parent = pb_fundo;
            l_tipo_02.Parent = pb_fundo;
            l_altura_02.Parent = pb_fundo;
            l_comprimento_02.Parent = pb_fundo;
            l_peso_02.Parent = pb_fundo;
            l_idade_02.Parent = pb_fundo;

            l_cod_01.BackColor = Color.Transparent;
            l_nome_01.BackColor = Color.Transparent;
            l_tipo_01.BackColor = Color.Transparent;
            l_altura_01.BackColor = Color.Transparent;
            l_comprimento_01.BackColor = Color.Transparent;
            l_peso_01.BackColor = Color.Transparent;
            l_idade_01.BackColor = Color.Transparent;

            l_cod_02.BackColor = Color.Transparent;
            l_nome_02.BackColor = Color.Transparent;
            l_tipo_02.BackColor = Color.Transparent;
            l_altura_02.BackColor = Color.Transparent;
            l_comprimento_02.BackColor = Color.Transparent;
            l_peso_02.BackColor = Color.Transparent;
            l_idade_02.BackColor = Color.Transparent;

            l_cod_01.Text = "Código: ?";
            l_nome_01.Text = "Nome: ?";
            l_tipo_01.Text = "Tipo: ?";
            l_altura_01.Text = "Altura: ?";
            l_comprimento_01.Text = "Comprimento: ?";
            l_peso_01.Text = "Peso: ?";
            l_idade_01.Text = "Idade: ?";

            l_cod_02.Text = "Código: ?";
            l_nome_02.Text = "Nome: ?";
            l_tipo_02.Text = "Tipo: ?";
            l_altura_02.Text = "Altura: ?";
            l_comprimento_02.Text = "Comprimento: ?";
            l_peso_02.Text = "Peso: ?";
            l_idade_02.Text = "Idade: ?";

            pb_ganhou.Visible = false;
            pb_perdeu.Visible = false;
        }

        private void carregaCartas()
        {
            posicao = 0;
            cartas = funcoes.informacoesCartas();
        }

        private void mudaCarta(char tipo)
        {
            object img1;
            if (tipo.Equals('S'))
            {
                posicao++;
                if (posicao >= 33)
                {
                    posicao = 0;
                }
                while (!cartas[posicao].ativo)
                {
                    posicao++;
                    if (posicao >= 33)
                    {
                        posicao = 0;
                    }
                }
            }
            else if (tipo.Equals('D'))
            {
                posicao--;
                if (posicao <= -1)
                {
                    posicao = 32;
                }
                while (!cartas[posicao].ativo)
                {
                    posicao--;
                    if (posicao <= -1)
                    {
                        posicao = 32;
                    }
                }
            }

            img1 = Super_Trunfo_Cliente.Properties.Resources.ResourceManager.GetObject(cartas[posicao].cod_Carta);
            pb_selfcard.Image = img1 as Image;
            img1 = null;

            l_cod_01.Text = "Código: " + cartas[posicao].cod_Carta;
            l_nome_01.Text = "Nome: " + cartas[posicao].nome;
            l_tipo_01.Text = "Tipo: " + cartas[posicao].tipo;
            l_altura_01.Text = "Altura: " + System.Convert.ToString(cartas[posicao].altura);
            l_comprimento_01.Text = "Comprimento: " + System.Convert.ToString(cartas[posicao].comprimento);
            l_peso_01.Text = "Peso: " + System.Convert.ToString(cartas[posicao].peso);
            l_idade_01.Text = "Idade: " + System.Convert.ToString(cartas[posicao].idade);

            if (posicao == 0)
            {
                pb_jogar.Image = Super_Trunfo_Cliente.Properties.Resources.Jogada_cinza;
                bloqueioEnv = true;
            } else
            {
                pb_jogar.Image = Super_Trunfo_Cliente.Properties.Resources.Jogada;
                bloqueioEnv = false;
            }
        }

        private void mudaCarta()
        {
            object img1;
            img1 = Super_Trunfo_Cliente.Properties.Resources.ResourceManager.GetObject(cartas[posicao].cod_Carta);
            pb_selfcard.Image = img1 as Image;
            img1 = null;

            l_cod_01.Text = "Código: " + cartas[posicao].cod_Carta;
            l_nome_01.Text = "Nome: " + cartas[posicao].nome;
            l_tipo_01.Text = "Tipo: " + cartas[posicao].tipo;
            l_altura_01.Text = "Altura: " + System.Convert.ToString(cartas[posicao].altura);
            l_comprimento_01.Text = "Comprimento: " + System.Convert.ToString(cartas[posicao].comprimento);
            l_peso_01.Text = "Peso: " + System.Convert.ToString(cartas[posicao].peso);
            l_idade_01.Text = "Idade: " + System.Convert.ToString(cartas[posicao].idade);

            if (posicao == 0)
            {
                pb_jogar.Image = Super_Trunfo_Cliente.Properties.Resources.Jogada_cinza;
                bloqueioEnv = true;
            }
            else
            {
                pb_jogar.Image = Super_Trunfo_Cliente.Properties.Resources.Jogada;
                bloqueioEnv = false;
            }
        }

        private void mudaCartaVencedor(int pos)
        {
            object img1;
            img1 = Super_Trunfo_Cliente.Properties.Resources.ResourceManager.GetObject(cartas[pos].cod_Carta);
            pb_otherCard.Image = img1 as Image;
            img1 = null;

            l_cod_02.Text = "Código: " + cartas[pos].cod_Carta;
            l_nome_02.Text = "Nome: " + cartas[pos].nome;
            l_tipo_02.Text = "Tipo: " + cartas[pos].tipo;
            l_altura_02.Text = "Altura: " + System.Convert.ToString(cartas[pos].altura);
            l_comprimento_02.Text = "Comprimento: " + System.Convert.ToString(cartas[pos].comprimento);
            l_peso_02.Text = "Peso: " + System.Convert.ToString(cartas[pos].peso);
            l_idade_02.Text = "Idade: " + System.Convert.ToString(cartas[pos].idade);
        }

        private void pb_setaEsquerda_MouseDown(object sender, MouseEventArgs e)
        {
            if (status_servico)
            {
                pb_setaEsquerda.Image = Super_Trunfo_Cliente.Properties.Resources.Esquerda_Rosa;
            }
        }

        private void pb_setaEsquerda_MouseUp(object sender, MouseEventArgs e)
        {
            if (status_servico)
            {
                pb_setaEsquerda.Image = Super_Trunfo_Cliente.Properties.Resources.Esquerda_Verde;
            }
        }

        private void pb_setaDireita_MouseDown(object sender, MouseEventArgs e)
        {
            if (status_servico)
            {
                pb_setaDireita.Image = Super_Trunfo_Cliente.Properties.Resources.Direita_Rosa;
            }
        }

        private void pb_setaDireita_MouseUp(object sender, MouseEventArgs e)
        {
            if (status_servico)
            {
                pb_setaDireita.Image = Super_Trunfo_Cliente.Properties.Resources.Direita_Verde;
            }
        }

        private void pb_setaEsquerda_Click(object sender, EventArgs e)
        {
            if (status_servico)
            {
                mudaCarta('D');
            }
        }

        private void pb_setaDireita_Click(object sender, EventArgs e)
        {
            if (status_servico)
            {
                mudaCarta('S');
            }
        }

        private void pb_start_stop_Click(object sender, EventArgs e)
        {
            mudaStatusServidor();
        }

        private void mudaStatusServidor()
        {
            string ip;
            TelaConexao tela_conex;
            this.primeiraJogada = false;

            if (status_servico)
            {
                timer1.Enabled = false;
                cliente.conectaServ(false, "");
                status_servico = false;
                pb_setaDireita.Image = Super_Trunfo_Cliente.Properties.Resources.Direita_Cinza;
                pb_setaEsquerda.Image = Super_Trunfo_Cliente.Properties.Resources.Esquerda_Cinza;
                pb_jogar.Image = Super_Trunfo_Cliente.Properties.Resources.Jogada_cinza;
                pb_start_stop.Image = Super_Trunfo_Cliente.Properties.Resources.start;
                pb_semaforo.Image = Super_Trunfo_Cliente.Properties.Resources.Semaforo_desligado;
                toolStripStatusLabel4.Text = "ID:  ";
                toolStripStatusLabel5.Text = "Jogadores: ";
                toolStripStatusLabel6.Text = "Cartas: ";
                toolStripStatusLabel7.Text = "Status: Desconectado";
                posicao = 0;
                mudaCarta();
                mudaCartaVencedor(0);
            }
            else
            {
                tela_conex = new TelaConexao();
                if (tela_conex.ShowDialog(this) == DialogResult.OK)
                {
                    ip = tela_conex.IP;
                    if (tela_conex.local)
                    {
                        if (!threadServidor.IsAlive)
                        {
                            threadServidor.Start();
                        }
                    }
                    if (cliente.conectaServ(true, ip))
                    {
                        status_servico = true;
                        pb_setaDireita.Image = Super_Trunfo_Cliente.Properties.Resources.Direita_Verde;
                        pb_setaEsquerda.Image = Super_Trunfo_Cliente.Properties.Resources.Esquerda_Verde;
                        if (!bloqueioEnv)
                        {
                            pb_jogar.Image = Super_Trunfo_Cliente.Properties.Resources.Jogada;
                        }
                        pb_start_stop.Image = Super_Trunfo_Cliente.Properties.Resources.stop;
                        setID(cliente.ID);
                        toolStripStatusLabel7.Text = "Status: Conectado";
                        buscarBarralho();
                    }
                    else
                    {
                        status_servico = false;
                        pb_setaDireita.Image = Super_Trunfo_Cliente.Properties.Resources.Direita_Cinza;
                        pb_setaEsquerda.Image = Super_Trunfo_Cliente.Properties.Resources.Esquerda_Cinza;
                        pb_jogar.Image = Super_Trunfo_Cliente.Properties.Resources.Jogada_cinza;
                        pb_start_stop.Image = Super_Trunfo_Cliente.Properties.Resources.start;
                        pb_semaforo.Image = Super_Trunfo_Cliente.Properties.Resources.Semaforo_desligado;
                        toolStripStatusLabel4.Text = "ID:  ";
                        toolStripStatusLabel5.Text = "Jogadores: ";
                        toolStripStatusLabel6.Text = "Cartas: ";
                        toolStripStatusLabel7.Text = "Status: Desconectado";
                        posicao = 0;
                        mudaCarta();
                        mudaCartaVencedor(0);
                    }
                }
            }
            quantidadeCartas();
        }

        private void buscarBarralho()
        {
            Itens_Compartilhados.RetornoJogada embaralhado = new Itens_Compartilhados.RetornoJogada();
            embaralhado = cliente.buscarBarralho();

            for (int i = 0; i < embaralhado.jogadores.Length; i++)
            {
                if (embaralhado.jogadores[i].ID == cliente.ID)
                {
                    for (int j = 1; j < cartas.Length; j++)
                    {
                        if (embaralhado.jogadores[i].cartas[j].ativo)
                        {
                            cartas[j].ativo = true;
                        } else
                        {
                            cartas[j].ativo = false;
                        }
                    }
                }
            }
            
            timer1.Enabled = true;
        }

        private void quantidadeCartas()
        {
            int qtd = 0;
            for (int i = 1; i < cartas.Length; i++)
            {
                if (cartas[i].ativo)
                {
                    qtd++;
                }
            }
            if (status_servico)
            {
                toolStripStatusLabel6.Text = "Cartas: " + Convert.ToString(qtd);
            }
        }

        private void setID(int id)
        {
            for (int i = 0; i < cartas.Length; i++)
            {
                cartas[i].ID = id;
            }
            toolStripStatusLabel4.Text = "ID: " + Convert.ToString(id);
        }
        private void pb_jogar_Click(object sender, EventArgs e)
        {
            if (status_servico && !bloqueioEnv)
            {
                timer1.Enabled = false;
                jogar();
                timer1.Enabled = true;
            }
        }

        private void jogar()
        {
            Itens_Compartilhados.RetornoJogada jogada = new Itens_Compartilhados.RetornoJogada();
            String atributo_teste;
            atributo_teste = "";
            pb_jogar.Image = Super_Trunfo_Cliente.Properties.Resources.Espera;
            pb_jogar.Refresh();
            this.primeiraJogada = true;

            if (rb_altura.Checked)
            {
                atributo_teste = "altura";
            }
            if (rb_comprimento.Checked)
            {
                atributo_teste = "comprimento";
            }
            if (rb_peso.Checked)
            {
                atributo_teste = "peso";
            }
            if (rb_idade.Checked)
            {
                atributo_teste = "idade";
            }

            cartas[posicao].atributo_teste = atributo_teste;

            jogada = cliente.jogada(cartas[posicao]);

            if (jogada.vencedor == cliente.ID)
            {
                for (int i = 0; i < jogada.cartasJogadas.Length; i++)
                {
                    cartas[funcoes.retornoPosCarta(jogada.cartasJogadas[i].cod_Carta)].ativo = true;
                }

                pb_ganhou.Visible = true;

            } else
            {
                cartas[posicao].ativo = false;
                posicao = 0;
                mudaCarta();
                pb_perdeu.Visible= true;
            }
            
            quantidadeCartas();
            mudaCartaVencedor(funcoes.retornoPosCarta(jogada.cartaVencedora.cod_Carta));
            pb_jogar.Image = Super_Trunfo_Cliente.Properties.Resources.Jogada;
            pb_jogar.Refresh();
            timer2.Enabled = true;         
        }

        private void Tela_FormClosing(object sender, FormClosingEventArgs e)
        {
            cliente.conectaServ(false, "");
            if (threadServidor.IsAlive)
            {
                threadServidor.Abort();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Itens_Compartilhados.RetornoJogada status = new Itens_Compartilhados.RetornoJogada();
            int provaReal = 0;
            int qtdCartas = 0;
            status = cliente.verificaStatus(atrib());
            toolStripStatusLabel5.Text = "Jogadores: " + status.qtdJogadores.ToString();
            setAtrib(status.jogadorDaVez, status.atributoDaVez, status.jogadorDaVezJogou);

            for (int i = 1; i < cartas.Length; i++)
            {
                if (cartas[i].ativo)
                {
                    qtdCartas++;
                }
            }

            if (qtdCartas <= 0)
            {
                cliente.perder();
                mudaStatusServidor();
                perder();
            }
            else {

                if (!this.primeiraJogada)
                {
                    for (int i = 0; i < status.jogadores.Length; i++)
                    {
                        if (status.jogadores[i].ID == cliente.ID)
                        {
                            for (int j = 1; j < cartas.Length; j++)
                            {
                                if (status.jogadores[i].cartas[j].ativo)
                                {
                                    cartas[j].ativo = true;
                                }
                                else
                                {
                                    cartas[j].ativo = false;
                                }
                            }
                        }
                    }
                }
            }
            quantidadeCartas();

            for (int i = 0; i < status.jogadores.Length; i++)
            {
                if ((status.jogadores[i].conectado) && (status.jogadores[i].jogando))
                {
                    provaReal++;
                }
            }

            if (provaReal < status.qtdJogadores)
            {
                mudaStatusServidor();
            }

            if (status.qtdJogadores == 1)
            {
                mudaStatusServidor();
                ganhar();
            }

        }

        private void setAtrib(int jogador, String atributo, Boolean jogou)
        {
            if (jogador == cliente.ID)
            {
                rb_altura.Enabled = true;
                rb_comprimento.Enabled = true;
                rb_peso.Enabled = true;
                rb_idade.Enabled = true;
                if (!jogou)
                {
                    pb_semaforo.Image = Super_Trunfo_Cliente.Properties.Resources.Semaforo_Amarelo;
                }
                else
                {
                    pb_semaforo.Image = Super_Trunfo_Cliente.Properties.Resources.Semaforo_Verde;
                }
            } else
            {
                rb_altura.Enabled = false;
                rb_comprimento.Enabled = false;
                rb_peso.Enabled = false;
                rb_idade.Enabled = false;

                if (!jogou)
                {
                    pb_semaforo.Image = Super_Trunfo_Cliente.Properties.Resources.Semaforo_Vermelho;
                } else
                {
                    pb_semaforo.Image = Super_Trunfo_Cliente.Properties.Resources.Semaforo_Verde;
                }

                switch (atributo)
                {
                    case "altura":
                        rb_altura.Checked = true;
                        break;
                    case "comprimento":
                        rb_comprimento.Checked = true;
                        break;
                    case "peso":
                        rb_peso.Checked = true;
                        break;
                    case "idade":
                        rb_idade.Checked = true;
                        break;
                }
            }            
        }

        private String atrib()
        {
            string retorno = string.Empty;

            if (rb_altura.Checked)
            {
                retorno = "altura";
            }
            if (rb_comprimento.Checked)
            {
                retorno = "comprimento";
            }
            if (rb_peso.Checked)
            {
                retorno = "peso";
            }
            if (rb_idade.Checked)
            {
                retorno = "idade";
            }

            return retorno;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pb_ganhou.Visible = false;
            pb_perdeu.Visible = false;
            timer2.Enabled = false;
        }
        
        private void perder()
        {
            pb_final.Image = Super_Trunfo_Cliente.Properties.Resources.perdedor_02;
            pb_final.Enabled = true;
            pb_final.Visible = true;
            pb_final.Refresh();
            Thread.Sleep(3500);
            pb_final.Image = Super_Trunfo_Cliente.Properties.Resources.perdedor_01;
            pb_final.Refresh();
            timer3.Enabled = true;
        }   
        
        private void ganhar()
        {
            pb_final.Image = Super_Trunfo_Cliente.Properties.Resources.ganhador_01;
            pb_final.Enabled = true;
            pb_final.Visible = true;
            pb_final.Refresh();
            Thread.Sleep(3500);
            pb_final.Image = Super_Trunfo_Cliente.Properties.Resources.ganhador_02;
            pb_final.Refresh();
            timer3.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            pb_final.Enabled = false;
            pb_final.Visible = false;
            timer3.Enabled = false;
        }
    }
}