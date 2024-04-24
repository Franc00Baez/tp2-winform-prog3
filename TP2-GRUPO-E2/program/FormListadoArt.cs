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
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FormAgrArt formAgrArt = new FormAgrArt();
            formAgrArt.ShowDialog();
            Refresh();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            FormArt formArt = new FormArt();    
            formArt.ShowDialog();
        }

    }
}
