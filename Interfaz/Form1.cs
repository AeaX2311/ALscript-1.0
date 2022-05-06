using Interfaz.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            //Iniciamos los richtextbox con numeracion de linea
            txtNumeracionCodificacion.Font = txtCodificacion.Font;
            txtCodificacion.Select();
            AddLineNumbersLineaCodigo();
            txtCompilacion.Font = txtCompilacion.Font;
            txtCompilacion.Select();
            AddLineNumbersCompilacion();


            dgvIdentificadores.Rows.Add("1", "1");
            dgvIdentificadores.Rows.Add("1", "1");
            dgvIdentificadores.Rows.Add("1", "1");

            dgvErrores.Rows.Add("1", "1","hola");
            dgvErrores.Rows.Add("1", "1", "hola");
            dgvErrores.Rows.Add("1", "1", "hola");
        }

        #region Acciones/Eventos
        private void btnLimpiar_Click(object sender, EventArgs e) {
            txtCodificacion.Text = txtCompilacion.Text = "";
            txtCodificacion.Enabled = txtCompilacion.Enabled = true;
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

            txtCodificacion.Enabled = txtCompilacion.Enabled = false;
        }
        #endregion

        

        #region Metodos

        /// <summary>
        /// Ejecuta el procedimiento principal de compilacion, tomando lo que se encuentre en la codificacion ingresada por el usuario.
        /// </summary>
        /// <returns></returns>
        private bool compilar() {
            bool tieneErrores = false;



            return tieneErrores;
        }

        private void AddLineNumbersLineaCodigo()
        {
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

        private void AddLineNumbersCompilacion()
        {
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
        private int getWidthLineaCodigo()
        {
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

        private int getWidthCompilacion()
        {
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
    }
}
