using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                lblCategoria.ForeColor = Color.Black;
                lblError.Visible = false;

                if (categoria == null)
                categoria = new Categoria();

                categoria.Descripcion = txtbCategoria.Text;
                
                if (categoria.ID != 0)
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea editar la categoría?", "Editando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        if (!validator())
                        {
                            catN.editar(categoria);
                            MessageBox.Show("Categoría editada");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe una categoría con esa descripción");
                        }
                        
                    }
                    
                }
                else
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea agregar la categoría?", "Agregando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        if (!validator())
                        {
                            catN.agregar(categoria);
                            MessageBox.Show("Categoría agregada");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe una categoría con esa descripción");
                            
                        }                     

                    }
                   
                }
                txtbCategoria.Text = categoria.Descripcion;
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

        private bool validator()
        {
            CatNegocio negocio = new CatNegocio();

            List<Categoria> lista = negocio.listar();

            if (txtbCategoria.Text != "")
            {
                foreach (Categoria item in lista)
                {
                    if (item.Descripcion.ToUpper() == txtbCategoria.Text.ToUpper())
                    {
                        if (this.categoria != null)
                        {
                            lblCategoria.ForeColor = Color.Red;
                            lblError.Text = "El nombre de la categoría está en uso";
                            lblError.Visible = false;
                            txtbCategoria.Clear();
                            return true;
                        }
                        else
                        {
                            lblCategoria.ForeColor = Color.Red;
                            lblError.Text = "El nombre de la categoría está en uso";
                            lblError.Visible = true;
                            txtbCategoria.Clear();
                            return true;
                        }

                    }
                }
            }
            return false;
        }
    }
}
