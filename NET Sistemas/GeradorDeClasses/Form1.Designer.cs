namespace GeradorDeClasses
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeProjeto = new System.Windows.Forms.TextBox();
            this.txtCaminhoProjeto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtConn = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbDTO = new System.Windows.Forms.CheckBox();
            this.cbDAO = new System.Windows.Forms.CheckBox();
            this.cbController = new System.Windows.Forms.CheckBox();
            this.ddlTabelas = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do Projeto:";
            // 
            // txtNomeProjeto
            // 
            this.txtNomeProjeto.Location = new System.Drawing.Point(121, 16);
            this.txtNomeProjeto.Name = "txtNomeProjeto";
            this.txtNomeProjeto.Size = new System.Drawing.Size(212, 20);
            this.txtNomeProjeto.TabIndex = 1;
            this.txtNomeProjeto.Text = "Financys";
            // 
            // txtCaminhoProjeto
            // 
            this.txtCaminhoProjeto.Location = new System.Drawing.Point(121, 45);
            this.txtCaminhoProjeto.Name = "txtCaminhoProjeto";
            this.txtCaminhoProjeto.Size = new System.Drawing.Size(212, 20);
            this.txtCaminhoProjeto.TabIndex = 10;
            this.txtCaminhoProjeto.Text = "C:\\Users\\acallegario.ATT\\Desktop\\Financys";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Caminho do Projeto:";
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(121, 113);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(172, 20);
            this.txtBanco.TabIndex = 5;
            this.txtBanco.Text = "Financys";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Selecione a Tabela:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(283, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "Gerar Classes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(339, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Abrir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(339, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(65, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // txtConn
            // 
            this.txtConn.Location = new System.Drawing.Point(121, 71);
            this.txtConn.Multiline = true;
            this.txtConn.Name = "txtConn";
            this.txtConn.Size = new System.Drawing.Size(283, 39);
            this.txtConn.TabIndex = 9;
            this.txtConn.Text = "server =localhost; user id =root; password = 1234; database = financys;";
            // 
            // cbDTO
            // 
            this.cbDTO.AutoSize = true;
            this.cbDTO.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDTO.Location = new System.Drawing.Point(121, 258);
            this.cbDTO.Name = "cbDTO";
            this.cbDTO.Size = new System.Drawing.Size(51, 21);
            this.cbDTO.TabIndex = 11;
            this.cbDTO.Text = "DTO";
            this.cbDTO.UseVisualStyleBackColor = true;
            // 
            // cbDAO
            // 
            this.cbDAO.AutoSize = true;
            this.cbDAO.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDAO.Location = new System.Drawing.Point(121, 274);
            this.cbDAO.Name = "cbDAO";
            this.cbDAO.Size = new System.Drawing.Size(53, 21);
            this.cbDAO.TabIndex = 12;
            this.cbDAO.Text = "DAO";
            this.cbDAO.UseVisualStyleBackColor = true;
            // 
            // cbController
            // 
            this.cbController.AutoSize = true;
            this.cbController.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbController.Location = new System.Drawing.Point(121, 291);
            this.cbController.Name = "cbController";
            this.cbController.Size = new System.Drawing.Size(81, 21);
            this.cbController.TabIndex = 13;
            this.cbController.Text = "Controller";
            this.cbController.UseVisualStyleBackColor = true;
            // 
            // ddlTabelas
            // 
            this.ddlTabelas.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlTabelas.FormattingEnabled = true;
            this.ddlTabelas.Location = new System.Drawing.Point(121, 146);
            this.ddlTabelas.MultiColumn = true;
            this.ddlTabelas.Name = "ddlTabelas";
            this.ddlTabelas.Size = new System.Drawing.Size(283, 109);
            this.ddlTabelas.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "String de Conexão:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Banco de Dados:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(304, 111);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Vizualizar Tabelas";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(429, 393);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ddlTabelas);
            this.Controls.Add(this.cbController);
            this.Controls.Add(this.cbDAO);
            this.Controls.Add(this.cbDTO);
            this.Controls.Add(this.txtConn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBanco);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCaminhoProjeto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomeProjeto);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador de Classe";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeProjeto;
        private System.Windows.Forms.TextBox txtCaminhoProjeto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtConn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox cbDTO;
        private System.Windows.Forms.CheckBox cbDAO;
        private System.Windows.Forms.CheckBox cbController;
        private System.Windows.Forms.CheckedListBox ddlTabelas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
    }
}

