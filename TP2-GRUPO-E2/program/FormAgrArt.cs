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
    public partial class FormAgrArt : Form
    {
        public FormAgrArt()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Articulo art = new Articulo();
            ArtNegocio artN = new ArtNegocio();
            try
            {
                art.Codigo = txtbCodArt.Text;
                art.Nombre = txtbNombre.Text;
                art.Categoria = (Categoria)cboxCategoria.SelectedItem;
                art.Marca = (Marca)cboxMarca.SelectedItem;
                decimal precio;
                if (!decimal.TryParse(txtbPrecio.Text, out precio))
                {
                    MessageBox.Show("Por favor ingrese un valor numérico válido para el precio.");
                    return;
                }
                art.Precio = precio;

                art.Descripcion = txtbDescripcion.Text;

                artN.agregar(art);
                MessageBox.Show("Artículo agregado");
                Close();
                Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error al ingresar el registro " + ex.Message);
            }
            
        }

        private void FormAgrArt_Load(object sender, EventArgs e)
        {
            MarcaNegocio marNeg = new MarcaNegocio();
            CatNegocio catNeg = new CatNegocio();
            try
            {
                cboxMarca.DataSource = marNeg.listar();
                cboxCategoria.DataSource = catNeg.listar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
