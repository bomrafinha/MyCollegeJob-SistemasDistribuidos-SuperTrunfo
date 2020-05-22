using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient cliente = new TcpClient("localhost", 8000);
            Console.WriteLine("Conectei no servidor!!");

            NetworkStream saida = cliente.GetStream();
            BinaryReader recebe = new BinaryReader(saida);
            BinaryWriter envia = new BinaryWriter(saida);

            Console.WriteLine("Digite a mensagem: ");
            string msg = Console.ReadLine();

            Console.WriteLine("Vou enviar a mensagem: " + msg);
            envia.Write(msg);

            Console.WriteLine("Aguardando o ok do servidor");
            msg = recebe.ReadString();
            Console.WriteLine("Recebi: " + msg);

            saida.Close();
            recebe.Close();
            envia.Close();
            cliente.Close();

            Console.WriteLine("Digite qualquer tecla para sair!");
            Console.ReadKey();
        }
    }
}
