using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace Sockets
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener servidor = new TcpListener(8000);

            servidor.Start();
            Console.WriteLine("Servidor Inicializado");

            TcpClient conversacliente = servidor.AcceptTcpClient();
            Console.WriteLine("Cliente Conectou!!");

            NetworkStream saida = conversacliente.GetStream();
            BinaryReader recebe = new BinaryReader(saida);
            BinaryWriter envia = new BinaryWriter(saida);

            string msg = recebe.ReadString();
            Console.WriteLine("Recebi a mensagem: " + msg);

            envia.Write("OK!!");

            saida.Close();
            recebe.Close();
            envia.Close();
            conversacliente.Close();
            servidor.Stop();

            Console.WriteLine("Digite qualquer tecla para sair!");
            Console.ReadKey();
        }
    }
}
