using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Trunfo_Cliente
{
    public partial class TelaConexao : Form
    {
        public string IP { get; set; }
        public Boolean local { get; set; }

        private String[] listaIPs;
        private Itens_Compartilhados.Funcoes funcoes;
        public TelaConexao()
        {
            InitializeComponent();
            local = false;
            funcoes = new Itens_Compartilhados.Funcoes();
            rb_Iniciar.Checked = true;
            l_fixo.Text = funcoes.retornaIP();
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {   
            if (rb_lista.Checked)
            {
                this.IP = cb_ListaIP.Items[cb_ListaIP.SelectedIndex].ToString();
            }
            else if (rb_Iniciar.Checked)
            {
                this.IP = funcoes.retornaIP();
                this.local = true;
            } else if (rb_informar.Checked)
            {
                this.IP = tb_InfIP.Text;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void b_buscar_Click(object sender, EventArgs e)
        {
            BuscaIPs buscaIPs = new BuscaIPs();
            buscaIPs.ShowDialog();
            this.listaIPs = buscaIPs.listaIPs;
            cb_ListaIP.Items.AddRange(this.listaIPs);
            if (this.listaIPs.Length > 0)
            {
                rb_lista.Checked = true;
                cb_ListaIP.SelectedIndex = 0;
            }
            else
            {
                rb_Iniciar.Checked = true;
            }            
        }

        private void tb_InfIP_TextChanged(object sender, EventArgs e)
        {
            rb_informar.Checked = true;
        }
    }
}
