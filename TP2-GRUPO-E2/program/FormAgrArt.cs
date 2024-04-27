using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program
{
    public partial class FormAgrArt : Form
    {   


        private Articulo articulo = null;
        public FormAgrArt()
        {
            InitializeComponent();
        }

        public FormAgrArt(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Editar artículo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ArtNegocio artN = new ArtNegocio();
            try
            {
                if (validar())
                {
                    return;
                }
                if (articulo == null)
                articulo = new Articulo();

                articulo.Codigo = txtbCodArt.Text;
                articulo.Nombre = txtbNombre.Text;
                articulo.Categoria = (Categoria)cboxCategoria.SelectedItem;
                articulo.Marca = (Marca)cboxMarca.SelectedItem;
                decimal precio;
                if (!decimal.TryParse(txtbPrecio.Text, out precio))
                {
                    MessageBox.Show("Por favor ingrese un valor numérico válido para el precio");
                    return;
                }
                articulo.Precio = precio;
                articulo.Imagen = new Imagen();
                articulo.Imagen.URL = txtUrlImagen.Text;
                articulo.Descripcion = txtbDescripcion.Text;

                if (articulo.Id != 0)
                {

                    DialogResult respuesta = MessageBox.Show("¿Desea editar el artículo?", "Editando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        artN.editar(articulo);
                        MessageBox.Show("Artículo editado");                
                    }
                             
                }
                else
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea agregar el artículo?", "Agregando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        artN.agregar(articulo);
                        MessageBox.Show("Artículo agregado");
                    }
                    
                }

                Close();
            }
            catch (Exception ex)
            {
                if (articulo.Id != 0)
                {
                    MessageBox.Show("Ocurrió un error al editar el registro " + ex.Message);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al agregar el registro " + ex.Message);
                }
                
            }
            
        }

        private bool validar()
        {
            if(txtbCodArt.Text == "")
            {
                lblCodArt.ForeColor = Color.Red;
                lblError.Visible = true;
                return true;
            }
            if (txtbNombre.Text == "")
            {
                lblNombre.ForeColor = Color.Red;
                lblError.Visible = true;
                return true;
            }
            if (cboxMarca.SelectedIndex == -1)
            {
                lblMarca.ForeColor = Color.Red;
                lblError.Visible = true;
                return true;
            }
            if (cboxCategoria.SelectedIndex == -1)
            {
                lblCategoria.ForeColor = Color.Red;
                lblError.Visible = true;
                return true;
            }
            if(txtbDescripcion.Text == "")
            {
                txtbDescripcion.ForeColor = Color.White;
                txtbDescripcion.Text = "Sin descripción";
            }
            return false;
        }

        private void FormAgrArt_Load(object sender, EventArgs e)
        {
            MarcaNegocio marNeg = new MarcaNegocio();
            CatNegocio catNeg = new CatNegocio();

            try
            {
               
                lblListado.Text = "Agregar Artículo";
                btnAgregar.Text = "AGREGAR";
                cboxMarca.DataSource = marNeg.listar();
                cboxMarca.ValueMember = "IDMarca";
                cboxMarca.DisplayMember = "Descripcion";
                cboxMarca.SelectedIndex = -1;
                cboxCategoria.DataSource = catNeg.listar();
                cboxCategoria.ValueMember = "ID";
                cboxCategoria.DisplayMember = "Descripcion";
                cboxCategoria.SelectedIndex = -1;

                if (articulo != null)
                {
                    lblListado.Text = "Editar Artículo";
                    btnAgregar.Text = "EDITAR";
                    txtbCodArt.Text = articulo.Codigo;
                    txtbNombre.Text = articulo.Nombre;
                    txtbDescripcion.Text = articulo.Descripcion;
                    txtbPrecio.Text = articulo.Precio.ToString();
                    txtUrlImagen.Text = articulo.Imagen.URL;
                    CargarImagen(articulo.Imagen.URL);
                    cboxCategoria.SelectedValue = articulo.Categoria.ID;
                    cboxMarca.SelectedValue = articulo.Marca.IDMarca;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                picbArticulos.Load(imagen);
            }
            catch (Exception)
            {
                picbArticulos.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQp_KiMdzcWl5r99nAPXG8dF0d5MWb2ZIX2bs1GvjRTvw&s");
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtUrlImagen.Text);
        }

        private void txtbNombre_Leave(object sender, EventArgs e)
        {
            ArtNegocio negocio = new ArtNegocio();

            List<Articulo> lista = negocio.listar();


            if (txtbNombre.Text != "")
            {
                foreach (Articulo item in lista)
                {
                    if (item.Nombre.ToUpper() == txtbNombre.Text.ToUpper())
                    {
                        lblNombre.ForeColor = Color.Red;
                        lblError.Text = "El nombre del artículo está en uso";
                        lblError.Visible = true;                      
                        txtbNombre.Clear();
                    }
                }
            }
        }
    }
}
