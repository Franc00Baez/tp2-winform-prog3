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
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cargar()
        {
            CatNegocio catNegocio = new CatNegocio();
            listaCategorias = catNegocio.listar();
            dataGridView1.DataSource = listaCategorias;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cargar();
            Refresh();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Categoria seleccionado;
            seleccionado = (Categoria)dataGridView1.CurrentRow.DataBoundItem;
            FormAgrCat formEdtCat = new FormAgrCat(seleccionado);
            formEdtCat.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CatNegocio artN = new CatNegocio();
            Categoria seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar la categoría?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Categoria)dataGridView1.CurrentRow.DataBoundItem;
                    artN.eliminar(seleccionado.ID);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
