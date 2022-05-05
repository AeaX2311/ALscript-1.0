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
        #endregion
    }
}
