using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itens_Compartilhados
{
    [Serializable]
    public class Comandos
    {
        public String comando { get; set; }
        public Carta carta { get; set; }
        public Jogador[] jogadores { get; set; }
        public String atributo { get; set; }
        public int ID { get; set; }

        public Comandos()
        {
            jogadores = new Jogador[8];
            for (int i = 0; i < jogadores.Length; i++)
            {
                jogadores[i] = new Jogador(i);
            }
        }
    }
}
