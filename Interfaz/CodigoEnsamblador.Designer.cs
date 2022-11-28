namespace Interfaz {
    partial class CodigoEnsamblador {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodigoEnsamblador));
            this.codigoEnsambladorTxt = new System.Windows.Forms.RichTextBox();
            this.btnSeAcaboTodo = new System.Windows.Forms.Button();
            this.txtResultados = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codigoEnsambladorTxt
            // 
            this.codigoEnsambladorTxt.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.codigoEnsambladorTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codigoEnsambladorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoEnsambladorTxt.ForeColor = System.Drawing.Color.Lime;
            this.codigoEnsambladorTxt.Location = new System.Drawing.Point(3, 3);
            this.codigoEnsambladorTxt.Name = "codigoEnsambladorTxt";
            this.codigoEnsambladorTxt.ReadOnly = true;
            this.codigoEnsambladorTxt.Size = new System.Drawing.Size(403, 521);
            this.codigoEnsambladorTxt.TabIndex = 0;
            this.codigoEnsambladorTxt.Text = "";
            // 
            // btnSeAcaboTodo
            // 
            this.btnSeAcaboTodo.BackColor = System.Drawing.Color.YellowGreen;
            this.tableLayoutPanel1.SetColumnSpan(this.btnSeAcaboTodo, 2);
            this.btnSeAcaboTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSeAcaboTodo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSeAcaboTodo.Location = new System.Drawing.Point(3, 530);
            this.btnSeAcaboTodo.Name = "btnSeAcaboTodo";
            this.btnSeAcaboTodo.Size = new System.Drawing.Size(812, 88);
            this.btnSeAcaboTodo.TabIndex = 1;
            this.btnSeAcaboTodo.Text = "Ejecutar codigo ensamblador";
            this.btnSeAcaboTodo.UseVisualStyleBackColor = false;
            this.btnSeAcaboTodo.Click += new System.EventHandler(this.btnSeAcaboTodo_Click);
            // 
            // txtResultados
            // 
            this.txtResultados.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultados.ForeColor = System.Drawing.Color.Lime;
            this.txtResultados.Location = new System.Drawing.Point(412, 3);
            this.txtResultados.Name = "txtResultados";
            this.txtResultados.ReadOnly = true;
            this.txtResultados.Size = new System.Drawing.Size(403, 521);
            this.txtResultados.TabIndex = 2;
            this.txtResultados.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtResultados, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSeAcaboTodo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.codigoEnsambladorTxt, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(818, 621);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // CodigoEnsamblador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ClientSize = new System.Drawing.Size(818, 621);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CodigoEnsamblador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Codigo Ensamblador";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox codigoEnsambladorTxt;
        private System.Windows.Forms.Button btnSeAcaboTodo;
        private System.Windows.Forms.RichTextBox txtResultados;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}