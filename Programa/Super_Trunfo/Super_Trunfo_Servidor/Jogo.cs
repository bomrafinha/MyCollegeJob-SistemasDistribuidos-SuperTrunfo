using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Trunfo_Servidor
{
    public class Jogo
    {
        public int qtdJogadores { get; set; }
        public int jogadoresEmEspera { get; set; }
        public Boolean isEmbaralhado { get; set; }
        public int jogadorDaVez { get; set; }
        public Boolean jogadorDaVezJogou { get; set; }
        public String atributoDaVez { get; set; }
        public Itens_Compartilhados.Carta[] jogadaEmEspera { get; set; }
        public Itens_Compartilhados.Jogador[] jogadores { get; set; }
        public Itens_Compartilhados.RetornoJogada embaralhado { get; set; }
        private Itens_Compartilhados.RetornoJogada retornoJogada { get; set; }

        private Itens_Compartilhados.Funcoes funcoes = new Itens_Compartilhados.Funcoes();

        public Jogo()
        {
            this.jogadores = new Itens_Compartilhados.Jogador[8];
            this.jogadaEmEspera = new Itens_Compartilhados.Carta[8];
            this.retornoJogada = new Itens_Compartilhados.RetornoJogada();
            this.embaralhado = new Itens_Compartilhados.RetornoJogada();
            this.qtdJogadores = 0;
            this.jogadoresEmEspera = 0;
            this.isEmbaralhado = false;
            this.jogadorDaVez = -1;
            this.jogadorDaVezJogou = false;
            this.atributoDaVez = "altura";

            for (int i = 0; i < this.jogadores.Length; i++)
            {
                this.jogadores[i] = new Itens_Compartilhados.Jogador(i);
            }

            for (int i = 0; i < this.jogadaEmEspera.Length; i++)
            {
                this.jogadaEmEspera[i] = new Itens_Compartilhados.Carta();
                this.jogadaEmEspera[i].ativo = false;
            }
        }
        
        public void embaralhar()
        {
            if (!this.isEmbaralhado)
            {
                int jogadoresAtivos = 0;

                this.embaralhado.vencedor = -1;
                this.embaralhado.cartasJogadas = null;
                this.embaralhado.cartaVencedora = null;

                for (int i = 0; i < this.jogadores.Length; i++)
                {
                    if (this.jogadores[i].conectado && this.jogadores[i].jogando)
                    {
                        jogadoresAtivos++;
                    }
                }

                this.qtdJogadores = jogadoresAtivos;
                this.embaralhado.qtdJogadores = jogadoresAtivos;
                this.jogadores = embaralhar(jogadoresAtivos);
                this.embaralhado.jogadores = this.jogadores;
                this.isEmbaralhado = true;
            }
        }

        private Itens_Compartilhados.Jogador[] embaralhar(int qtd)
        {
            int cartasCada = 32 / qtd;
            int cartasExtra = 32 % qtd;
            int numero;
            Boolean OK;
            Itens_Compartilhados.Jogador[] jogs = new Itens_Compartilhados.Jogador[8];
            Itens_Compartilhados.Carta[] cartas = new Itens_Compartilhados.Carta[33];
            jogs = this.jogadores;
            Random rnd = new Random();
            resetJogada();
            for (int i = 0; i < jogs.Length; i++)
            {
                for (int j = 0; j < jogs[i].cartas.Length; j++)
                {
                    jogs[i].cartas[j].ativo = false;
                    this.jogadores[i].cartas[j].ativo = false;
                }
            }
            if (!this.isEmbaralhado)
            {
                for (int i = 0; i < cartas.Length; i++)
                {
                    cartas[i] = new Itens_Compartilhados.Carta();
                    cartas[i].ativo = false;
                }

                for (int i = 0; i < jogs.Length; i++)
                {
                    if (jogs[i].conectado && jogs[i].jogando)
                    {
                        for (int j = 0; j < cartasCada; j++)
                        {
                            OK = false;
                            while (!OK)
                            {
                                numero = rnd.Next(1, 33);
                                if (!cartas[numero].ativo)
                                {
                                    jogs[i].cartas[numero].ativo = true;
                                    cartas[numero].ativo = true;
                                    OK = true;
                                }
                            }
                        }
                    }
                }

                if (cartasExtra > 0)
                {
                    List<int> lista = new List<int>();
                    lista.Clear();

                    for (int i = 0; i < cartasExtra; i++)
                    {
                        OK = false;

                        while (!OK)
                        {
                            numero = rnd.Next(0, jogs.Length - 1);
                            if (!lista.Contains(numero))
                            {
                                if (jogs[numero].conectado && jogs[numero].jogando)
                                {
                                    for (int j = 1; j < cartas.Length; j++)
                                    {
                                        if (!cartas[j].ativo)
                                        {
                                            jogs[numero].cartas[j].ativo = true;
                                            cartas[j].ativo = true;
                                            break;
                                        }
                                    }
                                    lista.Add(numero);
                                    OK = true;
                                }
                            }
                        }
                    }
                    lista.Clear();
                }
            }
            primeiroJogador();
            return jogs;
        }

        public Itens_Compartilhados.RetornoJogada jogada()
        {
            retornoJogada.qtdJogadores = this.qtdJogadores;
            retornoJogada.jogadores = this.jogadores;
            retornoJogada.cartasJogadas = jogadaEmEspera;
            int qtdJogada = 0;
            String trunfo = string.Empty;

            for (int i = 0; i < jogadaEmEspera.Length; i++)
            {
                if (jogadaEmEspera[i].ativo)
                {
                    qtdJogada++;
                    if (jogadaEmEspera[i].trunfo)
                    {
                        trunfo = jogadaEmEspera[i].cod_Carta;
                    }
                }
            }

            Itens_Compartilhados.Carta[] listaCartas = new Itens_Compartilhados.Carta[qtdJogada];

            for (int i = 0; i < listaCartas.Length; i++)
            {
                listaCartas[i] = new Itens_Compartilhados.Carta();
            }

            for (int i = 0; i < jogadaEmEspera.Length; i++)
            {
                if (jogadaEmEspera[i].ativo)
                {
                    listaCartas[i] = jogadaEmEspera[i];
                }
            }

            if (string.IsNullOrEmpty(trunfo))
            {
                List<Itens_Compartilhados.Carta> listaOrdenada = null;

                switch (listaCartas[0].atributo_teste)
                {
                    case "altura":
                        listaOrdenada = new List<Itens_Compartilhados.Carta>(listaCartas.OrderByDescending(lista => lista.altura).ToList());
                        break;
                    case "comprimento":
                        listaOrdenada = new List<Itens_Compartilhados.Carta>(listaCartas.OrderByDescending(lista => lista.comprimento).ToList());
                        break;
                    case "peso":
                        listaOrdenada = new List<Itens_Compartilhados.Carta>(listaCartas.OrderByDescending(lista => lista.peso).ToList());
                        break;
                    case "idade":
                        listaOrdenada = new List<Itens_Compartilhados.Carta>(listaCartas.OrderByDescending(lista => lista.idade).ToList());
                        break;
                }

                for (int j = 0; j < jogadaEmEspera.Length; j++)
                {
                    if (listaOrdenada[0].cod_Carta == jogadaEmEspera[j].cod_Carta)
                    {
                        retornoJogada.cartaVencedora = jogadaEmEspera[j];
                        retornoJogada.vencedor = jogadaEmEspera[j].ID;
                        this.jogadorDaVez = jogadaEmEspera[j].ID;
                        break;
                    }
                }
            } else
            {
                for (int i = 0; i < jogadaEmEspera.Length; i++)
                {
                    if (jogadaEmEspera[i].cod_Carta == trunfo)
                    {
                        retornoJogada.cartaVencedora = jogadaEmEspera[i];
                        retornoJogada.vencedor = jogadaEmEspera[i].ID;
                        this.jogadorDaVez = jogadaEmEspera[i].ID;
                        break;
                    }
                }
            }     
            return retornoJogada;
        }

        private void primeiroJogador()
        {
            Random rnd = new Random();
            Boolean OK = false;
            int numero;
            while (!OK)
            {
                numero = rnd.Next(0, this.jogadores.Length - 1);
                if (this.jogadores[numero].conectado && this.jogadores[numero].jogando)
                {
                    jogadorDaVez = jogadores[numero].ID;
                    OK = true;
                }
            }
        }
        public void reJogador()
        {
            Random rnd = new Random();
            Boolean OK = false;
            int numero;
            while (!OK)
            {
                numero = rnd.Next(0, this.jogadores.Length - 1);
                if (this.jogadores[numero].conectado && this.jogadores[numero].jogando)
                {
                    jogadorDaVez = jogadores[numero].ID;
                    OK = true;
                }
            }
        }

        public void insereJogador(string endPoint)
        {
            Boolean inserido = false;
            int id = Convert.ToInt32(funcoes.idSocket(endPoint));
            string ip = endPoint.Replace(":" + id.ToString(), "");
            for (int i = 0; i < jogadores.Length; i++)
            {
                if (!inserido)
                {
                    if (!jogadores[i].conectado)
                    {
                        jogadores[i].ID = id;
                        jogadores[i].ip = ip;
                        jogadores[i].conectado = true;
                        inserido = true;
                    }
                }
            }
        }

        public void removeJogador(string endPoint)
        {
            int id = Convert.ToInt32(funcoes.idSocket(endPoint));
            Boolean removido = false; ;
            for (int i = 0; i < jogadores.Length; i++)
            {
                if (!removido)
                {
                    if (jogadores[i].ID == id)
                    {
                        jogadores[i].ID = i;
                        jogadores[i].conectado = false;
                        jogadores[i].jogando = false;
                        removido = true;
                    }
                }
            }
        }
        public Itens_Compartilhados.RetornoJogada statusJogadores()
        {
            Itens_Compartilhados.RetornoJogada status = new Itens_Compartilhados.RetornoJogada();
            status.jogadores = this.jogadores;
            status.qtdJogadores = this.qtdJogadores;
            status.jogadorDaVez = this.jogadorDaVez;
            status.atributoDaVez = this.atributoDaVez;
            return status;
        }

        public void setJogar(Itens_Compartilhados.Jogador jogador)
        {
            for (int i = 0; i < jogadores.Length; i++)
            {
                if (jogadores[i].ID == jogador.ID)
                {
                    if (jogadores[i].jogando)
                    {
                        jogadores[i].jogando = false;
                    }
                    else
                    {
                        jogadores[i].jogando = true;
                    }
                }
            }
        }

        public void resetJogada()
        {
            for (int i = 0; i < jogadaEmEspera.Length; i++)
            {
                jogadaEmEspera[i].ativo = false;
            }
            this.jogadoresEmEspera = -1;
            this.jogadorDaVezJogou = false;
        }

        public void resetBarralho()
        {
            for (int i = 0; i < embaralhado.jogadores.Length; i++)
            {
                for (int j = 0; j < embaralhado.jogadores[i].cartas.Length; j++)
                {
                    this.embaralhado.jogadores[i].cartas[j].ativo = false;
                }
            }
            this.isEmbaralhado = false;
            this.atributoDaVez = "altura";
            this.jogadorDaVez = -1;
            this.jogadorDaVezJogou = false;
        }
    }
}
