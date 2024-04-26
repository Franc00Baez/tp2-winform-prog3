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
    public partial class FormBusID3 : Form
    {
        public FormBusID3()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validar()
        {
            if (txtbID.Text == "")
            {
                lblID.ForeColor = Color.Red;
                lblError.Visible = true;
                return true;
            }
            if (!validarNumero(txtbID.Text))
            {
                lblError.Text = "Este campo solo acepta valores numéricos";
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }
            lblID.ForeColor = Color.Black;
            lblError.Visible = false;
        }
    }
}
