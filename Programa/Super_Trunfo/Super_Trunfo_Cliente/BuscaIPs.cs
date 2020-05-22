using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Super_Trunfo_Cliente
{
    public partial class BuscaIPs : Form
    {
        public String[] listaIPs;
        private Boolean finalizado = false;
        public BuscaIPs()
        {
            InitializeComponent();
        }

        private void BuscaIPs_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            new Thread(() => buscaIP()).Start();
        }

        private void buscaIP()
        {
            int iniciadorLista = 0;
            String[] listaIP;
            String[] ipsValidos;
            Cliente cliente = new Cliente();
            listaIP = new String[255];
            listaIP = cliente.buscaServer();
            for (int i = 0; i < 255; i++)
            {
                if ((listaIP[i].CompareTo("")) > 0)
                {
                    iniciadorLista++;
                }
            }
            ipsValidos = new String[iniciadorLista];
            iniciadorLista = 0;
            for (int i = 0; i < 255; i++)
            {
                if ((listaIP[i].CompareTo("")) > 0)
                {
                    ipsValidos[iniciadorLista] = listaIP[i];
                    iniciadorLista++;
                }
            }
            this.listaIPs = ipsValidos;
            this.finalizado = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.finalizado)
            {
                this.Close();
            }

        }
    }
}
