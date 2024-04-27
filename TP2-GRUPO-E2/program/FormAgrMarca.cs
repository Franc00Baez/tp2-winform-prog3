using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

                lblMarca.ForeColor = Color.Black;
                lblError.Visible = false;

                if (marca == null)
                    marca = new Marca();

                marca.Descripcion = txtbMarca.Text;
                if (marca.IDMarca != 0)
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea editar la marca?", "Editando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        if (!validator())
                        {
                            marN.editar(marca);
                            MessageBox.Show("Marca editada");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe una marca con esa descripción");
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
                            marN.agregar(marca);
                            MessageBox.Show("Marca agregada");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe una marca con esa descripción");
                        }
                        

                    }
                    
                }

                txtbMarca.Text = marca.Descripcion;
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

        private bool validator()
        {
            MarcaNegocio negocio = new MarcaNegocio();

            List<Marca> lista = negocio.listar();

            if (txtbMarca.Text != "")
            {
                foreach (Marca item in lista)
                {
                    if (item.Descripcion.ToUpper() == txtbMarca.Text.ToUpper())
                    {
                        if (this.marca != null)
                        {
                            //lblMarca.ForeColor = Color.Red;
                            lblError.Text = "El nombre de la marca está en uso";
                            lblError.Visible = false;
                            txtbMarca.Clear();
                            return true;
                        }
                        else
                        {
                            lblMarca.ForeColor = Color.Red;
                            lblError.Text = "El nombre de la marca está en uso";
                            lblError.Visible = true;
                            txtbMarca.Clear();
                            return true;
                        }

                    }
                }
            }
            return false;
        }
    }
}