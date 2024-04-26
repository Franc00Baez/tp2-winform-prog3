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
    public partial class FormBusCategoria : Form
    {
        public FormBusCategoria()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validar()
        {
            if (txtbCategoria.Text == "")
            {
                lblCategoria.ForeColor = Color.Red;
                lblError.Visible = true;
                return true;
            }

            return false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }
            lblCategoria.ForeColor = Color.Black;
            lblError.Visible = false;
            ArtNegocio negocio = new ArtNegocio();
            List<Articulo> lista = negocio.listar();
            Articulo seleccionado;
            string nombre = txtbCategoria.Text;

            seleccionado = lista.FirstOrDefault(x => x.Categoria.Descripcion.ToUpper().Contains(nombre.ToUpper()));

            FormArt frm = new FormArt(seleccionado);
            frm.Show();
        }
    }
}
