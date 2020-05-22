using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Threading;

namespace Super_Trunfo_Cliente
{
    class Cliente
    {
        private int porta = 1702;
        private int ipCount = 0;
        private String[] ipArray;
        private Itens_Compartilhados.Funcoes funcoes;
        public Socket socketClient { get; set; }
        public int ID;

        public Cliente()
        {
            this.socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.funcoes = new Itens_Compartilhados.Funcoes();
            this.ipArray = new String[256];
            this.ID = -1;
        }

        private void TryConnect(String ip)
        {
            int tentativas = 0;
            while ((!socketClient.Connected) && (tentativas < 5))
            {
                try
                {
                    socketClient.Connect(IPAddress.Parse(ip), porta);
                    byte[] buff = new byte[256];
                    int received = socketClient.Receive(buff);
                    byte[] dataReceived = new byte[received];
                    Array.Copy(buff, dataReceived, received);
                    string text = Encoding.UTF8.GetString(dataReceived);
                    this.ID = Convert.ToInt32(text);
                }
                catch(SocketException)
                {
                    tentativas++;
                }
            }            
        }

        private void TrySend(byte[] dados)
        {
            try
            {
                socketClient.Send(dados);
            }
            catch (SocketException)
            {
                return;
            }
        }
        public Boolean conectaServ(Boolean status, String ip)
        {
            try
            {
                if (status)
                {
                    TryConnect(ip);
                    if (socketClient.Connected)
                    {
                        CargaJogadores carregaJogadores = new CargaJogadores(socketClient, ID);
                        carregaJogadores.ShowDialog();
                        if (carregaJogadores.DialogResult == DialogResult.OK)
                        {
                            this.embaralhar();
                            return true;
                        } else
                        {
                            Itens_Compartilhados.Comandos comando = new Itens_Compartilhados.Comandos();
                            comando.comando = "DESCONECTAR";
                            byte[] desconectar = this.funcoes.ObjectToByteArray(comando);
                            TrySend(desconectar);
                            socketClient.Close();
                            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            if (socketClient.Connected)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (socketClient.Connected)
                    {
                        Itens_Compartilhados.Comandos comando = new Itens_Compartilhados.Comandos();
                        comando.comando = "DESCONECTAR";
                        byte[] desconectar = this.funcoes.ObjectToByteArray(comando);
                        TrySend(desconectar);
                        socketClient.Close();
                        socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    }
                    if (socketClient.Connected)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public Itens_Compartilhados.RetornoJogada jogada(Itens_Compartilhados.Carta cartaEnv)
        {
            Itens_Compartilhados.Comandos comando = new Itens_Compartilhados.Comandos();
            comando.comando = "JOGADA";
            comando.carta = cartaEnv;
            comando.ID = this.ID;
            byte[] jogada = this.funcoes.ObjectToByteArray(comando);
            TrySend(jogada);
            byte[] buff = new byte[32768];
            int received = socketClient.Receive(buff);
            byte[] dataReceived = new byte[received];
            Array.Copy(buff, dataReceived, received);
            Itens_Compartilhados.RetornoJogada retornoJogada = new Itens_Compartilhados.RetornoJogada();
            retornoJogada = (Itens_Compartilhados.RetornoJogada)funcoes.ByteArrayToObject(buff);
            return retornoJogada;
        }
        public Itens_Compartilhados.RetornoJogada buscarBarralho()
        {
            Itens_Compartilhados.Comandos comando = new Itens_Compartilhados.Comandos();
            comando.comando = "BUSCAR_BARALHO";
            byte[] baralho = this.funcoes.ObjectToByteArray(comando);
            TrySend(baralho);
            byte[] buff = new byte[32768];
            int received = socketClient.Receive(buff);
            byte[] dataReceived = new byte[received];
            Array.Copy(buff, dataReceived, received);
            Itens_Compartilhados.RetornoJogada retornoJogada = new Itens_Compartilhados.RetornoJogada();
            retornoJogada = (Itens_Compartilhados.RetornoJogada)funcoes.ByteArrayToObject(dataReceived);
            return retornoJogada;
        }

        private void embaralhar()
        {
            Itens_Compartilhados.Comandos comando = new Itens_Compartilhados.Comandos();
            comando.comando = "EMBARALHAR";
            byte[] baralho = this.funcoes.ObjectToByteArray(comando);
            TrySend(baralho);
        }

        public void perder()
        {
            Itens_Compartilhados.Comandos comando = new Itens_Compartilhados.Comandos();
            comando.comando = "PERDER";
            comando.ID = this.ID;
            byte[] perder = this.funcoes.ObjectToByteArray(comando);
            TrySend(perder);
        }
        public String[] buscaServer()
        {         
            string faixaIP = "";
            string ipLocal = Dns.GetHostName();
            IPAddress[] ip = Dns.GetHostAddresses(ipLocal);
            ipLocal = ip[1].ToString();
            faixaIP = funcoes.retornaFaixaIP(ipLocal);

            for (int i = 0; i < 255; i++)
            {
                this.ipArray[i] = "";
                new Thread(()=>testaServer(faixaIP, i)).Start();
            }

            while (ipCount < 255)
            {
                Thread.Sleep(100);
            }

            return ipArray;
        }

        private void testaServer(string faixaIP, int i)
        {
            string retorno = "";
            string ip = faixaIP + i.ToString();
            Socket socketClientLocal = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            int tentativas = 0;
            while ((!socketClientLocal.Connected) && (tentativas < 2))
            {
                try
                {
                    socketClientLocal.Connect(IPAddress.Parse(ip), porta);
                    byte[] buff = new byte[256];
                    int received = socketClientLocal.Receive(buff);
                    byte[] dataReceived = new byte[received];
                    Array.Copy(buff, dataReceived, received);
                    string text = Encoding.UTF8.GetString(dataReceived);
                }
                catch (SocketException)
                {
                    tentativas++;
                }
            }

            if (socketClientLocal.Connected)
            {
                retorno = ip;
                Itens_Compartilhados.Comandos comando = new Itens_Compartilhados.Comandos();
                comando.comando = "DESCONECTAR";
                byte[] desconectar = this.funcoes.ObjectToByteArray(comando);
                socketClientLocal.Send(desconectar);
            }
            socketClientLocal.Close();
            lock(this)
            {
                ipCount++;
            }
            this.ipArray[i] = retorno;
        }

        public Itens_Compartilhados.RetornoJogada verificaStatus(String atrib)
        {
            Itens_Compartilhados.Comandos comando = new Itens_Compartilhados.Comandos();
            comando.comando = "STATUS_JOGADORES_ATRIBUTO";
            comando.atributo = atrib;
            comando.ID = this.ID;
            byte[] envioStatusJogador = this.funcoes.ObjectToByteArray(comando);
            socketClient.Send(envioStatusJogador);
            byte[] buff = new byte[32768];
            int received = socketClient.Receive(buff);
            byte[] dataReceived = new byte[received];
            Array.Copy(buff, dataReceived, received);
            Itens_Compartilhados.RetornoJogada retornoJogada = new Itens_Compartilhados.RetornoJogada();
            retornoJogada = (Itens_Compartilhados.RetornoJogada)funcoes.ByteArrayToObject(buff);            
            return retornoJogada;
        }        
    }
}