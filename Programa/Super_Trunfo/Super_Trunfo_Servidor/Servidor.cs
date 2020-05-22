using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Super_Trunfo_Servidor
{
    public class Servidor
    {
        public Boolean ativo;
        private Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private List<Socket> ListaDeClientesSockets = new List<Socket>();   /*Lista de sockets para adicionar clientes*/
        private const int _BUFFER_SIZE = 32768;
        private int _PORT;
        private string Ip;
        private byte[] _buffer = new byte[_BUFFER_SIZE];
        private Itens_Compartilhados.Funcoes funcoes;
        private Jogo jogo = new Jogo();


        public Servidor(string IP, int port)  /*Construtor para inicialização do IP e da Porta*/
        {
            ativo = true;
            this.Ip = IP;
            this._PORT = port;
            funcoes = new Itens_Compartilhados.Funcoes();
        }
        public void Connect()
        {
            try {
                Console.WriteLine("Servidor Socket ON");
                _serverSocket.Bind(new IPEndPoint(IPAddress.Any, _PORT));
                _serverSocket.Listen(8);
                _serverSocket.BeginAccept(AcceptCallback, null);
            }catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void Send(byte[] dados)
        {
            try {
                foreach (Socket socket in ListaDeClientesSockets)
                {
                    socket.Send(dados);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void FecharConexaoSocket()
        {
            try { 
                foreach (Socket socket in ListaDeClientesSockets)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }

                _serverSocket.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);

            }
        }

        /// <summary>AcceptCallback método da classe Server
        /// Evento realizado para aceitar conexões dos clientes adicionando em uma lista genérica
        /// /// </summary>

        private void AcceptCallback(IAsyncResult asyncronousResult)
        {
            Socket socket;

            try
            {
                if (ListaDeClientesSockets.Count <= 8)
                {
                    socket = _serverSocket.EndAccept(asyncronousResult);

                    ListaDeClientesSockets.Add(socket);
                    socket.BeginReceive(_buffer, 0, _BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
                    Console.WriteLine("Cliente Conectado " + socket.RemoteEndPoint.ToString());
                    _serverSocket.BeginAccept(AcceptCallback, null);
                    string idCorr = funcoes.idSocket(socket.RemoteEndPoint.ToString());
                    byte[] data = Encoding.UTF8.GetBytes(idCorr);
                    socket.Send(data);
                    jogo.insereJogador(socket.RemoteEndPoint.ToString());

                }
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            catch (Exception)
            {
                return;
            }
        }

        /// <summary>ReceiveCallBack método da classe Server
        /// Evento realizado para receber e enviar dados do cliente através de um IASyncResult
        /// </summary>

        private void ReceiveCallback(IAsyncResult asyncronousResult)
        {
            Socket current = (Socket)asyncronousResult.AsyncState;
            int received;

            try
            {
                received = current.EndReceive(asyncronousResult);
            }
            catch (SocketException) /*Catch realizado caso houver perca de conexão com o cliente*/
            {
                Console.WriteLine("Conexão com o cliente " + current.RemoteEndPoint.ToString() + " perdida.");
                jogo.removeJogador(current.RemoteEndPoint.ToString());
                current.Close();
                ListaDeClientesSockets.Remove(current);
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(_buffer, recBuf, received);
            Itens_Compartilhados.Comandos comando = new Itens_Compartilhados.Comandos();
            comando = (Itens_Compartilhados.Comandos)funcoes.ByteArrayToObject(recBuf);
            if (comando.comando == "JOGADA")
            {
                int primeiro;
                if (comando.ID == jogo.jogadorDaVez)
                {
                    jogo.jogadorDaVezJogou = true;
                }
                funcoes.escreveInfoCarta(comando.carta);
                jogo.jogadoresEmEspera++;
                primeiro = jogo.jogadoresEmEspera;
                jogo.jogadaEmEspera[jogo.jogadoresEmEspera] = comando.carta;
                if (primeiro == 0)
                {
                    while (jogo.qtdJogadores > (jogo.jogadoresEmEspera + 1)) ;
                    Itens_Compartilhados.RetornoJogada retornoJogada = new Itens_Compartilhados.RetornoJogada();
                    retornoJogada = jogo.jogada();
                    byte[] envioRetornoJogada = this.funcoes.ObjectToByteArray(retornoJogada);
                    Send(envioRetornoJogada);
                    jogo.resetJogada();
                } else
                {
                    while (jogo.jogadoresEmEspera > -1) ;
                }
            }
            else if (comando.comando == "DESCONECTAR")
            {
                jogo.removeJogador(current.RemoteEndPoint.ToString());
                current.Shutdown(SocketShutdown.Both);
                current.Close();
                ListaDeClientesSockets.Remove(current);
                Console.WriteLine("Cliente Desconectado ");
                jogo.resetBarralho();
                return;
            }
            else if (comando.comando == "STATUS_JOGADORES")
            {
                Itens_Compartilhados.RetornoJogada statusJogadores = new Itens_Compartilhados.RetornoJogada();
                statusJogadores = jogo.statusJogadores();
                statusJogadores.embaralhado = jogo.isEmbaralhado;
                byte[] envioStatusJogadores = this.funcoes.ObjectToByteArray(statusJogadores);
                current.Send(envioStatusJogadores);
            }
            else if (comando.comando == "STATUS_JOGADORES_ATRIBUTO")
            {
                Itens_Compartilhados.RetornoJogada statusJogadores = new Itens_Compartilhados.RetornoJogada();
                statusJogadores = jogo.statusJogadores();
                statusJogadores.jogadorDaVezJogou = jogo.jogadorDaVezJogou;
                if (comando.ID == jogo.jogadorDaVez)
                {
                    jogo.atributoDaVez = comando.atributo;
                }
                byte[] envioStatusJogadores = this.funcoes.ObjectToByteArray(statusJogadores);
                current.Send(envioStatusJogadores);
            }
            else if (comando.comando == "EMBARALHAR")
            {
                int primeiro;
                jogo.jogadoresEmEspera++;
                primeiro = jogo.jogadoresEmEspera;
                if (primeiro == 0)
                {
                    jogo.embaralhar();
                    while (!jogo.isEmbaralhado);  
                }
                jogo.resetJogada();
            }
            else if (comando.comando == "BUSCAR_BARALHO")
            {
                Itens_Compartilhados.RetornoJogada barralho = new Itens_Compartilhados.RetornoJogada();
                barralho = jogo.embaralhado;
                byte[] envioBarralho = this.funcoes.ObjectToByteArray(barralho);
                current.Send(envioBarralho);
            }
            else if (comando.comando == "JOGAR")
            {
                jogo.setJogar(comando.jogadores[0]);
            }
            else if (comando.comando == "PERDER")
            {
                for (int i = 0; i < jogo.jogadores.Length; i++)
                {
                    if (jogo.jogadores[i].ID == comando.ID)
                    {
                        jogo.jogadores[i].jogando = false;
                        jogo.qtdJogadores--;
                        if (jogo.jogadorDaVez == comando.ID)
                        {
                            jogo.reJogador();
                        }
                        Thread.Sleep(550);
                    }
                }
            }

            current.BeginReceive(_buffer, 0, _BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
        }
    }
}