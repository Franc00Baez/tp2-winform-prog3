﻿using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program
{
    public partial class FormBusID : Form
    {
        public FormBusID()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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
            if(validarNumero(txtbID.Text) == false)
            {
                MessageBox.Show("Porfavor ingrese un valor numerico!");
                return;
            }

            ArtNegocio negocio = new ArtNegocio();
            List<Articulo> lista = negocio.listar();
            Articulo seleccionado;
            string Id = txtbID.Text;

            seleccionado = lista.FirstOrDefault(x => x.Id == int.Parse(Id));

            FormArt frm = new FormArt(seleccionado);
            frm.Show();


        }
    }
}