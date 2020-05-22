namespace Super_Trunfo_Cliente
{
    partial class TelaConexao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.gb_selecao = new System.Windows.Forms.GroupBox();
            this.b_buscar = new System.Windows.Forms.Button();
            this.tb_InfIP = new System.Windows.Forms.TextBox();
            this.l_fixo = new System.Windows.Forms.Label();
            this.cb_ListaIP = new System.Windows.Forms.ComboBox();
            this.rb_Iniciar = new System.Windows.Forms.RadioButton();
            this.rb_informar = new System.Windows.Forms.RadioButton();
            this.rb_lista = new System.Windows.Forms.RadioButton();
            this.gb_selecao.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(262, 150);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 25);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(158, 150);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 25);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // gb_selecao
            // 
            this.gb_selecao.Controls.Add(this.b_buscar);
            this.gb_selecao.Controls.Add(this.tb_InfIP);
            this.gb_selecao.Controls.Add(this.l_fixo);
            this.gb_selecao.Controls.Add(this.cb_ListaIP);
            this.gb_selecao.Controls.Add(this.rb_Iniciar);
            this.gb_selecao.Controls.Add(this.rb_informar);
            this.gb_selecao.Controls.Add(this.rb_lista);
            this.gb_selecao.Location = new System.Drawing.Point(12, 12);
            this.gb_selecao.Name = "gb_selecao";
            this.gb_selecao.Size = new System.Drawing.Size(348, 118);
            this.gb_selecao.TabIndex = 2;
            this.gb_selecao.TabStop = false;
            this.gb_selecao.Text = "Selecionar Servidor";
            // 
            // b_buscar
            // 
            this.b_buscar.Image = global::Super_Trunfo_Cliente.Properties.Resources.busca;
            this.b_buscar.Location = new System.Drawing.Point(317, 17);
            this.b_buscar.Name = "b_buscar";
            this.b_buscar.Size = new System.Drawing.Size(21, 21);
            this.b_buscar.TabIndex = 3;
            this.b_buscar.UseVisualStyleBackColor = true;
            this.b_buscar.Click += new System.EventHandler(this.b_buscar_Click);
            // 
            // tb_InfIP
            // 
            this.tb_InfIP.Location = new System.Drawing.Point(184, 49);
            this.tb_InfIP.Name = "tb_InfIP";
            this.tb_InfIP.Size = new System.Drawing.Size(154, 20);
            this.tb_InfIP.TabIndex = 5;
            this.tb_InfIP.TextChanged += new System.EventHandler(this.tb_InfIP_TextChanged);
            // 
            // l_fixo
            // 
            this.l_fixo.AutoSize = true;
            this.l_fixo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_fixo.Location = new System.Drawing.Point(213, 85);
            this.l_fixo.Name = "l_fixo";
            this.l_fixo.Size = new System.Drawing.Size(131, 17);
            this.l_fixo.TabIndex = 4;
            this.l_fixo.Text = "255.255.255.255";
            // 
            // cb_ListaIP
            // 
            this.cb_ListaIP.FormattingEnabled = true;
            this.cb_ListaIP.Location = new System.Drawing.Point(156, 18);
            this.cb_ListaIP.Name = "cb_ListaIP";
            this.cb_ListaIP.Size = new System.Drawing.Size(155, 21);
            this.cb_ListaIP.TabIndex = 3;
            // 
            // rb_Iniciar
            // 
            this.rb_Iniciar.AutoSize = true;
            this.rb_Iniciar.Location = new System.Drawing.Point(6, 85);
            this.rb_Iniciar.Name = "rb_Iniciar";
            this.rb_Iniciar.Size = new System.Drawing.Size(201, 17);
            this.rb_Iniciar.TabIndex = 2;
            this.rb_Iniciar.TabStop = true;
            this.rb_Iniciar.Text = "Iniciar/Conectar Servidor Localmente";
            this.rb_Iniciar.UseVisualStyleBackColor = true;
            // 
            // rb_informar
            // 
            this.rb_informar.AutoSize = true;
            this.rb_informar.Location = new System.Drawing.Point(6, 52);
            this.rb_informar.Name = "rb_informar";
            this.rb_informar.Size = new System.Drawing.Size(172, 17);
            this.rb_informar.TabIndex = 1;
            this.rb_informar.TabStop = true;
            this.rb_informar.Text = "Informar Servidor Manualmente";
            this.rb_informar.UseVisualStyleBackColor = true;
            // 
            // rb_lista
            // 
            this.rb_lista.AutoSize = true;
            this.rb_lista.Location = new System.Drawing.Point(6, 19);
            this.rb_lista.Name = "rb_lista";
            this.rb_lista.Size = new System.Drawing.Size(144, 17);
            this.rb_lista.TabIndex = 0;
            this.rb_lista.TabStop = true;
            this.rb_lista.Text = "Selecionar Servidor Ativo";
            this.rb_lista.UseVisualStyleBackColor = true;
            // 
            // TelaConexao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 196);
            this.Controls.Add(this.gb_selecao);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaConexao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Escolha de Servidor";
            this.gb_selecao.ResumeLayout(false);
            this.gb_selecao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox gb_selecao;
        private System.Windows.Forms.TextBox tb_InfIP;
        private System.Windows.Forms.Label l_fixo;
        private System.Windows.Forms.ComboBox cb_ListaIP;
        private System.Windows.Forms.RadioButton rb_Iniciar;
        private System.Windows.Forms.RadioButton rb_informar;
        private System.Windows.Forms.RadioButton rb_lista;
        private System.Windows.Forms.Button b_buscar;
    }
}