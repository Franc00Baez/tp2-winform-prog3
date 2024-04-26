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
    public partial class FormArt : Form
    {
        private Articulo art = null;
        public FormArt()
        {
            InitializeComponent();
        }

        public FormArt(Articulo seleccionado)
        {
            InitializeComponent();
            art = seleccionado;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormArt_Load(object sender, EventArgs e)
        {
            lblCodArt2.Text = art.Codigo;
            lblNombre2.Text = art.Nombre;
            lblMarca2.Text = art.Marca.Descripcion;
            lblCategoria2.Text = art.Categoria.Descripcion;
            lblPrecio2.Text = art.Precio.ToString();
            lblDescripcion.Text = art.Descripcion;
            pictureBox.Load(art.Imagen.URL);


        }
    }
}
