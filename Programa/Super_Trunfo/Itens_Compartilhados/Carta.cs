using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itens_Compartilhados
{
    [Serializable]
    public class Carta : Object
    {
        public int ID { get; set; } //Exemplo 1, 2, 3, 4, ...
        public String cod_Carta { get; set; } //Exemplo 1A, 1B, 2A, 3D, etc.
        public String nome { get; set; } //Exemplo Herrerassauro, Procompsognato, Patagossauro, etc.
        public String tipo { get; set; } //Exemplo Carnivoro Triassico, Herbívoro Jurassico, etc
        public Double altura { get; set; } //Exemplo 1,5
        public Double comprimento { get; set; } //Exemplo 18,0
        public Double peso { get; set; } //Exemplo 1000
        public int idade { get; set; } //Exemplo 231
        public Boolean trunfo { get; set; } // Carta do Super Trunfo
        public String atributo_teste { get; set; } // atributo a ser comparado {altura, comprimento, peso, idade}
        public Boolean ativo { get; set; } // Seta a carta como ativa ou nao
        public String end_Imagem { get; set; } //Exemplo ../../Imagens/A1.png

        public Carta()
        {
        }
    }
}