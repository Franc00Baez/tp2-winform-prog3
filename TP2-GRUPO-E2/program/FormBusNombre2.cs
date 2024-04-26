﻿using System;
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
    public partial class FormBusNombre2 : Form
    {
        public FormBusNombre2()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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
        }
    }
}
