﻿using negocio;
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
    public partial class FormBusNombre : Form
    {
        public FormBusNombre()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validar()
        {
            if (txtbNombre.Text == "")
            {
                lblNombre.ForeColor = Color.Red;
                lblError.Visible = true;
                return true;
            }

            return false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }
            lblNombre.ForeColor = Color.Black;
            lblError.Visible = false;
            ArtNegocio negocio = new ArtNegocio();
            List<Articulo> lista = negocio.listar();
            Articulo seleccionado;
            string nombre = txtbNombre.Text;

            seleccionado = lista.FirstOrDefault(x => x.Nombre.ToUpper().Contains(nombre.ToUpper()));

            FormArt frm = new FormArt(seleccionado);
            frm.Show();

        }
    }
}
