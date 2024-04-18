using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

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

        private void buscarPorMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBusMarca formBusMarca = new FormBusMarca(); 
            formBusMarca.ShowDialog();
        }

        private void buscarPorCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBusCategoria formBusCategoria = new FormBusCategoria();
            formBusCategoria.ShowDialog();
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
    }
}
