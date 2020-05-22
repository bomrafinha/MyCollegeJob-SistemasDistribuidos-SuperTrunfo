using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Trunfo_Servidor
{
    public class Execucao
    {
        public void executar()
        {
            try
            {
                int porta = 1702;
                String ip = "127.0.0.1";

                Servidor server = new Servidor(ip, porta);

                server.Connect();

                while (server.ativo) ;
            }
            catch (Exception) { }
        }
    }
}
