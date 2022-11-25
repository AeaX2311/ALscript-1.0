
namespace Interfaz {
    partial class FormPrincipal {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.gpbCodificacion = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtCodificacion = new System.Windows.Forms.RichTextBox();
            this.txtNumeracionCodificacion = new System.Windows.Forms.RichTextBox();
            this.btnCompilar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.gpbLexico = new System.Windows.Forms.GroupBox();
            this.txtLexico = new System.Windows.Forms.RichTextBox();
            this.txtNumeracionCompilacion = new System.Windows.Forms.RichTextBox();
            this.gpbIdentificadores = new System.Windows.Forms.GroupBox();
            this.dgvIdentificadores = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbErrores = new System.Windows.Forms.GroupBox();
            this.dgvErrores = new System.Windows.Forms.DataGridView();
            this.TokenError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPalabra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardarArchivoToken = new System.Windows.Forms.Button();
            this.btnGuardarCodigo = new System.Windows.Forms.Button();
            this.btnCargarCodigo = new System.Windows.Forms.Button();
            this.gpbSintactico = new System.Windows.Forms.GroupBox();
            this.txtSintaxis = new System.Windows.Forms.RichTextBox();
            this.btnSintaxis = new System.Windows.Forms.Button();
            this.pnBotones = new System.Windows.Forms.Panel();
            this.btnEnsamblador = new System.Windows.Forms.Button();
            this.btnRunAll = new System.Windows.Forms.Button();
            this.btnTripletas = new System.Windows.Forms.Button();
            this.btnSemantica = new System.Windows.Forms.Button();
            this.secundarioNDivisiones = new System.Windows.Forms.TableLayoutPanel();
            this.gpbTripletas = new System.Windows.Forms.GroupBox();
            this.txtTripletas = new System.Windows.Forms.RichTextBox();
            this.gpbSemantica = new System.Windows.Forms.GroupBox();
            this.txtSemantica = new System.Windows.Forms.RichTextBox();
            this.mainDosDivisiones = new System.Windows.Forms.TableLayoutPanel();
            this.gpbCodificacion.SuspendLayout();
            this.gpbLexico.SuspendLayout();
            this.gpbIdentificadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).BeginInit();
            this.gpbErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
            this.gpbSintactico.SuspendLayout();
            this.pnBotones.SuspendLayout();
            this.secundarioNDivisiones.SuspendLayout();
            this.gpbTripletas.SuspendLayout();
            this.gpbSemantica.SuspendLayout();
            this.mainDosDivisiones.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbCodificacion
            // 
            this.gpbCodificacion.Controls.Add(this.lblInfo);
            this.gpbCodificacion.Controls.Add(this.txtCodificacion);
            this.gpbCodificacion.Controls.Add(this.txtNumeracionCodificacion);
            this.gpbCodificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbCodificacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbCodificacion.Location = new System.Drawing.Point(3, 3);
            this.gpbCodificacion.Name = "gpbCodificacion";
            this.gpbCodificacion.Size = new System.Drawing.Size(425, 692);
            this.gpbCodificacion.TabIndex = 0;
            this.gpbCodificacion.TabStop = false;
            this.gpbCodificacion.Text = "Codificación";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Teal;
            this.lblInfo.Location = new System.Drawing.Point(361, 646);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(58, 40);
            this.lblInfo.TabIndex = 1001;
            this.lblInfo.Text = "🖋️";
            // 
            // txtCodificacion
            // 
            this.txtCodificacion.AcceptsTab = true;
            this.txtCodificacion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCodificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodificacion.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodificacion.ForeColor = System.Drawing.Color.Black;
            this.txtCodificacion.Location = new System.Drawing.Point(53, 25);
            this.txtCodificacion.Name = "txtCodificacion";
            this.txtCodificacion.Size = new System.Drawing.Size(369, 664);
            this.txtCodificacion.TabIndex = 1;
            this.txtCodificacion.TabStop = false;
            this.txtCodificacion.Text = "";
            this.txtCodificacion.WordWrap = false;
            this.txtCodificacion.SelectionChanged += new System.EventHandler(this.txtCodificacion_SelectionChanged);
            this.txtCodificacion.VScroll += new System.EventHandler(this.txtCodificacion_VScroll);
            this.txtCodificacion.FontChanged += new System.EventHandler(this.txtCodificacion_FontChanged);
            this.txtCodificacion.TextChanged += new System.EventHandler(this.txtCodificacion_TextChanged);
            // 
            // txtNumeracionCodificacion
            // 
            this.txtNumeracionCodificacion.BackColor = System.Drawing.Color.LightGray;
            this.txtNumeracionCodificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeracionCodificacion.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtNumeracionCodificacion.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeracionCodificacion.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtNumeracionCodificacion.Location = new System.Drawing.Point(3, 25);
            this.txtNumeracionCodificacion.Name = "txtNumeracionCodificacion";
            this.txtNumeracionCodificacion.ReadOnly = true;
            this.txtNumeracionCodificacion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtNumeracionCodificacion.Size = new System.Drawing.Size(50, 664);
            this.txtNumeracionCodificacion.TabIndex = 1000;
            this.txtNumeracionCodificacion.TabStop = false;
            this.txtNumeracionCodificacion.Text = "";
            this.txtNumeracionCodificacion.FontChanged += new System.EventHandler(this.txtLineaCodigo_FontChanged);
            this.txtNumeracionCodificacion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtLineaCodigo_MouseDown);
            // 
            // btnCompilar
            // 
            this.btnCompilar.BackColor = System.Drawing.Color.LightGreen;
            this.btnCompilar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCompilar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCompilar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompilar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompilar.Location = new System.Drawing.Point(10, 10);
            this.btnCompilar.Name = "btnCompilar";
            this.btnCompilar.Size = new System.Drawing.Size(112, 48);
            this.btnCompilar.TabIndex = 2;
            this.btnCompilar.Text = "✔️ Léxico";
            this.btnCompilar.UseVisualStyleBackColor = false;
            this.btnCompilar.Click += new System.EventHandler(this.btnCompilar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLimpiar.Location = new System.Drawing.Point(1112, 10);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(112, 48);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "🧹 Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // gpbLexico
            // 
            this.gpbLexico.Controls.Add(this.txtLexico);
            this.gpbLexico.Controls.Add(this.txtNumeracionCompilacion);
            this.gpbLexico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbLexico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbLexico.Location = new System.Drawing.Point(3, 3);
            this.gpbLexico.Name = "gpbLexico";
            this.gpbLexico.Size = new System.Drawing.Size(392, 288);
            this.gpbLexico.TabIndex = 10;
            this.gpbLexico.TabStop = false;
            this.gpbLexico.Text = "Léxico";
            // 
            // txtLexico
            // 
            this.txtLexico.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLexico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLexico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLexico.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLexico.ForeColor = System.Drawing.Color.Black;
            this.txtLexico.Location = new System.Drawing.Point(53, 25);
            this.txtLexico.Name = "txtLexico";
            this.txtLexico.ReadOnly = true;
            this.txtLexico.Size = new System.Drawing.Size(336, 260);
            this.txtLexico.TabIndex = 9;
            this.txtLexico.Text = "";
            this.txtLexico.WordWrap = false;
            this.txtLexico.SelectionChanged += new System.EventHandler(this.txtCompilacion_SelectionChanged);
            this.txtLexico.VScroll += new System.EventHandler(this.txtCompilacion_VScroll);
            this.txtLexico.FontChanged += new System.EventHandler(this.txtCompilacion_FontChanged);
            this.txtLexico.TextChanged += new System.EventHandler(this.txtCompilacion_TextChanged);
            // 
            // txtNumeracionCompilacion
            // 
            this.txtNumeracionCompilacion.BackColor = System.Drawing.Color.LightGray;
            this.txtNumeracionCompilacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeracionCompilacion.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtNumeracionCompilacion.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeracionCompilacion.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtNumeracionCompilacion.Location = new System.Drawing.Point(3, 25);
            this.txtNumeracionCompilacion.Name = "txtNumeracionCompilacion";
            this.txtNumeracionCompilacion.ReadOnly = true;
            this.txtNumeracionCompilacion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtNumeracionCompilacion.Size = new System.Drawing.Size(50, 260);
            this.txtNumeracionCompilacion.TabIndex = 1001;
            this.txtNumeracionCompilacion.Text = "";
            this.txtNumeracionCompilacion.FontChanged += new System.EventHandler(this.txtNumeracionCompilacion_FontChanged);
            this.txtNumeracionCompilacion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNumeracionCompilacion_MouseDown);
            // 
            // gpbIdentificadores
            // 
            this.gpbIdentificadores.Controls.Add(this.dgvIdentificadores);
            this.gpbIdentificadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbIdentificadores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbIdentificadores.Location = new System.Drawing.Point(3, 591);
            this.gpbIdentificadores.Name = "gpbIdentificadores";
            this.gpbIdentificadores.Size = new System.Drawing.Size(392, 98);
            this.gpbIdentificadores.TabIndex = 7;
            this.gpbIdentificadores.TabStop = false;
            this.gpbIdentificadores.Text = "Tabla de identificadores";
            // 
            // dgvIdentificadores
            // 
            this.dgvIdentificadores.AllowUserToAddRows = false;
            this.dgvIdentificadores.AllowUserToDeleteRows = false;
            this.dgvIdentificadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIdentificadores.BackgroundColor = System.Drawing.Color.White;
            this.dgvIdentificadores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvIdentificadores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
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
            this.Column1,
            this.IDIdentificador,
            this.TipoDato,
            this.Valor});
            this.dgvIdentificadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIdentificadores.EnableHeadersVisualStyles = false;
            this.dgvIdentificadores.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvIdentificadores.Location = new System.Drawing.Point(3, 25);
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
            this.dgvIdentificadores.Size = new System.Drawing.Size(386, 70);
            this.dgvIdentificadores.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Token";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // IDIdentificador
            // 
            this.IDIdentificador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDIdentificador.HeaderText = "Nombre Identificador";
            this.IDIdentificador.Name = "IDIdentificador";
            this.IDIdentificador.ReadOnly = true;
            // 
            // TipoDato
            // 
            this.TipoDato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TipoDato.HeaderText = "Tipo de dato";
            this.TipoDato.Name = "TipoDato";
            this.TipoDato.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // gpbErrores
            // 
            this.gpbErrores.Controls.Add(this.dgvErrores);
            this.gpbErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbErrores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbErrores.Location = new System.Drawing.Point(401, 591);
            this.gpbErrores.Name = "gpbErrores";
            this.gpbErrores.Size = new System.Drawing.Size(393, 98);
            this.gpbErrores.TabIndex = 9;
            this.gpbErrores.TabStop = false;
            this.gpbErrores.Text = "Tabla de Errores";
            // 
            // dgvErrores
            // 
            this.dgvErrores.AllowUserToAddRows = false;
            this.dgvErrores.AllowUserToDeleteRows = false;
            this.dgvErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvErrores.BackgroundColor = System.Drawing.Color.White;
            this.dgvErrores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvErrores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
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
            this.Descripcion,
            this.clmnPalabra});
            this.dgvErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErrores.EnableHeadersVisualStyles = false;
            this.dgvErrores.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvErrores.Location = new System.Drawing.Point(3, 25);
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
            this.dgvErrores.Size = new System.Drawing.Size(387, 70);
            this.dgvErrores.TabIndex = 10;
            // 
            // TokenError
            // 
            this.TokenError.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TokenError.FillWeight = 68.35763F;
            this.TokenError.HeaderText = "Token";
            this.TokenError.Name = "TokenError";
            this.TokenError.ReadOnly = true;
            // 
            // Linea
            // 
            this.Linea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Linea.FillWeight = 60.9137F;
            this.Linea.HeaderText = "Linea";
            this.Linea.Name = "Linea";
            this.Linea.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.FillWeight = 170.7287F;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // clmnPalabra
            // 
            this.clmnPalabra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnPalabra.HeaderText = "Palabra";
            this.clmnPalabra.Name = "clmnPalabra";
            this.clmnPalabra.ReadOnly = true;
            // 
            // btnGuardarArchivoToken
            // 
            this.btnGuardarArchivoToken.BackColor = System.Drawing.Color.LightGreen;
            this.btnGuardarArchivoToken.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGuardarArchivoToken.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarArchivoToken.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarArchivoToken.Location = new System.Drawing.Point(979, 10);
            this.btnGuardarArchivoToken.Name = "btnGuardarArchivoToken";
            this.btnGuardarArchivoToken.Size = new System.Drawing.Size(133, 48);
            this.btnGuardarArchivoToken.TabIndex = 6;
            this.btnGuardarArchivoToken.Text = "⏬ Guardar archivo de tokens";
            this.btnGuardarArchivoToken.UseVisualStyleBackColor = false;
            this.btnGuardarArchivoToken.Click += new System.EventHandler(this.btnGuardarArchivoToken_Click);
            // 
            // btnGuardarCodigo
            // 
            this.btnGuardarCodigo.BackColor = System.Drawing.Color.LightGreen;
            this.btnGuardarCodigo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGuardarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarCodigo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCodigo.Location = new System.Drawing.Point(711, 10);
            this.btnGuardarCodigo.Name = "btnGuardarCodigo";
            this.btnGuardarCodigo.Size = new System.Drawing.Size(136, 48);
            this.btnGuardarCodigo.TabIndex = 4;
            this.btnGuardarCodigo.Text = "⏬ Guardar código";
            this.btnGuardarCodigo.UseVisualStyleBackColor = false;
            this.btnGuardarCodigo.Click += new System.EventHandler(this.btnGuardarCodigo_Click);
            // 
            // btnCargarCodigo
            // 
            this.btnCargarCodigo.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCargarCodigo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCargarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargarCodigo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarCodigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCargarCodigo.Location = new System.Drawing.Point(847, 10);
            this.btnCargarCodigo.Name = "btnCargarCodigo";
            this.btnCargarCodigo.Size = new System.Drawing.Size(132, 48);
            this.btnCargarCodigo.TabIndex = 5;
            this.btnCargarCodigo.Text = "⏫ Cargar código";
            this.btnCargarCodigo.UseVisualStyleBackColor = false;
            this.btnCargarCodigo.Click += new System.EventHandler(this.btnCargarCodigo_Click);
            // 
            // gpbSintactico
            // 
            this.gpbSintactico.Controls.Add(this.txtSintaxis);
            this.gpbSintactico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbSintactico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbSintactico.Location = new System.Drawing.Point(401, 3);
            this.gpbSintactico.Name = "gpbSintactico";
            this.gpbSintactico.Size = new System.Drawing.Size(393, 288);
            this.gpbSintactico.TabIndex = 1002;
            this.gpbSintactico.TabStop = false;
            this.gpbSintactico.Text = "Sintáctico";
            // 
            // txtSintaxis
            // 
            this.txtSintaxis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSintaxis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSintaxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSintaxis.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSintaxis.ForeColor = System.Drawing.Color.Black;
            this.txtSintaxis.Location = new System.Drawing.Point(3, 25);
            this.txtSintaxis.Name = "txtSintaxis";
            this.txtSintaxis.ReadOnly = true;
            this.txtSintaxis.Size = new System.Drawing.Size(387, 260);
            this.txtSintaxis.TabIndex = 9;
            this.txtSintaxis.Text = "";
            this.txtSintaxis.WordWrap = false;
            // 
            // btnSintaxis
            // 
            this.btnSintaxis.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSintaxis.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSintaxis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSintaxis.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSintaxis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSintaxis.Location = new System.Drawing.Point(122, 10);
            this.btnSintaxis.Name = "btnSintaxis";
            this.btnSintaxis.Size = new System.Drawing.Size(112, 48);
            this.btnSintaxis.TabIndex = 1003;
            this.btnSintaxis.Text = "✔️ Sintáxis";
            this.btnSintaxis.UseVisualStyleBackColor = false;
            this.btnSintaxis.Click += new System.EventHandler(this.btnSintaxis_Click);
            // 
            // pnBotones
            // 
            this.pnBotones.Controls.Add(this.btnRunAll);
            this.pnBotones.Controls.Add(this.btnEnsamblador);
            this.pnBotones.Controls.Add(this.btnTripletas);
            this.pnBotones.Controls.Add(this.btnSemantica);
            this.pnBotones.Controls.Add(this.btnSintaxis);
            this.pnBotones.Controls.Add(this.btnCompilar);
            this.pnBotones.Controls.Add(this.btnGuardarCodigo);
            this.pnBotones.Controls.Add(this.btnCargarCodigo);
            this.pnBotones.Controls.Add(this.btnGuardarArchivoToken);
            this.pnBotones.Controls.Add(this.btnLimpiar);
            this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBotones.Location = new System.Drawing.Point(0, 0);
            this.pnBotones.Name = "pnBotones";
            this.pnBotones.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.pnBotones.Size = new System.Drawing.Size(1234, 63);
            this.pnBotones.TabIndex = 1004;
            // 
            // btnEnsamblador
            // 
            this.btnEnsamblador.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnEnsamblador.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEnsamblador.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnsamblador.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnsamblador.Location = new System.Drawing.Point(458, 10);
            this.btnEnsamblador.Name = "btnEnsamblador";
            this.btnEnsamblador.Size = new System.Drawing.Size(112, 48);
            this.btnEnsamblador.TabIndex = 1007;
            this.btnEnsamblador.Text = "✔️ Assembly (MASM)";
            this.btnEnsamblador.UseVisualStyleBackColor = false;
            this.btnEnsamblador.Click += new System.EventHandler(this.btnEnsamblador_Click);
            // 
            // btnRunAll
            // 
            this.btnRunAll.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnRunAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRunAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRunAll.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunAll.Location = new System.Drawing.Point(570, 10);
            this.btnRunAll.Name = "btnRunAll";
            this.btnRunAll.Size = new System.Drawing.Size(118, 48);
            this.btnRunAll.TabIndex = 1005;
            this.btnRunAll.Text = "✔️ Ejecutar todo";
            this.btnRunAll.UseVisualStyleBackColor = false;
            this.btnRunAll.Click += new System.EventHandler(this.btnRunAll_Click);
            // 
            // btnTripletas
            // 
            this.btnTripletas.BackColor = System.Drawing.Color.Khaki;
            this.btnTripletas.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTripletas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTripletas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTripletas.Location = new System.Drawing.Point(346, 10);
            this.btnTripletas.Name = "btnTripletas";
            this.btnTripletas.Size = new System.Drawing.Size(112, 48);
            this.btnTripletas.TabIndex = 1006;
            this.btnTripletas.Text = "✔️ Código intermedio";
            this.btnTripletas.UseVisualStyleBackColor = false;
            this.btnTripletas.Click += new System.EventHandler(this.btnTripletas_Click);
            // 
            // btnSemantica
            // 
            this.btnSemantica.BackColor = System.Drawing.Color.Violet;
            this.btnSemantica.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSemantica.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSemantica.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSemantica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSemantica.Location = new System.Drawing.Point(234, 10);
            this.btnSemantica.Name = "btnSemantica";
            this.btnSemantica.Size = new System.Drawing.Size(112, 48);
            this.btnSemantica.TabIndex = 1004;
            this.btnSemantica.Text = "✔️ Semántica";
            this.btnSemantica.UseVisualStyleBackColor = false;
            this.btnSemantica.Click += new System.EventHandler(this.btnSemantica_Click);
            // 
            // secundarioNDivisiones
            // 
            this.secundarioNDivisiones.ColumnCount = 2;
            this.secundarioNDivisiones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.secundarioNDivisiones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.secundarioNDivisiones.Controls.Add(this.gpbTripletas, 1, 1);
            this.secundarioNDivisiones.Controls.Add(this.gpbSemantica, 0, 1);
            this.secundarioNDivisiones.Controls.Add(this.gpbIdentificadores, 0, 2);
            this.secundarioNDivisiones.Controls.Add(this.gpbErrores, 1, 2);
            this.secundarioNDivisiones.Controls.Add(this.gpbSintactico, 1, 0);
            this.secundarioNDivisiones.Controls.Add(this.gpbLexico, 0, 0);
            this.secundarioNDivisiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secundarioNDivisiones.Location = new System.Drawing.Point(434, 3);
            this.secundarioNDivisiones.Name = "secundarioNDivisiones";
            this.secundarioNDivisiones.RowCount = 3;
            this.secundarioNDivisiones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.secundarioNDivisiones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.secundarioNDivisiones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.secundarioNDivisiones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.secundarioNDivisiones.Size = new System.Drawing.Size(797, 692);
            this.secundarioNDivisiones.TabIndex = 1005;
            // 
            // gpbTripletas
            // 
            this.gpbTripletas.Controls.Add(this.txtTripletas);
            this.gpbTripletas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbTripletas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbTripletas.Location = new System.Drawing.Point(401, 297);
            this.gpbTripletas.Name = "gpbTripletas";
            this.gpbTripletas.Size = new System.Drawing.Size(393, 288);
            this.gpbTripletas.TabIndex = 1004;
            this.gpbTripletas.TabStop = false;
            this.gpbTripletas.Text = "Código intermedio";
            // 
            // txtTripletas
            // 
            this.txtTripletas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTripletas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTripletas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTripletas.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTripletas.ForeColor = System.Drawing.Color.Black;
            this.txtTripletas.Location = new System.Drawing.Point(3, 25);
            this.txtTripletas.Name = "txtTripletas";
            this.txtTripletas.ReadOnly = true;
            this.txtTripletas.Size = new System.Drawing.Size(387, 260);
            this.txtTripletas.TabIndex = 9;
            this.txtTripletas.Text = "";
            this.txtTripletas.WordWrap = false;
            // 
            // gpbSemantica
            // 
            this.gpbSemantica.Controls.Add(this.txtSemantica);
            this.gpbSemantica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbSemantica.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbSemantica.Location = new System.Drawing.Point(3, 297);
            this.gpbSemantica.Name = "gpbSemantica";
            this.gpbSemantica.Size = new System.Drawing.Size(392, 288);
            this.gpbSemantica.TabIndex = 1003;
            this.gpbSemantica.TabStop = false;
            this.gpbSemantica.Text = "Semántico";
            // 
            // txtSemantica
            // 
            this.txtSemantica.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSemantica.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSemantica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSemantica.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSemantica.ForeColor = System.Drawing.Color.Black;
            this.txtSemantica.Location = new System.Drawing.Point(3, 25);
            this.txtSemantica.Name = "txtSemantica";
            this.txtSemantica.ReadOnly = true;
            this.txtSemantica.Size = new System.Drawing.Size(386, 260);
            this.txtSemantica.TabIndex = 9;
            this.txtSemantica.Text = "";
            this.txtSemantica.WordWrap = false;
            // 
            // mainDosDivisiones
            // 
            this.mainDosDivisiones.ColumnCount = 2;
            this.mainDosDivisiones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.mainDosDivisiones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.mainDosDivisiones.Controls.Add(this.secundarioNDivisiones, 1, 0);
            this.mainDosDivisiones.Controls.Add(this.gpbCodificacion, 0, 0);
            this.mainDosDivisiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDosDivisiones.Location = new System.Drawing.Point(0, 63);
            this.mainDosDivisiones.Name = "mainDosDivisiones";
            this.mainDosDivisiones.RowCount = 1;
            this.mainDosDivisiones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainDosDivisiones.Size = new System.Drawing.Size(1234, 698);
            this.mainDosDivisiones.TabIndex = 1006;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1234, 761);
            this.Controls.Add(this.mainDosDivisiones);
            this.Controls.Add(this.pnBotones);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1250, 730);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compilador ALscript";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.gpbCodificacion.ResumeLayout(false);
            this.gpbCodificacion.PerformLayout();
            this.gpbLexico.ResumeLayout(false);
            this.gpbIdentificadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificadores)).EndInit();
            this.gpbErrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            this.gpbSintactico.ResumeLayout(false);
            this.pnBotones.ResumeLayout(false);
            this.secundarioNDivisiones.ResumeLayout(false);
            this.gpbTripletas.ResumeLayout(false);
            this.gpbSemantica.ResumeLayout(false);
            this.mainDosDivisiones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbCodificacion;
        private System.Windows.Forms.RichTextBox txtCodificacion;
        private System.Windows.Forms.Button btnCompilar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox gpbLexico;
        private System.Windows.Forms.RichTextBox txtLexico;
        private System.Windows.Forms.GroupBox gpbIdentificadores;
        private System.Windows.Forms.DataGridView dgvIdentificadores;
        private System.Windows.Forms.GroupBox gpbErrores;
        private System.Windows.Forms.DataGridView dgvErrores;
        private System.Windows.Forms.RichTextBox txtNumeracionCodificacion;
        private System.Windows.Forms.Button btnGuardarArchivoToken;
        private System.Windows.Forms.Button btnGuardarCodigo;
        private System.Windows.Forms.Button btnCargarCodigo;
        private System.Windows.Forms.RichTextBox txtNumeracionCompilacion;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.GroupBox gpbSintactico;
        private System.Windows.Forms.RichTextBox txtSintaxis;
        private System.Windows.Forms.Button btnSintaxis;
        private System.Windows.Forms.Panel pnBotones;
        private System.Windows.Forms.TableLayoutPanel secundarioNDivisiones;
        private System.Windows.Forms.TableLayoutPanel mainDosDivisiones;
        private System.Windows.Forms.Button btnSemantica;
        private System.Windows.Forms.GroupBox gpbSemantica;
        private System.Windows.Forms.RichTextBox txtSemantica;
        private System.Windows.Forms.Button btnRunAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TokenError;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPalabra;
        private System.Windows.Forms.Button btnTripletas;
        private System.Windows.Forms.GroupBox gpbTripletas;
        private System.Windows.Forms.RichTextBox txtTripletas;
        private System.Windows.Forms.Button btnEnsamblador;
    }
}

