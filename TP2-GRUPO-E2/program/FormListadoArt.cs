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
        public FormListadoArt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            FormAgrArt formEdtArt = new FormAgrArt();
            formEdtArt.ShowDialog();
        }

        private void FormListadoArt_Load(object sender, EventArgs e)
        {
            cargar();
            Refresh();
        }

        private void cargar()
        {
            ArtDB artDB = new ArtDB();
            dataGridView1.DataSource = artDB.Get();
        }

    }
}
