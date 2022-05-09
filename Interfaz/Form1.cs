using Interfaz.Clases;
using Interfaz.Connection;
using Interfaz.Facade;
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
        MatrizFacade facade;

        public Form1() {
            InitializeComponent();
        }

        #region Acciones/Eventos
        private void btnLimpiar_Click(object sender, EventArgs e) {
            txtCodificacion.Text = txtCompilacion.Text = "";
            txtCodificacion.Enabled = txtCompilacion.Enabled = true;
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
            facade = new MatrizFacade();

            Compilado resultado = facade.compilarCodigo(txtCodificacion.Text);

            txtCompilacion.Text = resultado.CodigoCompilado;

            if(resultado.Errores.Count > 0) {
                tieneErrores = true;
                cargarErrores(resultado.Errores);
            }

            if(resultado.Identificadores.Count > 0) {
                //asignar valores de identificadores
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

            foreach(Identificador i in identificadores) {
                dgvIdentificadores.Rows.Add(i.Nombre, i.Valor);
            }
        }
        #endregion
    }
}