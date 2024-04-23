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
        public FormAgrCat()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
                Categoria cat = new Categoria();
                CatNegocio artN = new CatNegocio();
                try
                {
                    cat.Descripcion = txtbCategoria.Text;
                    artN.agregar(cat);
                    MessageBox.Show("Categoría agregada");
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
