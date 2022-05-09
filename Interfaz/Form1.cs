using Interfaz.Clases;
using Interfaz.Clases.IO;
using Interfaz.Facade;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Interfaz {
    public partial class Form1 : Form {
        MatrizFacade facade;

        readonly SaveFileDialog saveFileDialog = new SaveFileDialog {
            Title = "Guardar archivo de tokens",
            Filter = "ALScript (*.alstf)|*.alstf",
            DefaultExt = "alstf",
            AddExtension = true,
            FileName = "ALScript Token File"
        };

        readonly OpenFileDialog openFileDialog = new OpenFileDialog() {
            AddExtension = true,
            Filter = "ALScript (*.alscript)|*.alscript",
            DefaultExt = "alscript"
        };

        public Form1() {
            InitializeComponent();

                ////Iniciamos los richtextbox con numeracion de linea
            txtNumeracionCodificacion.Font = txtCodificacion.Font;
            txtCodificacion.Select();
            AddLineNumbersLineaCodigo();
            txtCompilacion.Font = txtCompilacion.Font;
            txtCompilacion.Select();
            AddLineNumbersCompilacion();
        }

        #region Acciones Click
        private void btnLimpiar_Click(object sender, EventArgs e) {
            txtCodificacion.Text = txtCompilacion.Text = "";
            txtCodificacion.ReadOnly = false;
            dgvIdentificadores.Rows.Clear();
            dgvErrores.Rows.Clear();
        }

        private void btnCompilar_Click(object sender, EventArgs e) {
            if(string.IsNullOrEmpty(txtCodificacion.Text)) {
                MessageBox.Show("Favor de generar un codigo para poderlo compilar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(compilar())
                MessageBox.Show("Programa compilado con algunos errores, favor de verificar tabla de errores.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Programa compilado correctamente.", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtCodificacion.ReadOnly = true;
        }
        #endregion        

        #region Metodos
        /// <summary>
        /// Ejecuta el procedimiento principal de compilacion, tomando lo que se encuentre en la codificacion ingresada por el usuario.
        /// </summary>
        /// <returns></returns>
        private bool compilar() {
            bool tieneErrores = false;
            facade = new MatrizFacade();

            Compilado resultado = facade.compilarCodigo(txtCodificacion.Text);

            txtCompilacion.Text = resultado.CodigoCompilado;

            if(resultado.Errores.Count > 0) {
                tieneErrores = true;
                cargarErrores(resultado.Errores);
            }

            if(resultado.Identificadores.Count > 0) {
                cargarIdentificadores(resultado.Identificadores);
            }

            return tieneErrores;
        }

        private void cargarErrores(List<Error> errores) {
            dgvErrores.Rows.Clear();

            foreach(Error e in errores) {
                dgvErrores.Rows.Add(e.Token, e.Linea, facade.obtenerDescripcionError(e));
            }
        }

        private void cargarIdentificadores(List<Identificador> identificadores) {
            dgvIdentificadores.Rows.Clear();

            //Verificar repetidos
            foreach(Identificador i in identificadores) {
                dgvIdentificadores.Rows.Add(i.Nombre, i.Valor);
            }
        }
        
        private void AddLineNumbersLineaCodigo() {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);
            // get First Index & First Line from the richTextBoxs  
            int First_Index = txtCodificacion.GetCharIndexFromPosition(pt);
            int First_Line = txtCodificacion.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from the richTextBoxs    
            int Last_Index = txtCodificacion.GetCharIndexFromPosition(pt);
            int Last_Line = txtCodificacion.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox    
            txtNumeracionCodificacion.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            txtNumeracionCodificacion.Text = "";
            txtNumeracionCodificacion.Width = getWidthLineaCodigo();
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line; i <= Last_Line + 1; i++)
            {
                txtNumeracionCodificacion.Text += i + 1 + "\n";
            }
        }

        private void AddLineNumbersCompilacion() {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);
            // get First Index & First Line from the richTextBoxs  
            int First_Index = txtCompilacion.GetCharIndexFromPosition(pt);
            int First_Line = txtCompilacion.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from the richTextBoxs    
            int Last_Index = txtCompilacion.GetCharIndexFromPosition(pt);
            int Last_Line = txtCompilacion.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox    
            txtNumeracionCompilacion.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            txtNumeracionCompilacion.Text = "";
            txtNumeracionCompilacion.Width = getWidthCompilacion();
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line; i <= Last_Line + 1; i++)
            {
                txtNumeracionCompilacion.Text += i + 1 + "\n";
            }
        }

        private int getWidthLineaCodigo() {
            int w = 25;
            // get total lines of richTextBoxLineaCodigo 
            int line = txtNumeracionCodificacion.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)txtNumeracionCodificacion.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)txtNumeracionCodificacion.Font.Size;
            }
            else
            {
                w = 50 + (int)txtNumeracionCodificacion.Font.Size;
            }

            return w;
        }

        private int getWidthCompilacion() {
            int w = 25;
            // get total lines of richTextBoxCompilacion
            int line = txtNumeracionCompilacion.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)txtNumeracionCompilacion.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)txtNumeracionCompilacion.Font.Size;
            }
            else
            {
                w = 50 + (int)txtNumeracionCompilacion.Font.Size;
            }

            return w;
        }
        #endregion

        #region Eventos
        private void Form1_Resize(object sender, EventArgs e)
        {
            AddLineNumbersLineaCodigo();
            AddLineNumbersCompilacion();
        }

        private void txtCodificacion_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = txtCodificacion.GetPositionFromCharIndex(txtCodificacion.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbersLineaCodigo();
            }
        }

        private void txtCodificacion_VScroll(object sender, EventArgs e)
        {
            txtNumeracionCodificacion.Text = "";
            AddLineNumbersLineaCodigo();
            txtNumeracionCodificacion.Invalidate();
        }

        private void txtCodificacion_TextChanged(object sender, EventArgs e)
        {
            if (txtCodificacion.Text == "")
            {
                AddLineNumbersLineaCodigo();
            }
        }

        private void txtCodificacion_FontChanged(object sender, EventArgs e)
        {
            txtNumeracionCodificacion.Font = txtCodificacion.Font;
            txtCodificacion.Select();
            AddLineNumbersLineaCodigo();
        }

        private void txtLineaCodigo_FontChanged(object sender, EventArgs e)
        {
            txtNumeracionCodificacion.Font = txtCodificacion.Font;
            txtCodificacion.Select();
            AddLineNumbersLineaCodigo();
        }

        private void txtLineaCodigo_MouseDown(object sender, MouseEventArgs e)
        {
            txtCodificacion.Select();
            txtNumeracionCodificacion.DeselectAll();
        }

        private void txtCompilacion_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = txtCompilacion.GetPositionFromCharIndex(txtCompilacion.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbersCompilacion();
            }
        }

        private void txtCompilacion_VScroll(object sender, EventArgs e)
        {
            txtNumeracionCompilacion.Text = "";
            AddLineNumbersCompilacion();
            txtNumeracionCompilacion.Invalidate();
        }

        private void txtCompilacion_TextChanged(object sender, EventArgs e)
        {
            if (txtCompilacion.Text == "")
            {
                AddLineNumbersCompilacion();
            }
        }

        private void txtCompilacion_FontChanged(object sender, EventArgs e)
        {
            txtNumeracionCompilacion.Font = txtCompilacion.Font;
            txtCompilacion.Select();
            AddLineNumbersCompilacion();
        }

        private void txtNumeracionCompilacion_FontChanged(object sender, EventArgs e)
        {
            txtNumeracionCompilacion.Font = txtCompilacion.Font;
            txtCompilacion.Select();
            AddLineNumbersCompilacion();
        }

        private void txtNumeracionCompilacion_MouseDown(object sender, MouseEventArgs e)
        {
            txtCompilacion.Select();
            txtNumeracionCompilacion.DeselectAll();
        }
        #endregion

        private void btnGuardarArchivoToken_Click(object sender, EventArgs e) {
            saveFileDialog.ShowDialog();
            OutputArchivo.Guardar(txtCompilacion.Text, saveFileDialog.FileName);
            MessageBox.Show("¡Archivo de tokens guardado correctamente!", "Guardado", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnGuardarCodigo_Click(object sender, EventArgs e) {
            saveFileDialog.Filter = "ALScript (*.alscript)|*.alscript";
            saveFileDialog.Title = "Guardar codigo";
            saveFileDialog.DefaultExt = "alscript";
            saveFileDialog.FileName = "Codigo Alscript";
            saveFileDialog.AddExtension = true;

            saveFileDialog.ShowDialog();
            OutputArchivo.Guardar(txtCodificacion.Text, saveFileDialog.FileName);
            MessageBox.Show("¡Codigo guardado correctamente!", "Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void btnCargarCodigo_Click(object sender, EventArgs e) {
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                var codigo = OutputArchivo.Cargar(openFileDialog.FileName);
                btnLimpiar.PerformClick();
                txtCodificacion.Text = codigo;
            }
        }
    }
}