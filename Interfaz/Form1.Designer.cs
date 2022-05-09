
namespace Interfaz {
    partial class Form1 {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumeracionCodificacion = new System.Windows.Forms.RichTextBox();
            this.txtCodificacion = new System.Windows.Forms.RichTextBox();
            this.btnCompilar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNumeracionCompilacion = new System.Windows.Forms.RichTextBox();
            this.txtCompilacion = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvIdentificadores = new System.Windows.Forms.DataGridView();
            this.IDIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvErrores = new System.Windows.Forms.DataGridView();
            this.TokenError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardarArchivoToken = new System.Windows.Forms.Button();
            this.btnGuardarCodigo = new System.Windows.Forms.Button();
            this.btnCargarCodigo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumeracionCodificacion);
            this.groupBox1.Controls.Add(this.txtCodificacion);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 678);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Codificacion";
            // 
            // txtNumeracionCodificacion
            // 
            this.txtNumeracionCodificacion.BackColor = System.Drawing.Color.LightGray;
            this.txtNumeracionCodificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeracionCodificacion.Location = new System.Drawing.Point(6, 28);
            this.txtNumeracionCodificacion.Name = "txtNumeracionCodificacion";
            this.txtNumeracionCodificacion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtNumeracionCodificacion.Size = new System.Drawing.Size(50, 644);
            this.txtNumeracionCodificacion.TabIndex = 1000;
            this.txtNumeracionCodificacion.Text = "";
            this.txtNumeracionCodificacion.FontChanged += new System.EventHandler(this.txtLineaCodigo_FontChanged);
            this.txtNumeracionCodificacion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtLineaCodigo_MouseDown);
            // 
            // txtCodificacion
            // 
            this.txtCodificacion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCodificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodificacion.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodificacion.ForeColor = System.Drawing.Color.Black;
            this.txtCodificacion.Location = new System.Drawing.Point(41, 28);
            this.txtCodificacion.Name = "txtCodificacion";
            this.txtCodificacion.Size = new System.Drawing.Size(507, 644);
            this.txtCodificacion.TabIndex = 0;
            this.txtCodificacion.Text = "";
            this.txtCodificacion.SelectionChanged += new System.EventHandler(this.txtCodificacion_SelectionChanged);
            this.txtCodificacion.VScroll += new System.EventHandler(this.txtCodificacion_VScroll);
            this.txtCodificacion.FontChanged += new System.EventHandler(this.txtCodificacion_FontChanged);
            this.txtCodificacion.TextChanged += new System.EventHandler(this.txtCodificacion_TextChanged);
            // 
            // btnCompilar
            // 
            this.btnCompilar.BackColor = System.Drawing.Color.LightGreen;
            this.btnCompilar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCompilar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompilar.Location = new System.Drawing.Point(572, 296);
            this.btnCompilar.Name = "btnCompilar";
            this.btnCompilar.Size = new System.Drawing.Size(106, 54);
            this.btnCompilar.TabIndex = 1;
            this.btnCompilar.Text = "Compilar";
            this.btnCompilar.UseVisualStyleBackColor = false;
            this.btnCompilar.Click += new System.EventHandler(this.btnCompilar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(572, 356);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(106, 54);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNumeracionCompilacion);
            this.groupBox2.Controls.Add(this.txtCompilacion);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(684, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 678);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compilacion";
            // 
            // txtNumeracionCompilacion
            // 
            this.txtNumeracionCompilacion.BackColor = System.Drawing.Color.LightGray;
            this.txtNumeracionCompilacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeracionCompilacion.Location = new System.Drawing.Point(6, 28);
            this.txtNumeracionCompilacion.Name = "txtNumeracionCompilacion";
            this.txtNumeracionCompilacion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtNumeracionCompilacion.Size = new System.Drawing.Size(50, 644);
            this.txtNumeracionCompilacion.TabIndex = 1001;
            this.txtNumeracionCompilacion.Text = "";
            this.txtNumeracionCompilacion.FontChanged += new System.EventHandler(this.txtNumeracionCompilacion_FontChanged);
            this.txtNumeracionCompilacion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNumeracionCompilacion_MouseDown);
            // 
            // txtCompilacion
            // 
            this.txtCompilacion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCompilacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCompilacion.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompilacion.Location = new System.Drawing.Point(41, 28);
            this.txtCompilacion.Name = "txtCompilacion";
            this.txtCompilacion.ReadOnly = true;
            this.txtCompilacion.Size = new System.Drawing.Size(507, 644);
            this.txtCompilacion.TabIndex = 3;
            this.txtCompilacion.Text = "";
            this.txtCompilacion.SelectionChanged += new System.EventHandler(this.txtCompilacion_SelectionChanged);
            this.txtCompilacion.VScroll += new System.EventHandler(this.txtCompilacion_VScroll);
            this.txtCompilacion.FontChanged += new System.EventHandler(this.txtCompilacion_FontChanged);
            this.txtCompilacion.TextChanged += new System.EventHandler(this.txtCompilacion_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvIdentificadores);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 761);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(611, 219);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tabla de identificadores";
            // 
            // dgvIdentificadores
            // 
            this.dgvIdentificadores.AllowUserToAddRows = false;
            this.dgvIdentificadores.AllowUserToDeleteRows = false;
            this.dgvIdentificadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIdentificadores.BackgroundColor = System.Drawing.Color.White;
            this.dgvIdentificadores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvIdentificadores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvIdentificadores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(151)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(151)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIdentificadores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIdentificadores.ColumnHeadersHeight = 40;
            this.dgvIdentificadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDIdentificador,
            this.Valor});
            this.dgvIdentificadores.EnableHeadersVisualStyles = false;
            this.dgvIdentificadores.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvIdentificadores.Location = new System.Drawing.Point(6, 28);
            this.dgvIdentificadores.Name = "dgvIdentificadores";
            this.dgvIdentificadores.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(100)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIdentificadores.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIdentificadores.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvIdentificadores.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIdentificadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIdentificadores.Size = new System.Drawing.Size(599, 185);
            this.dgvIdentificadores.TabIndex = 0;
            // 
            // IDIdentificador
            // 
            this.IDIdentificador.HeaderText = "ID Identificador";
            this.IDIdentificador.Name = "IDIdentificador";
            this.IDIdentificador.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvErrores);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(632, 761);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(609, 219);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tabla de Errores";
            // 
            // dgvErrores
            // 
            this.dgvErrores.AllowUserToAddRows = false;
            this.dgvErrores.AllowUserToDeleteRows = false;
            this.dgvErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvErrores.BackgroundColor = System.Drawing.Color.White;
            this.dgvErrores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvErrores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvErrores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(66)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(66)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErrores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvErrores.ColumnHeadersHeight = 40;
            this.dgvErrores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TokenError,
            this.Linea,
            this.Descripcion});
            this.dgvErrores.EnableHeadersVisualStyles = false;
            this.dgvErrores.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvErrores.Location = new System.Drawing.Point(6, 28);
            this.dgvErrores.Name = "dgvErrores";
            this.dgvErrores.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(100)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErrores.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvErrores.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvErrores.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvErrores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrores.Size = new System.Drawing.Size(599, 185);
            this.dgvErrores.TabIndex = 1;
            // 
            // TokenError
            // 
            this.TokenError.HeaderText = "Token Error";
            this.TokenError.Name = "TokenError";
            this.TokenError.ReadOnly = true;
            // 
            // Linea
            // 
            this.Linea.HeaderText = "Linea";
            this.Linea.Name = "Linea";
            this.Linea.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // btnGuardarArchivoToken
            // 
            this.btnGuardarArchivoToken.BackColor = System.Drawing.Color.LightGreen;
            this.btnGuardarArchivoToken.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarArchivoToken.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarArchivoToken.Location = new System.Drawing.Point(1112, 701);
            this.btnGuardarArchivoToken.Name = "btnGuardarArchivoToken";
            this.btnGuardarArchivoToken.Size = new System.Drawing.Size(120, 54);
            this.btnGuardarArchivoToken.TabIndex = 5;
            this.btnGuardarArchivoToken.Text = "Guardar archivo de tokens";
            this.btnGuardarArchivoToken.UseVisualStyleBackColor = false;
            this.btnGuardarArchivoToken.Click += new System.EventHandler(this.btnGuardarArchivoToken_Click);
            // 
            // btnGuardarCodigo
            // 
            this.btnGuardarCodigo.BackColor = System.Drawing.Color.LightGreen;
            this.btnGuardarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarCodigo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCodigo.Location = new System.Drawing.Point(12, 696);
            this.btnGuardarCodigo.Name = "btnGuardarCodigo";
            this.btnGuardarCodigo.Size = new System.Drawing.Size(120, 54);
            this.btnGuardarCodigo.TabIndex = 6;
            this.btnGuardarCodigo.Text = "Guardar código";
            this.btnGuardarCodigo.UseVisualStyleBackColor = false;
            this.btnGuardarCodigo.Click += new System.EventHandler(this.btnGuardarCodigo_Click);
            // 
            // btnCargarCodigo
            // 
            this.btnCargarCodigo.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCargarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargarCodigo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarCodigo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCargarCodigo.Location = new System.Drawing.Point(138, 696);
            this.btnCargarCodigo.Name = "btnCargarCodigo";
            this.btnCargarCodigo.Size = new System.Drawing.Size(120, 54);
            this.btnCargarCodigo.TabIndex = 7;
            this.btnCargarCodigo.Text = "Cargar codigo";
            this.btnCargarCodigo.UseVisualStyleBackColor = false;
            this.btnCargarCodigo.Click += new System.EventHandler(this.btnCargarCodigo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1253, 992);
            this.Controls.Add(this.btnCargarCodigo);
            this.Controls.Add(this.btnGuardarCodigo);
            this.Controls.Add(this.btnGuardarArchivoToken);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCompilar);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compilador ALscript";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtCodificacion;
        private System.Windows.Forms.Button btnCompilar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtCompilacion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvIdentificadores;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridView dgvErrores;
        private System.Windows.Forms.RichTextBox txtNumeracionCodificacion;
        private System.Windows.Forms.RichTextBox txtNumeracionCompilacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TokenError;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.Button btnGuardarArchivoToken;
        private System.Windows.Forms.Button btnGuardarCodigo;
        private System.Windows.Forms.Button btnCargarCodigo;
    }
}

