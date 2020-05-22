using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itens_Compartilhados
{
    [Serializable]
    public class Jogador
    {
        public int ID { get; set; }
        public Carta[] cartas { get; set; }
        public Boolean conectado { get; set; }
        public Boolean jogando { get; set; }
        public string ip { get; set; }

        private Funcoes funcoes;


        public Jogador(int id)
        {
            this.ID = id;
            this.conectado = false;
            this.jogando = false;
            this.ip = "";
            this.funcoes = new Funcoes();
            this.cartas = this.funcoes.informacoesCartas();
            for (int i = 0; i < cartas.Length; i++)
            {
                cartas[i].ativo = false;
            }
        }    

    }
}
