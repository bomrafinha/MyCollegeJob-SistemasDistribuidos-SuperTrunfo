namespace Super_Trunfo_Cliente
{
    partial class CargaJogadores
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
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.b_jogar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.b_cancelar = new System.Windows.Forms.Button();
            this.l_prox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Enabled = false;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(364, 178);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "IP";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 150;
            // 
            // b_jogar
            // 
            this.b_jogar.Location = new System.Drawing.Point(301, 196);
            this.b_jogar.Name = "b_jogar";
            this.b_jogar.Size = new System.Drawing.Size(75, 23);
            this.b_jogar.TabIndex = 1;
            this.b_jogar.Text = "Jogar";
            this.b_jogar.UseVisualStyleBackColor = true;
            this.b_jogar.Click += new System.EventHandler(this.b_jogar_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // b_cancelar
            // 
            this.b_cancelar.Location = new System.Drawing.Point(211, 196);
            this.b_cancelar.Name = "b_cancelar";
            this.b_cancelar.Size = new System.Drawing.Size(75, 23);
            this.b_cancelar.TabIndex = 2;
            this.b_cancelar.Text = "Cancelar";
            this.b_cancelar.UseVisualStyleBackColor = true;
            this.b_cancelar.Click += new System.EventHandler(this.b_cancelar_Click);
            // 
            // l_prox
            // 
            this.l_prox.AutoSize = true;
            this.l_prox.Location = new System.Drawing.Point(13, 205);
            this.l_prox.Name = "l_prox";
            this.l_prox.Size = new System.Drawing.Size(124, 13);
            this.l_prox.TabIndex = 3;
            this.l_prox.Text = "Aguardar próximo jogo ...";
            this.l_prox.Visible = false;
            // 
            // CargaJogadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 227);
            this.Controls.Add(this.l_prox);
            this.Controls.Add(this.b_cancelar);
            this.Controls.Add(this.b_jogar);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CargaJogadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sala de espera";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button b_jogar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button b_cancelar;
        private System.Windows.Forms.Label l_prox;
    }
}