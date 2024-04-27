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
    public partial class FormListadoMarcas : Form
    {
        private List<Marca> listaMarcas;
        public FormListadoMarcas()
        {
            InitializeComponent();
        }
        private void FormListadoMarcas_Load(object sender, EventArgs e)
        {
            cargar();
            Refresh();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbCampoMar.Items.Add("Id");
            cbCampoMar.Items.Add("Descripcíon");
        }

        private void cargar()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            listaMarcas = marcaNegocio.listar();
            dataGridView1.DataSource = listaMarcas;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FormAgrMarca formAgrMarca = new FormAgrMarca(); 
            formAgrMarca.ShowDialog();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cargar();
            Refresh();
            lblERROR.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Marca seleccionado;
            seleccionado = (Marca)dataGridView1.CurrentRow.DataBoundItem;
            FormAgrMarca formEdtMar = new FormAgrMarca(seleccionado);
            formEdtMar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MarcaNegocio marN = new MarcaNegocio();
            Marca seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar la marca?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Marca)dataGridView1.CurrentRow.DataBoundItem;
                    marN.eliminar(seleccionado.IDMarca); ;
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cbCampoMar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbCampoMar.SelectedItem.ToString();

            if(opcion == "Id")
            {
                cbCriterioMar.Items.Clear();
                cbCriterioMar.Items.Add("Mayor a");
                cbCriterioMar.Items.Add("Menor que");
                cbCriterioMar.Items.Add("Igual a");
            }else
            {
                cbCriterioMar.Items.Clear();
                cbCriterioMar.Items.Add("Comienza con");
                cbCriterioMar.Items.Add("Termina por");
                cbCriterioMar.Items.Add("Contiene");
            }
        }

        private bool validar()
        {

            if (cbCampoMar.SelectedIndex == -1)
            {
                lblERROR.Text = "Es necesario seleccionar un campo";
                return true;
            }

            if (cbCriterioMar.SelectedIndex == -1)
            {
                lblERROR.Text = "Es necesario seleccionar un criterio";
                return true;
            }

            if (txtFiltrarMar.Text == "")
            {
                cargar();
                lblERROR.Text = "Campo de búsqueda vacio";

                return true;
            }

            return false;
        }
        private void btnFiltrarMar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();

            try
            {
                if (validar())
                {
                    return;
                }
                lblERROR.Text = "";

                string campo = cbCampoMar.SelectedItem.ToString();
                string criterio = cbCriterioMar.SelectedItem.ToString();
                string filtro = txtFiltrarMar.Text;
                dataGridView1.DataSource = negocio.Filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
