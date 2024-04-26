using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program
{
    public partial class FormListadoArt : Form
    {
        private List<Articulo> listaArticulos;
        public FormListadoArt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargar();
            Refresh();
            lblERROR.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FormAgrArt formAgrArt = new FormAgrArt();
            formAgrArt.ShowDialog();
            Refresh();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un artículo para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Articulo seleccionado;
            seleccionado = (Articulo)dataGridView1.CurrentRow.DataBoundItem;
            FormAgrArt formEdtArt = new FormAgrArt(seleccionado);
            formEdtArt.ShowDialog();
            cargar();
        }

        private void FormListadoArt_Load(object sender, EventArgs e)
        {
            cargar();
            Refresh();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["Precio"].DefaultCellStyle.Format = "0.##";
            cbCampo.Items.Add("Nombre");
            cbCampo.Items.Add("Marca");
            cbCampo.Items.Add("Categoria");
            cbCampo.Items.Add("Precio");
        }

        private void cargar()
        {   
            ArtNegocio artNegocio = new ArtNegocio();
            listaArticulos = artNegocio.listar();
            dataGridView1.DataSource = listaArticulos;
            dataGridView1.Columns["Imagen"].Visible = false;
            dataGridView1.Columns["Id"].Visible = false;
            CargarImagen(listaArticulos[0].Imagen.URL);
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                picbArtiuclos.Load(imagen);
            }
            catch (Exception)
            {
                picbArtiuclos.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQp_KiMdzcWl5r99nAPXG8dF0d5MWb2ZIX2bs1GvjRTvw&s");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dataGridView1.CurrentRow.DataBoundItem;
            CargarImagen(seleccionado.Imagen.URL);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un artículo para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Articulo seleccionado = (Articulo)dataGridView1.CurrentRow.DataBoundItem;
            FormArt formArt = new FormArt(seleccionado);    
            formArt.ShowDialog();
        

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArtNegocio artN = new ArtNegocio();
            Articulo seleccionado;
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione un artículo para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar el artículo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dataGridView1.CurrentRow.DataBoundItem;
                    artN.eliminar(seleccionado.Id);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool validar()
        {

            if (cbCampo.SelectedIndex == -1)
            {
                lblERROR.Text = "Es necesario seleccionar un campo";
                return true;
            }

            if (cbCriterio.SelectedIndex == -1) 
            {        
                lblERROR.Text = "Es necesario seleccionar un criterio";
                return true;
            }

            if (cbCampo.SelectedItem.ToString() == "Precio" && !validarNumero(txtFiltro.Text))
            {
                lblERROR.Text = "Este campo solo acepta valores numéricos";
                return true;
            }

            if (txtFiltro.Text == "")
            {
                cargar();
                lblERROR.Text = "Campo de búsqueda vacio";
                
                return true;
            }
            
            return false;
        }

  
        private bool validarNumero(string cadena)
        {
           foreach(char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }

        private void cbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbCampo.SelectedItem.ToString();
           
            if (opcion == "Precio")
            {

                cbCriterio.Items.Clear();
                cbCriterio.Items.Add("Mayor a");
                cbCriterio.Items.Add("Menor que");
                cbCriterio.Items.Add("Igual a");
            }
            else
            {
                cbCriterio.Items.Clear();
                cbCriterio.Items.Add("Comienza por");
                cbCriterio.Items.Add("Termina con");
                cbCriterio.Items.Add("Contiene");
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ArtNegocio negocio = new ArtNegocio();

            try
            {
                if (validar())
                {
                    return;
                }
                lblERROR.Text = "";
 
                string campo = cbCampo.SelectedItem.ToString();
                string criterio = cbCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;
                dataGridView1.DataSource = negocio.Filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
