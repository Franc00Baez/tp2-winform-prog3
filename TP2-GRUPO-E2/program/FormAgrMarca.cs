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
        private Marca marca = null;
        public FormAgrMarca()
        {
            InitializeComponent();
        }
        public FormAgrMarca(Marca marca)
        {
            InitializeComponent();
            this.marca = marca;
            Text = "Editar marca";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MarcaNegocio marN = new MarcaNegocio();
            try
            {
                if (marca == null)
                    marca = new Marca();

                marca.Descripcion = txtbMarca.Text;
                if (marca.IDMarca != 0)
                {
                    marN.editar(marca);
                    MessageBox.Show("Marca editada");
                }
                else
                {
                    marN.agregar(marca);
                    MessageBox.Show("Marca agregada");
                }

                Close();
            }
            catch (Exception ex)
            {

                if (marca.IDMarca != 0)
                {
                    MessageBox.Show("Ocurrió un error al editar el registro " + ex.Message);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al agregar el registro " + ex.Message);
                }
            }
        }

        private void FormAgrMarca_Load(object sender, EventArgs e)
        {
            try
            {
                lblListado.Text = "Agregar marca";
                btnAgregar.Text = "AGREGAR";
                if (marca != null)
                {
                    lblListado.Text = "Editar marca";
                    btnAgregar.Text = "EDITAR";
                    txtbMarca.Text = marca.Descripcion;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}