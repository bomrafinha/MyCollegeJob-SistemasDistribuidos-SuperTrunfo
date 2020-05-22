using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itens_Compartilhados
{
    [Serializable]
    public class RetornoJogada
    {
        public int vencedor { get; set; }
        public int qtdJogadores { get; set; }
        public Jogador[] jogadores { get; set; }
        public Carta[] cartasJogadas { get; set; } 
        public Carta cartaVencedora { get; set; }
        public int jogadorDaVez { get; set; }
        public String atributoDaVez { get; set; }
        public Boolean jogadorDaVezJogou { get; set; }
        public Boolean embaralhado { get; set; }

        public RetornoJogada()
        {
            this.embaralhado = false;
            jogadores = new Jogador[8];
            for (int i = 0; i < jogadores.Length; i++)
            {
                jogadores[i] = new Jogador(i);
            }
        }
    }
}
