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
    public partial class FormListadoCat : Form
    {
        private List<Categoria> listaCategorias;
        public FormListadoCat()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FormAgrCat formAgrCat = new FormAgrCat();
            formAgrCat.ShowDialog();
        }

        private void FormListadoCat_Load(object sender, EventArgs e)
        {
            cargar();
            Refresh();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbCampoCat.Items.Add("Id");
            cbCampoCat.Items.Add("Descripción");
        }

        private void cargar()
        {
            CatNegocio catNegocio = new CatNegocio();
            listaCategorias = catNegocio.listar();
            dataGridView1.DataSource = listaCategorias;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cargar();
            Refresh();
            lblERROR.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Categoria seleccionado;
            seleccionado = (Categoria)dataGridView1.CurrentRow.DataBoundItem;
            FormAgrCat formEdtCat = new FormAgrCat(seleccionado);
            formEdtCat.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CatNegocio artN = new CatNegocio();
            Categoria seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar la categoría?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Categoria)dataGridView1.CurrentRow.DataBoundItem;
                    artN.eliminar(seleccionado.ID);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cbCampoCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbCampoCat.SelectedItem.ToString();

            if (opcion == "Id")
            {
                cbCriterioCat.Items.Clear();
                cbCriterioCat.Items.Add("Mayor a");
                cbCriterioCat.Items.Add("Menor que");
                cbCriterioCat.Items.Add("Igual a");
            }
            else
            {
                cbCriterioCat.Items.Clear();
                cbCriterioCat.Items.Add("Comienza con");
                cbCriterioCat.Items.Add("Termina por");
                cbCriterioCat.Items.Add("Contiene");
            }
        }

        private bool validar()
        {

            if (cbCampoCat.SelectedIndex == -1)
            {
                lblERROR.Text = "Es necesario seleccionar un campo";
                return true;
            }

            if (cbCriterioCat.SelectedIndex == -1)
            {
                lblERROR.Text = "Es necesario seleccionar un criterio";
                return true;
            }

            if (txtFiltrarCat.Text == "")
            {
                cargar();
                lblERROR.Text = "Campo de búsqueda vacio";

                return true;
            }

            return false;
        }

        private void btnFiltrarCat_Click(object sender, EventArgs e)
        {
            CatNegocio negocio = new CatNegocio();

            try
            {
                if (validar())
                {
                    return;
                }
                lblERROR.Text = "";

                string campo = cbCampoCat.SelectedItem.ToString();
                string criterio = cbCriterioCat.SelectedItem.ToString();
                string filtro = txtFiltrarCat.Text;
                dataGridView1.DataSource = negocio.Filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
