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
    public partial class FormAgrArt : Form
    {
        public FormAgrArt()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ArtDB artDB = new ArtDB();
            try
            {
                artDB.Add(txtbCodArt.Text,txtbNombre.Text,txtbDescripcion.Text,int.Parse(cboxMarca.Text),int.Parse(cboxCategoria.Text),int.Parse(txtbPrecio.Text));
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error al ingresar el registro " + ex.Message);
            }
            
        }
    }
}
