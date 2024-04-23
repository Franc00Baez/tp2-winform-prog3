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
        }

        private void cargar()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            listaMarcas = marcaNegocio.listar();
            dataGridView1.DataSource = listaMarcas;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
        }
    }
}
