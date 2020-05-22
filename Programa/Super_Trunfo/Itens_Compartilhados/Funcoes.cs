using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Itens_Compartilhados
{
    [Serializable]
    public class Funcoes
    {
        public Carta[] informacoesCartas()
        {
            Carta[] cartas;
            cartas = new Carta[33];
            for (int i = 0; i < cartas.Length; i++)
            {
                cartas[i] = new Carta();
            }

            cartas[0].cod_Carta = "Capa";
            cartas[0].nome = "?";
            cartas[0].tipo = "?";
            cartas[0].altura = 0;
            cartas[0].comprimento = 0;
            cartas[0].peso = 0;
            cartas[0].idade = 0;
            cartas[0].trunfo = false;
            cartas[0].ativo = true;
            cartas[0].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources.Capa";

            cartas[1].cod_Carta = "1A";
            cartas[1].nome = "Herrerassauro";
            cartas[1].tipo = "Carnívoro Triassico";
            cartas[1].altura = 1.5;
            cartas[1].comprimento = 4.5;
            cartas[1].peso = 300;
            cartas[1].idade = 231;
            cartas[1].trunfo = false;
            cartas[1].ativo = true;
            cartas[1].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._1A";

            cartas[2].cod_Carta = "1B";
            cartas[2].nome = "Procompsognato";
            cartas[2].tipo = "Carnívoro Triassico";
            cartas[2].altura = 0.3;
            cartas[2].comprimento = 1.2;
            cartas[2].peso = 1;
            cartas[2].idade = 222;
            cartas[2].trunfo = false;
            cartas[2].ativo = true;
            cartas[2].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._1B";

            cartas[3].cod_Carta = "1C";
            cartas[3].nome = "Patagossauro";
            cartas[3].tipo = "Herbívoro Jurássico";
            cartas[3].altura = 8.0;
            cartas[3].comprimento = 18.0;
            cartas[3].peso = 16000;
            cartas[3].idade = 169;
            cartas[3].trunfo = false;
            cartas[3].ativo = true;
            cartas[3].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._1C";

            cartas[4].cod_Carta = "1D";
            cartas[4].nome = "Ceratossauro";
            cartas[4].tipo = "Carnívoro Jurássico";
            cartas[4].altura = 2.0;
            cartas[4].comprimento = 6.0;
            cartas[4].peso = 1000;
            cartas[4].idade = 156;
            cartas[4].trunfo = false;
            cartas[4].ativo = true;
            cartas[4].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._1D";

            cartas[5].cod_Carta = "2A";
            cartas[5].nome = "Pterodáctilo";
            cartas[5].tipo = "Carnívoro Jurássico";
            cartas[5].altura = 0.5;
            cartas[5].comprimento = 1.0;
            cartas[5].peso = 1;
            cartas[5].idade = 150;
            cartas[5].trunfo = false;
            cartas[5].ativo = true;
            cartas[5].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._2A";

            cartas[6].cod_Carta = "2B";
            cartas[6].nome = "Velociraptor";
            cartas[6].tipo = "Carnívoro Creatáceo";
            cartas[6].altura = 1.0;
            cartas[6].comprimento = 1.8;
            cartas[6].peso = 15;
            cartas[6].idade = 80;
            cartas[6].trunfo = false;
            cartas[6].ativo = true;
            cartas[6].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._2B";

            cartas[7].cod_Carta = "2C";
            cartas[7].nome = "Triceratopo";
            cartas[7].tipo = "Herbívoro Creatáceo";
            cartas[7].altura = 6.0;
            cartas[7].comprimento = 9.0;
            cartas[7].peso = 6000;
            cartas[7].idade = 68;
            cartas[7].trunfo = false;
            cartas[7].ativo = true;
            cartas[7].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._2C";

            cartas[8].cod_Carta = "2D";
            cartas[8].nome = "Baptornis";
            cartas[8].tipo = "Carnívoro Creatáceo";
            cartas[8].altura = 0.8;
            cartas[8].comprimento = 1.0;
            cartas[8].peso = 7;
            cartas[8].idade = 83;
            cartas[8].trunfo = false;
            cartas[8].ativo = true;
            cartas[8].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._2D";

            cartas[9].cod_Carta = "3A";
            cartas[9].nome = "Plateossauro";
            cartas[9].tipo = "Herbívoro Triassico";
            cartas[9].altura = 2.0;
            cartas[9].comprimento = 9.0;
            cartas[9].peso = 4000;
            cartas[9].idade = 221;
            cartas[9].trunfo = false;
            cartas[9].ativo = true;
            cartas[9].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._3A";

            cartas[10].cod_Carta = "3B";
            cartas[10].nome = "Peteinossauro";
            cartas[10].tipo = "Herbívoro Triassico";
            cartas[10].altura = 0.3;
            cartas[10].comprimento = 0.6;
            cartas[10].peso = 0.2;
            cartas[10].idade = 210;
            cartas[10].trunfo = false;
            cartas[10].ativo = true;
            cartas[10].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._3B";

            cartas[11].cod_Carta = "3C";
            cartas[11].nome = "Estegossauro";
            cartas[11].tipo = "Herbívoro Jurássico";
            cartas[11].altura = 4.0;
            cartas[11].comprimento = 9.0;
            cartas[11].peso = 2000;
            cartas[11].idade = 156;
            cartas[11].trunfo = false;
            cartas[11].ativo = true;
            cartas[11].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._3C";

            cartas[12].cod_Carta = "3D";
            cartas[12].nome = "Alossauro";
            cartas[12].tipo = "Carnívoro Jurássico";
            cartas[12].altura = 5.2;
            cartas[12].comprimento = 14.00;
            cartas[12].peso = 3600;
            cartas[12].idade = 156;
            cartas[12].trunfo = false;
            cartas[12].ativo = true;
            cartas[12].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._3D";

            cartas[13].cod_Carta = "4A";
            cartas[13].nome = "Ultrassauro";
            cartas[13].tipo = "Herbívoro Jurássico";
            cartas[13].altura = 22.00;
            cartas[13].comprimento = 38.00;
            cartas[13].peso = 90000;
            cartas[13].idade = 154;
            cartas[13].trunfo = false;
            cartas[13].ativo = true;
            cartas[13].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._4A";

            cartas[14].cod_Carta = "4B";
            cartas[14].nome = "Tiranossauro Rex";
            cartas[14].tipo = "Carnívoro Creatáceo";
            cartas[14].altura = 5.6;
            cartas[14].comprimento = 14.0;
            cartas[14].peso = 7000;
            cartas[14].idade = 68;
            cartas[14].trunfo = true;
            cartas[14].ativo = true;
            cartas[14].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._4B";

            cartas[15].cod_Carta = "4C";
            cartas[15].nome = "Carnotauro";
            cartas[15].tipo = "Carnívoro Creatáceo";
            cartas[15].altura = 3.0;
            cartas[15].comprimento = 7.5;
            cartas[15].peso = 1000;
            cartas[15].idade = 113;
            cartas[15].trunfo = false;
            cartas[15].ativo = true;
            cartas[15].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._4C";

            cartas[16].cod_Carta = "4D";
            cartas[16].nome = "Iberomesornis";
            cartas[16].tipo = "Onívoro Cretáceo";
            cartas[16].altura = 0.2;
            cartas[16].comprimento = 0.1;
            cartas[16].peso = 0.03;
            cartas[16].idade = 125;
            cartas[16].trunfo = false;
            cartas[16].ativo = true;
            cartas[16].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._4D";

            cartas[17].cod_Carta = "5A";
            cartas[17].nome = "Coelophisis";
            cartas[17].tipo = "Carnívoro Triassico";
            cartas[17].altura = 1.8;
            cartas[17].comprimento = 3.0;
            cartas[17].peso = 30;
            cartas[17].idade = 227;
            cartas[17].trunfo = false;
            cartas[17].ativo = true;
            cartas[17].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._5A";

            cartas[18].cod_Carta = "5B";
            cartas[18].nome = "Melanorossauro";
            cartas[18].tipo = "Herbívoro Triassico";
            cartas[18].altura = 12.00;
            cartas[18].comprimento = 15.0;
            cartas[18].peso = 8000;
            cartas[18].idade = 228;
            cartas[18].trunfo = false;
            cartas[18].ativo = true;
            cartas[18].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._5B";

            cartas[19].cod_Carta = "5C";
            cartas[19].nome = "Brachiossauro";
            cartas[19].tipo = "Herbívoro Jurássico";
            cartas[19].altura = 15.0;
            cartas[19].comprimento = 28.0;
            cartas[19].peso = 50000;
            cartas[19].idade = 156;
            cartas[19].trunfo = false;
            cartas[19].ativo = true;
            cartas[19].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._5C";


            cartas[20].cod_Carta = "5D";
            cartas[20].nome = "Dilofosauro";
            cartas[20].tipo = "Carnívoro Jurássico";
            cartas[20].altura = 2.5;
            cartas[20].comprimento = 7.0;
            cartas[20].peso = 450;
            cartas[20].idade = 206;
            cartas[20].trunfo = false;
            cartas[20].ativo = true;
            cartas[20].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._5D";

            cartas[21].cod_Carta = "6A";
            cartas[21].nome = "Othnielia";
            cartas[21].tipo = "Herbívoro Jurássico";
            cartas[21].altura = 1.1;
            cartas[21].comprimento = 1.5;
            cartas[21].peso = 40;
            cartas[21].idade = 146;
            cartas[21].trunfo = false;
            cartas[21].ativo = true;
            cartas[21].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._6A";

            cartas[22].cod_Carta = "6B";
            cartas[22].nome = "Carcharodontossauro";
            cartas[22].tipo = "Carnívoro Creatáceo";
            cartas[22].altura = 5.8;
            cartas[22].comprimento = 14.0;
            cartas[22].peso = 8000;
            cartas[22].idade = 113;
            cartas[22].trunfo = false;
            cartas[22].ativo = true;
            cartas[22].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._6B";
            
            cartas[23].cod_Carta = "6C";
            cartas[23].nome = "Barionix";
            cartas[23].tipo = "Carnívoro Creatáceo";
            cartas[23].altura = 8.0;
            cartas[23].comprimento = 12.0;
            cartas[23].peso = 2000;
            cartas[23].idade = 125;
            cartas[23].trunfo = false;
            cartas[23].ativo = true;
            cartas[23].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._6C";

            cartas[24].cod_Carta = "6D";
            cartas[24].nome = "Hylaeossauro";
            cartas[24].tipo = "Herbívoro Cretáceo";
            cartas[24].altura = 1.8;
            cartas[24].comprimento = 5.0;
            cartas[24].peso = 1500;
            cartas[24].idade = 130;
            cartas[24].trunfo = false;
            cartas[24].ativo = true;
            cartas[24].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._6D";

            cartas[25].cod_Carta = "7A";
            cartas[25].nome = "Eoraptor";
            cartas[25].tipo = "Carnívoro Triassico";
            cartas[25].altura = 0.8;
            cartas[25].comprimento = 1.0;
            cartas[25].peso = 10;
            cartas[25].idade = 231;
            cartas[25].trunfo = false;
            cartas[25].ativo = true;
            cartas[25].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._7A";

            cartas[26].cod_Carta = "7B";
            cartas[26].nome = "Nothossauro";
            cartas[26].tipo = "Carnívoro Triassico";
            cartas[26].altura = 8.0;
            cartas[26].comprimento = 9.0;
            cartas[26].peso = 400;
            cartas[26].idade = 220;
            cartas[26].trunfo = false;
            cartas[26].ativo = true;
            cartas[26].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._7B";

            cartas[27].cod_Carta = "7C";
            cartas[27].nome = "Diplodoco";
            cartas[27].tipo = "Herbívoro Jurássico";
            cartas[27].altura = 5.0;
            cartas[27].comprimento = 27.0;
            cartas[27].peso = 20000;
            cartas[27].idade = 156;
            cartas[27].trunfo = false;
            cartas[27].ativo = true;
            cartas[27].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._7C";

            cartas[28].cod_Carta = "7D";
            cartas[28].nome = "Compsognato";
            cartas[28].tipo = "Carnívoro Jurássico";
            cartas[28].altura = 0.7;
            cartas[28].comprimento = 1.0;
            cartas[28].peso = 2;
            cartas[28].idade = 156;
            cartas[28].trunfo = false;
            cartas[28].ativo = true;
            cartas[28].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._7D";

            cartas[29].cod_Carta = "8A";
            cartas[29].nome = "Oftalmossauro";
            cartas[29].tipo = "Carnívoro Jurássico";
            cartas[29].altura = 1.3;
            cartas[29].comprimento = 5.0;
            cartas[29].peso = 3000;
            cartas[29].idade = 165;
            cartas[29].trunfo = false;
            cartas[29].ativo = true;
            cartas[29].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._8A";

            cartas[30].cod_Carta = "8B";
            cartas[30].nome = "Psitacossauro";
            cartas[30].tipo = "Herbívoro Cretáceo";
            cartas[30].altura = 0.7;
            cartas[30].comprimento = 2.0;
            cartas[30].peso = 25;
            cartas[30].idade = 125;
            cartas[30].trunfo = false;
            cartas[30].ativo = true;
            cartas[30].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._8B";

            cartas[31].cod_Carta = "8C";
            cartas[31].nome = "Oviraptor";
            cartas[31].tipo = "Carnívoro Creatáceo";
            cartas[31].altura = 1.3;
            cartas[31].comprimento = 2.5;
            cartas[31].peso = 35;
            cartas[31].idade = 80;
            cartas[31].trunfo = false;
            cartas[31].ativo = true;
            cartas[31].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._8C";

            cartas[32].cod_Carta = "8D";
            cartas[32].nome = "Globidens";
            cartas[32].tipo = "Carnivoro Cretáceo";
            cartas[32].altura = 1.1;
            cartas[32].comprimento = 6.0;
            cartas[32].peso = 400;
            cartas[32].idade = 150;
            cartas[32].trunfo = false;
            cartas[32].ativo = true;
            cartas[32].end_Imagem = "Super_Trunfo_Cliente.Properties.Resources._8D";

            return cartas;
        }
        
        // Convert an object to a byte array
        public byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        // Convert a byte array to an Object
        public Object ByteArrayToObject(byte[] arrBytes)
        {
            Object obj;
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }

        public void escreveInfoCarta(Itens_Compartilhados.Carta carta)
        {
            Console.WriteLine("\nJogador: " + carta.ID);
            Console.WriteLine("\nCodigo: " + carta.cod_Carta);
            Console.WriteLine("Nome: " + carta.nome);
            Console.WriteLine("Tipo: " + carta.tipo);
            Console.WriteLine("Altura: " + carta.altura);
            Console.WriteLine("Comprimento: " + carta.comprimento);
            Console.WriteLine("Peso: " + carta.peso);
            Console.WriteLine("Idade: " + carta.idade);
            if (carta.trunfo)
            {
                Console.WriteLine("Essa carta e o Trunfo");
            }
            Console.WriteLine("\nAtributo selecionado: " + carta.atributo_teste);
        }

        public String retornaFaixaIP(string IP)
        {
            string retorno = "";
            int count = 0;

            for (int i = 0; i < IP.Length; i++)
            {
                if (((IP[i].CompareTo('.')) > 0) && (count < 3))
                {
                    retorno += IP[i];
                }else if (((IP[i].CompareTo('.')) <= 0) && (count < 3))
                {
                    retorno += IP[i];
                    count++;
                }
            }
            return retorno;
        }

        public String idSocket(string endPoint)
        {
            string retorno = "";
            Boolean ativo = false;
            for (int i = 0; i < endPoint.Length; i++)
            {
                if (ativo)
                {
                    retorno += endPoint[i];
                }
                
                if (String.Equals(endPoint[i], ':'))
                {
                    ativo = true;
                }
            }
            return retorno;
        }

        public string retornaIP()
        {
            string ipLocal = Dns.GetHostName();
            IPAddress[] ip = Dns.GetHostAddresses(ipLocal);
            ipLocal = ip[1].ToString();
            return ipLocal;
        }

        public int retornoPosCarta(String cod)
        {
            int retornoPosCarta = 0;

            switch (cod)
            {
                case "1A":
                    retornoPosCarta = 1;
                    break;
                case "1B":
                    retornoPosCarta = 2;
                    break;
                case "1C":
                    retornoPosCarta = 3;
                    break;
                case "1D":
                    retornoPosCarta = 4;
                    break;
                case "2A":
                    retornoPosCarta = 5;
                    break;
                case "2B":
                    retornoPosCarta = 6;
                    break;
                case "2C":
                    retornoPosCarta = 7;
                    break;
                case "2D":
                    retornoPosCarta = 8;
                    break;
                case "3A":
                    retornoPosCarta = 9;
                    break;
                case "3B":
                    retornoPosCarta = 10;
                    break;
                case "3C":
                    retornoPosCarta = 11;
                    break;
                case "3D":
                    retornoPosCarta = 12;
                    break;
                case "4A":
                    retornoPosCarta = 13;
                    break;
                case "4B":
                    retornoPosCarta = 14;
                    break;
                case "4C":
                    retornoPosCarta = 15;
                    break;
                case "4D":
                    retornoPosCarta = 16;
                    break;
                case "5A":
                    retornoPosCarta = 17;
                    break;
                case "5B":
                    retornoPosCarta = 18;
                    break;
                case "5C":
                    retornoPosCarta = 19;
                    break;
                case "5D":
                    retornoPosCarta = 20;
                    break;
                case "6A":
                    retornoPosCarta = 21;
                    break;
                case "6B":
                    retornoPosCarta = 22;
                    break;
                case "6C":
                    retornoPosCarta = 23;
                    break;
                case "6D":
                    retornoPosCarta = 24;
                    break;
                case "7A":
                    retornoPosCarta = 25;
                    break;
                case "7B":
                    retornoPosCarta = 26;
                    break;
                case "7C":
                    retornoPosCarta = 27;
                    break;
                case "7D":
                    retornoPosCarta = 28;
                    break;
                case "8A":
                    retornoPosCarta = 29;
                    break;
                case "8B":
                    retornoPosCarta = 30;
                    break;
                case "8C":
                    retornoPosCarta = 31;
                    break;
                case "8D":
                    retornoPosCarta = 32;
                    break;
            }

            return retornoPosCarta;
        }
    }
}
