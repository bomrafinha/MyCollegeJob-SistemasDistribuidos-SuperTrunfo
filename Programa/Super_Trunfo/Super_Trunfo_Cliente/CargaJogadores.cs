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
using System.Net.Sockets;
using System.Net;

namespace Super_Trunfo_Cliente
{
    public partial class CargaJogadores : Form
    {
        private Socket socket;
        private int ID;
        private Itens_Compartilhados.Funcoes funcoes;
        public CargaJogadores(Socket socket, int id)
        {
            InitializeComponent();
            funcoes = new Itens_Compartilhados.Funcoes();
            this.ID = id;
            this.socket = socket;
            b_jogar.Enabled = false;
            iniciaLista();
        }

        private void iniciaLista()
        {
            ListViewItem item = new ListViewItem("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            listView1.Items.Add(item);

            item = new ListViewItem("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            listView1.Items.Add(item);

            item = new ListViewItem("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            listView1.Items.Add(item);

            item = new ListViewItem("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            listView1.Items.Add(item);

            item = new ListViewItem("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            listView1.Items.Add(item);

            item = new ListViewItem("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            listView1.Items.Add(item);

            item = new ListViewItem("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            listView1.Items.Add(item);

            item = new ListViewItem("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            listView1.Items.Add(item);

            timer1.Enabled = true;
        }

        private void limpaLista()
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].SubItems[0].Text = "";
                listView1.Items[i].SubItems[1].Text = "";
                listView1.Items[i].SubItems[2].Text = "";
                listView1.Items[i].Checked = false;
            }
            listView1.Refresh();
        }

        private void verificaStatus()
        {
            Itens_Compartilhados.Comandos comando = new Itens_Compartilhados.Comandos();
            comando.comando = "STATUS_JOGADORES";
            byte[] envioStatusJogador = this.funcoes.ObjectToByteArray(comando);
            socket.Send(envioStatusJogador);
            byte[] buff = new byte[32768];
            int received = socket.Receive(buff);
            byte[] dataReceived = new byte[received];
            Array.Copy(buff, dataReceived, received);
            Itens_Compartilhados.RetornoJogada retornoJogada = new Itens_Compartilhados.RetornoJogada();
            retornoJogada = (Itens_Compartilhados.RetornoJogada)funcoes.ByteArrayToObject(buff);
            refreshLista(retornoJogada.jogadores, retornoJogada.embaralhado);
            iniciaJogo(retornoJogada.jogadores);
        }

        private void refreshLista(Itens_Compartilhados.Jogador[] jogadores, Boolean embaralhado)
        {
            int count = 0;
            Boolean existe = false;

            limpaLista();
            for (int i = 0; i < jogadores.Length; i++)
            {
                if (jogadores[i].conectado)
                {
                    listView1.Items[count].SubItems[0].Text = jogadores[i].ID.ToString();
                    listView1.Items[count].SubItems[1].Text = jogadores[i].ip.ToString();
                    if (jogadores[i].jogando)
                    {
                        listView1.Items[count].SubItems[2].Text = "Jogando.";
                        if (jogadores[i].ID == this.ID)
                        {
                            b_jogar.Text = "Esperar";
                        }
                    }
                    else
                    {
                        listView1.Items[count].SubItems[2].Text = "Esperando ...";
                        if (jogadores[i].ID == this.ID)
                        {
                            b_jogar.Text = "Jogar";
                        }
                    }
                    if (jogadores[i].ID == this.ID)
                    {
                        listView1.Items[count].Checked = true;
                        existe = true;
                    }
                    count++;
                }
            }
            listView1.Refresh();

            if (!existe)
            {
                timer1.Enabled = false;
                this.Close();
                return;
            }

            if ((count >= 2) && (!embaralhado))
            {
                b_jogar.Enabled = true;
            } else
            {
                b_jogar.Enabled = false;
            }

            if (embaralhado)
            {
                l_prox.Visible = true;
            }
            else
            {
                l_prox.Visible = false;
            }

        }

        private void iniciaJogo(Itens_Compartilhados.Jogador[] jogadores)
        {
            int conectados = 0;
            int jogando = 0;
            for (int i = 0; i < jogadores.Length; i++)
            {
                if (jogadores[i].conectado)
                {
                    conectados++;
                }

                if (jogadores[i].jogando)
                {
                    jogando++;
                }
            }
            if (conectados == jogando)
            {
                terminar();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            verificaStatus();
        }

        private void b_jogar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Itens_Compartilhados.Comandos comando = new Itens_Compartilhados.Comandos();
            comando.comando = "JOGAR";
            string id = funcoes.idSocket(socket.RemoteEndPoint.ToString());
            int idInt = Convert.ToInt32(id);
            comando.jogadores[0].ID = this.ID;
            byte[] jogar = this.funcoes.ObjectToByteArray(comando);
            socket.Send(jogar);
            timer1.Enabled = true;
        }

        private void b_cancelar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
        }

        private void terminar()
        {
            timer1.Enabled = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
