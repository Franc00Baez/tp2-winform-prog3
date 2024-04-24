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
    public partial class FormAgrCat : Form
    {
        private Categoria categoria = null;
        public FormAgrCat()
        {
            InitializeComponent();
        }
        public FormAgrCat(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
            Text = "Editar categoría";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
                CatNegocio catN = new CatNegocio();
                try
                {
                if (categoria == null)
                categoria = new Categoria();

                categoria.Descripcion = txtbCategoria.Text;
                
                if (categoria.ID != 0)
                {
                    catN.editar(categoria);
                    MessageBox.Show("Categoría editada");
                }
                else
                {
                    catN.agregar(categoria);
                    MessageBox.Show("Categoría agregada");
                }
                Close();
                }
                catch (Exception ex)
                {

                if (categoria.ID != 0)
                {
                    MessageBox.Show("Ocurrió un error al editar el registro " + ex.Message);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al agregar el registro " + ex.Message);
                }
            }
        }

        private void FormAgrCat_Load(object sender, EventArgs e)
        {

            try
            {
                lblListado.Text = "Agregar categoría";
                btnAgregar.Text = "AGREGAR";
                if (categoria != null)
                {
                    lblListado.Text = "Editar categoría";
                    btnAgregar.Text = "EDITAR";
                    txtbCategoria.Text = categoria.Descripcion;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
