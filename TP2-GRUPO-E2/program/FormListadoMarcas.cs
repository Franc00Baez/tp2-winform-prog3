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
        public FormListadoMarcas()
        {
            InitializeComponent();
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
    }
}
