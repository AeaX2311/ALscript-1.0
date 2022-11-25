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
            this.SuspendLayout();
            // 
            // codigoEnsambladorTxt
            // 
            this.codigoEnsambladorTxt.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.codigoEnsambladorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoEnsambladorTxt.ForeColor = System.Drawing.Color.Lime;
            this.codigoEnsambladorTxt.Location = new System.Drawing.Point(12, 12);
            this.codigoEnsambladorTxt.Name = "codigoEnsambladorTxt";
            this.codigoEnsambladorTxt.ReadOnly = true;
            this.codigoEnsambladorTxt.Size = new System.Drawing.Size(527, 689);
            this.codigoEnsambladorTxt.TabIndex = 0;
            this.codigoEnsambladorTxt.Text = "";
            // 
            // btnSeAcaboTodo
            // 
            this.btnSeAcaboTodo.Location = new System.Drawing.Point(12, 710);
            this.btnSeAcaboTodo.Name = "btnSeAcaboTodo";
            this.btnSeAcaboTodo.Size = new System.Drawing.Size(1060, 26);
            this.btnSeAcaboTodo.TabIndex = 1;
            this.btnSeAcaboTodo.Text = "Ejecutar codigo ensamblador";
            this.btnSeAcaboTodo.UseVisualStyleBackColor = true;
            this.btnSeAcaboTodo.Click += new System.EventHandler(this.btnSeAcaboTodo_Click);
            // 
            // txtResultados
            // 
            this.txtResultados.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultados.ForeColor = System.Drawing.Color.Lime;
            this.txtResultados.Location = new System.Drawing.Point(545, 12);
            this.txtResultados.Name = "txtResultados";
            this.txtResultados.ReadOnly = true;
            this.txtResultados.Size = new System.Drawing.Size(527, 689);
            this.txtResultados.TabIndex = 2;
            this.txtResultados.Text = "";
            // 
            // CodigoEnsamblador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 745);
            this.Controls.Add(this.txtResultados);
            this.Controls.Add(this.btnSeAcaboTodo);
            this.Controls.Add(this.codigoEnsambladorTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CodigoEnsamblador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodigoEnsamblador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox codigoEnsambladorTxt;
        private System.Windows.Forms.Button btnSeAcaboTodo;
        private System.Windows.Forms.RichTextBox txtResultados;
    }
}