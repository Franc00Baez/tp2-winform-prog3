﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace program
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            // Configuración del temporizador
            timer.Interval = 1000; // Intervalo en milisegundos (1000ms = 1 segundo)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void agregarArtículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAgrArt formAgrArt = new FormAgrArt();
            formAgrArt.ShowDialog();
        }

        private void buscarPorIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBusID formBusID = new FormBusID();
            formBusID.ShowDialog();
        }

        private void buscarPorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBusNombre formBusNombre = new FormBusNombre();
            formBusNombre.ShowDialog();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tsslFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/Franc00Baez/tp2-winform-prog3";

            Process.Start(url);
        }

        private void agregarMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAgrMarca formAgrMarca = new FormAgrMarca();
            formAgrMarca.ShowDialog();
        }

        private void agregarCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAgrCat formAgrCat = new FormAgrCat(); 
            formAgrCat.ShowDialog();
        }

        private void verListadoDeArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListadoArt formListadoArt = new FormListadoArt();
            formListadoArt.ShowDialog();
        }

        private void verListadoDeMarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListadoMarcas formListadoMarcas = new FormListadoMarcas();
            formListadoMarcas.ShowDialog();
        }

        private void verListadoDeCategoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListadoCat formListadoCat = new FormListadoCat();
            formListadoCat.ShowDialog();
        }

    }
}
