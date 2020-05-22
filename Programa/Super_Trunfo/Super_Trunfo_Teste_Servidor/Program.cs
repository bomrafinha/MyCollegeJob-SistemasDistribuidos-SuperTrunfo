using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Super_Trunfo_Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Super_Trunfo_Servidor.Execucao server = new Super_Trunfo_Servidor.Execucao();
                server.executar();
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);

            }

        }
    }
}
