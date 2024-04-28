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

        // Declarar una lista para almacenar las URLs de las imágenes disponibles para el artículo seleccionado
        List<String> urlsImagenes = new List<String>();

        // Declarar un índice para seguir la posición actual en la lista de imágenes
        int indiceImagenActual = 0;

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dataGridView1.CurrentRow.DataBoundItem;
                Console.WriteLine("Seleccionado artículo con ID: " + seleccionado.Id);

                CargarImagen(seleccionado.Imagen.URL);

                // Obtener las URLs de las imágenes disponibles para el artículo seleccionado
                urlsImagenes = ObtenerUrlsImagenesPorArticulo(seleccionado.Id);

                // Reiniciar el índice de imagen actual para mostrar la primera imagen disponible
                indiceImagenActual = 0;

                // Mostrar u ocultar los botones de navegación según sea necesario    
                ActualizarVisibilidadBotones();

            }
        }
        private List<string> ObtenerUrlsImagenesPorArticulo(int idArticulo)
        {
            List<string> urls = new List<string>();

            // Recorrer todas las filas del DataGridView
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                int id = Convert.ToInt32(fila.Cells["Id"].Value);
                string urlImagen = fila.Cells["Imagen"].Value.ToString();                     

                // Si el Id coincide con el Id del artículo especificado, agregar la URL a la lista
                if (id == idArticulo && !string.IsNullOrEmpty(urlImagen))
                {
                    urls.Add(urlImagen);
                    }
            }

            return urls;
        }

        int maximoImagenes = 5;
        private bool ContarImagenesPorArticulo(int idArticulo)
        {
            int contador = 0;

            // Recorrer todas las filas del DataGridView
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                // Obtener el Id del artículo de la fila actual
                int id = Convert.ToInt32(fila.Cells["Id"].Value);

                // Si el Id coincide con el Id del artículo seleccionado y la imagen no es "Sin imagen", aumentar el contador
                if (id == idArticulo && fila.Cells["Imagen"].Value.ToString() != "Sin imagen")
                {
                    contador++;
                }
            }

            // Devolver verdadero solo si el contador es menor o igual al número máximo de imágenes permitidas
            return contador <= maximoImagenes;
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
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
            foreach (char caracter in cadena)
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Asegurarse de que hay más de una imagen disponible
            if (urlsImagenes.Count > 1)
            {
                // Incrementar el índice de imagen actual
                indiceImagenActual++;

                // Si el índice supera el tamaño de la lista, volver al inicio
                if (indiceImagenActual >= urlsImagenes.Count)
                {
                    indiceImagenActual = 0;
                }

                // Cargar la siguiente imagen
                CargarImagen(urlsImagenes[indiceImagenActual]);

                // Actualizar la visibilidad de los botones de navegación
                ActualizarVisibilidadBotones();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            // Asegurarse de que hay más de una imagen disponible
            if (urlsImagenes.Count > 1)
            {
                // Decrementar el índice de imagen actual
                indiceImagenActual--;

                // Si el índice es menor que cero, ir al final de la lista
                if (indiceImagenActual < 0)
                {
                    indiceImagenActual = urlsImagenes.Count - 1;
                }

                // Cargar la imagen anterior
                CargarImagen(urlsImagenes[indiceImagenActual]);
                // Actualizar la visibilidad de los botones de navegación
                ActualizarVisibilidadBotones();
            }
        }
        private void ActualizarVisibilidadBotones()
        {
            // Mostrar u ocultar el botón de navegación hacia atrás según sea necesario
            btnPrev.Visible = urlsImagenes.Count > 1 && indiceImagenActual > 0;

            // Mostrar u ocultar el botón de navegación hacia adelante según sea necesario
            btnNext.Visible = urlsImagenes.Count > 1 && indiceImagenActual < urlsImagenes.Count - 1;
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Verificar si la fila actual no es la última
            if (e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                int currentId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                int nextId = (int)dataGridView1.Rows[e.RowIndex + 1].Cells["Id"].Value;

                // Si el ID de la fila actual es igual al de la siguiente fila, ocultar la fila actual
                if (currentId == nextId)
                {
                    dataGridView1.Rows[e.RowIndex + 1].Visible = false;
                }
            }
        }
    }
}