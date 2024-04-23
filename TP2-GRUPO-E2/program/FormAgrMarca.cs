using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program
{
    public partial class FormAgrMarca : Form
    {
        public FormAgrMarca()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Marca mar = new Marca();
            MarcaNegocio artN = new MarcaNegocio();
            try
            {
                mar.Descripcion = txtbMarca.Text;
                artN.agregar(mar);
                MessageBox.Show("Marca agregada");
                Close();
                Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error al ingresar el registro " + ex.Message);
            }
        }
    }
}
