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
        }

        private void cargar()
        {
            CatNegocio catNegocio = new CatNegocio();
            listaCategorias = catNegocio.listar();
            dataGridView1.DataSource = listaCategorias;
        }
    }
}
